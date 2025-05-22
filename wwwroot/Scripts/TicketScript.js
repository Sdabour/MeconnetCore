
function OnTicket()
{

 

    var vrServiceUrl = "../api/TicketWebController/GetNewAndAssignedTickets";
    var vrEmployee = document.getElementById("lblEmployeeID").value;
    var vrGroupID = document.getElementById("lblGroupID").value;
    var vrGroupMonitorID = document.getElementById("lblGroupMonitorID").value;
    
    var d = new Date();
    
    if (vrEmployee == null || vrEmployee == "" || vrEmployee == 0)
        return;
    
    document.getElementById("lblClock").innerHTML = d.toLocaleTimeString();
  
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: {
            strEmployee: vrEmployee, strGroup: vrGroupID, strMonitoringGroup:vrGroupMonitorID
        },
        success: successFunc,
        error: errorFunc
    });
  
    
   
    function successFunc(data, status) {
        {
            
            var strTemp = "<tr>" +
                "<th>تاريخ</th>" +
               "<th>نوع</th>"+
                "<th>عميل</th>" +
                "<th>مجموعة</th>" +
                "<th>" +
                "موظف</th>" +
                
                 
                "<th>" +
                "&#1581;&#1575;&#1604;&#1577;" +
                "</th>" +
                "</tr >";
            var vrVisit;
            var vrStyle;
            var arrPicked = data.filter(function (obj) { return obj.NewStatus==1; })
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
                   "<td>"+ vrVisit.TicketType +"</td>"+
                    "<td>" + vrVisit.CustomerName + "</td>" +
                    "<td>" + vrVisit.Group + " </td>" +
                                 
                    "<td>" + vrVisit.Employee + "</td>" +
                    "<td>" + vrVisit.Status + "</td>" +
                    "</tr>";
               
                
            }
            document.getElementById("tblNewTicket").innerHTML = strTemp;
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
            var arrWaiting = data.filter(function (obj) { return obj.NewStatus == 0; })
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
           

            document.getElementById("tblWaitingTicket").innerHTML = strTemp;
        }
             
          setTimeout(OnTicket, 5000);
    }

    
    function errorFunc(jqXHR, textStatus, errorThrown)
    {
        setTimeout(OnTicket, 30000);
    }
   

}
 