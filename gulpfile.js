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
    return gulp.src(path.join("src", "**", "*"))
        .pipe(gulp.dest(path.join("build", "dist")));
});

gulp.task("prepare:sass", () => {
    return gulp.src(path.join("build", "dist", "**", "*.scss"))
        .pipe(vinylPaths(del))
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest((file) => {
            return file.base;
        }));
});

gulp.task("prepare:fontawesome", () => {
    return gulp.src(path.join(__dirname, "node_modules", "@fortawesome", "fontawesome-pro-webfonts", "webfonts", "*.woff2"))
        .pipe(gulp.dest(path.join("build", "dist", "assets")));
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
    execAsync("electron " + path.join("build", "dist", "main.js"), (err, stdout, stderr) => {
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