function moveBar(elementSelector) {
    var $bar = $(elementSelector);
    var speed = 1000;

    setInterval(function () {
        $bar.animate({
            "top": "+=800"
        }, speed, function () {
            $bar.animate({
                "top": "-=820"
            }, speed);
        });
    }, speed * 2);
}
function oppositeMoveBar(elementSelector) {
    var $bar = $(elementSelector);
    var speed = 1000;

    setInterval(function () {
        $bar.animate({
            "top": "-=840"
        }, speed, function () {
            $bar.animate({
                "top": "+=800"
            }, speed);
        });
    }, speed * 2);
}
function slideIn(elementSelector) {
    $(elementSelector).slideDown(2000);
}