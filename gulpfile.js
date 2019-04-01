"use strict";

const gulp = require("gulp"),
    path = require("path"),
    {spawn} = require("child_process"),
    sass = require("gulp-sass"),
    del = require("del"),
    vinylPaths = require("vinyl-paths"),
    os = require("os");

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
    done();
});

gulp.task("clean", (done) => {
    del.sync("build");
    done();
});

/**************************
*** FRONTEND PREPARE TASKS
***************************/

gulp.task("prepare-copy", () => {
    return gulp.src(path.join("src", "SmoothTranscode", "**", "*"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare-fontawesome", () => {
    return gulp.src(path.join(__dirname, "node_modules", "@fortawesome", "fontawesome-pro-webfonts", "webfonts", "*.woff2"))
        .pipe(gulp.dest(path.join("build", "frontend", "assets")));
});

gulp.task("prepare-vue", () => {
    return gulp.src(path.join(__dirname, "node_modules", "vue", "dist", "vue.js"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare-lodash", () => {
    return gulp.src(path.join(__dirname, "node_modules", "lodash", "lodash.js"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare-moment", () => {
    return gulp.src(path.join(__dirname, "node_modules", "moment", "moment.js"))
        .pipe(gulp.dest(path.join("build", "frontend")));
});

gulp.task("prepare", gulp.parallel(
    "prepare-copy",
    "prepare-fontawesome",
    "prepare-vue",
    "prepare-lodash",
    "prepare-moment"
));

/************************
*** FRONTEND BUILD TASKS
*************************/

gulp.task("build-sass", () => {
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
    this.process = spawn(`"${path.join(__dirname, "node_modules", ".bin", "electron" + extension)}"`, [`"${path.join("build", "frontend", "main.js")}"`], {
        shell: true,
        windowsHide: true
    });
    done();
});

gulp.task("run", gulp.series(
    "clean-frontend",
    "prepare",
    "build-sass",
    "start-electron"
));

gulp.task("run-fullbuild", gulp.series(
    "clean",
    "prepare",
    "build",
    "start-electron"
));