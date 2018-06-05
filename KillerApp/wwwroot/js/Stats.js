var loadStats = function (element, target, current, max) {
    alert(width);
    var elem = document.getElementById(target);
    var width = current / max * 100;
    elem.style.width = width + '%';
};
    