var React = require('react');
var BookViewActions = require('../actions/BookViewActions');

var BookForm = React.createClass({
    getInitialState: function() {
        return { book: {
            title: '',
            summary: '',
            authorId: ''
        }}
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
        BookViewActions.saveBook(book);
    },
    render: function () {
        var self = this;
        return(
            <div className="col-lg-12">
                <form className="form-horizontal col-lg-4 col-lg-offset-4">
                    <fieldset>
                        <legend className="text-center">Create book</legend>
                        <div className="form-group">
                            <label className="control-label col-lg-2">Title</label>
                            <div className="col-lg-10">
                                <input className="form-control" name="title" type="text" value={self.state.book.title} placeholder="Title" onChange={self.changeBookState}/>
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="control-label col-lg-2">Summary</label>
                            <div className="col-lg-10">
                                <textarea className="form-control" name="summary" type="text" placeholder="Summary" value={self.state.book.summary} onChange={self.changeBookState}></textarea>
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="control-label col-lg-2">Author</label>
                            <div className="col-lg-10">
                                <select className="form-control" name="authorId" value={self.state.book.authorId} onChange={self.changeBookState}>
                                    <option value="">--</option>
                                    {this.props.authors.map(function (author) {
                                        return (
                                            <option key={author.id} value={author.id}>{author.name}</option>
                                        )
                                    })}
                                </select>
                            </div>
                        </div>
                    </fieldset>
                    <div className="form-group text-center">
                        <button className="btn btn-success" onClick={self.saveBook}>Save book</button>
                    </div>
                </form>
            </div>
        );
    }
});

module.exports = BookForm;
