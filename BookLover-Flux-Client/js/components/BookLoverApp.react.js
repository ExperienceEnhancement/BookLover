var React = require('react');

var BookLoverApp = React.createClass({
    render: function () {
        return (
            <div>
                <div className="navbar navbar-default">
                    <div className="container">
                        <div className="navbar-header">
                            <a className="navbar-brand">BookLover</a>
                        </div>
                        <div className="navbar-collapse collapse" id="navbar-main">
                            <ul className="nav navbar-nav">
                                <li>
                                    <a href="#/books">Books</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                {this.props.children}
            </div>
        );
    }
});

module.exports = BookLoverApp;