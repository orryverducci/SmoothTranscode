const {dialog, getCurrentWindow} = require("electron").remote,
    path = require("path"),
    Vue = require("../vue"),
    _ = require("../lodash"),
    {File} = require("../file"),
    {FFmpeg} = require("../ffmpeg");

/******************
*** USER INTERFACE
*******************/

let ui = new Vue({
    el: "#main-window",
    data: {
        files: [],
        dropActive: false,
        encoding: false,
        completedEncodes: 0,
        currentEncode: null,
        pendingEncodes: []
    },
    computed: {
        showPlaceholder: function() {
            return this.files.length == 0 && !this.dropActive;
        },
        totalEncodes: function() {
            return this.completedEncodes + this.pendingEncodes.length + (this.currentEncode === null ? 0 : 1);
        },
        totalPercentage: function() {
            if (this.encoding) {
                return Math.round(((100 * this.completedEncodes) + this.currentEncode.progressPercentage) / this.totalEncodes);
            } else {
                return 0;
            }
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
        removeOutput: removeOutput,
        changeOutputPath: ChangeOutputPath
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
    if (!_.find(ui.files, { path: filePath })) {
        let mediaFile = new File(filePath);
        if (!mediaFile.error) {
            ui.files.push(mediaFile);
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
    ui.files.splice(ui.files.indexOf(file), 1);
}

function addOutput(file) {
    file.addOutput();
}

function removeOutput(file, output) {
    file.removeOutput(output);
}

function ChangeOutputPath(output) {
    let filePath = dialog.showSaveDialog(getCurrentWindow(), {defaultPath: output.path});
    if (typeof filePath !== "undefined") {
        output.path = filePath;
    }
}

/***************
*** TRANSCODING
****************/

function StartTranscoding() {
    if (ui.files.length > 0) {
        for (let i = 0; i < ui.files.length; i++) {
            for (let x = 0; x < ui.files[i].outputs.length; x++) {
                if (ui.files[i].outputs[x].status == "pending") {
                    let encodeSession = new FFmpeg(ui.files[i], x);
                    ui.pendingEncodes.push(encodeSession);
                }
            }
        }
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
    if (ui.pendingEncodes.length > 0) {
        ui.currentEncode = ui.pendingEncodes.shift();
        ui.currentEncode.addListener("finished", () => {
            ui.completedEncodes++;
            ui.currentEncode++;
            StartNextFile();
        });
        ui.encoding = true;
        ui.currentEncode.start();
    } else {
        ui.encoding = false;
        ui.completedEncodes = 0;
        ui.currentEncode = null;
        let completeNotification = new Notification("SmoothTranscode", {
            body: "Media conversions finished"
        });
    }
}

function StopTranscoding() {
    ui.currentEncode.stop();
    ui.encoding = false;
    ui.currentEncode = 0;
    ui.currentEncode = null;
    ui.pendingEncodes = [];
}

/****************
*** WINDOW CLOSE
*****************/

window.onbeforeunload = (event) => {
    if (ui.encoding) {
        let confirmResult = dialog.showMessageBox(getCurrentWindow(), {
            type: "warning",
            buttons: ["Yes", "No"],
            title: "Encode in Progress",
            message: "Are you sure you want to exit?",
            detail: "An encode is currently in progress. Exiting will stop the encode before it completes."
        });
        if (confirmResult === 0) {
            StopTranscoding();
        } else {
            event.returnValue = false;
        }
    }
}