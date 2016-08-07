var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/ActionTypes');

var BookViewActions = {
    bookDetailsBtnClick: function (bookId) {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.BOOK_DETAILS_BTN_CLICK,
            data: bookId
        });
    },
    saveBook: function (book) {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.SAVE_BOOK,
            data: book
        })
    }
};

module.exports = BookViewActions;