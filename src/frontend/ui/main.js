import Vue from "Vue";
import MainWindow from "./main-window.vue";
import { config, library } from '@fortawesome/fontawesome-svg-core';
import { faArrowDown, faCheckCircle, faFileMedical, faFilm, faPlay, faPlus, faStop, faTimesCircle, faTrashAlt, faVolumeUp } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

/**
 * The main vue instance for the application.
 */
new Vue({ 
    el: "#container",
    render: h => h(MainWindow),
    created: function() {
        config.autoAddCss = false;
        library.add(faArrowDown);
        library.add(faCheckCircle);
        library.add(faFileMedical);
        library.add(faFilm);
        library.add(faPlay);
        library.add(faPlus);
        library.add(faStop);
        library.add(faTimesCircle);
        library.add(faTrashAlt);
        library.add(faVolumeUp);
        Vue.component("font-awesome-icon", FontAwesomeIcon);
    }
});