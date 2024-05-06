$(document).ready(function () {
    $(document).on('click', '.delete', deleteFromList);
});

function submitForm() {
    submitGenericForm("/Veterinarian/VeterinarianList", "#form-veterinarian-list", "#veterinarian-list-container");
}

function deleteFromList() {
    var completeName = $(this).data('complete-name');
    var speciality = $(this).data('speciality');
    var professionalLicense = $(this).data('professional-licence');
    var veterinarianId = $(this).data('id');
    modalConfiguration.bodyContent = customDataForModal.modalNameSection + ': ' + completeName + '<br />' + customDataForModal.modalSpecialitySection + ': ' + speciality + '<br />' + customDataForModal.modalLicenceSection + ': ' + professionalLicense;
    modalConfiguration.footerPrimaryButtonUrlAction = customDataForModal.deleteUrl + veterinarianId;
    setDataConfiguration();
    $('#custom-modal').modal('show');
}