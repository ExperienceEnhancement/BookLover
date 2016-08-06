var request = require('superagent');
var BooksListServerActions = require('../actions/BooksListServerActions');

function getBooks() {
    request.get('http://localhost:62636/api/books')
        .set('Accept', 'application/json')
        .end(function (err, response) {
            BooksListServerActions.receiveBooks(response.body);
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
            .end(function (err, response) {
                if(!err){
                    getBooks();
                }
            });
    }
};

module.exports = BooksApiService;