var keyMirror = require('keymirror');

// Define action constants
module.exports = keyMirror({
    // Server
    RECEIVE_BOOKS: null,
    RECEIVE_AUTHORS: null,
    RECEIVE_BOOK_FORM_ERRORS: null,
    RECEIVE_BOOK: null,
    
    // Views
    BOOK_DETAILS_BTN_CLICK: null,
    SAVE_BOOK: null
});