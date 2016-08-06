var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/ActionTypes');

var AuthorsServerActions = {
    receiveAuthors: function (data) {
        AppDispatcher.handleServerAction({
            actionType: ActionTypes.RECEIVE_AUTHORS,
            data: data
        });
    }
};

module.exports = AuthorsServerActions;