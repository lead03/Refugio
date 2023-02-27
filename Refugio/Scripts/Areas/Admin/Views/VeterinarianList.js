$(document).ready(function () {
    $('.btn-search').click(loadPage);
});

function loadPage() {
    //alert($(this).data('page-index'));
    var pageSelected = parseInt($(this).data('page-index'));
    $('#hdn-pager-index').val(1);
    $('#form-veterinarian-list').submit();
}