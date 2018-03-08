const {dialog, getCurrentWindow} = require("electron").remote,
    path = require("path"),
    Vue = require("../vue"),
    _ = require("../lodash"),
    {File} = require("../file");
    startConvertingBtn = document.getElementById("start-converting-btn"),
    addFileBtn = document.getElementById("add-file-btn");

/*************
*** VARIABLES
**************/

var files = [];

/******************
*** USER INTERFACE
*******************/

let fileList = new Vue({
    el: "main",
    data: {
        files: files,
        dropActive: false
    },
    computed: {
        showPlaceholder: function() {
            return this.files.length == 0 && !this.dropActive;
        }
    },
    methods: {
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
        addOutput: addOutput
    }
})

/***********************
*** BUTTON CLICK EVENTS
************************/

startConvertingBtn.addEventListener("click", (event) => {
    dialog.showErrorBox("Not Yet Implemented", "This feature has not yet been implemented.");
});

addFileBtn.addEventListener("click", (event) => {
    let filePaths = dialog.showOpenDialog(getCurrentWindow(), {properties: ["openFile", "multiSelections"]});
    if (typeof filePaths !== "undefined") {
        for (let file of filePaths) {
            addFile(file);
        }
    }
});

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