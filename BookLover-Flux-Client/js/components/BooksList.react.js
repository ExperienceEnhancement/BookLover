var React = require('react');
var Book = require('./Book.react.js');

var BooksList = React.createClass({
    render: function () {
        var booksNodes = this.props.books.map(function(book) {
            return (
                <Book key={book.id} title={book.title} author={book.author} summary={book.summary}></Book>
            );
        });

        return (
            <div className="col-lg-6 col-lg-offset-3">
                <h1 className="page-header text-center">Books</h1>
                {booksNodes}
            </div>
        );
    }
});

module.exports = BooksList;
