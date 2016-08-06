var AppDispatcher = require('../dispatcher/AppDispatcher');
var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');

// Action types
var ActionTypes = require('../constants/ActionTypes');

// Services
var AuthorsApiService = require('../api-services/AuthorsApiService');

var _authors = [{}];

function updateAuthorsList(authors) {
    _authors = authors;
}

var AuthorsStore = _.extend({}, EventEmitter.prototype, {
    getAuthorsList: function() {
        return _authors;
    },
    getAuthorsFromServer: function() {
        AuthorsApiService.get();
    },
    emitChange: function() {
        this.emit('change');
    },
    addChangeListener: function(callback) {
        this.on('change', callback);
    },
    removeChangeListener: function(callback) {
        this.removeListener('change', callback);
    }
});

AppDispatcher.register(function (payload) {
    var action = payload.action;
    switch(action.actionType) {
        case ActionTypes.RECEIVE_AUTHORS:
            updateAuthorsList(action.data);
            break;
        default:
            return true;
    }

    AuthorsStore.emitChange();
    return true;
});

module.exports = AuthorsStore;