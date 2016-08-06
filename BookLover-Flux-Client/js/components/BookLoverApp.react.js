var React = require('react');
var BooksList = require('./BooksList.react.js');
var BookForm = require('./BookForm.react.js');
var BooksStore = require('../stores/BooksStore.js');

function getBooksListState() {
    return {
        books: BooksStore.getBooks(),
        authors: [{id: 1, name: 'Jane Austin'}, {id: 2, name: 'Harper Lee'}]
    };
}

var BookLoverApp = React.createClass({
    getInitialState: function () {
        return getBooksListState();
    },
    componentDidMount: function () {
        BooksStore.addChangeListener(this._onChange);
    },
    componentWillMount: function () {
        BooksStore.removeChangeListener(this._onChange);
        BooksStore.pullBooksFromServer();
    },
    render: function () {
        return (
            <div className="book-lover-app">
                <BooksList books={this.state.books}></BooksList>
                <BookForm authors={this.state.authors}></BookForm>
            </div>
        );
    },
    _onChange: function () {
        this.setState(getBooksListState());
    }
});

module.exports = BookLoverApp;