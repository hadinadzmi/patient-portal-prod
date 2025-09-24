window.otp = {
    moveToNext: function (current, next) {
        if (current.value.length === current.maxLength) {
            next.focus();
        }
    },
    handleBackspace: function (current, previous) {
        if (current.value.length === 0 && previous) {
            previous.focus();
        }
    },
    clearAll: function (inputs) {
        inputs.forEach(input => input.value = '');
        inputs[0].focus();
    },
    getValue: function (element) {
        return element.value;
    },
    allowOnlyNumbers: function (event) {
        const charCode = event.which ? event.which : event.keyCode;
        if (charCode < 48 || charCode > 57) {
            event.preventDefault();
        }
    }
};
