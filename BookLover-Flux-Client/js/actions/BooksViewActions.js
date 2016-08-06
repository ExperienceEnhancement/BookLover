var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/ActionTypes');

var BookViewActions = {
    bookEditBtnClick: function () {
        AppDispatcher.handleViewAction({
            actionType: ActionTypes.EDIT_BOOK_BTN_CLICK
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