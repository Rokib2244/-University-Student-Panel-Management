$(function () {

    $("#departmentDropDownList").change(function () {
        $("#teacherDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        var jasonData = { deptId: departmentId };

        $.ajax({

            type: "POST",
            url: '/Course/GetTeachersByDepartmentId',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#teacherDropDownList").append('<option value=0>--Select a teacher--</option>');
                $.each(data, function (key, value) {

                    $("#teacherDropDownList").append('<option value=' + value.ID + '>' + value.Name + '</option>');

                });
            },

        });


        $("#courseCodeDropDownList").empty();
        var jasonData = { deptId: departmentId };

        $.ajax({

            type: "POST",
            url: '/Course/GetCoursesByDepartmentId',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function (data) {
                $("#courseCodeDropDownList").append('<option value=0>--Select a Course--</option>');
                $.each(data, function (key, value) {

                    $("#courseCodeDropDownList").append('<option value=' + value.ID + '>' + value.Code + '</option>');

                });
            },

        });
        ResetValue();
        return false;
    });

    $("#teacherDropDownList").change(function () {
        $("#creditTextBox").val("");
        $("#remainingCreditTextBox").val("");
        var teacherSelected = $("#teacherDropDownList").val();
        var jsonData = { TeacherId: teacherSelected };
        $.ajax({
            type: "POST",
            url: '/Course/GetTeacherById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            dataType: "json",
            success: function (data) {



                $("#creditTextBox").val(data[0].TotalCredit);
                $("#remainingCreditTextBox").val(data[0].RemainingCredit);

            },

        });

        if (teacherSelected == 0) {
            $("#creditTextBox").val("");
            $("#remainingCreditTextBox").val("");
        }
        return false;
    });

    $("#courseCodeDropDownList").change(function () {

        $("#nameTextBox").val("");
        $("#courseCreditTextBox").val("");
        var courseSelected = $("#courseCodeDropDownList").val();
        var jsonData = { courseId: courseSelected };
        $.ajax({
            type: "POST",
            url: '/Course/GetCourseById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            dataType: "json",
            success: function (data) {



                $("#nameTextBox").val(data[0].Name);
                $("#courseCreditTextBox").val(data[0].Credit);
            },
        });
        if (courseSelected == 0) {
            $("#courseName").val("");
            $("#courseCredit").val("");
        }
        return false;
    });



    return false;
});

function ResetValue() {
    $("#creditTextBox").val("");
    $("#remainingCreditTextBox").val("");
    $("#courseCodeDropDownList").empty();
    $("#teacherDropDownList").empty();
    $("#nameTextBox").val("");
    $("#courseCreditTextBox").val("");
    
}

