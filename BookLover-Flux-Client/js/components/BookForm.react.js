var React = require('react');
var _ = require('underscore');

// Constants
var BookFormConstants = require('../constants/BookFormConstants');

// Stores
var BooksStore = require('../stores/BooksStore');

// Actions
var BooksViewActions = require('../actions/BooksViewActions');

var BookForm = React.createClass({
    getInitialState: function() {
        return {book: BooksStore.getFormBook()};
    },
    componentDidMount: function () {
        BooksStore.addChangeListener(this.handleBookStoreChangeEvent);
    },
    componentWillMount: function () {
        BooksStore.removeChangeListener(this.handleBookStoreChangeEvent);
    },
    render: function () {
        var self = this;
        var errors = self.props.errors;
        return(
            <div className="col-lg-12">
                <form className="form-horizontal col-lg-4 col-lg-offset-4">
                    <fieldset>
                        <legend className="text-center">
                            {self.props.status == BookFormConstants.BOOK_FORM_CREATE_STATUS ?
                                BookFormConstants.BOOK_FORM_CREATE_STATUS :
                                BookFormConstants.BOOK_FORM_EDIT_STATUS} book
                        </legend>
                        <input type="hidden" name="id" value={self.state.book.id}/>
                        <div className={"form-group" + (errors.title ? ' has-error' : '')}>
                            <label className="control-label col-lg-2">Title</label>
                            <div className="col-lg-10">
                                <input className="form-control"
                                       name="title"
                                       type="text"
                                       placeholder="Title"
                                       value={self.state.book.title}
                                       onChange={self.changeBookState}/>
                                {errors.title ?
                                    errors.title.map(function (error) {
                                        return <span className="help-block">{error}</span> }) :
                                    ''}
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="control-label col-lg-2">Summary</label>
                            <div className="col-lg-10">
                                <textarea className="form-control"
                                          name="summary"
                                          type="text"
                                          placeholder="Summary"
                                          value={self.state.book.summary}
                                          onChange={self.changeBookState}></textarea>
                            </div>
                        </div>
                        <div className={"form-group" + (errors.authorId ? ' has-error' : '')}>
                            <label className="control-label col-lg-2">Author</label>
                            <div className="col-lg-10">
                                <select className="form-control"
                                        name="authorId"
                                        value={self.state.book.authorId}
                                        onChange={self.changeBookState}>
                                    <option value={BookFormConstants.AUTHOR_ID_DEFAULT_VALUE}>--</option>
                                    {this.props.authors.map(function (author) {
                                        return (
                                            <option value={author.id}>{author.firstName} {author.lastName}</option>
                                        )})}
                                </select>
                                {errors.authorId ?
                                    errors.authorId.map(function (error) {
                                        return <span className="help-block">{error}</span> }) :
                                    ''}
                            </div>
                        </div>
                    </fieldset>
                    <div className="form-group text-center">
                        <button className="btn btn-success" onClick={self.saveBook}>Save book</button>
                        <button className="btn btn-warning" onClick={self.clearBookForm}>Clear</button>
                    </div>
                </form>
            </div>
        );
    },
    changeBookState: function (e) {
        var book = this.state.book;
        var inputChanged = e.target;
        book[inputChanged.name] = inputChanged.value;
        this.setState({book: book});
    },
    saveBook: function (e) {
        e.preventDefault();
        var book = this.state.book;
        BooksViewActions.saveBook(book);
    },
    clearBookForm: function(e) {
        e.preventDefault();
        BooksViewActions.clearBookForm();
    },
    handleBookStoreChangeEvent: function () {
        this.setState({book: BooksStore.getFormBook()});
    }
});

module.exports = BookForm;
