
function FillFunction(vrSystemID)
{


    /*intProject,int intTower, int intFloorID, string strReservationCode,int intType,int intStatus*/



    var vrServiceUrl = "../api/UMSAPI/GetSystemFunctionLst";
    
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            intSys:vrSystemID
        },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrReservation;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrReservationID;

        var vrReservationSimple = new ReservationSimple();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {

            strDV += vrReservationSimple.GetRow(data[vrIndex]);

        }
        strDV += "</table>"
        //alert(strDV);
        var objDvReservation = document.getElementById("dvReservation");
        objDvReservation.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}
function ChangeUserPass()
{


    /*intProject,int intTower, int intFloorID, string strReservationCode,int intType,int intStatus*/
    var vrUser = GetUserChangePassword();
    if (vrUser.ID == 0) {
        return;
    }
    var vrUserStr = JSON.stringify(vrUser);

    var vrServiceUrl = "../api/UserAPI";

    $.ajax({
        type: 'POST',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: vrUserStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        if (data == 0) {
            alert("لم تتم العملية ربما كلمة المرور القديمة خاطئة");
            return;
        }
        else {
            alert("OK");
            window.location.replace("../login");
        }

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}