$(document).ready(function () {
    $(document).on('click', '.delete', showDeleteModal);
});

function submitForm() {
    submitGenericForm("/Veterinarian/VeterinarianList", "#form-veterinarian-list", "#veterinarian-list-container");
}

function showDeleteModal() {
    var completeName = $(this).data('complete-name');
    var speciality = $(this).data('speciality');
    var professionalLicense = $(this).data('professional-licence');
    var veterinarianId = $(this).data('id');
    resetModalConfiguration();
    modalConfiguration.bodyContent = deleteModalCustomData.modalNameSection + ': ' + completeName + '<br />' + deleteModalCustomData.modalSpecialitySection + ': ' + speciality + '<br />' + deleteModalCustomData.modalLicenceSection + ': ' + professionalLicense;
    modalConfiguration.bodyTitle = deleteModalBodyTitle;
    modalConfiguration.footerPrimaryButtonText = deleteModalPrimaryButtonText;
    modalConfiguration.footerPrimaryButtonUrlAction = deleteModalCustomData.deleteUrl + veterinarianId;
    modalConfiguration.footerSecondaryButtonText = deleteModalSecondaryButtonText;
    modalConfiguration.headerIcon = deleteModalIcon;
    modalConfiguration.headerTitle = deleteModalHeaderTitle;
    modalConfiguration.size = deleteModalSize;
    modalConfiguration.type = deleteModalType;
    setDataConfiguration();
    $('#custom-modal').modal('show');
}