
function OnVisit()
{

 

    var vrServiceUrl = "../api/VisitWebController/GetVisit";
    var vrBranchID = document.getElementById("lblBranchID").value;
    var d = new Date();
    
    if (vrBranchID == null || vrBranchID == "" || vrBranchID == 0)
        return;
    
    document.getElementById("lblClock").innerHTML = d.toLocaleTimeString();
  
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: {
            strBranch: vrBranchID
        },
        success: successFunc,
        error: errorFunc
    });
  
    
   
    function successFunc(data, status) {
        {
            
            var strTemp = "<tr>" +
                "<th>&#1578;&#1608;&#1602;&#1610;&#1578;</th>" +
                "<th>رقم</th>"+
                "<th>&#1593;&#1605;&#1610;&#1604;</th>" +
                "<th>&#1605;&#1580;&#1605;&#1608;&#1593;&#1577;</th>" +
                "<th>" +
                "&#1605;&#1608;&#1592;&#1601;</th>" +
                "<th>شباك</th>"+
                "<th>" +
                "&#1578;&#1608;&#1602;&#1610;&#1578;" +
                "</th>" +
                "<th>" +
                "&#1581;&#1575;&#1604;&#1577;" +
                "</th>" +
                "</tr >";
            var vrVisit;
            var vrStyle;
            var arrPicked = data.filter(function (obj) { return obj.Picked; })
            for (var vrIndex = 0; vrIndex < arrPicked.length; vrIndex++)
            {
                if (vrIndex % 2 == 0)
                    vrStyle = "background-color:whitesmoke;";
                else
                    vrStyle = "background-color:silver;";
                vrVisit = arrPicked[vrIndex];
                strTemp = strTemp +
                    " <tr style=\"" + vrStyle +"\" >  " +
                    "<td>" + vrVisit.Time + "</td>" +
                    "<td>" + vrVisit.VisitNo + "</td>" +
                    "<td>" + vrVisit.CustomerName + "</td>" +
                    "<td>" + vrVisit.Group + " </td>" +
                    "<td>" + vrVisit.AssignedEmployee + " </td>" +
                    "<td>" + vrVisit.WindowNo + " </td>" +
                    "<td>" + vrVisit.StatusTime + "</td>" +
                    "<td>" + vrVisit.Status + "</td>" +
                    "</tr>";
               
                
            }
            document.getElementById("tblPickedVisitDisplay").innerHTML = strTemp;
        }
        {
             
           vrStyle = "background-color:whitesmoke;";
            strTemp = "<tr >" +
                "<th>&#1578;&#1608;&#1602;&#1610;&#1578;</th>" +
                "<th>رقم</th>"+
                "<th>&#1593;&#1605;&#1610;&#1604;</th>" +
                "<th>&#1575;&#1604;&#1608;&#1581;&#1583;&#1577;</th>" +
                "<th>" +
                "&#1605;&#1580;&#1605;&#1608;&#1593;&#1577;" +
                "</th>" +
                "<th>" +
                "&#1605;&#1587;&#1574;&#1608;&#1604;</th>" +
                "<th>" +
                "&#1608;&#1589;&#1601;</th>" +
                "<th>" +
                "<span lang=\"ar-eg\">&#1606;&#1608;&#1593;</span></th>" +

                "</tr >";


            var vrVisit;
            var arrVisit = [];
            var arrWaiting = data.filter(function (obj) { return !obj.Picked; })
            for (var vrIndex = 0; vrIndex < arrWaiting.length; vrIndex++) {
                vrVisit = arrWaiting[vrIndex];
                if(vrIndex%2 ==0)
                    vrStyle = "background-color:whitesmoke;";
                else
                    vrStyle = "background-color:silver;";
                strTemp = strTemp +
                    " <tr style=\""+  vrStyle +"\" >  " +
                    "<td>" + vrVisit.Time + "</td>" +
                    "<td>"+ vrVisit.VisitNo+"</td>"+
                    "<td>" + vrVisit.CustomerName + "</td>" +
                    "<td>" + vrVisit.Unit + " </td>" +
                    "<td>" + vrVisit.Group + " </td>" +
                    "<td>" + vrVisit.Employee + "</td>" +
                    "<td>" + vrVisit.Desc + "</td>" +
                    "<td>" + vrVisit.VisitType + "</td>" +
                    "</tr>";

            }
           

            document.getElementById("tblFreeVisitDisplay").innerHTML = strTemp;
        }
        var arrNonBroadCasted = [];
        for (var vrIndex = 0; vrIndex < arrPicked.length
            ; vrIndex++)
        {
            vrVisit = arrPicked[vrIndex];
            if (!vrVisit.IsBroadCasted
                && vrVisit.VisitNo != 0 
                &&vrVisit.WindowNo!=0
              
            )
            {
                arrNonBroadCasted[arrNonBroadCasted.length] = vrVisit;
               
            }
        }
        if (arrNonBroadCasted.length > 0)
        {
            try {
                BroadCastMultipleVisit(arrNonBroadCasted);
            }
            catch (e)
            {
                setTimeout(OnVisit, 5000);
            }
        }
        else
          setTimeout(OnVisit, 5000);
    }

    
    function errorFunc(jqXHR, textStatus, errorThrown)
    {
        setTimeout(OnVisit, 30000);
    }
   

}
function BroadCastMultipleVisit(arrVisit)
{
    var arrVSrc = [];
    var vrVisit;
    var vrAudioIndex;
    for (var vrVisitIndex = 0; vrVisitIndex < arrVisit.length; vrVisitIndex++)
    {
        vrVisit = arrVisit[vrVisitIndex];

        vrAudioIndex = vrVisitIndex * 4;
        arrVSrc[vrAudioIndex] = '../Records/Customer.wav';
        arrVSrc[vrAudioIndex + 1] = '../Records/' + vrVisit.VisitNo + '.wav';
        arrVSrc[vrAudioIndex + 2] = '../Records/Window.wav';
        arrVSrc[vrAudioIndex + 3] = '../Records/' + vrVisit.WindowNo + '.wav';


    }
    var objPlayingObject = document.createElement("AUDIO");
    var vrIndex = 0;
    objPlayingObject.setAttribute("autoPlay", "false");
    document.body.appendChild(objPlayingObject);
    objPlayingObject.setAttribute("id", "objPlayingObject");
    
    
    
    PlayLst();
    function PlayLst()
    {
         
        if (vrIndex >= arrVSrc.length)
        {
            //REmove To cLean the dom
            objPlayingObject.remove();
            setTimeout(OnVisit, 5000);
        }
        else
        {
            if (vrIndex % 4 == 3)
            {
                
                BroadCastVisit(vrVisit.ID);

            }

            //objPlayingObject.setAttribute("src", arrVSrc[vrIndex]);
            
            try {
                if ((vrIndex % 4 != 3 && vrIndex % 4 != 2)
                    || vrVisit.WindowNo > 0) {
                    objPlayingObject.src = arrVSrc[vrIndex];
                    objPlayingObject.play();

                    objPlayingObject.onended = function () {

                        vrIndex++;
                        PlayLst();

                    };
                }
                else
                {
                    vrIndex++;
                    setTimeout(PlayLst, 200);
                }
                
            }
            catch (e)
            {
                var vrText = e.message;
                alert(vrText);
                vrIndex++;
                setTimeout(PlayLst, 1000);
            }
            

        }
    }

}
function BroadCastVisit(vrVisitID)
{
   
   
    var objVisit = '{ "strVisitID": "' + vrVisitID + '"}';
    var vrServiceUrl = "../api/VisitWebController/BroadCastVisit?strVisitID="+vrVisitID;
    $.ajax({
        type: "GET",
        url: vrServiceUrl,
       async:false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        
        success: function (response) {
           
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

}
function SaveNewVisit()
{
    var strPhone = document.getElementById("txtPhoneNo").value;
    var strBranch = document.getElementById("txtBranchID").value;
    var strType = document.getElementById("cmbVisitType").value;
    var strGroup = document.getElementById("cmbVisitType").getAttribute("workGroupValue");
    var vrAllVisiType = JSON.parse(strGroup);
    var vrVisitTypeArr = vrAllVisiType.filter(function (objX) {return objX.ID == strType });
    if (vrVisitTypeArr.length == 0)
        return;
    strGroup = vrVisitTypeArr[0].WorkGroup;
    var objVisit = { Branch: strBranch, Group: strGroup, VisitType: strType };
    var vrServiceUrl = "../api/VisitWebController/NewVisit";
    $.ajax({
        type: "POST",
        url: vrServiceUrl,
        data: JSON.stringify(objVisit),
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (response) {
            var vrVisitNo = response;

        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

}