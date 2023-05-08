//$(document).ready(function () {
//    // Hide the vertical scrollbar
//    $('html').css('overflow-y', 'hidden');

//    // Add scroll functionality for both mouse and touch events
//    var lastY = 0;
//    $(window).on('mousewheel touchmove', function (event) {
//        var deltaY = event.originalEvent.deltaY || event.originalEvent.touches[0].clientY - lastY;
//        lastY = event.originalEvent.touches[0].clientY;
//        var scrollAmount = Math.max(-1, Math.min(1, deltaY));
//        $('html').scrollTop($('html').scrollTop() - (scrollAmount * 40));
//        event.preventDefault();
//    });
//});

//document.addEventListener('DOMContentLoaded', function () {
//    // Hide the vertical scrollbar
//    document.body.style.overflowY = 'hidden';

//    // Add scroll functionality for both mouse and touch events
//    var lastY = 0;
//    document.addEventListener('mousewheel', handleScroll);
//    document.addEventListener('touchmove', handleScroll);

//    function handleScroll(event) {
//        var deltaY = event.deltaY || event.touches[0].clientY - lastY;
//        lastY = event.touches[0].clientY;
//        var scrollAmount = Math.max(-1, Math.min(1, deltaY));
//        window.scrollBy(0, -scrollAmount * 40);
//        event.preventDefault();
//    }
//});
//function fadeIn()
//{
//    $(document).ready(function () {
//        $('#fadeMeIn').each(function (index) {
//            $(this).delay(100 * index).fadeIn(500);
//        });
//    });
//};


