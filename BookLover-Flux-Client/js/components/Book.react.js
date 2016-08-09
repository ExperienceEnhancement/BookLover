var React = require('react');

var BooksStore = require('../stores/BooksStore');

var BooksViewActions = require('../actions/BooksViewActions');

var BooksList = React.createClass({
    getInitialState: function () {
        return BooksStore.getBookWithReviews();
    },
    componentWillMount: function () {
        var bookId = this.props.params.id;
        BooksViewActions.getBookWithReviews(bookId);
        BooksStore.removeChangeListener(this.handleBookStoreChangeEvent);
    },
    componentDidMount: function () {
        BooksStore.addChangeListener(this.handleBookStoreChangeEvent);
    },
    render: function () {
        return (
            <div className="col-lg-6 col-lg-offset-3 book">
                <h1 className="page-header text-center">{this.state.title}</h1>
                <div className="list-group">
                    <div className="list-group-item">
                        <span className="glyphicon glyphicon-book book-icon"></span>
                        Written by <span className="text-warning">{this.state.author}</span>
                    </div>
                    <div className="list-group-item">
                        <span className="glyphicon glyphicon-star book-icon"></span>
                        <span className="text-warning">{this.state.reviews.length}</span> Book lovers have reviewed
                    </div>
                    <div className="list-group-item clearfix">
                        <h3 className="page-header text-center title-without-margin">Summary</h3>
                        <div className="col-lg-8 col-lg-offset-2">
                            {this.state.summary}
                        </div>
                    </div>
                </div>
                <h2 className="page-header text-center">Reviews</h2>
                <div className="col-lg-8 col-lg-offset-2">
                    {this.state.reviews.map(function (review) {
                        return(
                            <div className="well">
                                <div>
                                    <span className="glyphicon glyphicon-star book-icon"></span>
                                    Rate <span className="text-warning">{review.rate}</span>
                                </div>
                                <blockquote>
                                    <p>{review.comment}</p>
                                    <small>Reviewed by <cite title={review.username}>{review.username}</cite></small>
                                </blockquote>
                            </div>
                        )
                    })}
                </div>
            </div>
        );
    },
    handleBookStoreChangeEvent: function () {
        this.setState(BooksStore.getBookWithReviews());
    }
});

module.exports = BooksList;
