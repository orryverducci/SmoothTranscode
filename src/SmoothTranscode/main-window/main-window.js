const {dialog, getCurrentWindow} = require("electron").remote,
    path = require("path"),
    Vue = require("../vue"),
    _ = require("../lodash"),
    {File} = require("../file"),
    {FFmpeg} = require("../ffmpeg");

/*************
*** VARIABLES
**************/

var files = [];

/******************
*** USER INTERFACE
*******************/

let ui = new Vue({
    el: "#main-window",
    data: {
        files: files,
        dropActive: false,
        encoding: false,
        currentEncode: 0,
        encodeSessions: [],
        encodePercentage: 0,
        encodeStatus: ""
    },
    computed: {
        showPlaceholder: function() {
            return this.files.length == 0 && !this.dropActive;
        },
        totalPercentage: function() {
            return Math.round(((100 * this.currentEncode) + this.encodePercentage) / this.encodeSessions.length);
        }
    },
    methods: {
        convertClicked: StartTranscoding,
        stopClicked: StopTranscoding,
        addFilesClicked: AddFilesClicked,
        dragEnter: function(event) {
            event.preventDefault();
            this.dropActive = true;
        },
        dragLeave: function(event) {
            event.preventDefault();
            this.dropActive = false;
        },
        drop: function(event) {
            event.preventDefault();
            for (let file of event.dataTransfer.files) {
                addFile(file.path);
            }
            this.dropActive = false;
        },
        removeFile: removeFile,
        addOutput: addOutput,
        removeOutput: removeOutput
    }
})

/***********************
*** BUTTON CLICK EVENTS
************************/

function AddFilesClicked(event) {
    let filePaths = dialog.showOpenDialog(getCurrentWindow(), {properties: ["openFile", "multiSelections"]});
    if (typeof filePaths !== "undefined") {
        for (let file of filePaths) {
            addFile(file);
        }
    }
}

/********************
*** DRAG/DROP EVENTS
*********************/

document.addEventListener("dragover", (event) => {
    event.preventDefault();
});

document.addEventListener("drop", (event) => {
    event.preventDefault();
});

/*******************
*** FILE MANAGEMENT
********************/

function addFile(filePath) {
    if (!_.find(files, { path: filePath })) {
        let mediaFile = new File(filePath);
        if (!mediaFile.error) {
            files.push(mediaFile);
            addOutput(mediaFile);
        }
        else {
            dialog.showMessageBox(getCurrentWindow(), {
                type: "error",
                title: "Unable to add file",
                message: "Unable to add file",
                detail: "Check the file is a valid video or audio file."
            });
        }
    }
}

function removeFile(file) {
    files.splice(files.indexOf(file), 1);
}

function addOutput(file) {
    file.addOutput();
}

function removeOutput(file, output) {
    file.removeOutput(output);
}

/***************
*** TRANSCODING
****************/

function StartTranscoding() {
    if (files.length > 0) {
        for (let i = 0; i < files.length; i++) {
            for (let x = 0; x < files[i].outputs.length; x++) {
                let encodeSession = new FFmpeg(files[i], x);
                ui.encodeSessions.push(encodeSession);
            }
        }
        ui.encoding = true;
        StartNextFile();
    } else {
        dialog.showMessageBox(getCurrentWindow(), {
            type: "error",
            title: "No files to convert",
            message: "No files to convert",
            detail: "Please add video or audio files to convert them."
        });
    }
}

function StartNextFile() {
    ui.encodePercentage = 0;
    ui.encodeStatus = "";
    if (ui.currentEncode < ui.encodeSessions.length) {
        ui.encodeSessions[ui.currentEncode].addListener("progressChanged", () => {
            ui.encodePercentage = ui.encodeSessions[ui.currentEncode].progressPercentage;
            ui.encodeStatus = ui.encodeSessions[ui.currentEncode].progressStatus;
        });
        ui.encodeSessions[ui.currentEncode].addListener("finished", () => {
            ui.currentEncode++;
            StartNextFile();
        });
        ui.encodeSessions[ui.currentEncode].start();
    } else {
        ui.encoding = false;
        ui.currentEncode = 0;
    }
}

function StopTranscoding() {
    dialog.showMessageBox(getCurrentWindow(), {
        type: "error",
        title: "Not Yet Implemented",
        message: "Not Yet Implemented"
    });
}