"use strict";

const gulp = require("gulp"),
    path = require("path"),
    exec = require("child_process").execSync,
    sass = require("gulp-sass"),
    del = require("del"),
    vinylPaths = require("vinyl-paths");

/***************
*** CLEAN TASKS
****************/

gulp.task("clean", function(done) {
    del.sync("build");
    done();
});

/*****************
*** PREPARE TASKS
******************/

gulp.task("prepare:copy", function() {
    return gulp.src(path.join("src", "**", "*"))
        .pipe(gulp.dest(path.join("build", "dist")));
});

gulp.task("prepare:sass", function() {
    return gulp.src(path.join("build", "dist", "**", "*.scss"))
        .pipe(vinylPaths(del))
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest((file) => {
            return file.base;
        }));
});

gulp.task("prepare:fontawesome", function() {
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

gulp.task("start-electron", function(done) {
    exec("electron " + path.join("build", "dist", "main.js"), function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        cb(err);
    });
    done();
});

gulp.task("run", gulp.series(
    "clean",
    "prepare",
    "start-electron"
));