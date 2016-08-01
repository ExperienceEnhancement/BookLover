var AppDispatcher = require('../dispatcher/AppDispatcher.js');
var BooksListConstants = require('../constants/BooksListConstants.js');

var BooksListActions = {
    getBooks: function (data) {
        AppDispatcher.handleAction({
            actionType: BooksListConstants.GET_BOOKS,
            data: data
        });
    }
};

module.exports = BooksListActions;
