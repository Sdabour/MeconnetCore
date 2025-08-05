

async function EditMOStatusByUser() {
    var vrUserName = document.getElementById("txtUserName").value;
    var vrPassword = document.getElementById("txtPassword").value;
  /*  var vrAlert = document.getElementById("lblUMSID").value;*/
    var vrMO = document.getElementById("lblMOID").value;
    var vrStatus = document.getElementById("lbStatus").value;
    if (vrMO == null || vrMO == "" || vrMO == "0") { return false; }
    var objParam = { strUserName: vrUserName, strPass: vrPassword, intMO: vrMO, intStatus: vrStatus };
    var vrServiceUrl = "../api/MOAPI";
    //var vrServiceUrl = "../mrp_production/create";
   await  $.ajax({
        method: 'PUT',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(objParam),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status)
    {
        if (data == true) {
            document.getElementById("txtUserName").value = "";
            document.getElementById("txtPassword").value = "";
            document.getElementById("lblMOID").value = "0";
            document.getElementById("lbStatus").value = "0";
          /*  FillMOListInitially();*/

        }
        else { alert("Check User Name or Pass"); }
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("Error");

    }
   
    document.getElementById('myUserLogInModal').style.display = 'none';
}
function FillMO() {
    var vrIsDateRange = 0;
    if (document.getElementById("chkIsDateRange") != null) {
        vrIsDateRange = document.getElementById("chkIsDateRange").checked ? 1 : 0;
    }
    var vrStart = new Date().toDateString();
    if (vrIsDateRange == 1 && document.getElementById("dtStart") != null) {
        vrStart = document.getElementById("dtStart").value;
    }
    var vrEnd = new Date().toDateString();
    if (vrIsDateRange == 1 && document.getElementById("dtEnd") != null) {
        vrEnd = document.getElementById("dtEnd").value;
    }
    var vrStatus = 0;
    var vrServiceUrl = "../api/MOAPI";
  //  var vrServiceUrl = "../mrp_production/create";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intStatus: vrStatus, intDateRange: vrIsDateRange, dtStart: vrStart, dtEnd: vrEnd }
        ,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillMOTable(data);
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        // setTimeout(FillServiceGroup, 10000);
    }

}
function FillMOListInitially() {
    var vrIsDateRange = 1;
   
    var vrStart = new Date().toDateString();
   
    var vrEnd = new Date().toDateString();
   
    var vrStatus = 0;
    //var vrServiceUrl = "../mrp_production/create";
    var vrServiceUrl = "../api/MOAPI";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intStatus: vrStatus, intDateRange: vrIsDateRange, dtStart: vrStart, dtEnd: vrEnd }
        ,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        document.getElementById("lblAllMO").value = JSON.stringify(data);
        FillMOLstTable();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        // setTimeout(FillServiceGroup, 10000);
    }

}

