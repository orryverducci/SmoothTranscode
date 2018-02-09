"use strict";

const gulp = require("gulp"),
    path = require("path"),
    exec = require("child_process").execSync,
    execAsync = require("child_process").exec,
    sass = require("gulp-sass"),
    del = require("del"),
    vinylPaths = require("vinyl-paths"),
    os = require("os");

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

gulp.task("prepare:lodash", () => {
    return gulp.src(path.join(__dirname, "node_modules", "lodash", "lodash.js"))
        .pipe(gulp.dest(path.join("build", "SmoothTranscode")));
});

gulp.task("prepare:ffmpeg", (done) => {
    exec(path.join(__dirname, "src", "ffmpeg", "configure") + " --prefix=" + path.join(__dirname, "build") + " --pkg-config=pkg-config --pkg-config-flags=--static --enable-gpl --enable-version3 --enable-gray --disable-ffplay --disable-logging --disable-doc --arch=x86_64", {
        cwd: path.join(__dirname, "src", "ffmpeg"),
        env: {
            "LDFLAGS": "-L" + path.join(__dirname, "build", "lib"),
            "CFLAGS": "-I" + path.join(__dirname, "build", "include")
        }
    }, (err, stdout, stderr) => {
        if (err) {
            console.error("Error: ${err}");
        }
    });
    done();
});

gulp.task("prepare", gulp.series(
    "prepare:copy",
    "prepare:sass",
    "prepare:fontawesome",
    "prepare:lodash",
    "prepare:ffmpeg"
));

/***************
*** BUILD TASKS
****************/

gulp.task("build:ffmpeg", (done) => {
    exec("make -j " + os.cpus().length, {
        cwd: path.join(__dirname, "src", "ffmpeg")
     }, (err, stdout, stderr) => {
        if (err) {
            console.error("Error: ${err}");
        }
    });
    exec("make install", {
        cwd: path.join(__dirname, "src", "ffmpeg")
     }, (err, stdout, stderr) => {
        if (err) {
            console.error("Error: ${err}");
        }
    });
    done();
});

gulp.task("build", gulp.series(
    "build:ffmpeg"
));

/*************
*** RUN TASKS
**************/

gulp.task("start-electron", (done) => {
    execAsync(path.join(__dirname, "node_modules", ".bin", "electron") + " " + path.join("build", "SmoothTranscode", "main.js"), (err, stdout, stderr) => {
        if (err) {
            console.error("Error: ${err}");
        }
    });
    done();
});

gulp.task("run", gulp.series(
    "clean",
    "prepare",
    "build",
    "start-electron"
));