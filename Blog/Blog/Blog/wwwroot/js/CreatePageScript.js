$(document).ready(function () {
    var key = document.getElementById("usname").innerText
    document.getElementById("text22").innerHTML = localStorage.getItem(key+"desc");
    delelem()
})

window.onunload = function () {
    SaveDesc();
}