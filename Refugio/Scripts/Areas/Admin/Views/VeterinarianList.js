$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $('.pager-index').click(loadPage);
    $('.filter').change(setFilterIsModified);
    $('#btn-reset-filters').click(cleanFilters);
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

function cleanFilters() {
    $('.filter').each(function () {
        $(this).val("");
    });
    $('#form-veterinarian-list').submit();
}