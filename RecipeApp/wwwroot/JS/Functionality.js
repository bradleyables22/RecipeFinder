
function moveCircle(elementSelector) {
    var $circle = $(elementSelector);
    var speed = 1000;

    setInterval(function () {
        $circle.animate({
            "top": "+=800"
        }, speed, function () {
            $circle.animate({
                "top": "-=820"
            }, speed);
        });
    }, speed * 2);
}