"use strict";

const gulp = require("gulp"),
    path = require("path"),
    exec = require("child_process").execSync;

/*****************
*** PREPARE TASKS
******************/

gulp.task("prepare:copy", function() {
    return gulp.src(path.join("src", "**", "*"))
        .pipe(gulp.dest(path.join("build", "dist")));
});

gulp.task("prepare", gulp.series(
    "prepare:copy"
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
    "prepare",
    "start-electron"
));