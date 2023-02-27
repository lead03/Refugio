$(document).ready(function () {
    $('.pager-index').click(loadPage);
});

function loadPage() {
    //alert($(this).data('page-index'));
    var pageSelected = parseInt($(this).data('page-index'));
    $('#hdn-pager-index').val(pageSelected);
    $('#form-veterinarian-list').submit();
}