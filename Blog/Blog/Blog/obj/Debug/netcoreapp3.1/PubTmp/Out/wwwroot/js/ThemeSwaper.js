
const theme = window.matchMedia("(prefers-color-scheme: dark)")
theme.addListener((e) => {
    if (e.matches) {
        doDarkTheme();
    }
    else {
        location.reload()
    }
});
if (theme.matches) {
    doDarkTheme();
}

function doDarkTheme() {
    $(document).ready(function () {
        var x = document.getElementsByTagName("body");
        x[0].setAttribute("class", "bg-more-dark text-white")
        // x[0].addClass="text-white"
        $(".animate-dark").each(function () {
            $(this).addClass("bg-blue")
        })
        $(".swap-s-btn").each(function () {
            $(this).addClass("bg-blue");
        })
        $(".bg-swap").each(function () {
            $(this).addClass("bg-gray border-dark");
        })
        $("input").each(function () {
            $(this).addClass("text-white");
        })
        $("textarea").each(function () {
            $(this).addClass("text-white");
        })
        $(".swap-text").each(function () {
            $(this).addClass("text-white");
        })
        $(".kulveniam").each(function () {
            $(this).addClass("border-blue");
        })
        $("input.btn").each(function () {
            $(this).addClass("text-dark");
        })
    })
}
