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
    $('#generic-admin-modal .custom-modal-title-icon').addClass('fa fa-exclamation-triangle');
    $('#generic-admin-modal .custom-modal-title').html(modalDeleteConfiguration.modalDeleteTitle);
    $('#generic-admin-modal .custom-modal-body p:eq(0)').html(modalDeleteConfiguration.modalDeleteBodyAnswer);
    $('#generic-admin-modal .custom-modal-body p:eq(1)').html(modalDeleteConfiguration.modalNameSection + ': '+ completeName + '<br />' +
        modalDeleteConfiguration.modalSpecialitySection + ': ' + speciality + '<br />' +
        modalDeleteConfiguration.modalLicenceSection + ': ' + professionalLicense);
    $('#generic-admin-modal .button-primary-text').html(modalDeleteConfiguration.modalPrimaryButtonText);
    $('#generic-admin-modal .button-secondary-text').html(modalDeleteConfiguration.modalSecondaryButtonText);

    if (modalDeleteConfiguration.modalType == 'danger') {
        $('#generic-admin-modal .button-primary').removeClass('success');
        $('#generic-admin-modal .button-primary').removeClass('warning');
        $('#generic-admin-modal .button-primary').removeClass('info');
        $('#generic-admin-modal .button-primary').addClass('danger');
        $('#generic-admin-modal .custom-modal-header').removeClass('success');
        $('#generic-admin-modal .custom-modal-header').removeClass('warning');
        $('#generic-admin-modal .custom-modal-header').removeClass('info');
        $('#generic-admin-modal .custom-modal-header').addClass('danger');
        $('#generic-admin-modal .custom-modal-content').removeClass('success');
        $('#generic-admin-modal .custom-modal-content').removeClass('warning');
        $('#generic-admin-modal .custom-modal-content').removeClass('info');
        $('#generic-admin-modal .custom-modal-content').addClass('danger');
    }
    else if (modalDeleteConfiguration.modalType == 'success') {
        $('#generic-admin-modal .button-primary').removeClass('danger');
        $('#generic-admin-modal .button-primary').removeClass('warning');
        $('#generic-admin-modal .button-primary').removeClass('info');
        $('#generic-admin-modal .button-primary').addClass('success');
        $('#generic-admin-modal .custom-modal-header').removeClass('danger');
        $('#generic-admin-modal .custom-modal-header').removeClass('warning');
        $('#generic-admin-modal .custom-modal-header').removeClass('info');
        $('#generic-admin-modal .custom-modal-header').addClass('success');
        $('#generic-admin-modal .custom-modal-content').removeClass('danger');
        $('#generic-admin-modal .custom-modal-content').removeClass('warning');
        $('#generic-admin-modal .custom-modal-content').removeClass('info');
        $('#generic-admin-modal .custom-modal-content').addClass('success');
    }
    else if (modalDeleteConfiguration.modalType == 'warning') {
        $('#generic-admin-modal .button-primary').removeClass('danger');
        $('#generic-admin-modal .button-primary').removeClass('success');
        $('#generic-admin-modal .button-primary').removeClass('info');
        $('#generic-admin-modal .button-primary').addClass('warning');
        $('#generic-admin-modal .custom-modal-header').removeClass('danger');
        $('#generic-admin-modal .custom-modal-header').removeClass('success');
        $('#generic-admin-modal .custom-modal-header').removeClass('info');
        $('#generic-admin-modal .custom-modal-header').addClass('warning');
        $('#generic-admin-modal .custom-modal-content').removeClass('danger');
        $('#generic-admin-modal .custom-modal-content').removeClass('success');
        $('#generic-admin-modal .custom-modal-content').removeClass('info');
        $('#generic-admin-modal .custom-modal-content').addClass('warning');
    }
    else if (modalDeleteConfiguration.modalType == 'info') {
        $('#generic-admin-modal .button-primary').removeClass('danger');
        $('#generic-admin-modal .button-primary').removeClass('success');
        $('#generic-admin-modal .button-primary').removeClass('warning');
        $('#generic-admin-modal .button-primary').addClass('info');
        $('#generic-admin-modal .custom-modal-header').removeClass('danger');
        $('#generic-admin-modal .custom-modal-header').removeClass('success');
        $('#generic-admin-modal .custom-modal-header').removeClass('warning');
        $('#generic-admin-modal .custom-modal-header').addClass('info');
        $('#generic-admin-modal .custom-modal-content').removeClass('danger');
        $('#generic-admin-modal .custom-modal-content').removeClass('success');
        $('#generic-admin-modal .custom-modal-content').removeClass('warning');
        $('#generic-admin-modal .custom-modal-content').addClass('info');
    }
    // Actualiza el enlace de eliminación dentro del modal
    $('#generic-admin-modal .button-primary').attr('href', modalDeleteConfiguration.modalUrlAction + veterinarianId);

    // Muestra el modal
    $('#generic-admin-modal').modal('show');
}