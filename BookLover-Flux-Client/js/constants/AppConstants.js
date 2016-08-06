var keyMirror = require('keymirror');

// Define action constants
module.exports = keyMirror({
    // Server
    RECEIVE_BOOKS: null,
    RECEIVE_AUTHORS: null,
    
    // Views
    EDIT_BOOK_BTN_CLICK: null,
    SAVE_BOOK: null
});