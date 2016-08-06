var AppDispatcher = require('../dispatcher/AppDispatcher');
var Constants = require('../constants/AppConstants');

var BookViewActions = {
    bookEditBtnClick: function () {
        AppDispatcher.handleViewAction({
            actionType: Constants.EDIT_BOOK_BTN_CLICK
        });
    },
    saveBook: function (book) {
        AppDispatcher.handleViewAction({
            actionType: Constants.SAVE_BOOK,
            data: book
        })
    }
};

module.exports = BookViewActions;