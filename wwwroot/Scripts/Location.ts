var PointType = "MM";
var LocationID = "";
 

class WorkLocation
{
    public ID: number;
    public Desc:string;
    public CenterLong:string;
    public  CenterLat:string;
    public PointLong:string;
    public PoingLat: string;
    
    FillLocationLst()
    {
      
        let strLocation: string;
        strLocation = document.getElementById("lblWorkLocation").getAttribute("value");

        let objLocationCol: WorkLocation[];
        let objLocation: WorkLocation;

        objLocationCol = JSON.parse(strLocation);
        let strDiv = "";
        let strCenterClass: string;
        let strPointClass: string;
        for (var intIndex = 0; intIndex < objLocationCol.length; intIndex++)
        {
            objLocation = objLocationCol[intIndex];
            if (objLocation.CenterLong != "")
                strCenterClass = "btn btn-success";
            else
                strCenterClass = "btn btn-primary";

            if (objLocation.PointLong != "")
                strPointClass = "btn btn-success";
            else
                strPointClass = "btn btn-primary";
            strDiv += "<div class=\"col - 3\"> "+
                "<div class=\"form-group row\" >"+
                    "<div class=\"col\" >"+

                        "<label>"+objLocation.Desc+" </label>"+

                        "</div>"+
                "<div class=\"col\" ><input type=\"button\" id=\"btnCenter" + objLocation.ID.toString() + "\" name=\"btnCenter" + objLocation.ID.toString() + "\" value=\"Center\" class=\"" + strCenterClass +"\" onclick=\"GetLocation1('"+objLocation.ID.toString()+"','C')\" /> </div>"+
                "<div class=\"col\" > <input type=\"button\" id =\"btnPoint" + objLocation.ID.toString() + "\" name = \"btnPoint" + objLocation.ID.toString() + "\" value=\"Point\" class=\"" + strPointClass + "\" onclick=\"GetLocation1('" + objLocation.ID.toString() +"','P')\" /> </div>"+
                                "</div>"+
                                "</div>";
        }
        document.getElementById("dvMain").innerHTML = strDiv;
      
    }
    GetLocation(strLocationID:string,strpointType: string) {
        
        PointType = strpointType;
        LocationID = strLocationID;
        let x: HTMLElement;
        x= document.getElementById("lblCurrentLocation");
        if (navigator.geolocation) {
         
            navigator.geolocation.getCurrentPosition(this.showPosition);
            
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
    }

    showPosition(position: GeolocationPosition) {
       
        var x = document.getElementById("lblCurrentLocation");
        
        x.innerHTML =PointType + " : " + "Latitude: " + position.coords.latitude +
            "<br>Longitude: " + position.coords.longitude;
        



        var objPoint = { "LocationID": LocationID," PointType": PointType, "PointLat": position.coords.latitude, "PointLong":position.coords.longitude };
        var vrServiceUrl = "../api/WorkLocationWebController/UploadPoint";
        
        //$.ajax({
        //    type: "POST",
        //    url: vrServiceUrl,
        //    data: JSON.stringify(objPoint),
        //    async: false,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",

        //    success: function (response) {
        //        var vrVisitNo = response;

        //    },
        //    failure: function (response) {
        //        alert(response.responseText);
        //    },
        //    error: function (response) {
        //        alert(response.responseText);
        //    }
        //});
    }
}