var React = require('react');

// Components
var Book = require('./Book.react');

var BooksList = React.createClass({
    render: function () {
        var booksNodes = this.props.books.map(function(book) {
            return (
                <Book id={book.id} title={book.title} author={book.author} summary={book.summary}></Book>
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
