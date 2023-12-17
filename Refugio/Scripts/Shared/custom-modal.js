var modalConfiguration = {
    headerIcon: '',
    headerTitle: '',
    bodyTitle: '',
    bodyContent: '',
    footerPrimaryButtonText: '',
    footerPrimaryButtonUrlAction: '',
    footerSecondaryButtonText: '',
    footerSecondaryButtonUrlAction: '',
    footerAdditionalButtonText: '',
    footerAdditionalButtonUrlAction: '',
    type: '',
}

function setDataConfiguration() {
    setTextConfiguration();
    configureButtonsVisibilityAndTexts();
    setModalTypeConfiguration();
}

function setModalTypeConfiguration() {
    var modalTypes = ['danger', 'success', 'warning', 'info']; //Keys declaradas en Resources/Common/ModalTypes. TODO: Mejorar esto
    switch (modalConfiguration.type) {
        case (modalTypes[0]):
            setDangerConfiguration();
            break;
        case (modalTypes[1]):
            setSuccessConfiguration();
            break;
        case (modalTypes[2]):
            setWarningConfiguration();
            break;
        case (modalTypes[3]):
            setInfoConfiguration();
            break;
        default:
            console.log('Error: Modal type not found');
    }
}

function setDangerConfiguration() {
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

function setSuccessConfiguration() {
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

function setWarningConfiguration() {
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

function setInfoConfiguration() {
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

function resetModalConfiguration() {
    modalConfiguration.headerIcon = '';
    modalConfiguration.headerTitle = '';
    modalConfiguration.bodyTitle = '';
    modalConfiguration.bodyContent = '';
    modalConfiguration.footerPrimaryButtonText = '';
    modalConfiguration.footerPrimaryButtonUrlAction = '';
    modalConfiguration.footerSecondaryButtonText = '';
    modalConfiguration.footerSecondaryButtonUrlAction = '';
    modalConfiguration.footerAdditionalButtonText = '';
    modalConfiguration.footerAdditionalButtonUrlAction = '';
    modalConfiguration.modalType = '';
}

function configureButtonsVisibilityAndTexts() {
    if (modalConfiguration.footerPrimaryButtonText.length > 0) {
        $('#custom-modal .button-primary').html(modalConfiguration.footerPrimaryButtonText);
        $('#custom-modal .button-primary').show();
        if (modalConfiguration.footerPrimaryButtonUrlAction.length > 0) {
            $('#custom-modal .button-primary').attr('href', modalConfiguration.footerPrimaryButtonUrlAction);
        }
        else {
            $('#custom-modal .button-primary').attr('href', '');
        }
    }
    else {
        $('#custom-modal .button-primary').hide();
    }
    if (modalConfiguration.footerSecondaryButtonText.length > 0) {
        $('#custom-modal .button-secondary').html(modalConfiguration.footerSecondaryButtonText);
        $('#custom-modal .button-secondary').show();
        if (modalConfiguration.footerSecondaryButtonUrlAction.length > 0) {
            $('#custom-modal .button-secondary').attr('href', modalConfiguration.footersecondaryButtonUrlAction);
        }
        else {
            $('#custom-modal .button-secondary').attr('href', '');
        }
    }
    else {
        $('#custom-modal .button-secondary').hide();
    }
    if (modalConfiguration.footerAdditionalButtonText.length > 0) {
        $('#custom-modal .button-additional').html(modalConfiguration.footerAdditionalButtonText);
        $('#custom-modal .button-additional').show();
        if (modalConfiguration.footeradditionalButtonUrlAction.length > 0) {
            $('#custom-modal .button-additional').attr('href', modalConfiguration.footeradditionalButtonUrlAction);
        }
        else {
            $('#custom-modal .button-additional').attr('href', '');
        }
    }
    else {
        $('#custom-modal .button-additional').hide();
    }
}

function setTextConfiguration() {
    $('#custom-modal .custom-modal-title-icon').addClass(modalConfiguration.headerIcon);
    $('#custom-modal .custom-modal-title').html(modalConfiguration.headerTitle);
    $('#custom-modal .custom-modal-body p:eq(0)').html(modalConfiguration.bodyTitle);
    $('#custom-modal .custom-modal-body p:eq(1)').html(modalConfiguration.bodyContent);
}