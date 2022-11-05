$(document).ready(function () {
    $("btnPreview").click(function () {
        alert("Button click event fired");
        ReportManager.Loadreport();
    });
});

var ReportManager = {
    Loadreport: function () {
        var jesonParam: '',
        var serviceUrl: "../DailyPosition/GenerateDailyPositionReport/",
        ReportManager.Getreport(serviceUrl, jesonParam, onFailed);
        function onFailed() {
            aleart("Found error!");
        }
    },
    Getreport: function (serviceUrl, jesonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jesonParams + "}",
            contentType: "application/jeson; charset=utf-8",
            success: function () {
                window.open('../Reports/ReportViewer.aspx', '_newtab');
            },
            errer: errorCallback
        });
    }
}