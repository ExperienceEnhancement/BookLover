var React = require('react');

// Actions
var BooksViewActions = require('../actions/BooksViewActions');

// Components
var BookForm = require('../components/BookForm.react');

var Book = React.createClass({
    render: function () {
        return (
            <div className="book panel panel-info">
                <h3 className="book-title panel-heading text-center">{this.props.title}</h3>
                <div className="panel-body clearfix">
                    <div className="pull-left">
                        <span className="glyphicon glyphicon-book book-icon"></span>
                        Written by {this.props.author}
                    </div>
                    <div className="pull-right">
                        <span className="btn btn-sm btn-primary"
                              onClick={this.handleDetailsBtnClick.bind(this, this.props.id)}>Details</span>
                        <span className="btn btn-sm btn-danger"
                            onClick={this.handleDeleteBtnClick.bind(this, this.props.id)}>Delete</span>
                    </div>
                </div>
            </div>
        );
    },
    handleDetailsBtnClick: function (bookId) {
        BooksViewActions.bookDetails(bookId);
    },
    handleDeleteBtnClick: function (bookId) {
        BooksViewActions.deleteBook(bookId);
    }
});

module.exports = Book;
