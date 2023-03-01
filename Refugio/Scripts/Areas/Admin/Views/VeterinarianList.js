$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $('.pager-index').click(loadPage);
    $('.filter').change(setFilterIsModified);
});

function loadFilters() {
    $('#hdn-pager-index').val(1);
    $('#form-veterinarian-list').submit();
}

function loadPage() {
    var pageSelected = parseInt($(this).data('page-index'));
    $('#hdn-pager-index').val(pageSelected);
    $('#form-veterinarian-list').submit();
}

function setFilterIsModified() {
    $('#hdn-filter-modified-indicator').val(true);
}