$(document).ready(function () {
    $('#btn-search').click(loadFilters);
    $(document).on('click', '.pager-index', loadPage);
    $('#btn-reset-filters').click(cleanFilters);
    $('.filter').change(setFilterIsModified);
    $(document).on('click', '.delete', deleteFromList);
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
    // Obtén los datos de la fila actual
    var completeName = $(this).data('complete-name');
    var speciality = $(this).data('speciality');
    var professionalLicense = $(this).data('professional-licence');
    var veterinarianId = $(this).data('id');
    // Actualiza el contenido del modal
    $('#generic-admin-modal .modal-title').html(modalDeleteConfiguration.modalDeleteTitle);
    $('#generic-admin-modal .modal-body p:eq(0)').html(modalDeleteConfiguration.modalDeleteBodyAnswer);
    $('#generic-admin-modal .modal-body p:eq(1)').html(modalDeleteConfiguration.modalNameSection + ': '+ completeName + '<br />' +
        modalDeleteConfiguration.modalSpecialitySection + ': ' + speciality + '<br />' +
        modalDeleteConfiguration.modalLicenceSection + ': ' + professionalLicense);

    // Actualiza el enlace de eliminación dentro del modal
    $('#generic-admin-modal .modal-footer a').attr('href', modalDeleteConfiguration.modalUrlAction + veterinarianId);

    // Muestra el modal
    $('#generic-admin-modal').modal('show');
}