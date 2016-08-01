var React = require('react');
var Book = require('./Book.react.js');

var BooksList = React.createClass({
    render: function () {
        var booksNodes = this.props.data.map(function(book) {
            return (
                <Book key={book.id} title={book.title} author={book.author} summary={book.summary}></Book>
            );
        });

        return (
            <div className="booksList">
                {booksNodes}
            </div>
        );
    }
});

module.exports = BooksList;
