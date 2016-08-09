var AppDispatcher = require('../dispatcher/AppDispatcher');
var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');

// Constants
var BookFormConstants = require('../constants/BookFormConstants');

// Action types
var ActionTypes = require('../constants/ActionTypes');

// Api services
var BooksApiService = require('../api-services/BooksApiService');

// State variables
var _books = [{}]; // BooksList
var _bookFormErrors = {}; // BookForm
var _bookFormStatus = BookFormConstants.BOOK_FORM_CREATE_STATUS; // BookForm
var _formBook = getFormBookInitialState(); // BookForm
var _bookWithReviews = {
    title: '',
    summary: '',
    author: '',
    reviews: []
};

function getFormBookInitialState(){
    return {
        id: '',
        title: '',
        summary: '',
        authorId: BookFormConstants.AUTHOR_ID_DEFAULT_VALUE
    }
}

function setBooksList(books) {
    _books = books;
}

function setBookFormErrors(bookFormErrors) {
    _bookFormErrors = bookFormErrors;
}

function setFormBook(book) {
    _formBook = book;
}

function saveBook(book) {
    if(book.id) {
        BooksApiService.update(book);
    } else {
        BooksApiService.save(book);
    }
}

function deleteBook(bookId) {
    BooksApiService.delete(bookId);
}

function getBooksFromServer() {
    BooksApiService.get();
}

function getBookFromServer(bookId) {
    BooksApiService.getBook(bookId);
}

function clearBookForm() {
    _bookFormErrors = {};
    _bookFormStatus = BookFormConstants.BOOK_FORM_CREATE_STATUS;
    _formBook = getFormBookInitialState();
}

function getBookWithReviewsFromServer(bookId) {
    BooksApiService.getBookWithReviews(bookId);
}

function setBookWithReviews(book) {
    _bookWithReviews = book;
}

var BooksStore = _.extend({}, EventEmitter.prototype, {
    getBooksList: function () {
        return _books;
    },
    getBookFormErrors: function() {
        return _bookFormErrors;
    },
    getFormBook: function() {
        return _formBook
    },
    getBookFormStatus: function () {
        return _bookFormStatus;
    },
    getBookWithReviews: function () {
        return _bookWithReviews;
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
        // Server actions
        case ActionTypes.RECEIVE_BOOKS:
            setBooksList(action.data);
            break;
        case ActionTypes.RECEIVE_BOOK_FORM_ERRORS:
            setBookFormErrors(action.data);
            if(_.isEmpty(action.data)) {
                setFormBook(getFormBookInitialState());
                _bookFormStatus = BookFormConstants.BOOK_FORM_CREATE_STATUS;
            }

            break;
        case ActionTypes.RECEIVE_BOOK_WITH_REVIEWS:
            setBookWithReviews(action.data);
            break;
        case ActionTypes.RECEIVE_BOOK:
            setFormBook(action.data);
            _bookFormStatus = BookFormConstants.BOOK_FORM_EDIT_STATUS;
            _bookFormErrors = {};
            break;
        // View actions
        case ActionTypes.GET_BOOKS_LIST:
            getBooksFromServer();
            break;
        case ActionTypes.SAVE_BOOK:
            saveBook(action.data);
            break;
        case ActionTypes.BOOK_DETAILS:
            getBookFromServer(action.data);
            break;
        case ActionTypes.CLEAR_BOOK_FORM:
            clearBookForm();
            break;
        case ActionTypes.DELETE_BOOK:
            deleteBook(action.data);
            break;
        case ActionTypes.GET_BOOK_WITH_REVIEWS:
            getBookWithReviewsFromServer(action.data);
            break;
        default:
            return true;
    }

    BooksStore.emitChange();
    return true;
});

module.exports = BooksStore;
