const fa = require("../../wwwroot/js/plugins/ui/fullcalendar/core/locales/fa");

function AlertFire() {
    var vrIsDateRange = false;
    var vrLastStatus = true;
    var vrReason = 0;
    var vrStoppedStatus = 0;

    var vrFrom = document.getElementById("dtAlertFrom").value;


    var vrTo = document.getElementById("dtAlertTo").value;
    var vrShow = document.getElementById("lblShowMeasureAlertModal").value;
    if (vrShow == "1") {
        vrIsDateRange = true;
        if (!document.getElementById("chkAllAlert").checked) {
            vrLastStatus = false;
        }
    }
    
    var vrServiceUrl = "../api/ServiceAPI/GetAlert";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { blIsDateRange:vrIsDateRange,dtFrom: vrFrom, dtTo: vrTo, blLastStatus: vrLastStatus, intReason: vrReason, intStoppedStatus: vrStoppedStatus },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        if (!vrIsDateRange) {
            var strMSG = "";

            var vrNotStopped = data.filter(function (vrObj) { return vrObj.Stopped == false; });

            var vrMsgCount = vrNotStopped.length == 0 ? "" : vrNotStopped.length;
            document.getElementById("lblMessageCount").innerText = vrMsgCount;
            document.getElementById("ulMSG").innerHTML = "";
            var objMSG = new MeasureAlert();
            for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
                strMSG += GetAlertShort(data[vrIndex]);
            }
            document.getElementById("ulMSG").innerHTML = strMSG;
            if (vrMsgCount > 0)
                Beep();
            else
                StopBeep();
        }
        else
        {
            var vrTable = "<table class='table'>";
            var vrAlert = new MeasureAlert();
            for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
                vrTable += vrAlert.GetRow(data[vrIndex]);
            }
            vrTable += "</table>";
            document.getElementById("tblAlert").innerHTML = vrTable;
            //ShowMeasureAlertModal();

        }
        // setTimeout(OnAlert, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        document.getElementById("lblMessageCount").innerText = "";
        //setTimeout(OnHandShake, 30000);
    }

    return false;
}
function CheckAckUser() {
    var vrUserName = document.getElementById("txtUserName").value;
    var vrPassword = document.getElementById("txtPassword").value;
    var vrAlert = document.getElementById("lblUMSID").value;
    if (vrAlert == null || vrAlert == "" || vrAlert == "0") { return false; }

    var vrServiceUrl = "../api/ServiceAPI/AckAlert";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { strUsrName:vrUserName, strPass:vrPassword, intAlert:vrAlert },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status)
    {
        
       
        
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
       
      
    }
    document.getElementById("txtUserName").value = "";
    document.getElementById("txtPassword").value = "";
    document.getElementById("lblUMSID").value = "0";
    CloseUserLoginModal();
}
