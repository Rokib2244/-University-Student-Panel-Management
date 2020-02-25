$('#fromTimeTextBox,#toTimeTextBox').timepicker({
    timeFormat: 'h:mm',
    interval: 30,
    minTime: '1',
    maxTime: '12:00',
    defaultTime: '10',
    startTime: '12:00',
    dynamic: true,
    dropdown: true,
    scrollbar: true
});