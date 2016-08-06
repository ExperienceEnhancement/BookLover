var request = require('superagent');
var BooksServerActions = require('../actions/BooksServerActions');

function getBooks() {
    request.get('http://localhost:62636/api/books')
        .set('Accept', 'application/json')
        .end(function (err, response) {
            BooksServerActions.receiveBooks(response.body);
        });
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
                var formErrors = {};

                if(!err){
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
            });
    }
};

module.exports = BooksApiService;