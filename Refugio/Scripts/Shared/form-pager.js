$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $(document).on('click', '.pager-index', loadPage);
    $('#btn-reset-filters').click(function (event) {
        cleanFilters(event, this);
    });
    submitForm();
});

function loadFilters(event) {
    event.preventDefault();
    $('#hdn-pager-index').val(1);
    submitForm();
}

function loadPage(event) {
    event.preventDefault();
    var targetPage = parseInt($(this).data('page-index'));
    $('#hdn-pager-index').val(targetPage);
    submitForm();
}

function cleanFilters(event, button) {
    event.preventDefault();
    var form = $(button).closest('form');
    form.trigger("reset");
    form.find('#hdn-pager-index').val(1);
    submitForm();
}

function submitGenericForm(url, formDataSelector, resultContainerSelector) {
    var formData = $(formDataSelector).serialize();
    $.ajax({
        url: url,
        data: formData,
        success: function (result) {
            $(resultContainerSelector).html(result);
        },
        error: function (xhr, status, error) {
            alert(xhr + "status: " + status);
        }
    });
}
