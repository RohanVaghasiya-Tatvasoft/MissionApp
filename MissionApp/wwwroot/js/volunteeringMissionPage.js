﻿function LoginFirst() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'You are not Logged-in!!! Login First...',
    })
}

function AddToFavourite(missionId) {
    console.log(missionId)
    $.ajax({
        url: "/Customer/Mission/AddToFavourite",
        method: "POST",
        data: { 'missionId': missionId },
        success: function (data) {
            location.reload();
            //var newm = $($.parseHTML(data)).find("#favouriteBtn").html();
            //$("#favouriteBtn").html(newm);
            //console.log(data);
            //var s = $($.parseHTML(data)).find("#nav-comments").html();
            //$("#nav-comments").html(s);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

//----------------------------------------------------------------------------------------//

function AddComment(missionId) {
    var comment_area = $("#comment_area").val();

    $.ajax({
        url: "/Customer/Mission/AddComment",
        method: "POST",
        dataType: "html",
        data: { 'missionId': missionId, "comment_area": comment_area },
        success: function (data) {
            var newm = $($.parseHTML(data)).find("#commentForLoad").html();
            $("#commentForLoad").html(newm);
            $('#comment_area').val('');
        },
        error: function (error) {
            console.log(error);
        }
    });
}

//----------------------------------------------------------------------------------------//

function Alert(text) {
    Swal.fre({
        icon: 'eror',
        text: text,
        timer: 1500
    })
}

function sendMail(missionId) {

    var recUsersList = [];
    $('.modal-body input[type="checkbox"]:checked').each(function () {
        recUsersList.push($(this).attr("id"));
    });

    $('#divLoader').removeClass('d-none');
    $('#modal-content').addClass('d-none');
    console.log(recUsersList);
    if (recUsersList.length > 0) {
        $.ajax({
            type: 'POST',
            url: '/Customer/Mission/RecommandToCoworkers',
            data: { "missionId": missionId, "userIds": recUsersList },
            success: function () {
                $("#divLoader").addClass("d-none");
                $('#modal-content').removeClass('d-none');
                Swal.fire({
                    title: 'Success!',
                    html: 'Story sent succesfully.',
                    timer: 2000,
                    didOpen: () => {
                        Swal.showLoading()
                        const b = Swal.getHtmlContainer().querySelector('b')
                        timerInterval = setInterval(() => {
                            b.textContent = Swal.getTimerLeft()
                        }, 100)
                    },
                    willClose: () => {
                        clearInterval(timerInterval)
                    }
                })
            },
            error: function () {
                $("#divLoader").addClass("d-none");
                console.log('error');
            },
        });
    }
    else {
        $("#divLoader").addClass("d-none");
        $('#modal-content').removeClass('d-none');
        alterForMail(0);
        $('#divLoader').addClass('d-none');
        $('#modal-content').removeClass('d-none');
        Swal.fire({
            title: 'Alert',
            html: 'Select at least one user!',
            timer: 3000,
            didOpen: () => {
                Swal.showLoading()
                const b = Swal.getHtmlContainer().querySelector('b')
                timerInterval = setInterval(() => {
                    b.textContent = Swal.getTimerLeft()
                }, 100)
            },
            willClose: () => {
                clearInterval(timerInterval)
            }
        })
    }
}

//----------------------------------------------------------------------------------------//

function changeRating(starNum, missionId) {
    var star = document.getElementById('span-' + starNum);
    console.log(star);

    var isStarSelected = star.getAttribute('src').endsWith("star-fill.png");
    var rating = 1;
    for (var i = 1; i <= 5; i++) {
        if (i <= starNum) {
            $("#span-" + i).attr("src", "/images/star-fill.png");
            rating = i;
        } else {
            $("#span-" + i).attr("src", "/images/star-empty.png");
        }
    }

    $.ajax({
        url: "/Customer/Mission/UpdateAndAddRate",
        type: "POST",
        data: {
            'missionId': missionId, 'rating': rating
        },
        success: function (data) {
            var newm = $($.parseHTML(data)).find("#avg-rating-part").html();
            $("#avg-rating-part").html(newm);
            console.log(rating);
            console.log("rating is updated succesfully");
        }
    });
}

//----------------------------------------------------------------------------------------//

function ApplyMission(missionId) {
    $.ajax({
        type: 'POST',
        url: '/Customer/Mission/ApplyMission',
        data: { "missionId": missionId },
        success: function (data) {
            var newm = $($.parseHTML(data)).find("#apply").html();
            $("#apply").html(newm);
            /*Swal.fire({
                title: 'Succes',
                text: 'You have succesfully applied for mission',
            })*/
        },
        error: function () {
            console.log('error');
        },
    });
}

//----------------------------------------------------------------------------------------//

function pendingRating(x) {
    if (x == 0) {
        Swal.fire({
            icon: 'error',
            title: 'Pending',
            text: 'You are approval request is being pending!!!'
        })
    }
    else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'You have not applied for this mission yet!!!'
        })
    }
}

//----------------------------------------------------------------------------------------//

function loadVolunteers(pg, mid) {
    $.ajax({
        type: 'GET',
        url: '/Customer/Mission/volunteerPage',
        data: { "pg": pg, 'id': mid },
        success: function (data) {
            $('#changeVolunteer').html("");
            $('#changeVolunteer').html(data);
        },
        error: function () {
            console.log('error');
        },
    });
}