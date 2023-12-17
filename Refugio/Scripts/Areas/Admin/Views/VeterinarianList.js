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
    $('#custom-modal .custom-modal-title-icon').addClass(modalDeleteConfiguration.modalIcon);
    $('#custom-modal .custom-modal-title').html(modalDeleteConfiguration.modalDeleteTitle);
    $('#custom-modal .custom-modal-body p:eq(0)').html(modalDeleteConfiguration.modalDeleteBodyAnswer);
    $('#custom-modal .custom-modal-body p:eq(1)').html(modalDeleteConfiguration.modalNameSection + ': '+ completeName + '<br />' +
        modalDeleteConfiguration.modalSpecialitySection + ': ' + speciality + '<br />' +
        modalDeleteConfiguration.modalLicenceSection + ': ' + professionalLicense);
    $('#custom-modal .button-primary-text').html(modalDeleteConfiguration.modalPrimaryButtonText);
    $('#custom-modal .button-secondary-text').html(modalDeleteConfiguration.modalSecondaryButtonText);

    if (modalDeleteConfiguration.modalType == 'danger') {
        $('#custom-modal .button-primary').removeClass('success');
        $('#custom-modal .button-primary').removeClass('warning');
        $('#custom-modal .button-primary').removeClass('info');
        $('#custom-modal .button-primary').addClass('danger');
        $('#custom-modal .custom-modal-header').removeClass('success');
        $('#custom-modal .custom-modal-header').removeClass('warning');
        $('#custom-modal .custom-modal-header').removeClass('info');
        $('#custom-modal .custom-modal-header').addClass('danger');
        $('#custom-modal .custom-modal-content').removeClass('success');
        $('#custom-modal .custom-modal-content').removeClass('warning');
        $('#custom-modal .custom-modal-content').removeClass('info');
        $('#custom-modal .custom-modal-content').addClass('danger');
    }
    else if (modalDeleteConfiguration.modalType == 'success') {
        $('#custom-modal .button-primary').removeClass('danger');
        $('#custom-modal .button-primary').removeClass('warning');
        $('#custom-modal .button-primary').removeClass('info');
        $('#custom-modal .button-primary').addClass('success');
        $('#custom-modal .custom-modal-header').removeClass('danger');
        $('#custom-modal .custom-modal-header').removeClass('warning');
        $('#custom-modal .custom-modal-header').removeClass('info');
        $('#custom-modal .custom-modal-header').addClass('success');
        $('#custom-modal .custom-modal-content').removeClass('danger');
        $('#custom-modal .custom-modal-content').removeClass('warning');
        $('#custom-modal .custom-modal-content').removeClass('info');
        $('#custom-modal .custom-modal-content').addClass('success');
    }
    else if (modalDeleteConfiguration.modalType == 'warning') {
        $('#custom-modal .button-primary').removeClass('danger');
        $('#custom-modal .button-primary').removeClass('success');
        $('#custom-modal .button-primary').removeClass('info');
        $('#custom-modal .button-primary').addClass('warning');
        $('#custom-modal .custom-modal-header').removeClass('danger');
        $('#custom-modal .custom-modal-header').removeClass('success');
        $('#custom-modal .custom-modal-header').removeClass('info');
        $('#custom-modal .custom-modal-header').addClass('warning');
        $('#custom-modal .custom-modal-content').removeClass('danger');
        $('#custom-modal .custom-modal-content').removeClass('success');
        $('#custom-modal .custom-modal-content').removeClass('info');
        $('#custom-modal .custom-modal-content').addClass('warning');
    }
    else if (modalDeleteConfiguration.modalType == 'info') {
        $('#custom-modal .button-primary').removeClass('danger');
        $('#custom-modal .button-primary').removeClass('success');
        $('#custom-modal .button-primary').removeClass('warning');
        $('#custom-modal .button-primary').addClass('info');
        $('#custom-modal .custom-modal-header').removeClass('danger');
        $('#custom-modal .custom-modal-header').removeClass('success');
        $('#custom-modal .custom-modal-header').removeClass('warning');
        $('#custom-modal .custom-modal-header').addClass('info');
        $('#custom-modal .custom-modal-content').removeClass('danger');
        $('#custom-modal .custom-modal-content').removeClass('success');
        $('#custom-modal .custom-modal-content').removeClass('warning');
        $('#custom-modal .custom-modal-content').addClass('info');
    }
    // Actualiza el enlace de eliminación dentro del modal
    $('#custom-modal .button-primary').attr('href', modalDeleteConfiguration.modalUrlAction + veterinarianId);

    // Muestra el modal
    $('#custom-modal').modal('show');
}