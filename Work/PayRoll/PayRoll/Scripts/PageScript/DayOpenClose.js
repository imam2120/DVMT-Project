

$(document).ready(function () {
    LoadDayOpenCloseDate();
    LoadDayStatus();
});


function FormDataAsObject() {
    var object = new Object();
    object.TransDate = $('#txtDateToOpenClose').val();
    object.OpenCloseByUser = "Admin";
    object.Action = $('#txtActionId').val();

    return object;
}


function EnableDisableControls(status) {
    if (status == "1") {
        $('#btnSave').prop('disabled', false);
        $('#btnUpdate').prop('disabled', true);
        $('#btnDelete').prop('disabled', true);
    }
    else if (status == "2") {
        $('#btnSave').prop('disabled', true);
        $('#btnUpdate').prop('disabled', false);
        $('#btnDelete').prop('disabled', false);
    }

    else {
        $('#btnSave').prop('disabled', false);
        $('#btnUpdate').prop('disabled', false);
        $('#btnDelete').prop('disabled', false);
    }
}

function LoadDayOpenCloseDate() {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/DayOpenClose/GetOpenCloseDate",
        data: {},
        async: false,
        dataType: "json",
        success: function (data) {
            $("#txtDateToOpenClose").val(data);
        }
    });   
}

function LoadDayStatus() {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/DayOpenClose/GetDayStatus",
        data: {},
        async: false,
        dataType: "json",
        success: function (data) {
            $("#txtActionId").val(data);
        }
    });
}

function Save() {
    var object = FormDataAsObject();
    debugger;

    if (DayOpenCloseValidation(object)) {

        $.ajax({
            url: '@Url.Action("CreateOrUpdate", "DayOpenClose")',
            method: 'post',
            dataType: 'json',
            async: false,
            data: {

                TransDate: object.TransDate,
                OpenCloseByUser: object.OpenCloseByUser,
                Action: object.Action,                

            },
            success: function (data) {
                var vmMsg = data;
                if (vmMsg.MessageType == 1) {
                    ShowNotification(1, vmMsg.ReturnMessage);
                    LoadDayOpenCloseDate();
                    LoadDayStatus();

                } else {
                    ShowNotification(3, vmMsg.ReturnMessage);
                }
            },
            error: function () {
            }
        });
    }
}

function DayOpenCloseValidation(formObject) {

    if (!formObject.TransDate) {
        $('#txtDateToOpenClose').focus();
        ShowNotification('2', 'Date for Open/Close Can not be empty.');
        return false;
    }


    return true;
}

