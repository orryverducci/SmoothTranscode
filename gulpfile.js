"use strict";

const gulp = require("gulp"),
    path = require("path"),
    exec = require("child_process").execSync,
    execAsync = require("child_process").exec,
    sass = require("gulp-sass"),
    del = require("del"),
    vinylPaths = require("vinyl-paths");

/***************
*** CLEAN TASKS
****************/

gulp.task("clean", (done) => {
    del.sync("build");
    done();
});

/*****************
*** PREPARE TASKS
******************/

gulp.task("prepare:copy", () => {
    return gulp.src(path.join("src", "SmoothTranscode", "**", "*"))
        .pipe(gulp.dest(path.join("build", "SmoothTranscode")));
});

gulp.task("prepare:sass", () => {
    return gulp.src(path.join("build", "SmoothTranscode", "**", "*.scss"))
        .pipe(vinylPaths(del))
        .pipe(sass({
            includePaths: [
                path.join(__dirname, "src", "SmoothTranscode"),
                path.join(__dirname, "node_modules", "bootstrap", "scss"),
            ]
        }).on("error", sass.logError))
        .pipe(gulp.dest((file) => {
            return file.base;
        }));
});

gulp.task("prepare:fontawesome", () => {
    return gulp.src(path.join(__dirname, "node_modules", "@fortawesome", "fontawesome-pro-webfonts", "webfonts", "*.woff2"))
        .pipe(gulp.dest(path.join("build", "SmoothTranscode", "assets")));
});

gulp.task("prepare", gulp.series(
    "prepare:copy",
    "prepare:sass",
    "prepare:fontawesome"
));

/*************
*** RUN TASKS
**************/

gulp.task("start-electron", (done) => {
    execAsync("electron " + path.join("build", "SmoothTranscode", "main.js"), (err, stdout, stderr) => {
        if (err) {
            console.error("Error: ${err}");
        }
    });
    done();
});

gulp.task("run", gulp.series(
    "clean",
    "prepare",
    "start-electron"
));