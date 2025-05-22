
function OnReservation() {

    var objParm = { ID: 115, Name: 'Abdo' };
    

    var vrParm = JSON.stringify(objParm); //"{\"strID\":\"0\",\"strName\":\"Sameh\"}";

    var vrServiceUrl = "../api/ReservationWebController/GetReservation";
    var vrStarContractDate = document.getElementById("dtSUBRESContractFrom");
    
    var vrEndContractDate = document.getElementById("dtSUBRESContractTo");
    var vrIsContractDateRange = !Date.parse(vrStarContractDate) && !Date.parse(vrEndContractDate);//!default(vrStarContractDate) && !default(vrEndContractDate);
    var vrStarReservationDate = document.getElementById("dtSUBRESReservationFrom");
    var vrEndReservationDate = document.getElementById("dtSUBRESReservationTo");
    var vrIsReservationDateRange = !Date.parse(vrStarReservationDate) && !Date.parse(vrEndReservationDate);
    var vrName = document.getElementById("txtCustomerName").value;
    var vrCustomerPhone = document.getElementById("txtCustomerPhone").value;
    
    var vrUnitCode = document.getElementById("txtSUBRESUnitCode").value;
    var vrProjectIDs = document.getElementById("SUBRESProjectCheckedCol").value;
    var vrBranchIDs = document.getElementById("SUBRESBranchCheckedCol").value;
    var vrResubmissionIDs = document.getElementById("SUBRESResubmissionTypeCheckedCol").value;
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            blIsContractingDateRange: vrIsContractDateRange
            , dtStartContractingDate :vrStarContractDate
            , dtEndContractingDate: vrEndContractDate
            , blIsReservationDateRange : vrIsReservationDateRange
            , dtReservationDateStart: vrStarReservationDate
            ,dtReservationEnd : vrEndReservationDate
            , strUnitCode: vrUnitCode
            , strProjectIDs : vrProjectIDs
            , strTowerIDs : ''
            , strResubmissionTypeIDs: vrResubmissionIDs
            ,strBranchIDs : vrBranchIDs
        },
        success: successResFunc,
        error: errorResFunc
    });


    function successResFunc(data, status) {


        var strTemp = "<tr height=10>" +
            "<th width= \"23\">" +
            "<input type=\"checkbox\" id=\"chkAllCustomer\" name=\"chkAllCustomer\" onchange=\"ChkChanged('chkAllCustomer', 'chkCustomer', 'CustomerCheckCol')\">" +
            " </th>" +
            "<th width=\"38\"><span lang=\"ar-eg\">&#1603;&#1608;&#1583;</span></th>" +
            "<th width=\"193\"><span lang=\"ar-eg\">&#1575;&#1587;&#1605;</span></th>" +
            "<th width=\"86\"><span lang=\"ar-eg\">&#1605;&#1588;&#1585;&#1608;&#1593;</span></th>" +
            "<th ><span lang=\"ar-eg\">&#1608;&#1581;&#1583;&#1577;</span></th>" +
            "</tr >";
        var vrCustomer;
        var arrCustomer = [];
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            vrCustomer = data[vrIndex];
            strTemp = strTemp + " <tr>  " +
                "<td width=\"23\"> " +
                " <input type=\"checkbox\" id=\"chkCustomer" + vrCustomer._ID + "\" name=\"chkCustomer" + vrCustomer._ID + "\">" +
                "</td><td width=\"38\">" + vrCustomer._ID + "</td> " +
                " <td width=\"193\">" + vrCustomer._Name + "</td> " +
                "<td width=\"86\">" + vrCustomer._Project + "</td> " +
                "<td>" + vrCustomer._UnitCode + "</td>" +
                "</tr>";
            arrCustomer[vrIndex] = vrCustomer._ID;
        }
        document.getElementById("CustomerCheckCol").value = JSON.stringify(arrCustomer);
        var strTemp1 = document.getElementById("CustomerCol");
        document.getElementById("CustomerCol").value = JSON.stringify(data);
        document.getElementById("tblCustomerDisplay").innerHTML = strTemp;
    }

    function errorResFunc(jqXHR, textStatus, errorThrown) {
        alert("Error :" + errorThrown);
    }

}

function OnCustomer() {

    var objParm = { ID : 115, Name : 'Abdo' };


    var vrParm = JSON.stringify(objParm); //"{\"strID\":\"0\",\"strName\":\"Sameh\"}";

    var vrServiceUrl = "../api/CustomerWebController/GetCustomer";
    var vrName = document.getElementById("txtCustomerName").value;
    var vrCustomerPhone = document.getElementById("txtCustomerPhone").value;
    var vrCustomerUnit = document.getElementById("txtCustomerUnitCode").value;
    var vrProjectIDs = document.getElementById("CustomerProjectCheckedCol").value;
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',
       
        dataType: 'json',
        data: {
            id: 0, strName: vrName,
            strPhone: vrCustomerPhone, strUnitCode: vrCustomerUnit, strIDNo: '',
            strProjectIDs: vrProjectIDs
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {
      

        var strTemp = "<tr height=10>"+
            "<th width= \"23\">"+
            "<input type=\"checkbox\" id=\"chkAllCustomer\" name=\"chkAllCustomer\" onchange=\"ChkChanged('chkAllCustomer', 'chkCustomer', 'CustomerCheckCol')\">"+
                " </th>"+
                "<th width=\"38\"><span lang=\"ar-eg\">&#1603;&#1608;&#1583;</span></th>"+
                "<th width=\"193\"><span lang=\"ar-eg\">&#1575;&#1587;&#1605;</span></th>"+
                "<th width=\"86\"><span lang=\"ar-eg\">&#1605;&#1588;&#1585;&#1608;&#1593;</span></th>"+
                "<th ><span lang=\"ar-eg\">&#1608;&#1581;&#1583;&#1577;</span></th>"+
                    "</tr >";
        var vrCustomer;
        var arrCustomer = [];
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++)
        {
            vrCustomer = data[vrIndex];
            strTemp = strTemp + " <tr>  " +
                "<td width=\"23\"> " +
                " <input type=\"checkbox\" id=\"chkCustomer" + vrCustomer._ID + "\" name=\"chkCustomer" + vrCustomer._ID + "\">" +
                "</td><td width=\"38\">"+ vrCustomer._ID +"</td> " +
                " <td width=\"193\">" + vrCustomer._Name+"</td> " +
                "<td width=\"86\">"+ vrCustomer._Project +"</td> " +
                "<td>"+ vrCustomer._UnitCode +"</td>" +
                "</tr>";
            arrCustomer[vrIndex] = vrCustomer._ID;
        }
    //tblFreeVisitDisplay
        document.getElementById("tblCustomerDisplay").innerHTML = strTemp;
    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("Error :" + errorThrown);
    }

}
function FillSelectedCustomer() {
    var vrFrame = document.getElementById("CustomerFrame");

    var strCustomer = vrFrame.contentWindow.document.getElementById("CustomerCol").value;
    if (strCustomer == null || strCustomer == "")
        return;
        var vrCustomerCol = JSON.parse(strCustomer);
    var vrSelectedCustomer = [];
    var vrCheck;
    for (var vrIndex = 0; vrIndex < vrCustomerCol.length; vrIndex++)
    {
        vrCheck = vrFrame.contentWindow.document.getElementById("chkCustomer" + vrCustomerCol[vrIndex]._ID);
        if (vrCheck != null && vrCheck.checked) {
            vrSelectedCustomer[vrSelectedCustomer.length] = vrCustomerCol[vrIndex];
        }
    }

    var vrSelectedTable = "";
    var vrCurrentSelectedCustomer = [];
    var strCurrentSelectedCustomer = document.getElementById("SelectedCustomerCol").value;
    if (strCurrentSelectedCustomer != "")
        vrCurrentSelectedCustomer = JSON.parse(strCurrentSelectedCustomer);

    for (var vrIndex = 0; vrIndex < vrSelectedCustomer.length; vrIndex++) {
        vrCurrentSelectedCustomer[vrCurrentSelectedCustomer.length] = vrSelectedCustomer[vrIndex];

      
    }

    for (var vrIndex = 0; vrIndex < vrCurrentSelectedCustomer.length; vrIndex++) {
       

        vrSelectedTable += "<tr>";

        vrSelectedTable += "<td>" + vrCurrentSelectedCustomer[vrIndex]._ID + "</td>";
        vrSelectedTable += "<td>" + vrCurrentSelectedCustomer[vrIndex]._Name + "</td>";
        vrSelectedTable += "<td>" + vrCurrentSelectedCustomer[vrIndex]._IDNo + "</td>";
        vrSelectedTable += "</tr>"
    }


    document.getElementById("tblSelectedCustomer").innerHTML = vrSelectedTable;
    document.getElementById("SelectedCustomerCol").value = JSON.stringify(vrCurrentSelectedCustomer);

}    
/**
 * check all changed
 * @param {any} strCheckAllName
 * @param {any} strCheckPrefix
 * @param {any} strIDsName
 */
function ChkChanged(strCheckAllName, strCheckPrefix, strIDsName)
{
    var objCheckAll = document.getElementById(strCheckAllName);
    var strCheckName;
    var objIDCol = [];
    var strIDs = document.getElementById(strIDsName).value;
    if (strIDs != null && strIDs != "")
    {
        objIDCol = JSON.parse(strIDs);
    }
    var blChecked = document.getElementById(strCheckAllName).checked;
    for (var intIndex = 0; intIndex < objIDCol.length; intIndex++)
    {
        strCheckName = strCheckPrefix + objIDCol[intIndex];
        document.getElementById(strCheckName).checked = blChecked;

    }


}

/**
 * 
 * @param {any} txtFilter ID of txtFilter input
 * @param {any} tblContainer ID of Table Contining the CheckBox and Desc
 * @param {any} strPrefix Prefix presents the prefix of the control naming like Floor or Tower (floor[tblFloor,chkFloor1,txtFloor],Tower[tblTower,chkTower,txtTower])
 * @param {any} txtChecked ID of hidden input storing the checked array 
 */
 function OnTxtFloorChanged(txtFilter,tblContainer,strPrefix,txtChecked)
  {
            var objText = document.getElementById(txtFilter);
            var txtValue = objText.value;
            //alert(txtValue);
            var objTblContainer = document.getElementById(tblContainer);
            var objCheckedText = document.getElementById(txtChecked);

            var strCheckedCol = objCheckedText.getAttribute("value");
            var objCol = JSON.parse(objTblContainer.getAttribute("ObjectCol"));
            var objSelectedCol = [];
           // alert(objCol.length);
            var intNewIndex = 0;
            for (var i = 0; i < objCol.length; i++)
            {
                if (objCol[i].Name.indexOf(txtValue, 0) != -1)
                {
                //objSelectedCol.add(objCol[i]);
                    objSelectedCol[intNewIndex] = objCol[i];
                    intNewIndex++;

                }
            }
            //alert("Selected Length:"+objSelectedCol.length);
            
            var objCheckedCol = [];
            if(strCheckedCol != "")
              objCheckedCol =  JSON.parse(strCheckedCol); 
            var strChecked;
            var strNewTable = "";
            for (var i = 0; i < objSelectedCol.length; i++)
            {
                strChecked = "";
                if (objCheckedCol.indexOf(objSelectedCol[i].ID.toString()) != -1)
                    strChecked = " checked ";
                
                strNewTable += "<tr>";
                strNewTable += "<td>";
                strNewTable += "<input id=\'" + strPrefix + objSelectedCol[i].ID + "\' type=checkbox " + strChecked +    
                " onchange=\"OnCheckChanged(\'"+ strPrefix+ objSelectedCol[i].ID +"\', \'"+ tblContainer +"\',\'"+objSelectedCol[i].ID+"\',\'"+ txtChecked +"\')\" />";
                strNewTable += "</td>";
                strNewTable += "<td>";
                strNewTable += objSelectedCol[i].Name ;
                strNewTable += "</td>";
                strNewTable += "</tr>";
            }
 
             objTblContainer.innerHTML = strNewTable;
}
/**
 * 
 * @param {any} strCheck CheckBox ID
 * @param {any} tblContainer contining table ID
 * @param {any} intID  Item ID presented by checkbox ex(FloorID,TowerID)
 * @param {any} txtChecked hidden Input storing the array of checked ids
 */
function OnCheckChanged(strCheck, tblContainer, intID,txtChecked)
{
    var objContainer = document.getElementById(tblContainer);
    var objChecked = document.getElementById(txtChecked);
    var strCheckedCol = objChecked.getAttribute("value");
    var objCheckedCol;
    if (strCheckedCol == null || strCheckedCol == "") {
        objCheckedCol = [];
    }
    else {
        objCheckedCol = JSON.parse(strCheckedCol);
    }
    var objCheck = document.getElementById(strCheck);
    var valChecked = objCheck.getAttribute("isChecked");
    valChecked = objContainer.getAttribute("id");
   // alert(objCheck.checked);
    if (document.getElementById(strCheck).checked == true) {
        objCheckedCol[objCheckedCol.length] = intID;
    }
    else {
        var intIndex = objCheckedCol.indexOf(intID);
          if (intIndex != -1)
              delete objCheckedCol[intIndex];
        }
  
    strCheckedCol = "";
    if (objCheckedCol.length > 0)
        strCheckedCol = JSON.stringify(objCheckedCol);
    strCheckedCol = strCheckedCol.replace(",null", "")
    strCheckedCol = strCheckedCol.replace("null,", "")
    strCheckedCol = strCheckedCol.replace("null", "")
    //document.getElementById(tblContainer).
    //    setAttribute("CheckedObjectCol", strCheckedCol);
    objChecked.setAttribute("value",strCheckedCol)

    //alert(strCheckedCol);
}



/**
 * 
 * @param {any} txtFilter ID of txtFilter input
 * @param {any} tblContainer ID of Table Contining the CheckBox and Desc
 * @param {any} strPrefix Prefix presents the prefix of the control naming like Floor or Tower (floor[tblFloor,chkFloor1,txtFloor],Tower[tblTower,chkTower,txtTower])
 * @param {any} txtChecked ID of hidden input storing the checked array 
 */
function OnTxtFilterChanged(txtFilter, tblContainer, strPrefix, txtChecked) {
    var objText = document.getElementById(txtFilter);
    var txtValue = objText.value;
    //alert(txtValue);
    var objTblContainer = document.getElementById(tblContainer);
    var objCheckedText = document.getElementById(txtChecked);

    var strCheckedCol = objCheckedText.getAttribute("value");
    var objCol = JSON.parse(objTblContainer.getAttribute("ObjectCol"));
    var objSelectedCol = [];
    // alert(objCol.length);
    var intNewIndex = 0;
    for (var i = 0; i < objCol.length; i++) {
        if (objCol[i].Name.indexOf(txtValue, 0) != -1) {
            //objSelectedCol.add(objCol[i]);
            objSelectedCol[intNewIndex] = objCol[i];
            intNewIndex++;

        }
    }
    //alert("Selected Length:"+objSelectedCol.length);

    var objCheckedCol = [];
    if (strCheckedCol != "")
        objCheckedCol = JSON.parse(strCheckedCol);
    var strChecked;
    var strNewTable = "";
    for (var i = 0; i < objSelectedCol.length; i++) {
        strChecked = "";
        if (objCheckedCol.indexOf(objSelectedCol[i].ID.toString()) != -1)
            strChecked = " checked ";
        strNewTable += "<tr><td>";
        strNewTable += "<label>";
        strNewTable += objSelectedCol[i].Name; 
        strNewTable += "<input id=\'" + strPrefix + objSelectedCol[i].ID + "\' type=checkbox " + strChecked +
            " onchange=\"OnCheckChanged(\'" + strPrefix + objSelectedCol[i].ID + "\', \'" + tblContainer + "\',\'" + objSelectedCol[i].ID + "\',\'" + txtChecked + "\')\" />";
        strNewTable += "<span>";
        strNewTable += "</span>";
        strNewTable += "</label>";
        strNewTable += "</tr></td>";
           }

    objTblContainer.innerHTML = strNewTable;
}
function AlertBranch() {
    var vrBranch = document.getElementById("cmbBranch");
    alert(vrBranch.toString());
    alert(document.getElementById("cmbBranch").ej2_instances[0]);
}
function FillTowerCmb() {
    var vrProjectControl = document.getElementById("Project");

    var vrProjectArr = vrProjectControl.ej2_instances[0].value;
    
    
    
    if (vrProjectArr == null || vrProjectArr.length == 0)
        return;
    var vrProjectID = vrProjectArr[0];

    var vrTower = document.getElementById("lblTower").value;
    var vrTowerLst = JSON.parse(vrTower);
    //alert("Says" + vrProjectID);
    var vrSelectedTowers = vrTowerLst.filter(x => { return x.ForeignKey == vrProjectID; });
    //alert("Says" + vrSelectedTowers.length);
    document.getElementById("Tower").dataSource =vrSelectedTowers;
}
function FillCustomer() {

    var objParm = { ID: 115, Name: 'Abdo' };


    var vrParm = JSON.stringify(objParm); //"{\"strID\":\"0\",\"strName\":\"Sameh\"}";

    var vrServiceUrl = "../api/CustomerWeb/GetCustomer";
    var vrName = document.getElementById("txtCustomerName").value;
    var vrCustomerPhone = document.getElementById("txtCustomerPhone").value;
    var vrCustomerUnit = document.getElementById("txtCustomerUnitCode").value;
    var vrProjectIDs = "";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            id: 0, strName: vrName,
            strPhone: vrCustomerPhone, strUnitCode: vrCustomerUnit, strIDNo: '',
            strProjectIDs: vrProjectIDs
        },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrCustomer;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrCustomerID;
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            strDV += "<tr>";
            vrCustomer = data[vrIndex];
            vrCustomerID = "lblCustomer" + vrCustomer.ID;
            vrRdID = "rdCustomer" + vrCustomer.ID;
            vrRdChecked = "";
            vrRdSpanClass = "";
            if (vrIndex == 0) {
                vrRdChecked = " checked=\"\" ";
                vrRdSpanClass = " class=\"checked\"";
            }
            strDV += "<input type=\"hidden\" id=\"" + vrCustomerID + "\" value='" + JSON.stringify(vrCustomer) + "'\>";
            strDV += "<td>" + vrCustomer._ID + "</td>";



            strDV += "<td>" + vrCustomer._Name + "</td>";


            strDV += "<td>" + vrCustomer._Project + "</td>";
            strDV += "<td>" + vrCustomer._UnitCode + "</td>";
            strDV += "<td>" + vrCustomer._IDNo + "</td>";
            strDV += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnCustomer" + vrCustomer.ID + "\"  onclick=\"return onReturnClick('" + vrCustomerID + "')\" name=\"btnReturnCustomer" + vrCustomer.ID + "\" /></td>";
            strDV += "</tr>";
        }
        strDV += "</table>"
        //alert(strDV);
        var objDvCustomer = document.getElementById("dvCustomer");
        objDvCustomer.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}

function FillMultiCustomer() {


    /*intProject,int intTower, int intFloorID, string strCustomerCode,int intType,int intStatus*/


    var vrServiceUrl = "../api/CustomerWeb/GetSimpleCustomer";
    var vrName = document.getElementById("txtCustomerName").value;
    var vrCustomerPhone = document.getElementById("txtCustomerPhone").value;
    var vrCustomerUnit = document.getElementById("txtCustomerUnitCode").value;
    var vrProjectIDs = "";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            id: 0, strName: vrName,
            strPhone: vrCustomerPhone, strUnitCode: vrCustomerUnit, strIDNo: ''
        },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrCustomer;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrCustomerID;

        let vrCustomerSimple = new CustomerSimple();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {

            strDV += vrCustomerSimple.GetRow(data[vrIndex]);

        }
        strDV += "</table>"
        //alert(strDV);
        var objDvCustomer = document.getElementById("dvCustomer");
        objDvCustomer.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}

function FillUnit() {


    /*intProject,int intTower, int intFloorID, string strUnitCode,int intType,int intStatus*/



    var vrServiceUrl = "../api/UnitWeb/GetUnit";
    var vrName = document.getElementById("txtUnitCode").value;

    var vrProject = document.getElementById("Project").ej2_instances[0].value;

    //alert(vrProject);
   // vrProject = 0;
    var vrTower = document.getElementById("Tower").ej2_instances[0].value;
    var vrFloor = document.getElementById("Floor").ej2_instances[0].value;
    var vrType = 0;// document.getElementById("Type").value;
    if (vrProject == null)
        vrProject = 0;
    if (vrFloor == null)
        vrFloor = 0;
    if (vrTower == null)
        vrTower = 0;
    var vrProjectIDs = "";
    var vrStatus = 0;
    if (document.getElementById("lblUnitStatus") != null)
    {
        vrStatus = document.getElementById("lblUnitStatus").getAttribute("value");

    }
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            intProject: vrProject, intTower: vrTower, intFloorID: vrFloor, strUnitCode: vrName, intType: vrType, intStatus: vrStatus
        },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrUnit;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrUnitID;

        let vrUnitSimple = new UnitSimple();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
          
            strDV += vrUnitSimple.GetRow(data[vrIndex]);

        }
        strDV += "</table>"
        //alert(strDV);
        var objDvUnit = document.getElementById("dvUnit");
        objDvUnit.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}




function FillCheck() {


    /*blDirection,strStatus,intCustomer,strBenificiary,intCheckID,strCheckCode*/


    /*txtCheckID,txtCheckCode,txtCheckBenificiary*/
    var vrServiceUrl = "../api/CheckWebAPI/GetCheck";
    var vrID = document.getElementById("txtCheckID").value;
    var vrIntID = 0;
    if (vrID != "")
        vrIntID = vrID;

    var vrCode = document.getElementById("txtCheckCode").value;
    var vrBenificiary = document.getElementById("txtCheckBenificiary").value;
    var vrDirection = true;
    var vrStatus = "";
    var vrCustomerID = 0;
    var vrProjectIDs = "";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            blDirection:vrDirection, strStatus:vrStatus, intCustomer:vrCustomerID, strBenificiary:vrBenificiary, intCheckID:vrCheckID, strCheckCode:vrCode
        },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrCheck;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrCheckID;

        let vrCheckSimple = new CheckSimple();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {

            strDV += vrCheckSimple.GetRow(data[vrIndex]);

        }
        strDV += "</table>"
        //alert(strDV);
        var objDvCheck = document.getElementById("dvCheck");
        objDvCheck.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}



function AddValue(ValueLabel) {
    var vrSimpleValue = new SimpleValue(0, 0, "", "", 0, new Date(), ValueLabel);
    vrSimpleValue.SetControls(ValueLabel);
    var intTypeID = document.getElementById(vrSimpleValue.cmbLabelType).ej2_instances[0].value;
    if (intTypeID == null)
        intTypeID = 0;
    var strTypeName = document.getElementById(vrSimpleValue.cmbLabelType).value;
    var strDesc = document.getElementById(vrSimpleValue.txtLabelDesc).value;
    var dblValue = document.getElementById(vrSimpleValue.txtLabelValue).value;;
    var dtDate = document.getElementById(vrSimpleValue.dtLabelDate).value;
    var vrValue = new SimpleValue(0, intTypeID, strTypeName, strDesc, dblValue, dtDate, ValueLabel);
    vrValue.AddValueToSelected();
    document.getElementById(vrSimpleValue.txtLabelValue).setAttribute("value", "");
    document.getElementById(vrSimpleValue.txtLabelDesc).setAttribute("value", "");

}

function AddInstallmentGroup()
{
    
    
    var intTypeID = document.getElementById("cmbInstallmentType").ej2_instances[0].value;
    if (intTypeID == "" || intTypeID == 0) { alert("فضلا حدد النوع"); return ; }
    var strTypeName = document.getElementById("cmbInstallmentType").value;
   /* var strDesc = document.getElementById(vrSimpleValue.txtLabelDesc).value;*/
    var dblValue = document.getElementById("txtOneInstallmentValue").value;
    var intCount = document.getElementById("txtInstallmentNo").value;
    var dblTotalValue = document.getElementById("txtDevidedValue").value;
    if (dblTotalValue == "" || dblTotalValue == 0 )
    {
        alert("فضلا حدد القيمة");
        return ;
    }
    var dtStartControl = document.getElementById("dtInstallmentTypeStart");
    var dtStartDate = document.getElementById("dtInstallmentTypeStart").value;
    
    var vrValue = new InstallmentGroup();
    vrValue.SetData(dblTotalValue, intTypeID,strTypeName, intCount, dtStartDate, 0);
    vrValue.SetNewInstallmentLst();
    vrValue.AddNewGroup(vrValue);
    document.getElementById("txtOneInstallmentValue").value="";
    document.getElementById("txtInstallmentNo").value="";
    //document.getElementById("txtDevidedValue").value="";
    //document.getElementById("txtDevidedValue").value="";
}
function ShowModal(intIndex) {
    var vrInstallmentGroup = new InstallmentGroup();       
    vrInstallmentGroup = InstallmentGroup.GetInstallmentGroup(intIndex);
    //var vrStrInstallment = vrInstallmentGroup.GetInstallmentTable();
    //document.getElementById("dvInstallment").innerHTML = vrInstallmentGroup.GetInstallmentTable();
    var InstallmentModal = document.getElementById("myInstallmentModal");
    InstallmentModal.style.display = "block";
    return false;
}
function onDeleteInstallmentGroupClick(intIndex)
{
    var vrValue = new InstallmentGroup();
    vrValue.DeleteInstallmentGroup(intIndex);

}

function OnGridRowSelected(arGs) {
    var vrGrdTag = "#Grid" ;
    try {
        //lblGidIDs
        //lblGridCheckedIDs
        var vrX = arGs.selectedRowIndexes;
        var vrCheckedIDs = [];
        var vrIDs = [];
        var vrIDsStr = document.getElementById("lblGidIDs").value;
        if (vrIDsStr != "") { vrIDs = JSON.parse(vrIDsStr); }

        for (var vrIndex = 0; vrIndex < vrX.length; vrIndex++)
        {
            vrCheckedIDs[vrCheckedIDs.length] = vrIDs[vrX[vrIndex]];

        }
        vrIDsStr = JSON.stringify(vrCheckedIDs);
      
  /*      document.getElementById("lblGridCheckedIDs").setAttribute("value", vrIDsStr);*/
        document.getElementById("lblGridCheckedIDs").value= vrIDsStr;
    }
    catch
    { }
  

}

function FillEMployee() {
    var vrEmployeeSector = 0;
    var vrEmployeeSectorCmbName = "cmbEmployeeSectorLevel";
    for (var vrIndex = 5; vrIndex >= 1; vrIndex--) {
        if (document.getElementById(vrEmployeeSectorCmbName + vrIndex).value > 0) {
            vrEmployeeSector = document.getElementById(vrEmployeeSectorCmbName + vrIndex).value;
            break;
        }
    }


    var objDvEmployee = document.getElementById("dvEmployee");
    objDvEmployee.innerHTML = "";
    var strName = document.getElementById("txtEmployeeName").value;
    var strCode = document.getElementById("txtEmployeeCode").value;

    var objEmpSearch = { ID: 0, Code: strCode, Name: strName, Job: "", EmployeeSector: "" };
    var vrEmpSearch = JSON.stringify(objEmpSearch);
    var objEmp = { strEmpCode: strCode, strEmpName: strName };
    //alert(JSON.stringify(objEmp));
    var vrServiceUrl = "../api/EmployeeWeb/GetEmployee";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intSectorID: vrEmployeeSector, strEmpCode: strCode, strEmpName: strName },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrEmployee;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrEmployeeID;
      //  var vrTempEmp = new Employee();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            strDV += "<tr>";
            vrEmployee = data[vrIndex];
          strDV+=  GetEmployeeRow(vrEmployee);
         
            strDV += "</tr>";
        }
        strDV += "</table>"
        //alert(strDV);
        objDvEmployee.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}
function onSimpleCustomerClick(vrLblName) {

    var vrLbl = document.getElementById(vrLblName).value;

    var vrCustomer = JSON.parse(vrLbl);

    //alert(document.getElementById("lblCustomer").innerText);
    document.getElementById("lblCustomer").innerText = vrCustomer.Name;
    document.getElementById("lblCustomerValue").setAttribute("value", vrLbl);

    var vrModal = document.getElementById("myCustomerModal");
    vrModal.style.display = "none";
    return false;
}