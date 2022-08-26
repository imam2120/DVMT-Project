
$(document).ready(function () {
    GridDataLoad();
});

function GridDataLoad() {
    $("#grid").kendoGrid().empty();
    var result = CallAjax_POST('GetDepartment/Department', '', false, false)
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
                { name: "DepartmentId", operator: "eq" },
                { name: "DepartmentName", operator: "contains" },
                { name: "FatherName", operator: "contains" },
                { name: "MotherName", operator: "contains" },

            ]
        },
        columns: [

            { field: "DepartmentId", title: "Department Id", filterable: true, filterable: { multi: true, search: true }, width: "70px" },
            { field: "DepartmentName", title: "Department Name", filterable: true, filterable: { multi: true, search: true }, width: "80px" },
            { field: "CreatedBy", title: "Created By", filterable: true, filterable: { multi: true, search: true }, width: "80px" },
            { field: "CreatedDate", title: "Created Date", filterable: true, filterable: { multi: true, search: true }, width: "90px" },
            { field: "MakeBy", title: "Make By", filterable: true, filterable: { multi: true, search: true }, width: "120px" },
            { field: "MakeDate", title: "Make Date", filterable: true, filterable: { multi: true, search: true }, width: "120px" },

        ],
        change: function (e) {
            onChngeUpdateValueSet();
        }
    });
}



function FormDataAsObject() {
    var object = new Object();
    object.DepartmentName = $('#txtDepartmentName').val();
    object.DepartmentId = $('#txtDepartmentId').val();
    return object;
}

function ResetForm() {
    $('#txtDepartmentName').val('');
    $('#txttxtDepartmentId').val('');

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

    if (EmployeeInfoValidation(object)) {

          var data = new Object();

           data.DepartmentName = object.DepartmentName,
            data.operationType = 1

        var result = CallAjax_POST('CreateOrUpdate/Department', data, false, false)
        if (result.MessageType == 1) {
            ShowNotification(1, result.ReturnMessage);
            ResetForm();
            GridDataLoad();
        } else {
            ShowNotification(3, result.ReturnMessage);

        }  
    }
}

function Update() {
    var formObject = FormDataAsObject();

    if (EmployeeInfoValidation(formObject)) {

           var data = new Object();
            data.DepartmentId = formObject.DepartmentId,
            data.DepartmentName = formObject.DepartmentName,
            data.operationType = 2

        var result = CallAjax_POST('CreateOrUpdate/Department', data, false, false)
        if (result.MessageType == 1) {
            ShowNotification(1, result.ReturnMessage);
            ResetForm();
            GridDataLoad();
        } else {
            ShowNotification(3, result.ReturnMessage);

        }
    }

}

function Delete() {
    var formObject = FormDataAsObject();

    if (EmployeeInfoValidation(formObject)) {

        var data = new Object();
        data.DepartmentId = formObject.DepartmentId,
        data.operationType = 3

        var result = CallAjax_POST('CreateOrUpdate/Department', data, false, false)
        if (result.MessageType == 1) {
            ShowNotification(1, result.ReturnMessage);
            ResetForm();
            GridDataLoad();
        } else {
            ShowNotification(3, result.ReturnMessage);

        }
    }

}

function onChngeUpdateValueSet() {
    var grid = $("#grid").data("kendoGrid");
    if (grid.select().length > 0) {
        var selectedItem = grid.dataItem(grid.select());
        if (selectedItem != null) {
            $('#txtDepartmentId').val(selectedItem.DepartmentId);
            $('#txtDepartmentName').val(selectedItem.DepartmentName);
        }
    }
}

function EmployeeInfoValidation(formObject) {

    if (!formObject.DepartmentName) {
        $('#txtDepartmentName').focus();
        ShowNotification('2', 'Department Name Can not be empty.');
        return false;
    }


    return true;
}
