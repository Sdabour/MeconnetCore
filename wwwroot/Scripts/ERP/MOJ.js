function EditMOStatusByUser() {
    var vrUserName = document.getElementById("txtUserName").value;
    var vrPassword = document.getElementById("txtPassword").value;
  /*  var vrAlert = document.getElementById("lblUMSID").value;*/
    var vrMO = document.getElementById("lblMOID").value;
    var vrStatus = document.getElementById("lbStatus").value;
    if (vrMO == null || vrMO == "" || vrMO == "0") { return false; }
    var objParam = { strUserName: vrUserName, strPass: vrPassword, intMO: vrMO, intStatus: vrStatus };
    var vrServiceUrl = "../api/MOAPI";
    $.ajax({
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

        }
        else { alert("Check User Name or Pass"); }
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("Error");

    }
   
    document.getElementById('myUserLogInModal').style.display = 'none';
}