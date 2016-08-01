var React = require('react');
var Render = require('react-dom').render;
var BookLoverApp = require('./components/BookLoverApp.react');

Render(
    <BookLoverApp />,
    document.getElementById('book-lover-app')
);