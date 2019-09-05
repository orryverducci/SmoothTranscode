<template>
    <div id="main-window" class="window">
        <nav id="toolbar">
            <ul>
                <li v-if="!encoding"><a href="#" id="start-converting-btn" v-on:click="convertClicked"><font-awesome-icon icon="play"></font-awesome-icon>Start Converting</a></li>
                <li v-if="encoding"><a href="#" id="stop-converting-btn" v-on:click="stopClicked"><font-awesome-icon icon="stop"></font-awesome-icon>Stop Converting</a></li>
                <li v-if="!encoding"><a href="#" id="add-file-btn" v-on:click="addFilesClicked"><font-awesome-icon icon="plus"></font-awesome-icon>Add File</a></li>
            </ul>
        </nav>
        <main v-on:dragenter="dragEnter">
            <ul id="file-list" v-if="files.length > 0">
                <li v-for="file in files" v-bind:data-file="file.id" :key="file.id">
                    <header>
                        <div class="title">
                            <font-awesome-icon icon="film" v-if="file.videoStreams.length > 0"></font-awesome-icon>
                            <font-awesome-icon icon="volume-up" v-if="file.videoStreams.length == 0"></font-awesome-icon>
                            {{ file.name }}
                        </div>
                        <div v-if="!encoding">
                            <a href="#" title="Remove File" class="button icon-only" v-on:click="removeFile(file)"><font-awesome-icon icon="trash-alt"></font-awesome-icon>Remove File</a>
                            <a href="#" title="Add Output" class="button icon-only" v-on:click="addOutput(file)"><font-awesome-icon icon="plus"></font-awesome-icon>Add Output</a>
                        </div>
                    </header>
                    <ul v-if="file.outputs.length > 0">
                        <li v-for="output in file.outputs" v-bind:data-output="output.id" :key="output.id">
                            <div class="status error" v-if="output.status == 'error'" :title="output.errorMessage"><font-awesome-icon icon="times-circle"></font-awesome-icon></div>
                            <div class="status complete" v-if="output.status == 'complete'" title="Encode Finished"><font-awesome-icon icon="check-circle"></font-awesome-icon></div>
                            <div class="info">
                                <p><strong>Output: </strong><a href="#" class="output-link" v-on:click="changeOutputPath(file, output)">{{ output.path }}</a></p>
                                <p><strong>Preset: </strong>{{ output.settings.presetName }}</p>
                            </div>
                            <div v-if="!encoding">
                                <a href="#" title="Remove Output" class="button icon-only" v-on:click="removeOutput(file, output)"><font-awesome-icon icon="trash-alt"></font-awesome-icon>Remove Output</a>
                            </div>
                        </li>
                    </ul>
                </li>
            </ul>
            <p id="placeholder" v-if="showPlaceholder"><font-awesome-icon icon="file-medical"></font-awesome-icon>Add video or audio files to get started</p>
            <div id="drag-notice" v-if="dropActive">
                <p><font-awesome-icon icon="arrow-down"></font-awesome-icon>Drop files here</p>
            </div>
            <div id="drop-target" v-if="dropActive" v-on:dragleave="dragLeave" v-on:drop="drop"></div>
        </main>
        <aside v-if="encoding">
            <p>Encoding {{ currentEncode }} of {{ totalEncodes }}</p>
            <progress v-bind:value="percentComplete" max="100">{{percentComplete}}%</progress>
            <p>Time Encoded: {{ time }} - Encoding Bitrate: {{ bitrate }} - Encoding Speed: {{ speed }}</p>
        </aside>
    </div>
</template>

<script>
const {ipcRenderer} = require("electron"),
    {dialog, getCurrentWindow} = require("electron").remote;

export default {
    data: function() {
        return {
            files: [],
            dropActive: false,
            encoding: false,
            percentComplete: -1,
            currentEncode: 0,
            totalEncodes: 0,
            time: "00:00:00",
            bitrate: "0kbits/s",
            speed: "0x"
        }
    },
    computed: {
        showPlaceholder: function() {
            return this.files.length == 0 && !this.dropActive;
        }
    },
    watch: {
        percentComplete: function() {
            getCurrentWindow().setProgressBar(percentage);
        }
    },
    methods: {
        convertClicked: function() {
            if (this.files.length > 0) {
                ipcRenderer.send("start-encoding");
            } else {
                dialog.showMessageBox(getCurrentWindow(), {
                    type: "error",
                    title: "No files to convert",
                    message: "No files to convert",
                    detail: "Please add video or audio files to convert them."
                });
            }
        },
        stopClicked: function() {
            ipcRenderer.send("stop-encoding");
        },
        updateEncodeStatus: function(event, status) {
            this.encoding = status.encoding;
            this.percentComplete = status.percentage;
            this.currentEncode = status.currentEncode;
            this.totalEncodes = status.totalEncodes;
            this.time = status.time,
            this.bitrate = status.bitrate,
            this.speed = status.speed
        },
        addFilesClicked: async function(event) {
            let dialogResult = await dialog.showOpenDialog(getCurrentWindow(), {properties: ["openFile", "multiSelections"]});
            if (!dialogResult.canceled) {
                for (let file of dialogResult.filePaths) {
                    this.addFile(file);
                }
            }
        },
        addFile: function(filePath) {
            ipcRenderer.send("add-file", filePath);
        },
        showAddFileError: function() {
            dialog.showMessageBox(getCurrentWindow(), {
                type: "error",
                title: "Unable to add file",
                message: "Unable to add file",
                detail: "Check the file is a valid video or audio file."
            });
        },
        updateFiles: function(event, files) {
            this.files = JSON.parse(files);
        },
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
                this.addFile(file.path);
            }
            this.dropActive = false;
        },
        removeFile: function(file) {
            ipcRenderer.send("remove-file", file.id);
        },
        addOutput: function(file) {
            ipcRenderer.send("add-output", file.id);
        },
        removeOutput: function(file, output) {
            ipcRenderer.send("remove-output", file.id, output.id);
        },
        changeOutputPath: async function(file, output) {
            let dialogResult = await dialog.showSaveDialog(getCurrentWindow(), {defaultPath: output.path});
            if (!dialogResult.canceled) {
                ipcRenderer.send("change-output-path", file.id, output.id, dialogResult.filePath);
            }
        }
    },
    mounted: function() {
        document.addEventListener("dragover", (event) => {
            event.preventDefault();
        });
        document.addEventListener("drop", (event) => {
            event.preventDefault();
        });
        window.onbeforeunload = async (event) => {
            if (this.encoding) {
                let dialogResult = await dialog.showMessageBox(getCurrentWindow(), {
                    type: "warning",
                    buttons: ["Yes", "No"],
                    title: "Encode in Progress",
                    message: "Are you sure you want to exit?",
                    detail: "An encode is currently in progress. Exiting will stop the encode before it completes."
                });
                if (dialogResult.response === 0) {
                    this.stopClicked();
                } else {
                    event.returnValue = false;
                }
            }
        }
        ipcRenderer.on("add-file-error", this.showAddFileError);
        ipcRenderer.on("update-files", this.updateFiles);
        ipcRenderer.on("encode-status-update", this.updateEncodeStatus);
        ipcRenderer.send("ready");
    }
}
</script>