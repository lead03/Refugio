$(document).ready(function () {
    $(document).on('click', '.delete', showDeleteVeterinarianSpecialityModal);
});

function submitForm() {
    submitGenericForm("/Speciality/SpecialityList", "#form-speciality-list", "#speciality-list-container");
}

function showDeleteVeterinarianSpecialityModal() {
    var specialityName = $(this).data('speciality');
    var specialityId = $(this).data('id');
    resetModalConfiguration();
    modalConfiguration.bodyContent = deleteVeterinarianSpecialityModalCustomData.BodyContentNameSection + ': ' + specialityName;
    modalConfiguration.bodyTitle = deleteVeterinarianSpecialityModalCustomData.BodyTitle;
    modalConfiguration.footerPrimaryButtonText = deleteVeterinarianSpecialityModalCustomData.PrimaryButtonText;
    modalConfiguration.footerPrimaryButtonUrlAction = deleteVeterinarianSpecialityModalCustomData.PrimaryButtonUrlAction + specialityId;
    modalConfiguration.footerSecondaryButtonText = deleteVeterinarianSpecialityModalCustomData.SecondaryButtonText;
    modalConfiguration.headerIcon = deleteModalIcon;
    modalConfiguration.headerTitle = deleteVeterinarianSpecialityModalCustomData.HeaderTitle;
    modalConfiguration.size = deleteModalSize;
    modalConfiguration.type = deleteModalType;
    setDataConfiguration();
    $('#custom-modal').modal('show');
}
