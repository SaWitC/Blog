// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//document.querySelectorAll('textarea').addEventListener('input', function (e) {
//    e.target.style.height = 'auto'
//    e.target.style.height = e.target.scrollHeight + 2 + "px"
//})

//function ReturnWidth() {
//    var width = screen.width;
//    (document.getElementById("width")).value = width;
//}

//function www() {
//    alert("hello wait")
//}

function btnLocker(e) {
    try {
        var btn = document.getElementById("editbtn")
        btn.addEventListener("click", lockEditbtn);
    }
    catch{

    }
}

function lockEditbtn() {
    var btn = document.getElementById("editbtn")
    if (window.screen.width < 700) {
        alert("cool");
        btn.href = "SmalWidth";
    }
}




