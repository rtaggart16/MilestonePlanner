
function copyMilestone(id) {

    function hideTooltip() {
        setTimeout(function () {
            $('#M' + id).tooltip('hide');
        }, 1000);
    }

    function setTooltip(message) {
        $('#M' + id).tooltip('hide')
            .attr('data-original-title', message)
            .tooltip('show');
    }

    var clipboard = new ClipboardJS('#M' + id);

    clipboard.on('success', function (e) {
        setTooltip('Copied!');
        hideTooltip();
    });

    clipboard.on('error', function (e) {
        setTooltip('Failed!');
        hideTooltip();
    });

    $('#M' + id).tooltip({
        trigger: 'click',
        placement: 'bottom'
    });
