var AppDispatcher = require('../dispatcher/AppDispatcher');

// Action types
var ActionTypes = require('../constants/ActionTypes');

var BookViewActions = {
    getBooksList: function () {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.GET_BOOKS_LIST
        });
    },
    getAuthorsOptions: function () {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.GET_AUTHORS_OPTIONS
        });
    },
    bookDetails: function (bookId) {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.BOOK_DETAILS,
            data: bookId
        });
    },
    clearBookForm: function () {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.CLEAR_BOOK_FORM
        })
    },
    saveBook: function (book) {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.SAVE_BOOK,
            data: book
        })
    },
    deleteBook: function(bookId) {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.DELETE_BOOK,
            data: bookId
        })
    },
    getBookWithReviews: function(bookId) {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.GET_BOOK_WITH_REVIEWS,
            data: bookId
        })
    }
};

module.exports = BookViewActions;