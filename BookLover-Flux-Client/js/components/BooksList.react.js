var React = require('react');

// Components
var BookListItem = require('./BookListItem.react.js');

var BooksList = React.createClass({
    render: function () {
        var booksNodes = this.props.books.map(function(book) {
            return (
                <BookListItem id={book.id} title={book.title} author={book.author} summary={book.summary}></BookListItem>
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
