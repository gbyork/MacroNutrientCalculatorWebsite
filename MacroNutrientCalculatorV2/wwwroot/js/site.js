$(document).ready(function () {
    $('#calculateBtn').click(function () {
        var isValid = true;
        $('input[type="text"]').each(function () {
            if ($.trim($(this).val()) === '') {
                isValid = false;
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        if (!isValid) {
            $('#result').text('Please fill out all fields.');
            return;
        }

        var input = {
            gender: $('#gender').val(),
            age: parseInt($('#age').val()),
            bodyWeight: parseFloat($('#bodyWeight').val()),
            heightFeetTall: parseInt($('#heightFeetTall').val()),
            heightInchesTall: parseInt($('#heightInchesTall').val()),
            activityFrequency: $('#activityFrequency').val(),
            carbPercentage: parseInt($('#carbPercentage').val()),
            fatPercentage: parseInt($('#fatPercentage').val()),
            proteinPercentage: parseInt($('#proteinPercentage').val())
        };

        $.ajax({
            url: '/api/MacroNutrient/Calculate',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(input),
            success: function (response) {
                $('#result').text(response);
            },
            error: function (xhr, status, error) {
                $('#result').text('Error: ' + xhr.responseText);
            }
        });
    });
});
