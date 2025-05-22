

function FillReservation() {


    /*intProject,int intTower, int intFloorID, string strReservationCode,int intType,int intStatus*/



    var vrServiceUrl = "../api/ReservationWeb/GetSimpleReservation";
    var vrName = document.getElementById("txtReservationUnitCode").value;

    var vrProject = "";

    //alert(vrProject);
    // vrProject = 0;
    var vrStatus = "";
    var vrReservationID = 0;
    var vrCustomerID =0;
    var vrProjectID =0;
    var vrUnitCode = vrName;
    
    
    if (document.getElementById("lblReservationStatus") != null) {
        vrStatus = document.getElementById("lblReservationStatus").getAttribute("value");

    }
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
     strStatus:vrStatus,intReservationID:vrReservationID, intCustomerID:vrCustomerID,intProjectID: vrProjectID, strUnitCode:vrUnitCode
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

function FillReservationSimpleInstallment() {


    /**/
    if (document.getElementById("dvInstallment") == null)
    {
        return;
    }
        var vrReservation = JSON.parse(document.getElementById("lblReservationValue").getAttribute("value"));
        if (vrReservation == null || vrReservation.ID == 0)
            return;


        var vrServiceUrl = "../api/ReservationWeb/GetInstallmentByReservation";
        var vrREservation = document.getElementById("txtReservationCode").value;

        var vrProject = "";



        var vrReservationID = vrReservation.ID;



   /* if (document.getElementById("lblReservationStatus") != null)*/ {
            /*  vrStatus = document.getElementById("lblReservationStatus").getAttribute("value");*/

        }
        $.ajax({
            type: 'GET',
            url: vrServiceUrl,
            contentType: 'application/json; charset=utf-8',

            dataType: 'json',
            data: {
                intReservationID: vrReservationID
            },
            success: successFunc,
            error: errorFunc
        });



        function successFunc(data, status) {


            //var strDV = "<table class=\"table\">";
            var strDV = "";


            var vrInstallmentSimple = new InstallmentSimple();
            for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {

                strDV += vrInstallmentSimple.GetInstallmentPaymentRow(data[vrIndex]);

            }
            // strDV += "</table>"

            var objDvReservation = document.getElementById("dvInstallment");
            objDvReservation.innerHTML = strDV;
            document.getElementById("lblGridCheckedIDs").setAttribute("value", vrReservationID);

        }

        function errorFunc(jqXHR, textStatus, errorThrown) {
            alert("ErrorFunct :" + errorThrown);
        }
        FillReservationSimpleCheck();
    
    return false;


}

function FillReservationSimpleCheck() {


    /**/

    var vrReservation = JSON.parse(document.getElementById("lblReservationValue").getAttribute("value"));
    if (vrReservation == null || vrReservation.ID == 0)
        return;


    var vrServiceUrl = "../api/CheckWebAPI/GetReservationCustomerCheck";
    

    var vrProject = "";



    var vrReservationID = vrReservation.ID;



   /* if (document.getElementById("lblReservationStatus") != null)*/ {
        /*  vrStatus = document.getElementById("lblReservationStatus").getAttribute("value");*/

    }
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            intReservationID: vrReservationID
        },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        //var strDV = "<table class=\"table\">";
        var strDV = "";

        document.getElementById("lblAllCheck").value = JSON.stringify(data);
        document.getElementById("dvCheck").innerHTML = FillPaymentCheckTable();
        
        // strDV += "</table>"

        

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}