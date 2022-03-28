function onDragStart(event) {
    event
        .dataTransfer
        .setData('text/plain', event.target.id);

    // event
    //   .currentTarget
    //   .style
    //   .backgroundColor = 'yellow';
}

function onDragOver(event) {
    event.preventDefault();
}

function onDrop(event) {
    const id = event
        .dataTransfer
        .getData('text');

    const draggableElement = document.getElementById(id);
    const dropzone = event.target;
    if (dropzone.tagName == "DIV")
        dropzone.appendChild(draggableElement);

    event
        .dataTransfer
        .clearData();
}
//helper elelements

function h2f() {
    document.getElementById("text22").innerHTML += ` <h2 id="draggable-1" contenteditable="true" class="d1del m-2 example-draggable" draggable="true"ondragstart="onDragStart(event);" >text</h2>`
    delelem()
    catchcl()
}

function h3f() {
    document.getElementById("text22").innerHTML += ` <h3 id="draggable-1" contenteditable="true"class="d1del m-2  example-draggable" draggable="true"ondragstart="onDragStart(event);" >text</h3>`
    delelem()
    catchcl()
}

function h4f() {
    document.getElementById("text22").innerHTML += ` <h4 id="draggable-1" contenteditable="true"class="d1del m-2  example-draggable" draggable="true"ondragstart="onDragStart(event);" >text</h4>`
    delelem()
    catchcl()
}
function h5f() {
    document.getElementById("text22").innerHTML += ` <h5 id="draggable-1" contenteditable="true"class="d1del m-2  example-draggable" draggable="true"ondragstart="onDragStart(event);" >text</h5>`
    delelem()
    catchcl()
}
function h6f() {
    document.getElementById("text22").innerHTML += ` <h6 id="draggable-1" contenteditable="true"class="d1del m-2  example-draggable" draggable="true"ondragstart="onDragStart(event);" >text</h6>`
    delelem()
    catchcl()
}

function p() {
    document.getElementById("text22").innerHTML += ` <p id="draggable-1" contenteditable="true"class="d1del m-2  example-draggable" draggable="true"ondragstart="onDragStart(event);" >text</p>`
    delelem()
    catchcl()
}

//for editor

function delelem() {// удаление элемента
    $(".d1del").dblclick(function () {
        $(this).remove();
    })
}

function catchcl() {//установка значения
    var x = document.getElementById("submitData");
    x.addEventListener("click", function () {
        document.getElementById("text").value = ParseText();
        var x = document.getElementById("text22");
        document.getElementById("textNotParse").value = x.innerHTML
    });
}

function ParseText(argument) {
    var x = document.getElementById("text22");
    var text = x.innerHTML;
    text = text.replace(/contenteditable="true"/g, "");
    text = text.replace(/draggable="true"/g, "");
    text = text.replace(/ondragstart="onDragStart(event);"/g, "");
    return text;
}

function SaveDesc() {
    var key = document.getElementById("usname").innerText;
    localStorage.setItem(key.toString()+"desc", document.getElementById("text22").innerHTML);
}


//swap theme color

function DarkTheme() {
    //var key = document.getElementById("usname").innerText;
    //localStorage.setItem(key.toString() + "theme", "dark");

    var x = document.getElementsByTagName("body");
    x[0].setAttribute("class", "bg-dark")
}
//$(document).ready(function () {
//    var key = document.getElementById("usname").innerText;
//    if (localStorage.getItem(key + "theme") == "dark") {
//        var x = document.getElementsByTagName("body");
//        x[0].setAttribute("class","bg-dark")
//    }
//})