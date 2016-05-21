function AddDatePicker() {
    var $datePicker = $(".datepicker");

    if ($datePicker != null)
        $datePicker.datepicker({
            inline: true,
            changeMonth: true,
            changeYear: true
        });
}