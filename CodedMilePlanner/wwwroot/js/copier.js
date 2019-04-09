// Tooltip

$('.clipboardButton').tooltip({
    trigger: 'click',
    placement: 'bottom'
});

function setTooltip(message) {
    $('.clipboardButton').tooltip('hide')
        .attr('data-original-title', message)
        .tooltip('show');
}

function hideTooltip() {
    setTimeout(function () {
        $('.clipboardButton').tooltip('hide');
    }, 1000);
}

// Clipboard

var clipboard = new ClipboardJS('.clipboardButton');

clipboard.on('success', function (e) {
    setTooltip('Copied!');
    hideTooltip();
});

clipboard.on('error', function (e) {
    setTooltip('Failed!');
    hideTooltip();
});