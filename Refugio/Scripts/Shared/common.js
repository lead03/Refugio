var currentLanguage = getCookie('Language');

if (currentLanguage === languages.SpanishKey) {
    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?\d+(,\d+)?$/.test(value);
    };
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    };
} else if (currentLanguage === languages.EnglishKey) {
    $.validator.methods.number = function (value, element) {
        return this.optional(element) || !isNaN(parseFloat(value)) && isFinite(value);
    };
    $.validator.methods.range = function (value, element, param) {
        return this.optional(element) || (value >= param[0] && value <= param[1]);
    };
}

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
    return null;
}