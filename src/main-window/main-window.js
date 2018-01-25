const ipc = require("electron").ipcRenderer,
    startConvertingBtn = document.getElementById("start-converting-btn"),
    addFileBtn = document.getElementById("add-file-btn"),
    mainArea = document.getElementsByTagName("main")[0],
    dropTarget = document.getElementById("drop-target");

/***********************
*** BUTTON CLICK EVENTS
************************/

startConvertingBtn.addEventListener("click", (event) => {
    ipc.send("start-converting-clicked");
});

addFileBtn.addEventListener("click", (event) => {
    ipc.send("add-file-clicked");
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
        console.log('File(s) you dragged here: ', file.path)
    }
    if (mainArea.classList.contains("drop-active")) {
        mainArea.classList.remove("drop-active");
    }
});