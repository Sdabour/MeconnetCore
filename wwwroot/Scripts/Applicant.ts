class ApplicantSingle
{
    public Name: string;
   public ID: number;
    public Code: string;
    public Sector: string;
   public  Department: string;
   public Job: string;
    public Processed: boolean;
    public Value: string;
    public ForiegnID: number;
    public IsCurrentApplicant: boolean;
    //intType 0 =>Evaluation 1=>User
    FillApplicantLst(strApplicantLbl: string, strApplicantTble: string, strApplicantCode: string, strApplicantName: string, intStatus: number,intType:number) {
        var vrApplicant = document.getElementById(strApplicantLbl);
        if (vrApplicant == null)
        {
            return;
        }
        var strApplicant = vrApplicant.getAttribute("value");
    if (strApplicant != "") {
        let arrApplicant: ApplicantSingle[] = JSON.parse(strApplicant);
        document.getElementById("lblTotalCount").innerText = arrApplicant.length.toString();
        document.getElementById("lblProcessedCount").innerText = arrApplicant.filter(function (objX) { return objX.Processed;}).length.toString();
        let arrApplicantFilter  :ApplicantSingle[];
        arrApplicantFilter= arrApplicant.filter(x =>
            strApplicantCode == "" || x.Code.indexOf(strApplicantCode) > -1

        );
        arrApplicantFilter = arrApplicantFilter.filter(x =>
            (strApplicantName == "") || (x.Name.indexOf(strApplicantName) > -1) || (x.Code.indexOf(strApplicantName) > -1)

        );
        arrApplicantFilter = arrApplicantFilter.filter(x =>
            (intStatus == 0 || (intStatus == 1 && x.Processed) || (intStatus == 2 && !x.Processed))

        );
        let objSingle :ApplicantSingle;
        let strApplicantRow: string;
        strApplicantRow = "";
        for (var intIndex = 0; intIndex < arrApplicantFilter.length && intIndex <100; intIndex++)
        {
            objSingle = arrApplicantFilter[intIndex];
            strApplicantRow += "<tr  style=\"max-width:100%;text-align:right;line-height:10px;\">";
            strApplicantRow += "<td style=\"padding:5px;\" width=\"10%\">";
            strApplicantRow += objSingle.Code == null ? "&nbsp;" : objSingle.Code;
            strApplicantRow+= "</td>";
            strApplicantRow += "<td style=\"padding:5px;\" align=\"center\" width=\"40%\" dir=\"rtl\">" + objSingle.Name + " </td>";
            strApplicantRow += "<td style=\"padding:5px;\" align=\"center\" width=\"35%\" dir=\"rtl\">" + objSingle.Job  + " </td>";
            strApplicantRow += "<td style=\"padding:5px; \" width=\"5%\" >";
            strApplicantRow += (objSingle.Processed ? "تم" : "X");
           strApplicantRow += "</td>";
            strApplicantRow += "<td style=\"padding:5px;\" width = \"5%\" >";
            strApplicantRow += (objSingle.Value == null ? "&nbsp;" : objSingle.Value);
            strApplicantRow += " </td>";
            strApplicantRow += "<td style=\"padding:5px; \" width=\"5%\">";
            if (!objSingle.IsCurrentApplicant) {
                strApplicantRow += this.GetRef(intType,objSingle);
            }
            strApplicantRow+= "</td>";
            strApplicantRow += "</tr>";
           // strApplicantRow += "</table></td></tr>";
        }
        vrApplicant = document.getElementById(strApplicantTble);
        vrApplicant.innerHTML = strApplicantRow;
        //document.getElementById(strApplicantTble).setAttribute("innerHtml", strApplicantRow);


    }
    }
    GetRef(intType: number,objSingle:ApplicantSingle): string
    {
        let Returned: string;
        
        Returned =window.location.origin;
        if (intType == 0) {
            Returned = "<a href = \"" + Returned + "/ApplicantWorkerEstimation/index?AppID=" + objSingle.ID + "&StatementID=" + objSingle.ForiegnID.toString() + "\">&#1578;&#1602;&#1610;&#1610;&#1605; </a>";
        }
        else if (intType == 1) { Returned = "<a href = \"" + Returned + "/Login/CreateUser?AppID=" + objSingle.ID + "\">مستخدم </a>"; }
        return Returned;
    }
    RadioButtonStr(intID: number):string
    {
        let Returned: string;
        Returned = "";
        Returned += "<div class=\"form - group pt - 2\">"+
            "< label class=\"font-weight-semibold\" > Left stacked styled < /label> "+
                "< div class=\"form-check\" >"+
                    "<label class=\"form-check-label\" >"+
                        "<div class=\"uniform-choice\" > <span class=\"checked\" > <input type=\"radio\" class=\"form-check-input-styled\" name = \"stacked-radio-left\" checked = \"\" data - fouc=\"\" > </span></div >"+
                            "Selected styled"+
                                "< /label>"+
                                "< /div>"+

                              "  < div class=\"form-check\" >"+
                                    "<label class=\"form-check-label\" >"
                                        " <div class=\"uniform-choice\" >  <span><input type=\"radio\" class=\"form-check-input-styled\" name = \"stacked-radio-left\" data - fouc=\"\" > </span></div >"+
                                            "Unselected styled "+
                                                "< /label> "+
                                                " < /div> "+

                                           
                                                                "</div> ";
        return Returned;
    }
}
class EstimationStatementSingle
{   
    public Desc: string;
    public ID: number;
    public Date: Date;
    public IsGlobal: boolean;
}
class ApplicantEstimationStatementSingle
{
    public Applicant: ApplicantSingle;
    public EstimationStatement: EstimationStatementSingle;
    public CostCenter: string;
    public EstimationGroup: string;
    public IsSummary: boolean;
}
class ApplicantEstimationStatementElementSingle {
    public Statement: number;
    public ElementID: number;
    public ElementDesc: string;
    public EstimationValue: number;
    public ElementValue: number;
    public IsFuzzyValue: boolean;
    public FuzzyValue: number;
    public Group: string;
    public GroupPerc: number;
    public GroupOrder: number;
    public GroupName: string;
    public ElementWeight: number;
    SetEstimationTotals(intElementID: number,strNewValue:string)
    {
        let objElementCol: ApplicantEstimationStatementElementSingle[];
        let objElement: ApplicantEstimationStatementElementSingle = new ApplicantEstimationStatementElementSingle();
        let strElementCol: string;
        
        strElementCol = document.getElementById("lblElementCol").getAttribute("value");
        objElementCol = JSON.parse(strElementCol);
        let dblTotal: number = 0;
        let dblTotalRef: number = 0;
        let dblValue: number = 0;
        let dblEstimationValue: number = 0;
        let strEstimationName: string = "txtEstimationValue" + intElementID.toString();
        var objEstimationControl = document.getElementById(strEstimationName);
        let dblElementWeight:number = 0;

        let strValue: string = strNewValue;
        try {
            dblValue = parseFloat(strValue);
        } catch { }
        let objFilterElementCol: ApplicantEstimationStatementElementSingle[];
        objFilterElementCol = objElementCol.filter(x => x.ElementID == intElementID);
        if (objFilterElementCol.length > 0)
        {
            objElement = objFilterElementCol[0];
            
            dblEstimationValue = objElement.ElementValue;
            if (dblValue > dblEstimationValue)
            {
                alert("الدرجة اكبر من المتوقع");
              
                objEstimationControl.innerText = dblEstimationValue.toString();
                dblValue = dblEstimationValue;
            }
             strValue = (dblValue * 100 / objElement.ElementValue).toFixed().toString();
            var objEstimationControl1 = document.getElementById("txtPerc" + intElementID.toString());
          
            objEstimationControl1.innerText = strValue;
            objFilterElementCol[0].EstimationValue = dblValue;
            objFilterElementCol = null;
            objFilterElementCol = objElementCol.filter(x => x.Group == objElement.Group);

            dblValue = 0;
             strValue = "lblGroupValue" + objElement.Group.toString();
            for (var intIndex = 0; intIndex < objFilterElementCol.length; intIndex++)
            {
                if (objFilterElementCol[intIndex].ElementWeight == 0)
                {
                    objFilterElementCol[intIndex].ElementWeight = 100 / objFilterElementCol.length;
                }
                dblValue += (objFilterElementCol[intIndex].EstimationValue / objFilterElementCol[intIndex].ElementValue) * objFilterElementCol[intIndex].ElementWeight;
            }
            document.getElementById(strValue).innerText =  Math.round(dblValue).toString();

        }
        if (objElement.ElementID > 0)
        {
            objEstimationControl = null;
            objFilterElementCol = objElementCol;
            objFilterElementCol = objFilterElementCol.filter(x => x.EstimationValue != -1);
            dblTotal = 0;
            dblTotalRef = 0;
            var objValueElement;
            let dblTotalValue1: number = 0;
            for (var intIndex = 0; intIndex < objFilterElementCol.length; intIndex++)
            {
                objEstimationControl = null;
                objEstimationControl = document.getElementById("chkStopElement" + objFilterElementCol[intIndex].ElementID.toString());
                if (objEstimationControl.getAttribute("checked") == "true")
                    continue;
                objValueElement = null;
                objValueElement = document.getElementById("txtEstimationValue" + objFilterElementCol[intIndex].ElementID.toString());
                let strValue = objValueElement.value;
                dblValue = 0;
                
                try {
                    dblValue = parseFloat(strValue);
                    dblTotal += dblValue;
                    dblTotalRef += objFilterElementCol[intIndex].ElementValue;
                    dblTotalValue1 += (dblValue / objFilterElementCol[intIndex].ElementValue) * objFilterElementCol[intIndex].ElementWeight * (objFilterElementCol[intIndex].GroupPerc/100);
                }
                catch { }
                

            }

            objEstimationControl = null;
            document.getElementById("lblTotalValue").innerText = Math.round( dblTotalValue1).toString();
            document.getElementById("lblTotalPerc").innerText = (dblTotal * 100 / dblTotalRef).toFixed().toString();
            strValue = dblEstimationValue > 0 ? (dblValue *100/ dblEstimationValue).toString() : "";
        
            
        }

    }
}
