var request = require('superagent');

// Actions
var AuthorsServerActions = require('../actions/AuthorsServerActions');

var AuthorsApiService = {
    get: function() {
        request
            .get('http://localhost:62636/api/authors')
            .set('Accept', 'application]json')
            .end(function (err, response) {
                AuthorsServerActions.receiveAuthors(response.body);
            });
    }
};

module.exports = AuthorsApiService;