var AppDispatcher = require('../dispatcher/AppDispatcher');
var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');

// Action types
var ActionTypes = require('../constants/ActionTypes');

// Api services
var BooksApiService = require('../api-services/BooksApiService');

var _books = [{}];
var _bookFormErrors = {};

function updateBooksList(books) {
    _books = books;
}

function saveBook(book) {
    BooksApiService.save(book);
}

function updateBookFormErrors(bookFormErrors) {
    _bookFormErrors = bookFormErrors;
}

var BooksStore = _.extend({}, EventEmitter.prototype, {
    getBooksFromServer: function () {
        BooksApiService.get();
    },
    getBooksList: function () {
        return _books;
    },
    getBookFormErrors: function() {
        return _bookFormErrors;
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
        case ActionTypes.RECEIVE_BOOKS:
            updateBooksList(action.data);
            break;
        case ActionTypes.SAVE_BOOK:
            saveBook(action.data);
            break;
        case ActionTypes.RECEIVE_BOOK_FORM_ERRORS:
            updateBookFormErrors(action.data);
            break;
        default:
            return true;
    }

    BooksStore.emitChange();
    return true;
});

module.exports = BooksStore;
