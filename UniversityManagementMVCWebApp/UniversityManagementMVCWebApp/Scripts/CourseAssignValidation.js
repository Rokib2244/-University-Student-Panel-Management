//$(document).ready(function() {
//    $("#submitForm").validate({
//        rules: {
//            DepartmentID: {
//                min:1
//            },
//            TeacherID: {
//                min:1
//            },
//            CourseID: {
//                min:1
//            }
//        },
//        messages: {
//            DepartmentID: {
//                min: "Select a Department"
//            },
//            TeacherID: {
//                min: "Select a Teacher"
//            },
//            CourseID: {
//                min: "Select a Course"
//            }
//        }
//    });
//});
$(document).ready(function() {
    $("body").on("click", ".assign-btn",function() {
        var remainingCredit = parseFloat($("#remainingCreditTextBox").val(),10);
        var courseCredit = parseFloat($("#courseCreditTextBox").val(),10);
        if (remainingCredit - courseCredit < 0) {
            var form = '<div class="form-container"><div class="post-form"><h4 class="confirm-message">' + 'Do you want to assign the course?' + '</h4>' +
                '<div class="form-group">' +
                '<div class="row"><div class="col-sm-offset-2 col-sm-10 btn-container">' +
                '<input type="submit" class="btn btn-info col-sm-5 yes-btn" value="Yes"><button type="button" class="btn btn-danger col-sm-5 no-btn">No</button></div></div></form></div>';
            $("body").append(form);
            $("body").on("click", ".yes-btn", function(event) {
                event.preventDefault();
                $("#submitForm").submit();
            });
            $("body").on("click", ".no-btn", function(event) {
                event.preventDefault();
                $(".form-container").remove();
            });
            return false;
        } else {
            $("#submitForm").submit();
        }
    });
});