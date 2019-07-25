<template>
    <div id="main-window" class="window">
        <nav id="toolbar">
            <ul>
                <li v-if="!encoding"><a href="#" data-icon="" id="start-converting-btn" v-on:click="convertClicked">Start Converting</a></li>
                <li v-if="encoding"><a href="#" data-icon="" id="stop-converting-btn" v-on:click="stopClicked">Stop Converting</a></li>
                <li v-if="!encoding"><a href="#" data-icon="" id="add-file-btn" v-on:click="addFilesClicked">Add File</a></li>
            </ul>
        </nav>
        <main v-on:dragenter="dragEnter">
            <ul id="file-list" v-if="files.length > 0">
                <li v-for="file in files" v-bind:data-file="file.id" :key="file.id">
                    <header>
                        <div class="title" :data-icon="file.videoStreams.length > 0 ? '\uf008' : '\uf028'">
                            {{ file.name }}
                        </div>
                        <div v-if="!encoding">
                            <a href="#" title="Remove File" class="button icon-only" data-icon="" v-on:click="removeFile(file)">Remove File</a>
                            <a href="#" title="Add Output" class="button icon-only" data-icon="" v-on:click="addOutput(file)">Add Output</a>
                        </div>
                    </header>
                    <ul v-if="file.outputs.length > 0">
                        <li v-for="output in file.outputs" v-bind:data-output="output.id" :key="output.id">
                            <div class="status error" data-icon="" v-if="output.status == 'error'" :title="output.errorMessage"></div>
                            <div class="status complete" data-icon="" v-if="output.status == 'complete'" title="Encode Finished"></div>
                            <div class="info">
                                <p><strong>Output: </strong><a href="#" class="output-link" v-on:click="changeOutputPath(output)">{{ output.path }}</a></p>
                                <p><strong>Preset: </strong>{{ output.settings.presetName }}</p>
                            </div>
                            <div v-if="!encoding">
                                <a href="#" title="Remove Output" class="button icon-only" data-icon="" v-on:click="removeOutput(file, output)">Remove Output</a>
                            </div>
                        </li>
                    </ul>
                </li>
            </ul>
            <p id="placeholder" data-icon="" v-if="showPlaceholder">Add video or audio files to get started</p>
            <div id="drag-notice" v-if="dropActive">
                <p data-icon="">Drop files here</p>
            </div>
            <div id="drop-target" v-if="dropActive" v-on:dragleave="dragLeave" v-on:drop="drop"></div>
        </main>
        <aside v-if="encoding">
            <p>Encoding {{ completedEncodes + 1 }} of {{ totalEncodes }}</p>
            <progress v-bind:value="totalPercentage" max="100">{{totalPercentage}}%</progress>
            <p>Time Encoded: {{ currentEncode.progressTime }} - Encoding Bitrate: {{ currentEncode.progressBitrate }} - Encoding Speed: {{ currentEncode.progressSpeed }}</p>
        </aside>
    </div>
</template>

<script>
import _ from "lodash";
import { File } from "./file.js";
import { FFmpeg } from "./ffmpeg.js";

const { ipcRenderer } = require("electron"),
    { dialog, getCurrentWindow } = require("electron").remote;

export default {
    data: function() {
        return {
            files: [],
            dropActive: false,
            encoding: false,
            completedEncodes: 0,
            currentEncode: null,
            pendingEncodes: []
        }
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
                let progress = Math.round(((100 * this.completedEncodes) + this.currentEncode.progressPercentage) / this.totalEncodes);
                getCurrentWindow().setProgressBar(progress / 100);
                return progress;
            } else {
                getCurrentWindow().setProgressBar(-1);
                return 0;
            }
        }
    },
    methods: {
        convertClicked: function() {
            if (this.files.length > 0) {
                for (let i = 0; i < this.files.length; i++) {
                    for (let x = 0; x < this.files[i].outputs.length; x++) {
                        if (this.files[i].outputs[x].status == "pending") {
                            let encodeSession = new FFmpeg(this.files[i], x);
                            this.pendingEncodes.push(encodeSession);
                        }
                    }
                }
                this.startNextFile();
            } else {
                dialog.showMessageBox(getCurrentWindow(), {
                    type: "error",
                    title: "No files to convert",
                    message: "No files to convert",
                    detail: "Please add video or audio files to convert them."
                });
            }
        },
        startNextFile: function() {
            if (this.pendingEncodes.length > 0) {
                this.currentEncode = this.pendingEncodes.shift();
                this.currentEncode.addListener("finished", () => {
                    this.completedEncodes++;
                    this.currentEncode++;
                    this.startNextFile();
                });
                this.encoding = true;
                this.currentEncode.start();
            } else {
                this.encoding = false;
                this.completedEncodes = 0;
                this.currentEncode = null;
                getCurrentWindow().setProgressBar(-1);
                let completeNotification = new Notification("SmoothTranscode", {
                    body: "Media conversions finished"
                });
            }
        },
        stopClicked: function() {
            this.currentEncode.stop();
            this.encoding = false;
            this.currentEncode = 0;
            this.currentEncode = null;
            this.pendingEncodes = [];
            getCurrentWindow().setProgressBar(-1);
        },
        addFilesClicked: function(event) {
            let filePaths = dialog.showOpenDialog(getCurrentWindow(), {properties: ["openFile", "multiSelections"]});
            if (typeof filePaths !== "undefined") {
                for (let file of filePaths) {
                    this.addFile(file);
                }
            }
        },
        addFile: function(filePath) {
            if (!_.find(this.files, { path: filePath })) {
                let mediaFile = new File(filePath);
                if (!mediaFile.error) {
                    this.files.push(mediaFile);
                    this.addOutput(mediaFile);
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
            this.files.splice(this.files.indexOf(file), 1);
        },
        addOutput: function(file) {
            file.addOutput();
        },
        removeOutput: function(file, output) {
            file.removeOutput(output);
        },
        changeOutputPath: function(output) {
            let filePath = dialog.showSaveDialog(getCurrentWindow(), {defaultPath: output.path});
            if (typeof filePath !== "undefined") {
                output.path = filePath;
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
        window.onbeforeunload = (event) => {
            if (this.encoding) {
                let confirmResult = dialog.showMessageBox(getCurrentWindow(), {
                    type: "warning",
                    buttons: ["Yes", "No"],
                    title: "Encode in Progress",
                    message: "Are you sure you want to exit?",
                    detail: "An encode is currently in progress. Exiting will stop the encode before it completes."
                });
                if (confirmResult === 0) {
                    this.stopClicked();
                } else {
                    event.returnValue = false;
                }
            }
        }
        ipcRenderer.send("ready");
    }
}
</script>