
function LoadDesignationCombo(controlId, isDefaultRecordRequired) {
    var url = '/Common/GetAllDesignation';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}


function LoadGenderData(controlId, isDefaultRecordRequired) {
    var url = '/EmployeeInfo/LoadAllGender';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}

function LoadMaritalStatus(controlId, isDefaultRecordRequired) {
    var url = '/EmployeeInfo/LoadAllMaritalStatus';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}

function LoadStatus(controlId, isDefaultRecordRequired) {
    var url = '/EmployeeInfo/LoadStatus';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}
function LoadAdjustmentType(controlId, isDefaultRecordRequired) {
    var url = '/Common/LoadAdjustmentType';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}

function LoadDepartmentCombo(controlId, isDefaultRecordRequired) {
    var url = '/Common/GetAllDepartment';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}
function LoadSalaryGroupCombo(controlId, isDefaultRecordRequired) {
    var url = '/Common/GetAllSalaryGroup';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}

function LoadBreakupCombo(controlId, isDefaultRecordRequired) {
    var url = '/Common/GetAllBreakup';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}
function LoadAllMonth(controlId, isDefaultRecordRequired)
{
    var url = '/Common/LoadAllMonth';
    LoadCombo(controlId, url, isDefaultRecordRequired);

}



function LoadJoiningType(controlId, isDefaultRecordRequired) {
    var url = '/EmployeeInfo/LoadJoiningType';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}

function LoadBloodGroup(controlId, isDefaultRecordRequired) {
    var url = '/EmployeeInfo/LoadAllBloodGroup';
    LoadCombo(controlId, url, isDefaultRecordRequired);
}


function GetAllSpeceficProject(controlId, firstIdentityCode, secondIdentityCode, isDefaultRecordRequired) {
    var url = '/Common/GetAttachedSpeceficProjects';
    LoadComboWithTwoCondition(controlId, url, firstIdentityCode, secondIdentityCode, isDefaultRecordRequired);
}


//function LoadCombo(controlId, url, identityCode, isDefaultRecordRequired) {
function LoadCombo(controlId, url, isDefaultRecordRequired) {

    //alert(url);
   
    $.ajax({
        url: url,
        //url: '@Url.Action("GetAllRootArea","Common")',
        type: 'get',
        async: false,
        //data: {
        //    identityCode: identityCode
        //},
        
        success: function (res) {
            var data = res;
            //alert('Success');
            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);
                });
            }
        },
        error: function () {
            alert('Error');
        }
    });
}

function LoadComboClass(controlId, url, identityCode, isDefaultRecordRequired) {
    $.ajax({
        url: url,
        type: 'get',
        async: false,
        data: {
            identityCode: identityCode
        },
        success: function (res) {
            var data = res;

            $("." + controlId).empty();
            $("." + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("." + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("." + controlId).get(0).options[$("." + controlId).get(0).options.length] = new Option(item.Text, item.Value);//chancge later
                });
            }
        },
        error: function () {
        }
    });
}

function LoadComboWithCondition(controlId, url, identityCode, isDefaultRecordRequired) {
    $.ajax({
        url: url,
        type: 'get',
        async: false,
        data: {
            identityCode: identityCode
        },
        success: function (res) {
            var data = res;

            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);//chancge later
                });
            }
        },
        error: function () {
        }
    });
}

function LoadComboWithTwoCondition(controlId, url, firstIdentityCode, secondIdentityCode, isDefaultRecordRequired) {
    $.ajax({
        url: url,
        type: 'get',
        async: false,
        data: {
            firstIdentityCode: firstIdentityCode, secondIdentityCode: secondIdentityCode
        },
        success: function (res) {
            var data = res;

            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (isDefaultRecordRequired) {
                $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Text, item.Value);//chancge later
                });
            }
        },
        error: function () {
        }
    });
}


