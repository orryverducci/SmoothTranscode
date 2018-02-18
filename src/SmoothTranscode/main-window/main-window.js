const {dialog, getCurrentWindow} = require("electron").remote,
    path = require("path"),
    _ = require("../lodash"),
    {File} = require("../file");
    startConvertingBtn = document.getElementById("start-converting-btn"),
    addFileBtn = document.getElementById("add-file-btn"),
    mainArea = document.getElementsByTagName("main")[0],
    fileList = document.getElementById("file-list"),
    dropTarget = document.getElementById("drop-target");

/*************
*** VARIABLES
**************/

var files = [];

/***********************
*** BUTTON CLICK EVENTS
************************/

startConvertingBtn.addEventListener("click", (event) => {
    dialog.showErrorBox("Not Yet Implemented", "This feature has not yet been implemented.");
});

addFileBtn.addEventListener("click", (event) => {
    dialog.showOpenDialog(getCurrentWindow(), {properties: ["openFile", "multiSelections"]}, (filePaths) => {
        for (let file of filePaths) {
            addFile(file);
        }
    });
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

mainArea.addEventListener("dragenter", (event) => {
    event.preventDefault();
    mainArea.classList.add("drop-active");
});

dropTarget.addEventListener("dragleave", (event) => {
    event.preventDefault();
    if (mainArea.classList.contains("drop-active")) {
        mainArea.classList.remove("drop-active");
    }
});

dropTarget.addEventListener("drop", (event) => {
    event.preventDefault();
    for (let file of event.dataTransfer.files) {
        addFile(file.path);
    }
    if (mainArea.classList.contains("drop-active")) {
        mainArea.classList.remove("drop-active");
    }
});

/*******************
*** FILE MANAGEMENT
********************/

function addFile(filePath) {
    if (!_.find(files, { path: filePath })) {
        let mediaFile = new File(filePath);
        if (!mediaFile.error) {
            files.push(mediaFile);
            mainArea.classList.remove("placeholder-visible");
            let fileListEntry = document.createElement("li");
            fileListEntry.setAttribute("data-file", mediaFile.id);
            fileListEntry.innerHTML = filePath.substring(filePath.lastIndexOf(path.sep) + 1);
            fileList.appendChild(fileListEntry);
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