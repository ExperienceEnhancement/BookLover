var React = require('react');

// Components
var BooksList = require('./BooksList.react');
var BookForm = require('./BookForm.react');

// Stores
var BooksStore = require('../stores/BooksStore');
var AuthorsStore = require('../stores/AuthorsStore');

function getBooksListState() {
    return {
        books: BooksStore.getBooksList(),
        bookFormErrors: BooksStore.getBookFormErrors(),
        book: BooksStore.getFormBook(),
        authors: AuthorsStore.getAuthorsList(),
        status: 'create'
    }
}

var BookLoverApp = React.createClass({
    getInitialState: function () {
        return getBooksListState();
    },
    componentWillMount: function () {
        BooksStore.removeChangeListener(this._onChange);
        AuthorsStore.removeChangeListener(this._onChange);
        // Api invocations by the stores
        BooksStore.getBooksFromServer();
        AuthorsStore.getAuthorsFromServer();
    },
    componentDidMount: function () {
        BooksStore.addChangeListener(this._onChange);
        AuthorsStore.addChangeListener(this._onChange);
    },
    render: function () {
        return (
            <div className="book-lover-app">
                <BooksList books={this.state.books}></BooksList>
                <BookForm errors={this.state.bookFormErrors} authors={this.state.authors} book={this.state.book} status={this.state.status}></BookForm>
            </div>
        );
    },
    _onChange: function () {
        this.setState(getBooksListState());
    }
});

module.exports = BookLoverApp;