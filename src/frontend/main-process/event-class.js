/** Provides functions for listening to and firing events. */
export class EventClass {
    /**
     * The event listeners.
     *
     * @type {Map}
     */
    _listeners = new Map();

    /**
     * Initialises an instance of EventClass.
     */
    constructor() { }

    /**
     * Add an event listener callback to an event channel.
     *
     * @param {string} channel - The name of the channel to listen to.
     * @param {Function} callback - A callback method to run when the event channel is fired.
     */
    addListener(channel, callback) {
        // Create the event channel with an empty array of callbacks if it doesn't exist
        if (!this._listeners.has(channel)) {
            this._listeners.set(channel, []);
        }
        // Add the callback to the event channel array
        this._listeners.get(channel).push(callback);
    }

    /**
     * Removes an event listener callback from an event channel.
     *
     * @param {string} channel - The name of the channel to remove the listener from.
     * @param {Function} callback - The callback method to be removed from the event channel.
     * @returns {boolean} True if successfully removed, false otherwise.
     */
    removeListener(channel, callback) {
        // Get listener callbacks for the channel, and initialise the index
        let listeners = this._listeners.get(channel);
        let index;
        // If there are listeners for the channel, check for the callback and remove it
        if (typeof listeners !== "undefined" && listeners.length > 0) {
            // Determine the index of the callback to be removed
            index = listeners.reduce((i, listener, index) => {
                if (typeof listener === "function" && listener === callback) {
                    return index;
                }
                return i;
            }, -1);
            // If an index is returned, remove it from the array of callbacks
            if (index > -1) {
                listeners.splice(index, 1);
                this.listeners.set(channel, listeners);
                // Return tue to indicate the listener was successfully removed
                return true;
            }
        }
        // Return false if unable to remove the callback
        return false;
    }

    /**
     * Fires an event channel.
     *
     * @param {string} channel - The name of the event channel to fire.
     */
    fireEvent(channel) {
        // Get the event listeners for the channel
        let listeners = this._listeners.get(channel);
        // If there are listeners, call each one
        if (typeof listeners !== "undefined" && listeners.length > 0) {
            listeners.forEach((listener) => {
                listener();
            });
        }
    }
}