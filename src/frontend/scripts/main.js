import Vue from "Vue";
import MainWindow from "./main-window.vue";

/**
 * The main vue instance for the application.
 */
new Vue({ 
    el: "#container",
    components: {
        MainWindow
    }
});