$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $(document).on('click', '.pager-index', loadPage);
    $('#btn-reset-filters').click(cleanFilters);
/*    $(document).on('click', '.delete', deleteFromList);*/
    submitForm();
});

function loadFilters() {
    event.preventDefault();
    $('#hdn-pager-index').val(1);
    submitForm();
}

function loadPage() {
    event.preventDefault();
    var targetPage = parseInt($(this).data('page-index'));
    $('#hdn-pager-index').val(targetPage);
    submitForm();
}

function cleanFilters() {
    event.preventDefault();
    $('#form-speciality-list').trigger("reset");
    $('#hdn-pager-index').val(1);
    submitForm();
}

function submitForm() {
    $.ajax({
        url: "/Speciality/SpecialityList",
        data: $("#form-speciality-list").serialize(),
        success: function (result) {
            $("#speciality-list-container").html(result);
        },
        error: function (xhr, status, error) {
            alert(xhr + "status: " + status);
        }
    });
}
