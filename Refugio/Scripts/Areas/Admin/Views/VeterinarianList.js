$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $('.pager-index').click(loadPage);
});

function loadFilters() {
    //event.preventDefault();
    $('#hdn-pager-index').val(1);
    $('#form-veterinarian-list').submit();
}

function loadPage() {
    var pageSelected = parseInt($(this).data('page-index'));
    $('#hdn-pager-index').val(pageSelected);
    $('#form-veterinarian-list').submit();
}

//function avoidSubmit(event) {
//    if (event.which == 13) {
//        event.preventDefault();
//    }
//}