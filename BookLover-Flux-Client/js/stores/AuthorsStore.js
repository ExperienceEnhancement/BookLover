var AppDispatcher = require('../dispatcher/AppDispatcher');
var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');

// Action types
var ActionTypes = require('../constants/ActionTypes');

// Api services
var AuthorsApiService = require('../api-services/AuthorsApiService');

// State variables
var _authors = [{}];

function getAuthorsFromServer() {
    AuthorsApiService.get();
}

function setAuthorsList(authors) {
    _authors = authors;
}

var AuthorsStore = _.extend({}, EventEmitter.prototype, {
    getAuthorsList: function() {
        return _authors;
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
        // Server actions
        case ActionTypes.RECEIVE_AUTHORS:
            setAuthorsList(action.data);
            break;
        // View actions
        case ActionTypes.GET_AUTHORS_OPTIONS:
            getAuthorsFromServer();
            break;
        default:
            return true;
    }

    AuthorsStore.emitChange();
    return true;
});

module.exports = AuthorsStore;