
 

function OnHandShake() {

    var vrApplicantIDs = document.getElementById("lblApplicantIDs").value;

    if (vrApplicantIDs == null || vrApplicantIDs == "")
        return;
    if (document.getElementById("lblTrackAuthorized").value == "0")
        return;
    var objPrm = { strApplicantIDs:vrApplicantIDs };
  
  
    var vrServiceUrl = "http://localhost:51143/HandShake/GetOnline/";
    vrServiceUrl = "../api/HandShake/GetTodayHandShaked";
    $.ajax({
        method: 'POST',
       
        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(objPrm),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        var strApplicant = "";
        var vrApplicant;
        var vrOnlineData = data.filter(function (vrObj) { return vrObj.Status == 0 || vrObj.Status == 1;});

        var vrOnlineCount = vrOnlineData.length == 0 ? "" : vrOnlineData.length;
        document.getElementById("lblOnlineCount").innerText = vrOnlineCount;
        document.getElementById("ulOnlineUser").innerHTML = "";
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            vrApplicant = data[vrIndex];
            strApplicant += " <li class=\"media\">" +
                "<div class=\"mr-3\">";
            strApplicant += "<img src=\"../wwwroot/images/placeholders/placeholder.jpg\" width=\"36\"" + "height=\"36\" class=\"rounded-circle\" alt=\"\">";

            strApplicant += "</div>" +
                "<div class=\"media-body\">";
            strApplicant += "<a href=\"/LocationAssignPoint/DisplayLocationOnMap?Long=" + vrApplicant.Long + "&Lat=" + vrApplicant.Lat +"&AppName="+vrApplicant.ApplicantName+ "\" target=\"_blank\" class=\"media-title font-weight-semibold\">";
            strApplicant += vrApplicant.ApplicantName;

            strApplicant += "</a>";
            strApplicant += "<span class=\"d-block text-muted font-size-sm\">" + vrApplicant.JobDesc + "</span>" +
                "</div>" +
                "<div class=\"ml-3 align-self-center\">";
            if (vrApplicant.Status == 0) {
                strApplicant += "<span class=\"badge badge-mark border-success\"></span>";
            }
            else if (vrApplicant.Status == 1) {
                strApplicant += "<span class=\"badge badge-mark border-danger\"></span>";
            }
            else {
                strApplicant += "<span class=\"badge badge-mark border-grey-400\"></span>";
            }
            strApplicant+="</div>" +
                "</li>";
        }
        document.getElementById("ulOnlineUser").innerHTML = strApplicant;
        FillHandShakeTable(data);
        setTimeout(OnHandShake, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        document.getElementById("lblOnlineCount").innerText = "";
        setTimeout(OnHandShake, 30000);
    }


}

function FillHandShakeTable(data)
{
    if (document.getElementById("tblOnlineBody") == null)
        return;
    if (document.getElementById("lblEmployeeValue") != null && document.getElementById("lblEmployeeValue").value != null && document.getElementById("lblEmployeeValue").value != "")
    {
        var vrEmployee = JSON.parse(document.getElementById("lblEmployeeValue").value);
        data = data.filter(function (objX) { return objX.ApplicantID==vrEmployee.ID; });
    }
    var vrHandShake;
    var vrTable = "";
    var vrUrl = "";
    for (var vrIndex = 0; vrIndex < data.length; vrIndex++)
    {
        vrHandShake = data[vrIndex];
        vrUrl = "<a href=\"/LocationAssignPoint/DisplayLocationOnMap?Long=" + vrHandShake.Long + "&Lat=" + vrHandShake.Lat + "&AppName=" + vrHandShake.ApplicantName + "\" target=\"_blank\" class=\"media-title font-weight-semibold\">عرض</a>";

        vrTable += "<tr>"+
            "<td>"+
            vrHandShake.ApplicantCode+ "</td >"+
                                "<td>"+ vrHandShake.ApplicantName +
            "</td><td>" + vrHandShake.JobDesc+"</td><td>"+
            vrHandShake.LastDateStr + "</td><td>" + vrHandShake.LastTimeStr + "</td><td>" + vrHandShake.StatusStr+"</td><td>"+
            vrUrl+"</td></tr>";
    }
    document.getElementById("tblOnlineBody").innerHTML = vrTable;
    if (document.getElementById("lblLong") != null && document.getElementById("lblLat") && data.length == 1)
    {
        if (
            (document.getElementById("lblLong").value != null && document.getElementById("lblLong").value != data[0].Long) || (document.getElementById("lblLat").value != null && document.getElementById("lblLat").value != data[0].Lat))
        {
            document.getElementById("lblLong").value = data[0].Long;

            document.getElementById("lblLat").value = data[0].Lat;
            DrawLongLatOnMap();
        }
    }
}




function UploadPosition()
{
    var vrServiceUrl = "http://ds.morshedy.com/HSApi/HandShake/HandShakePos";

    var vrAppID = document.getElementById("lblAppID").value;
    //var vrLoc = 

    $.ajax({
        type: 'POST',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: {
            strApplicantIDs: vrApplicantIDs
        },
        success: successUploadFunc,
        error: errorUploadFunc
    });



    function successUploadFunc(data, status) {
        
         
        
    }


    function errorUploadFunc(jqXHR, textStatus, errorThrown) {
         
    }
}