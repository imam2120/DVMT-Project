
    _serverDate = null;

$(document).ready(function () {
            LoadDepartment();
            LoadDesignation();
            /* alert('test 1');*/
            $("#grid").kendoGrid().empty();
            // debugger;
            var result = CallAjax_POST('GetEmployee/EmployeeInfo', '', false, false)
            if (result.length > 0) {
                //    $("#dvExport").css('display', 'block');
                //else
                //    $("#dvExport").css('display', 'none');
                //alert("Test");
                PopulateGridView(result);
            } else {
                alert("Error! Please Contact..");
                //        $("#dvExport").css('display', 'none');
            }

           
        });

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
        toolbar: ["search"],
        search: {
            fields: [
                { name: "EmployeeId", operator: "eq" },
                { name: "Name", operator: "contains" },
                { name: "FatherName", operator: "contains" },
                { name: "MotherName", operator: "contains" },

            ]
        },
      
        columns: [

            { field: "EmployeeId", title: "Employee Id", filterable: true, filterable: { multi: true, search: true }, width: "120px" },
            { field: "Name", title: "Employee Name", filterable: true, filterable: { multi: true, search: true }, width: "120px" },
            { field: "FatherName", title: "Father's Name", filterable: true, filterable: { multi: true, search: true }, width: "120px" },
            { field: "MotherName", title: "Mother's Name", filterable: { multi: true, search: true }, width: "120px" },
            { field: "Select ", title: "Action", filterable: false, width: "50px", template: "<button type='button' class='btn btn-success btn-sm k-button' onclick='printSelected();' id='btnEdit'>Select</button>" }
  
        ],
        change: function (e) {
            var grid = $("#grid").data("kendoGrid");
            if (grid.select().length > 0) {
                var selectedItem = grid.dataItem(grid.select());
                if (selectedItem != null) {
                    alert('Test');
                }
            }
        }

       
    });
}

function printSelected() {
    var grid = $("#grid").data("kendoGrid");
     grid.select();
    var ddd = grid.getSelectedData();
    console.log(grid.getSelectedData());
}

    function FormDataAsObject() {
        var object = new Object();
        object.Name = $('#txtEmployeeName').val();
        object.ContractNumber = $('#txtContractNumber').val();
        object.NID = $('#txtNationalId').val();
        object.EmergencyNumber = $('#txtEmergencyNumber').val();
        object.GenderId = $('#ddlGender').val();
        object.FatherName = $('#txtFatherName').val();
        object.MaritalStatus = $('#ddlMaritalStatus').val();
        object.MotherName = $('#txtMotherName').val();
        object.DeptId = $('#ddlDepartment').val();
        object.PresentAddress = $('#txtPresentAddress').val();
        object.DesignationId = $('#ddlDesignation').val();
        object.PermanentAddress = $('#txtPermanentAddress').val();
        object.DOB = $('#txtDateOfBirth').val();
        object.BloodGroup = $('#txtBloodGroup').val();

        return object;
    }

    function ResetForm() {
        $('#txtEmployeeName').val('');
        $('#txtContractNumber').val('');
        $('#txtNationalId').val('');
        $('#txtEmergencyNumber').val('');
        $('#ddlGender').val('');
        $('#txtFatherName').val('');
        $('#ddlMaritalStatus').val('');
        $('#txtMotherName').val('');
        $('#ddlDepartment').val('');
        $('#txtPresentAddress').val('');
        $('#ddlDesignation').val('');
        $('#txtPermanentAddress').val('');
        $('#txtDateOfBirth').val('');
        $('#txtBloodGroup').val('');

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

    function OnSelectUser(userName) {

        $.ajax({
            url: '@Url.Action("GetAUser", "UserInfo")',
            type: 'get',
            dataType: 'json',
            async: false,
            data: {
                userName: userName
            },
            success: function (data) {
                ResetForm();
                $('#txtUserName').val(data.UserName);
                $('#txtUserFullName').val(data.UserFullName);
                $('#txtUserPassword').val(data.UserPassword);
                $('#ddlUserRole').val(data.UserRoleId);
                $('#ddlUserStatus').val(data.UserStatusId);
                EnableDisableControls("2");
                LoadUserInfoGrid();

            },
            error: function () {

            }
        });
    }

    function Save()
        {
            var object = FormDataAsObject();
            debugger;
           // alert($('#ddlDepartment').val);

            if (EmployeeInfoValidation(object)) {

        $.ajax({
            url: '@Url.Action("CreateOrUpdate", "EmployeeInfo")',
            method: 'post',
            dataType: 'json',
            async: false,
            data: {
                Name: object.Name,
                ContractNumber: object.ContractNumber,
                NID: object.NID,
                EmergencyNumber: object.EmergencyNumber,
                GenderId: object.GenderId,
                FatherName: object.FatherName,
                MaritalStatus: object.MaritalStatus,
                MotherName: object.MotherName,
                DeptId: object.DeptId,
                PresentAddress: object.PresentAddress,
                DesignationId: object.DesignationId,
                PermanentAddress: object.PermanentAddress,
                DOB: object.DOB,
                BloodGroup: object.BloodGroup,

                //UserName: formObject.UserName,
                //UserFullName: formObject.UserFullName,
                //UserPassword: formObject.UserPassword,
                //UserRoleId: formObject.UserRoleId,
                //UserStatusId: formObject.UserStatus,
            },
            success: function (data) {
                var vmMsg = data;
                if (vmMsg.MessageType == 1) {
                    ShowNotification(1, vmMsg.ReturnMessage);
                    ResetForm();
                    //LoadUserInfoGrid();

                } else {
                    ShowNotification(3, vmMsg.ReturnMessage);
                }
            },
            error: function () {
            }
        });
            }
        }

    function Update()
        {
            var formObject = FormDataAsObject();

            if (EmployeeInfoValidation(formObject)) {

        $.ajax({
            url: '@Url.Action("Update", "UserInfo")',
            method: 'post',
            dataType: 'json',
            async: false,
            data: {
                UserName: formObject.UserName,
                UserFullName: formObject.UserFullName,
                UserPassword: formObject.UserPassword,
                UserRoleId: formObject.UserRoleId,
                UserStatusId: formObject.UserStatus,
            },
            success: function (data) {
                var vmMsg = data;
                if (vmMsg.MessageType == 1) {
                    ShowNotification(1, vmMsg.ReturnMessage);
                    ResetForm();
                    LoadUserInfoGrid();

                } else {
                    ShowNotification(3, vmMsg.ReturnMessage);

                }
            },
            error: function () {

            }
        });

            }

        }

    function Delete()
        {
            var formObject = FormDataAsObject();

            $.ajax({
        url: '@Url.Action("Delete", "UserInfo")',
                method: 'post',
                dataType: 'json',
                async: false,
                data: {
        userName: formObject.UserName,
                },
                success: function (data) {
                    var vmMsg = data;
                    if (vmMsg.MessageType == 1) {
        ShowNotification(1, vmMsg.ReturnMessage);
                        ResetForm();
                        LoadUserInfoGrid();

                    } else {
        ShowNotification(3, vmMsg.ReturnMessage);

                    }
                },
                error: function () {
    }
            });

        }

    function EmployeeInfoValidation(formObject) {

            if (!formObject.Name) {
        $('#txtEmployeeName').focus();
                ShowNotification('2', 'Employee Name Can not be empty.');
                return false;
            }

            if (!formObject.ContractNumber) {
        $('#txtContractNumber').focus();
                ShowNotification('2', 'Contract No Can not be empty.');
                return false;
            }

            if (!formObject.NID) {
        $('#txtNationalId').focus();
                ShowNotification('2', 'National ID Can not be empty.');
                return false;
            }
            if (!formObject.DeptId) {
        $('#ddlDesignation').focus();
                ShowNotification('2', 'Department Can not be empty.');
                return false;
            }
            if (!formObject.PresentAddress) {
        $('#txtPresentAddress').focus();
                ShowNotification('2', 'Present Address Can not be empty.');
                return false;
            }

            if (!formObject.PermanentAddress) {
        $('#txtPermanentAddress').focus();
                ShowNotification('2', 'Permanent Address Can not be empty.');
                return false;
            }


            return true;
        }

    function LoadDepartment() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "/EmployeeInfo/LoadDepartment",
            data: {},
            async: false,
            dataType: "json",
            success: function (data) {
                $("#ddlDepartment").empty();
                $("#ddlDepartment").append($("<option></option>").val("-1").html("--Select Department--"));
                $.each(data, function (i, item) {
                    //console.log(item);
                    $("#ddlDepartment").append($("<option></option>").val(item.Key).html(item.Value));
                });
            }
        });
           $("#ddlDepartment").selectpicker('refresh');
        }

    function LoadDesignation() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "/EmployeeInfo/LoadDesignation",
            data: {},
            async: false,
            dataType: "json",
            success: function (data) {
                $("#ddlDesignation").empty();
                $("#ddlDesignation").append($("<option></option>").val("-1").html("--Select Designation--"));
                $.each(data, function (i, item) {
                    //console.log(item);
                    $("#ddlDesignation").append($("<option></option>").val(item.Key).html(item.Value));
                });
            }
        });
            $("#ddlDesignation").selectpicker('refresh');
        }

