$(document).ready(function () {
    $("#veterinarianSpecialityForm").validate({
        rules: {
            SpecialityNameES: {
                required: true,
                maxlength: 100
            },
            SpecialityNameEN: {
                required: true,
                maxlength: 100
            }
        },
        messages: {
            SpecialityNameES: {
                required: "Este campo es obligatorio.",
                maxlength: "No puede superar los 100 caracteres."
            },
            SpecialityNameEN: {
                required: "Este campo es obligatorio.",
                maxlength: "No puede superar los 100 caracteres."
            }
        }
    });
});