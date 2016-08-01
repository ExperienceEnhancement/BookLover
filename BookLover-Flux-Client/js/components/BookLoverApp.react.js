var React = require('react');
var BooksList = require('./BooksList.react.js');
var BooksApiService = require('../api-services/BooksApiService.js');

var BookLoverApp = React.createClass({
    getInitialState: function () {
        return {};
    },
    componentDidMount: function () {
        var thisScope = this;
        BooksList.get().then(function (data) {
            thisScope.setState({data: data});
        });

    },
    render: function () {
        return (
            <div className="book-lover-app">
                <BooksList data={this.state.data}></BooksList>
            </div>
        );
    }
});

module.exports = BookLoverApp;