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
            fileListEntry.id = "file-" + mediaFile.id;
            let fileHeading = document.createElement("header");
            let fileHeadingTitle = document.createElement("div");
            if (mediaFile.videoStreams.length > 0) {
                fileHeadingTitle.setAttribute("data-icon", "\uf008");
            }
            else {
                fileHeadingTitle.setAttribute("data-icon", "\uf028");
            }
            fileHeadingTitle.innerHTML = filePath.substring(filePath.lastIndexOf(path.sep) + 1);
            fileHeadingTitle.classList.add("title");
            fileHeading.appendChild(fileHeadingTitle);
            fileHeadingButtons = document.createElement("div");
            addButton = document.createElement("a");
            addButton.setAttribute("href", "#");
            addButton.setAttribute("data-icon", "\uf067");
            addButton.classList.add("button");
            addButton.innerHTML = "Add Output";
            addButton.addEventListener("click", (event) => {
                addOutput(mediaFile.id);
            });
            fileHeadingButtons.appendChild(addButton);
            fileHeading.appendChild(fileHeadingButtons);
            fileListEntry.appendChild(fileHeading);
            let fileOutputs = document.createElement("ul");
            fileOutputs.id = "file-" + mediaFile.id + "-outputs";
            fileListEntry.appendChild(fileOutputs);
            fileList.appendChild(fileListEntry);
            addOutput(mediaFile.id);
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

function addOutput(fileID)
{
    let file = files.find(element => {
        return element.id == fileID;
    });
    if (typeof file == "undefined") {
        return;
    }
    let transcodeOutput = file.addOutput();
    let outputEntry = document.createElement("li");
    outputEntry.setAttribute("data-output", transcodeOutput.id);
    outputEntry.id = "output-" + transcodeOutput.id;
    outputEntry.innerHTML = transcodeOutput.path;
    fileEntry = document.getElementById("file-" + fileID + "-outputs");
    fileEntry.appendChild(outputEntry);
}