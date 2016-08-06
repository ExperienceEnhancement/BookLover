var AppDispatcher = require('../dispatcher/AppDispatcher');
var EventEmitter = require('events').EventEmitter;
var Constants = require('../constants/AppConstants.js');
var BooksApiService = require('../api-services/BooksApiService');
var _ = require('underscore');

var _books = [ {} ];

function updateBooksList(books) {
    _books = books;
}

function saveBook(book) {
    BooksApiService.save(book);
}

var BooksStore = _.extend({}, EventEmitter.prototype, {
    pullBooksFromServer: function () {
        BooksApiService.get();
    },
    getBooks: function () {
        return _books;
    },
    emitChange: function () {
        this.emit('change');
    },
    addChangeListener: function (callback) {
        this.on('change', callback);
    },
    removeChangeListener: function (callback) {
        this.removeListener('change', callback);
    }
});

AppDispatcher.register(function (payload) {
    var action = payload.action;
    switch (action.actionType) {
        case Constants.RECEIVE_BOOKS:
            updateBooksList(action.data);
            break;
        case Constants.SAVE_BOOK:
            saveBook(action.data);
            break;
        default:
            return true;
    }

    BooksStore.emitChange();
    return true;
});

module.exports = BooksStore;
