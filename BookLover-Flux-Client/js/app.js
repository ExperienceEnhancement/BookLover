var React = require('react');
var Render = require('react-dom').render;

// React router imports
var ReactRouter = require('react-router');
var Router = ReactRouter.Router;
var Route = ReactRouter.Route;
var hashHistory = ReactRouter.hashHistory;

// Components
var BookLoverApp = require('./components/BookLoverApp.react');
var Books = require('./components/Books.react');

Render(
    <Router history={hashHistory}>
        <Route path="/" component={BookLoverApp}>
            <Route path="books" component={Books}/>
        </Route>
    </Router>,
    document.getElementById('book-lover-app')
);