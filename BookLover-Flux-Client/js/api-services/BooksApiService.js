var request = require('superagent');

var BooksApiService = {
    get: function () {
        var deferred = Q.defer();

        request.get('http://localhost:62636/api/books')
            .set('Accept', 'application/json')
            .end(function (err, response) {
                deferred.resolve(response);
            });
        
        return deferred.promise;
    }
};

module.exports = BooksApiService;


