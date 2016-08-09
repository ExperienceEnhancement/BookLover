var React = require('react');

// Actions
var BooksViewActions = require('../actions/BooksViewActions');

// Stores
var BooksStore = require('../stores/BooksStore');
var AuthorsStore = require('../stores/AuthorsStore');

// Components
var BooksList = require('./BooksList.react');
var BookForm = require('./BookForm.react');

function getAppState() {
    return {
        booksListState: BooksStore.getBooksList(),
        bookFormState: {
            errors: BooksStore.getBookFormErrors(),
            book: BooksStore.getFormBook(),
            status: BooksStore.getBookFormStatus(),
            authors: AuthorsStore.getAuthorsList()
        }
    }
}

var Books = React.createClass({
    getInitialState: function () {
        return getAppState();
    },
    componentWillMount: function () {
        BooksStore.removeChangeListener(this._onChange);
        AuthorsStore.removeChangeListener(this._onChange);
        BooksViewActions.getBooksList();
        BooksViewActions.getAuthorsOptions();
    },
    componentDidMount: function () {
        BooksStore.addChangeListener(this._onChange);
        AuthorsStore.addChangeListener(this._onChange);
    },
    render: function () {
        return (
            <div className="book-lover-app">
                <BooksList books={this.state.booksListState}></BooksList>
                <BookForm
                    errors={this.state.bookFormState.errors}
                    authors={this.state.bookFormState.authors}
                    status={this.state.bookFormState.status}></BookForm>
            </div>
        );
    },
    _onChange: function () {
        this.setState(getAppState());
    }
});

module.exports = Books;