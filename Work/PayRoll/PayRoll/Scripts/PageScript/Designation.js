

$(document).ready(function () {
    GridDataLoad();
});

function GridDataLoad() {
    $("#grid").kendoGrid().empty();
    var result = CallAjax_POST('GetDesignation/Designation', '', false, false)
    if (result.length > 0) {
        PopulateGridView(result);
    } else {
        alert("Error! Please Contact..");
    }
}


function PopulateGridView(result) {
    //debugger;
    $("#grid").kendoGrid({
        dataSource: result,
        pageable: true,
        filterable: true,
        pageSize: 20,
        pageable: true,
        pageable: {
            input: false,
            numeric: true,
            butonCount: 5,
            pageSize: 20,
            alwaysVisible: true,
            previousNext: true,
            serverPaging: true,
            serverFiltering: true,
        },
        //height: 550,
        // toolbar: ["create"],
        selectable: true,
        //toolbar: ["search"],//search commented on 20aug22
        search: {
            fields: [
                { name: "DesignationId", operator: "eq" },
                { name: "DesignationName", operator: "contains" },
            ]
        },
        columns: [

            { field: "DesignationId", title: "Designation Id", filterable: true, filterable: { multi: true, search: true }, width: "70px" },
            { field: "DesignationName", title: "Designation Name", filterable: true, filterable: { multi: true, search: true }, width: "80px" },
            { field: "CreatedBy", title: "Created By", filterable: true, filterable: { multi: true, search: true }, width: "80px" },
            { field: "CreatedDate", title: "Created Date", filterable: true, filterable: { multi: true, search: true }, width: "90px" },
            { field: "MakeBy", title: "Make By", filterable: true, filterable: { multi: true, search: true }, width: "120px" },
            { field: "MakeDate", title: "Make Date", filterable: true, filterable: { multi: true, search: true }, width: "120px" },

        ],

    });
}

function FormDataAsObject() {
    var object = new Object();
    object.DesignationName = $('#txtDesignationName').val();
    object.MakeBy = $('#txtMakeBy').val();

    return object;
}

function ResetForm() {
    $('#txtDesignationName').val('');
    $('#txtMakeBy').val('');

    EnableDisableControls("1");
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

function Save() {
    var object = FormDataAsObject();
    debugger;

    if (DesignationValidation(object)) {

        $.ajax({
            url: '@Url.Action("CreateOrUpdate", "Designation")',
            method: 'post',
            dataType: 'json',
            async: false,
            data: {
                DesignationName: object.DesignationName,
                MakeBy: object.MakeBy,

            },
            success: function (data) {
                var vmMsg = data;
                if (vmMsg.MessageType == 1) {
                    ShowNotification(1, vmMsg.ReturnMessage);
                    ResetForm();
                    GridDataLoad();

                } else {
                    ShowNotification(3, vmMsg.ReturnMessage);
                }
            },
            error: function () {
            }
        });
    }
}

// function Update() {
//    var formObject = FormDataAsObject();

//    if (EmployeeInfoValidation(formObject)) {

//        $.ajax({
//            url: '@Url.Action("Update", "UserInfo")',
//            method: 'post',
//            dataType: 'json',
//            async: false,
//            data: {
//                UserName: formObject.UserName,
//                UserFullName: formObject.UserFullName,
//                UserPassword: formObject.UserPassword,
//                UserRoleId: formObject.UserRoleId,
//                UserStatusId: formObject.UserStatus,
//            },
//            success: function (data) {
//                var vmMsg = data;
//                if (vmMsg.MessageType == 1) {
//                    ShowNotification(1, vmMsg.ReturnMessage);
//                    ResetForm();
//                    LoadUserInfoGrid();

//                } else {
//                    ShowNotification(3, vmMsg.ReturnMessage);

//                }
//            },
//            error: function () {

//            }
//        });

//    }

//} 

//        function Delete() {
//    var formObject = FormDataAsObject();

//    $.ajax({
//        url: '@Url.Action("Delete", "UserInfo")',
//        method: 'post',
//        dataType: 'json',
//        async: false,
//        data: {
//            userName: formObject.UserName,
//        },
//        success: function (data) {
//            var vmMsg = data;
//            if (vmMsg.MessageType == 1) {
//                ShowNotification(1, vmMsg.ReturnMessage);
//                ResetForm();
//                LoadUserInfoGrid();

//            } else {
//                ShowNotification(3, vmMsg.ReturnMessage);

//            }
//        },
//        error: function () {
//        }
//    });

//} 

function DesignationValidation(formObject) {

    if (!formObject.DesignationName) {
        $('#txtDesignationName').focus();
        ShowNotification('2', 'Designation Name Can not be empty.');
        return false;
    }


    return true;
}

