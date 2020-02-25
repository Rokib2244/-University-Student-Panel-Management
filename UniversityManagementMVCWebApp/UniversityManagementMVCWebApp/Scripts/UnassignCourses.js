$(document).ready(function () {
    if (window.location.pathname === "/Course/Unassign") {
        var headerMessage = "Are you sure to unassign all courses?";
    } else {
        var headerMessage = "Are you sure to unallocate all classrooms info?";
    }
    $(".unassign-btn").on("click", function () {
        var form = '<div class="form-container"><form class="form-horizontal post-form" method="POST"><h4 class="confirm-message">'+headerMessage+'</h4>' +
                    '<div class="form-group">' +
                    '<div class="row"><div class="col-sm-offset-2 col-sm-10 btn-container">' +
                    '<button type="submit" class="btn btn-info col-sm-5 yes-btn">Yes</button><button type="button" class="btn btn-danger col-sm-5 no-btn">No</button></div></div></form></div>';
        //var fomrContainer='<div class="form-container"></div>';
        //<div class="col-sm-offset-2 col-sm-5">
        //<a href="'+href+'" class="btn btn-danger col-sm-5 no-btn">No</a>
        $(".form-div").append(form);
    });
    $("body").on('click', '.no-btn', function (event) {
        event.preventDefault();
        $(".form-container").remove();
    });
});