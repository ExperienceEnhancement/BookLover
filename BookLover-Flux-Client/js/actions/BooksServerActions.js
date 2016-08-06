var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/ActionTypes');

var BooksListServerActions = {
    receiveBooks: function (data) {
        AppDispatcher.handleServerAction({
            actionType: ActionTypes.RECEIVE_BOOKS,
            data: data
        });
    },
    receiveBookFormErrors: function(data) {
        AppDispatcher.handleServerAction({
            actionType: ActionTypes.RECEIVE_BOOK_FORM_ERRORS,
            data: data
        });
    }
};

module.exports = BooksListServerActions;