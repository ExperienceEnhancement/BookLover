var keyMirror = require('keymirror');

// Define action constants
module.exports = keyMirror({
    // Server
    RECEIVE_BOOKS: null,
    RECEIVE_AUTHORS: null,
    RECEIVE_BOOK_FORM_ERRORS: null,
    RECEIVE_BOOK: null,
    RECEIVE_BOOK_WITH_REVIEWS: null,
    
    // Views
    GET_BOOKS_LIST: null,
    GET_AUTHORS_OPTIONS: null,
    BOOK_DETAILS: null,
    CLEAR_BOOK_FORM: null,
    SAVE_BOOK: null,
    DELETE_BOOK: null,
    GET_BOOK_WITH_REVIEWS: null
});