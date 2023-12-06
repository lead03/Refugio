$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $(document).on('click', '.pager-index', loadPage);
    $('#btn-reset-filters').click(cleanFilters);
    $('.filter').change(setFilterIsModified);
    $('.icon-button.delete').on('click', function (e) {
        deleteFromList()
    });
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

function setFilterIsModified() {
    $('#hdn-filter-modified-indicator').val(true);
}

function cleanFilters() {
    event.preventDefault();
    $('#form-veterinarian-list').trigger("reset");
    $('#hdn-pager-index').val(1);
    $('#hdn-filter-modified-indicator').val(true);
    submitForm();
}

function submitForm() {
    $.ajax({
        url: "/Veterinarian/VeterinarianList",
        data: $("#form-veterinarian-list").serialize(),
        success: function (result) {
            $("#veterinarian-list-container").html(result);
        },
        error: function (xhr, status, error) {
            alert(xhr + "status: " + status);
        }
    });
}

function deleteFromList() {
    e.preventDefault();

    // Obtén los datos de la fila actual
    var firstName = $(this).closest('tr').find('td:eq(0)').text();
    var lastName = $(this).closest('tr').find('td:eq(1)').text();
    var speciality = $(this).closest('tr').find('td:eq(2)').text();
    var professionalLicense = $(this).closest('tr').find('td:eq(3)').text();

    // Actualiza el contenido del modal
    $('#modal-delete .modal-title').html('@Refugio.Resources.Languages.Global.Delete @Refugio.Resources.Languages.Global.Veterinarian.ToLower()');
    $('#modal-delete .modal-body p:eq(0)').html('@Refugio.Resources.Languages.Global.SureDelete @Refugio.Resources.Languages.Global.Veterinarian.ToLower()?');
    $('#modal-delete .modal-body p:eq(1)').html('@Refugio.Resources.Languages.Global.Name: ' + lastName + ', ' + firstName + '<br />' +
        '@Refugio.Resources.Languages.Global.Speciality: ' + speciality + '<br />' +
        '@Refugio.Resources.Languages.Global.ProfessionalLicense: ' + professionalLicense);

    // Actualiza el enlace de eliminación dentro del modal
    $('#modal-delete .modal-footer a').attr('href', $(this).attr('href'));

    // Muestra el modal
    $('#modal-delete').modal('show');
}