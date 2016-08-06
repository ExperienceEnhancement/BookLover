var AppDispatcher = require('../dispatcher/AppDispatcher.js');
var Constants = require('../constants/AppConstants.js');

var BooksListServerActions = {
    receiveBooks: function (data) {
        AppDispatcher.handleServerAction({
            actionType: Constants.RECEIVE_BOOKS,
            data: data
        });
    }
};

module.exports = BooksListServerActions;
