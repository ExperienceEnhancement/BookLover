var request = require('superagent');

// Actions
var BooksServerActions = require('../actions/BooksServerActions');

function getBooks() {
    request.get('http://localhost:62636/api/books')
        .set('Accept', 'application/json')
        .end(function (err, response) {
            BooksServerActions.receiveBooks(response.body);
        });
}

function processSaveUpdateServerResponse(err) {
    var formErrors = {};

    if(!err) {
        getBooks();
    } else {
        var errors = err.response.body.modelState;
        for (var error in errors) {
            if (errors.hasOwnProperty(error)) {
                var errorKey = error.replace('model.', '');
                errorKey = errorKey.charAt(0).toLowerCase() + errorKey.slice(1);
                formErrors[errorKey] = errors[error];
            }
        }
    }

    BooksServerActions.receiveBookFormErrors(formErrors);
}

var BooksApiService = {
    get: function () {
        getBooks();
    },
    save: function (book) {
        request
            .post('http://localhost:62636/api/books')
            .send(book)
            .set('Accept', 'application/json')
            .end(function (err) {
                processSaveUpdateServerResponse(err);
            });
    },
    update: function(book) {
        request
            .patch('http://localhost:62636/api/books/' + book.id)
            .send({
                title: book.title,
                summary: book.summary,
                authorId: book.authorId
            })
            .set('Accept', 'application/json')
            .end(function(err) {
                processSaveUpdateServerResponse(err);
            });

    },
    delete: function (bookId) {
        request
            .delete('http://localhost:62636/api/books/' + bookId)
            .set('Accept', 'application/json')
            .end(function (err) {
                if(!err) {
                    getBooks();
                }
            })
    },
    getBook: function(bookId) {
        request
            .get('http://localhost:62636/api/books/' + bookId)
            .set('Accept', 'application/json')
            .end(function (err, response) {
                if(!err) {
                    BooksServerActions.receiveBook(response.body);
                }
            });
    }
};

module.exports = BooksApiService;