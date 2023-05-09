function showToast(message) {
    var toast = document.createElement('div');
    toast.classList.add('toast');
    toast.innerText = message;
    document.body.appendChild(toast);
    setTimeout(function () {
        toast.classList.add('hide');
        setTimeout(function () {
            document.body.removeChild(toast);
        }, 1000);
    }, 3000);
}