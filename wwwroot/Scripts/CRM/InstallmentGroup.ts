class InstallmentGroup
{
    static InstallmentTypeLbl: string="lblInstallmentType";
    
    TotalValue: number;
    InstallmentTypeID: number;
    InstallmentTypeName: string;
    Count: number;
    StartDate: Date;
    PeriodID: number;/*0 then yearly 1 monthly*/
    PeriodName: string;/**/
    InstallmentLst: InstallmentSimple[];
    constructor() { }
    SetData(dblTotalValue: number, intInstallmentType: number,strInstallmentTypeName:string, intCount: number, dtStartDate: Date, intPeriodID: number)
    {
        this.TotalValue = dblTotalValue;
        this.InstallmentTypeID = intInstallmentType;
        this.InstallmentTypeName = strInstallmentTypeName;
        this.Count = intCount;
        this.StartDate = dtStartDate;
        this.PeriodID = intPeriodID;

    }
    SetNewInstallmentLst()
    {
        let Returned: InstallmentSimple[];
        let vrRemaining: number;
        vrRemaining = this.TotalValue;
        let vrValue: number;
        vrValue = vrRemaining / this.Count;
        var vrIndex: number;
        var vrDate: Date;
        let vrMonthes: number;
        vrMonthes = 1;
        let objSimple: InstallmentSimple;
        let vrTypeStr: string;
        vrTypeStr = document.getElementById(InstallmentGroup.InstallmentTypeLbl).getAttribute("value");
        let objInstallmentTypeCol: InstallmentType[];
        objInstallmentTypeCol = JSON.parse(vrTypeStr);
        let objInstallmentType: InstallmentType;
        let objTempTypeCol: InstallmentType[];
        objTempTypeCol = objInstallmentTypeCol.filter(x => { return x.ID == this.InstallmentTypeID; });
        objInstallmentType = objTempTypeCol[0];
        if (objInstallmentType.Period == 0)
            vrMonthes = objInstallmentType.PeriodAmount * 12;
        else
            vrMonthes = objInstallmentType.PeriodAmount;
        vrDate = this.StartDate;
        let vrCurrentMonth: number;
        vrDate = new Date(this.StartDate.toString());
        vrCurrentMonth = vrDate.getMonth();
        this.InstallmentLst = [];
        while (vrRemaining >= 1)
        {
            vrRemaining -= vrValue;
            let objSimple = new InstallmentSimple();
            objSimple.Value = vrValue;
           
            objSimple.DueDate =new Date (vrDate.toString());
            vrCurrentMonth = vrDate.getMonth();
            /*vrDate = new Date(vrDate.getFullYear(),  vrDate.setMonth(vrDate.getMonth() + vrMonthes));*/
            vrCurrentMonth += vrMonthes;
            vrDate.setMonth(vrCurrentMonth);
            objSimple.TypeID = objInstallmentType.ID;
            objSimple.TypeName = objInstallmentType.NameA;
            this.InstallmentLst[this.InstallmentLst.length] = objSimple;
            
            //vrIndex++;
        }

       // this.AddNewGroup(this);
    }
    AddNewGroup(objInstallmentGroup:InstallmentGroup)
    {
        var vrInstallmentGroupStr: string;
        vrInstallmentGroupStr = document.getElementById("lblInstallmentGroup").getAttribute("value");
        var vrInstallmentGroupLst: InstallmentGroup[];
        if (vrInstallmentGroupStr != "") {
            vrInstallmentGroupLst = JSON.parse(vrInstallmentGroupStr);

        }
        else
            vrInstallmentGroupLst = [];
        vrInstallmentGroupLst[vrInstallmentGroupLst.length] = objInstallmentGroup;
        vrInstallmentGroupStr = JSON.stringify(vrInstallmentGroupLst);
        document.getElementById("lblInstallmentGroup").setAttribute("value", vrInstallmentGroupStr);
        this.FillInstallmentGroupTable();

    }
     
    FillInstallmentGroupTable()
    {
        var vrInstallmentGroupStr: string;
        if (document.getElementById("lblInstallmentGroup") == null)
            return;
        vrInstallmentGroupStr = document.getElementById("lblInstallmentGroup").getAttribute("value");
        var vrInstallmentGroupLst: InstallmentGroup[];
        let intIndex: number;
        let Returned: string;
        let vrObjID: string;

        Returned = "<table class=\"table\">";
        if (vrInstallmentGroupStr != "") {
            vrInstallmentGroupLst = JSON.parse(vrInstallmentGroupStr);
            let objBiz: InstallmentGroup;
            for (intIndex = 0; intIndex < vrInstallmentGroupLst.length; intIndex++) {
                Returned += "<tr>";
                vrObjID = "lblInstallmentGroup"+ intIndex;
                objBiz = vrInstallmentGroupLst[intIndex];
              /*  Returned += "<input type=\"hidden\" id=\"" + vrObjID + "\" value='" + JSON.stringify(objBiz) + "'\>";*/
                Returned += "<td>" + objBiz.Count + "</td>";
                Returned += "<td>" + objBiz.InstallmentTypeName + "</td>";
                Returned += "<td>" + objBiz.TotalValue + "</td>";
                Returned += "<td>" + objBiz.StartDate + "</td>";
                Returned += "<td><input type=\"button\" value=\"اقساط\" id=\"btnShowInstallment" + intIndex + "\"  onclick=\"return ShowModal(" + intIndex + ")\" name=\"btnShowInstallment" + intIndex + "\" /></td>";
                Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDeleteInstallmentGroup" + intIndex + "\"  onclick=\"return onDeleteInstallmentGroupClick(" + intIndex + ")\" name=\"btnDeleteInstallmentGroup" + intIndex + "\" /></td>";
                Returned += "</tr>";
            }

        }
        Returned += "</table>";
       
        document.getElementById("dvSelectedInstallmentType").innerHTML = Returned;
        let objReservation: ReservationSimple = new ReservationSimple();
        let dblRemaining: Number = objReservation.GetRemainingValue();
        (<HTMLInputElement>document.getElementById("txtDevidedValue")).value= dblRemaining.toString();
        /*document.getElementById("txtOneInstallmentValue").setAttribute("value", "0");*/
      
    }
    DeleteInstallmentGroup(intIndex: number)
    {
        var vrInstallmentGroupStr: string;
        vrInstallmentGroupStr = document.getElementById("lblInstallmentGroup").getAttribute("value");

        var vrInstallmentGroupLst: InstallmentGroup[];
        var vrNewInstallmentGroupLst: InstallmentGroup[];
        vrNewInstallmentGroupLst = [];
        if (vrInstallmentGroupStr != "") {
            vrInstallmentGroupLst = JSON.parse(vrInstallmentGroupStr);

        }
        else {
            vrInstallmentGroupLst = [];
            return;
        }
        let objInstallmentGroup: InstallmentGroup;
        let vrIndex: number;
        for (vrIndex = 0; vrIndex < vrInstallmentGroupLst.length; vrIndex++)
        {
            if (vrIndex != intIndex) {
                vrNewInstallmentGroupLst[vrNewInstallmentGroupLst.length] = vrInstallmentGroupLst[vrIndex];
            }
        }
        
        vrInstallmentGroupStr = JSON.stringify(vrNewInstallmentGroupLst);
        document.getElementById("lblInstallmentGroup").setAttribute("value", vrInstallmentGroupStr);
        this.FillInstallmentGroupTable();
    }
    static InstallmentTableStr(objBiz: InstallmentGroup): string
    {
        let Returned: string;
        Returned = "<table  class=\"table\">";
        let intIndex: number;
        for (intIndex = 0; intIndex < objBiz.InstallmentLst.length; intIndex++) {
            Returned += InstallmentSimple.GetDataRow(objBiz.InstallmentLst[intIndex],intIndex);
        }
        Returned += "</table>";
        return Returned;
    }
    static GetInstallmentGroup(intIndex: number):InstallmentGroup
    {
        let Returned: InstallmentGroup;
        Returned = new InstallmentGroup();
        let vrInstallmentGroupStr: string;
        vrInstallmentGroupStr = document.getElementById("lblInstallmentGroup").getAttribute("value");
        let vrInstallmentGroupLst: InstallmentGroup[];
        vrInstallmentGroupLst = [];
        let vrObject: object;
        if (vrInstallmentGroupStr != "") {
           vrObject = JSON.parse(vrInstallmentGroupStr);
             Object.assign(vrInstallmentGroupLst,vrObject)
            if (vrInstallmentGroupLst.length > 0)
                Returned = vrInstallmentGroupLst[intIndex];
        }
        let strInstallmentTable: string;
        strInstallmentTable = InstallmentGroup.InstallmentTableStr(Returned);
        let dvInstallment = document.getElementById("dvInstallment");
        dvInstallment.innerHTML = strInstallmentTable;
        document.getElementById("lblCurrentGroupIndex").setAttribute("value", intIndex.toString());
        return Returned;
    }

}