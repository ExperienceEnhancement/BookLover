var React = require('react');
var Render = require('react-dom').render;

// Components
var BookLoverApp = require('./components/BookLoverApp.react');

Render(
    <BookLoverApp />,
    document.getElementById('book-lover-app')
);