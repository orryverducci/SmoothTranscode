"use strict";

const gulp = require("gulp"),
    path = require("path"),
    {spawn} = require("child_process"),
    sass = require("gulp-sass"),
    del = require("del"),
    os = require("os"),
    rollup = require("gulp-better-rollup"),
    resolve = require("rollup-plugin-node-resolve"),
    vue = require("rollup-plugin-vue"),
    commonjs = require("rollup-plugin-commonjs"),
    sourcemaps = require('gulp-sourcemaps'),
    eslint = require("gulp-eslint");

/****************
*** HELPER TASKS
*****************/

gulp.task("lint", (done) => {
    return gulp.src(path.join("src", "frontend", "**", "*.{js,vue}"))
    .pipe(eslint())
    .pipe(eslint.format())
    .pipe(eslint.failAfterError());
});

/***************
*** CLEAN TASKS
****************/

gulp.task("clean-frontend", (done) => {
    del.sync(path.join("build", "frontend"));
    done();
});

gulp.task("clean-native", (done) => {
    del.sync(path.join("build", "bin"));
    del.sync(path.join("build", "include"));
    del.sync(path.join("build", "lib"));
    del.sync(path.join("build", "share"));
    del.sync(path.join("build", "ffmpeg-build.log"));
    done();
});

gulp.task("clean", (done) => {
    del.sync("build");
    done();
});

/**************************
*** FRONTEND PREPARE TASKS
***************************/

gulp.task("prepare", () => {
    return gulp.src([path.join("src", "frontend", "main-process", "*"), path.join("src", "frontend", "ui", "**", "*.html")], { base: path.join("src", "frontend") })
        .pipe(gulp.dest(path.join("build", "frontend")));
});

/************************
*** FRONTEND BUILD TASKS
*************************/

gulp.task("build-js", () => {
    return gulp.src(path.join("src", "frontend", "ui", "main.js"))
        .pipe(sourcemaps.init())
        .pipe(rollup({
            cache: false,
            plugins: [
                resolve({
                    mainFields: ["module", "jsnext", "jsnext:main"]
                }),
                commonjs(),
                vue()
            ]
        }, {
            file: "main.js",
            format: "es"
        }))
        .pipe(sourcemaps.write())
        .pipe(gulp.dest(path.join("build", "frontend", "ui")));
});

gulp.task("build-sass", () => {
    return gulp.src(path.join("src", "frontend", "ui", "styles", "global.scss"))
        .pipe(sourcemaps.init())
        .pipe(sass({
            includePaths: [
                path.join(__dirname, "src", "frontend", "styles"),
                path.join(__dirname, "node_modules", "bootstrap", "scss"),
                path.join(__dirname, "node_modules", "@fortawesome", "fontawesome-svg-core")
            ]
        }).on("error", sass.logError))
        .pipe(sourcemaps.write())
        .pipe(gulp.dest(path.join("build", "frontend", "ui", "styles")));
});

/***************************
*** NATIVE CODE BUILD TASKS
****************************/

gulp.task("build-ffmpeg", (done) => {
    let test = spawn(`"${path.join(__dirname, "native-build.sh")}"`, {
        shell: true,
        windowsHide: true
    })
    test.stdout.on('data', (data) => {
        console.log(data.toString());
      });
      
      test.stderr.on('data', (data) => {
        console.log(`stderr: ${data}`);
      });
    test.on("close", (code) => {
        if (code === 0) {
            done();
        } else {
            done(new Error())
        }
    })
});

/*******************
*** FULL BUILD TASK
********************/

gulp.task("build", gulp.parallel(
    "build-js",
    "build-sass",
    "build-ffmpeg"
));

/*************
*** RUN TASKS
**************/

gulp.task("start-electron", (done) => {
    let extension = "";
    if (os.platform == "win32") {
        extension = ".cmd";
    }
    this.process = spawn(`"${path.join(__dirname, "node_modules", ".bin", "electron" + extension)}"`, ["--remote-debugging-port=9223", `"${path.join("build", "frontend", "main-process", "main.js")}"`], {
        shell: true,
        windowsHide: true
    });
    done();
});

gulp.task("run", gulp.series(
    "clean-frontend",
    "prepare",
    "build-js",
    "build-sass",
    "start-electron"
));

gulp.task("run-fullbuild", gulp.series(
    "clean",
    "prepare",
    "build",
    "start-electron"
));