"use strict";

const gulp = require("gulp"),
    path = require("path"),
    exec = require("child_process").execSync,
    {spawn} = require("child_process"),
    sass = require("gulp-sass"),
    del = require("del"),
    vinylPaths = require("vinyl-paths"),
    os = require("os");

/***************
*** CLEAN TASKS
****************/

gulp.task("clean:frontend", (done) => {
    del.sync(path.join("build", "frontend"));
    done();
});

gulp.task("clean:native", (done) => {
    del.sync(path.join("build", "bin"));
    del.sync(path.join("build", "include"));
    del.sync(path.join("build", "lib"));
    del.sync(path.join("build", "share"));
    done();
});

gulp.task("clean:all", (done) => {
    del.sync("build");
    done();
});

/**************************
*** FRONTEND PREPARE TASKS
***************************/

gulp.task("prepare:copy", () => {
    return gulp.src(path.join("src", "SmoothTranscode", "**", "*"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare:fontawesome", () => {
    return gulp.src(path.join(__dirname, "node_modules", "@fortawesome", "fontawesome-pro-webfonts", "webfonts", "*.woff2"))
        .pipe(gulp.dest(path.join("build", "frontend", "assets")));
});

gulp.task("prepare:vue", () => {
    return gulp.src(path.join(__dirname, "node_modules", "vue", "dist", "vue.js"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare:lodash", () => {
    return gulp.src(path.join(__dirname, "node_modules", "lodash", "lodash.js"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare:moment", () => {
    return gulp.src(path.join(__dirname, "node_modules", "moment", "moment.js"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare:frontend", gulp.parallel(
    "prepare:copy",
    "prepare:fontawesome",
    "prepare:vue",
    "prepare:lodash",
    "prepare:moment"
));

/*****************************
*** NATIVE CODE PREPARE TASKS
******************************/

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

/*********************
*** FULL PREPARE TASK
**********************/

gulp.task("prepare:all", gulp.parallel(
    "prepare:frontend",
    "prepare:ffmpeg"
));

/************************
*** FRONTEND BUILD TASKS
*************************/

gulp.task("build:sass", () => {
    return gulp.src(path.join("build", "frontend", "**", "*.scss"))
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

/***************************
*** NATIVE CODE BUILD TASKS
****************************/

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

/*******************
*** FULL BUILD TASK
********************/

gulp.task("build:all", gulp.parallel(
    "build:sass",
    "build:ffmpeg"
));

/*************
*** RUN TASKS
**************/

gulp.task("start-electron", (done) => {
    let extension = "";
    if (os.platform == "win32") {
        extension = ".bat";
    }
    this.process = spawn(path.join(__dirname, "node_modules", ".bin", "electron" + extension ), [path.join("build", "frontend", "main.js")], {
        windowsHide: true
    });
    done();
});

gulp.task("run", gulp.series(
    "clean:frontend",
    "prepare:frontend",
    "build:sass",
    "start-electron"
));

gulp.task("run:fullbuild", gulp.series(
    "clean:all",
    "prepare:all",
    "build:all",
    "start-electron"
));