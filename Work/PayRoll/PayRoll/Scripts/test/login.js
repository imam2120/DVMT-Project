
    $(document).ready(function(){
        $("#txtUserName").focus();
    });

        $("#btnLogin").click(function () {
            LoginTry();
            //alert("You are login"); dosto tk shes 
        });
        function LoginTry()
        {
            var msg = "";
            var userName = $("#txtUserName").val().trim();
            var password = $("#txtPassword").val().trim();
            if (userName == "") {
                msg = "User name can not be empty."
                errorModalDisplay(msg);
                return;
            }
            if (password == "") {
                msg = "Password can not be empty."
                errorModalDisplay(msg);
                return;
            }
            $.ajax({
                url: '@Url.Action("Login","Login")',
                type: 'post',
                async: false,
                data: { userName: userName, password: password },
                success: function (resp) {
                    var msg = resp;
                    if (msg.MessageType == "1") {
                        var url = '@Url.Action("Index","Dashboard")';
                        console.log(url);
                        window.location.href = url;
                    }
                    else {
                        msg = "Invalid username password"
                        errorModalDisplay(msg);
                       
                    }
                },
                error: function (resp) {
                    $("#lblMessage").html(msg.ReturnMessage);
                }
            });

           

        }

    //function Mykeydown(e, txtPassword) {
    //    var code = (e.keycode ? e.keycode : e.which)
    //    if (code == 13) {
    //        DoLogin();
    //    }
    //};

    function errorModalDisplay(msg) {
        swal({
            title: "Oops...",
            text: msg,
            confirmButtonColor: "#EF5350",
            type: "error"
        });
    };