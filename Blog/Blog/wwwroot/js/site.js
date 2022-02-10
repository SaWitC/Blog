// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.querySelectorAll('textarea').addEventListener('input', function (e) {
    e.target.style.height = 'auto'
    e.target.style.height = e.target.scrollHeight + 2 + "px"
})

function ReturnWidth() {
    var width = screen.width;
    (document.getElementById("width")).value = width;
}