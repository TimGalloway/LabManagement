$(document).ready(function () {
    $('#SendInvToSame').change(function () {
        if (this.checked) {
            $('#InvoiceName').val($('#Name').val());
            $('#InvoiceCompany').val($('#Company').val());
            $('#InvoiceMailingAddress').val($('#MailingAddress').val());
            $('#InvoiceEmailAddress').val($('#EmailAddress').val());
            $('#InvoicePhoneNumber').val($('#PhoneNumber').val());
            $('#InvoiceFaxNumber').val($('#FaxNumber').val());

            //$('#InvoiceName').prop('disabled', true);
            //$('#InvoiceCompany').prop('disabled', true);
            //$('#InvoiceMailingAddress').prop('disabled', true);
            //$('#InvoiceEmailAddress').prop('disabled', true);
            //$('#InvoicePhoneNumber').prop('disabled', true);
            //$('#InvoiceFaxNumber').prop('disabled', true);
        }
        else{
            $('#InvoiceName').val('');
            $('#InvoiceCompany').val('');
            $('#InvoiceMailingAddress').val('');
            $('#InvoiceEmailAddress').val('');
            $('#InvoicePhoneNumber').val('');
            $('#InvoiceFaxNumber').val('');

            //$('#InvoiceName').prop('disabled', false);
            //$('#InvoiceCompany').prop('disabled', false);
            //$('#InvoiceMailingAddress').prop('disabled', false);
            //$('#InvoiceEmailAddress').prop('disabled', false);
            //$('#InvoicePhoneNumber').prop('disabled', false);
            //$('#InvoiceFaxNumber').prop('disabled', false);
        }
    });
});