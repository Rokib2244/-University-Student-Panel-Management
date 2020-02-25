$(function() {

    $("#departmentDropDownList").change(function() {
        $("#courseDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        var jasonData = { id: departmentId };

        $.ajax({
            type: "POST",
            url: '/ClassRoom/GetCourses',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function(data) {
                $("#courseDropDownList").append('<option value=0>--Select a Course--</option>');
                $.each(data, function(key, value) {

                    $("#courseDropDownList").append('<option value=' + value.ID + '>' + value.Code + '</option>');

                });
            },

        });


        $("#roomDropDownList").empty();
        var jasonData = { id: departmentId };

        $.ajax({
            type: "POST",
            url: '/ClassRoom/GetRooms',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function(data) {
                $("#roomDropDownList").append('<option value=0>--Select a Class Room--</option>');
                $.each(data, function(key, value) {

                    $("#roomDropDownList").append('<option value=' + value.ID + '>' + value.Name + '</option>');

                });
            },

        });
    });
});