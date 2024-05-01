$("#success-message").hide();
function GetUsers() {
    $.ajax({
        url: "/User/GetUsersViewModel",
        method: "GET",
        success: function (result) {
            $("#user-list").html(result);
        },
        error: function (error, xhr) {

        }
    })
}

function AddUser() {
    $.ajax({
        url: "/User/CreateUser",
        method: "GET",
        success: function (result) {
            console.log(result);
            $("#add-user").html(result);
        },
        error: function (error, xhr) {

        }
    })
}

function SaveUser() {
    debugger;
    var name = $("#UserName").val();
    var paidMoney = $("#PaidMoney").val();
    var isActive = $("#IsActive").val();

    var dataObj = { UserName: name, PaidMoney: paidMoney, IsActive: isActive };

    $.ajax({
        url: "/User/SaveUser",
        method: "POST",
        data: dataObj,
        success: function (result) {
            console.log(result);
            if (result.isSuccess) {
                //$("#success-message").append("<p>Kayıt başarıyla oluşturuldu. Kayıt No : " + result.record.id + "</p>");
                //$("#success-message").show();

                //$("#add-user").html("");

                /*GetUsers();*/
                window.location.href = "http://localhost:5245/User/Index";
            }
        },
        error: function (error, xhr) {

        }
    })
}