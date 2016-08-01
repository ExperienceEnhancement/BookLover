var React = require('react');

var Book = React.createClass({
    render: function () {
        return (
            <div>
                <div>{this.props.title}</div>
                <div>Written by{this.props.author}</div>
            </div>
        );
    }
});

module.exports = Book;
