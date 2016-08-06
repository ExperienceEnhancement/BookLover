var AppDispatcher = require('../dispatcher/AppDispatcher.js');
var Constants = require('../constants/AppConstants.js');

var AuthorsServerActions = {
    receiveAuthors: function (data) {
        AppDispatcher.handleServerAction({
            actionType: Constants.RECEIVE_AUTHORS,
            data: data
        });
    }
};

module.exports = AuthorsServerActions;