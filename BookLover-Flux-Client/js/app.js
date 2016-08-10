var React = require('react');
var Render = require('react-dom').render;

// React router imports
var ReactRouter = require('react-router');
var Router = ReactRouter.Router;
var Route = ReactRouter.Route;
var IndexRoute = ReactRouter.IndexRoute;
var hashHistory = ReactRouter.hashHistory;

// Components
var BookLoverApp = require('./components/BookLoverApp.react');
var Books = require('./components/Books.react');
var Book = require('./components/Book.react');

Render(
    <Router history={hashHistory}>
        <Route path="/" component={BookLoverApp}>
            <IndexRoute component={Books}/>
            <Route path="books" component={Books}/>
            <Route path="books/:id" component={Book}/>
        </Route>
    </Router>,
    document.getElementById('book-lover-app')
);