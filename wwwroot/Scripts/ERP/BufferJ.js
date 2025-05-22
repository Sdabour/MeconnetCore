
function FillBufferGroup() {


    var vrServiceUrl = "api/BufferMeasureAPI";
    var vrIsDateRange = 0;

    var vrStart = new Date().toISOString().substring(0, 10);
    var vrEnd = new Date().toISOString().substring(0, 10);
    if (document.getElementById("chkGroupDateRange") != null)
        vrIsDateRange = document.getElementById("chkGroupDateRange").checked ? 1 : 0;
    if (vrIsDateRange == 1) {
        vrStart = document.getElementById("dtGroupDateFrom").value;
        vrEnd = document.getElementById("dtGroupDateTo").value;
    }
    if (vrStart == "" || vrEnd == "") {
        vrStart = new Date().toISOString().toString().substring(0, 10);
        vrEnd = new Date().toISOString().toString().substring(0, 10);
    }
    var vrData = {
        blIsDateRange: vrIsDateRange, dtStart: vrStart, dtEnd: vrEnd
    };
    var vrDataStr = JSON.stringify(vrData);
     
    $.ajax({
        type: 'POST',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: vrDataStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";


       
        var vrStrArr;
        var vrStrCard = "";
        var vrCardExists = false;
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {

            strDV += GetMeterGroupRow(data[vrIndex]);
            if (document.getElementById("dvGroupCard" + data[vrIndex].ID) != null) {
                vrCardExists = true;
            }
            {
                vrStrCard += GetGroupCard(data[vrIndex]);
            }
        }
        strDV += "</table>"
        //alert(strDV);
        if (!vrCardExists) {
            document.getElementById("dvGroupCard").innerHTML = vrStrCard;

        }
        var objDvGroup = document.getElementById("dvMeterGroup");
        /*  if (strDV != "") {*/
        objDvGroup.innerHTML = strDV;
        /*}*/
        DisplayLatestMeterRead();
        DisplayLatestMeasureRead();
        try {
            FillMeterMeasure();
        }
        catch
        {
        }
        if (document.getElementById("chkGroupDateRange").checked)
        {
            //setTimeout(FillBufferGroup, 5000);
        }

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillBufferGroup, 10000);
    }


    return false;


}

function FillMeterMeasure() {


    /*intMeter,intMeasureType,dtFrom,dtTo*/
    var vrMeter = Number(document.getElementById("lblMeter").value);
    var vrMeasureType = Number(document.getElementById("lblMeasureType").value);
    var vrFrom = document.getElementById("dtMeasureFrom").value;

    var vrTo = document.getElementById("dtMeasureTo").value;
    if (vrMeter == 0) {
        return;
    }
    var vrSearchObj = { intMeter: vrMeter, intMeasureType: vrMeasureType, dtFrom: vrFrom, dtTo: vrTo };
    var vrSearchStr = JSON.stringify(vrSearchObj);
    var vrServiceUrl = "api/BufferMeasureAPI";

   // vrSearchStr = "";

    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intMeter: vrMeter, intMeasureType: vrMeasureType, dtFrom: vrFrom, dtTo: vrTo }
,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";



        var vrStrArr;
        //var vrStrCard = "";
        var vrIsAccumulated = false;
        if (data.length > 0) {
            vrIsAccumulated = data[0].IsAccumulated;
            document.getElementById("lblMeterMeasureDesc").innerText = data[0].MeterDesc + "-" + data[0].TypeName;
        }
        var vrScalarValue = 0;
        if (vrIsAccumulated && data.length > 0) {

            vrScalarValue = data[0].Value;
            if (data.length > 1)
                vrScalarValue -= data[data.length - 1].Value;
        }
        else if (data.length > 0) {
            vrScalarValue = (data.map(x => x.Value).reduce((a, b) => a + b)) / data.length;
        }
        if (document.getElementById("lblScalarValue") != null) {

            document.getElementById("lblScalarValue").innerText = vrScalarValue.toFixed(3);
        }
        SetMeterLstMorisDat(data);
        SetMorisBar();
        for (var vrIndex = data.length - 1; vrIndex >= 0; vrIndex--) {

            strDV += MeterMeasure.GetRow(data[vrIndex]);
            //vrStrCard += GetGroupCard(data[vrIndex]);
        }
        strDV += "</table>"
        //alert(strDV);
        document.getElementById("tblMeterMeasure").innerHTML = strDV;



    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
       // setTimeout(FillServiceGroup, 10000);
    }
    setTimeout(FillMeterMeasure, 10000);

    return false;


}
function SetMorisBar() {
    document.getElementById("dvGraph").innerHTML = "";
    var vrJson = document.getElementById("lblGraphJson").value;
    if (vrJson != "") {
        var vrJsonObject;
        var vrJsonY;
        var vrJsonLabel;
        try {
            //alert(vrJson);
            vrJsonObject = JSON.parse(vrJson);
            vrJsonY = JSON.parse(document.getElementById("lblGraphJsonY").value)
            vrJsonLabel = JSON.parse(document.getElementById("lblGraphJsonLabel").value)
        } catch (a) {
            alert(a);
        }
        try {
            Morris.Line({
                element: 'dvGraph',
                data: vrJsonObject
                ,
                xkey: document.getElementById("lblGraphJsonX").value,
                ykeys: vrJsonY,
                labels: vrJsonLabel,
                stacked: true
            });
        } catch (a) {
            //alert(a);
        }
    }
    //    try {
    //        Morris.Bar({
    //            element: 'dvGraph',
    //            data: [
    //                { x: '2011 Q1', y: 3, z: 2, a: 3 },
    //                { x: '2011 Q2', y: 2, z: null, a: 1 },
    //                { x: '2011 Q3', y: 0, z: 2, a: 4 },
    //                { x: '2011 Q4', y: 2, z: 4, a: 3 }
    //            ],
    //            xkey: 'x',
    //            ykeys: ['y', 'z', 'a'],
    //            labels: ['Y', 'Z', 'A'],
    //            stacked: true
    //        });
    //    } catch (a) { alert(a); }
    //}
}