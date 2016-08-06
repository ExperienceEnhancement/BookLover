var React = require('react');
var BookViewActions = require('../actions/BookViewActions');

var Book = React.createClass({
    handleEditBtnClick: function () {
        BookViewActions.bookEditBtnClick();
    },
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
                        <span className="btn btn-sm btn-warning" onClick={this.handleEditBtnClick}>Edit</span>
                        <span className="btn btn-sm btn-danger">Delete</span>
                    </div>
                </div>
            </div>
        );
    }
});

module.exports = Book;
