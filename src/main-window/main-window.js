const {dialog, getCurrentWindow} = require("electron").remote,
    path = require("path"),
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
    if (!files.includes(filePath)) {
        mainArea.classList.remove("placeholder-visible");
        files.push(filePath);
        let fileListEntry = document.createElement("li");
        fileListEntry.setAttribute("data-file", "0");
        fileListEntry.innerHTML = filePath.substring(filePath.lastIndexOf(path.sep) + 1);
        fileList.appendChild(fileListEntry);
    }
}