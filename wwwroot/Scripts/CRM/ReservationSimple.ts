class ReservationSimple
{
    ///
    public ID: number;
    public UnitCOde: string;
    public UnitFullName: string;
    public CustomerName: string;
    public StatusStr: string;
    public Project: string;
    public Branch: string;
    public PaidValue: number;
    public RemainingValue: number;
    public SalesMen: string;
    public UsrIns: string;
    public TimIns: string;
    public UsrUpd: string;
    public TimUpd: string;
    ////////////
    TotalValue: number =0;
    ReservationDate: Date;
    ContractingDate: Date;
    DeliveryDate: Date;
    public CancelationDate: Date;
    public CancelationNote: string;
    public CancelationCost: number;
    public PayBackComplete: boolean;
    public PayBackCompleteDate: Date;
    public PayBackCompleteUsr: number;
    public CancelationType: number;
    public CancelationTypeNameA: string;
    public CancelationTypeNameE: string;



    //lblSelectedTempPayment
    TempPaymentLst: SimpleValue[];
    //lblSelectedBonus
    BonusLst: SimpleValue[];
    //lblSelectedUtility
    UtilityLst: SimpleValue[];
    //lblSelectedDiscount
    DiscountLst: SimpleValue[];
    //lblInstallmentGroup
    InstallmentGroupLst: InstallmentGroup[];
    //lblSelectedUnit
    UnitLst: UnitSimple[]=[];
    //lblSelectedCustomer
    CustomerLst: CustomerSimple[] = [];
    EmpLst: Employee[] = [];

    SetLst()
    {
        try {
            var vrControl = parseFloat((<HTMLInputElement>document.getElementById("Value")).value);
            let strValue: string = document.getElementById("Value").getAttribute("value");
            this.TotalValue = parseInt((<HTMLInputElement>document.getElementById("Value")).value);
        } catch {

        }
        let strLst: string;
        //lblSelectedTempPayment
        this.TempPaymentLst = [];
        strLst = document.getElementById("lblSelectedTempPayment").getAttribute("value");
        if (strLst != "")
        {
            this.TempPaymentLst = JSON.parse(strLst);
        }
        //lblSelectedBonus
        this.BonusLst = [];
        if (document.getElementById("lblSelectedBonus") != null) {
            strLst = document.getElementById("lblSelectedBonus").getAttribute("value");
            if (strLst != "") {
                this.BonusLst = JSON.parse(strLst);
            }
        }
        //lblSelectedUtility
        this.UtilityLst = [];
        if (document.getElementById("lblSelectedUtility") != null) {
            strLst = document.getElementById("lblSelectedUtility").getAttribute("value");
            if (strLst != "") {
                this.UtilityLst = JSON.parse(strLst);
            }
        }
        //lblSelectedDiscount
        this.DiscountLst = [];
        if (document.getElementById("lblSelectedDiscount") != null) {
            strLst = document.getElementById("lblSelectedDiscount").getAttribute("value");
            if (strLst != "") {
                this.DiscountLst = JSON.parse(strLst);
            }
        }
        //lblInstallmentGroup
        this.InstallmentGroupLst = [];
        if (document.getElementById("lblInstallmentGroup") != null) {
            strLst = document.getElementById("lblInstallmentGroup").getAttribute("value");
            if (strLst != "") {
                this.InstallmentGroupLst = JSON.parse(strLst);
            }
        }
        this.CustomerLst = [];
        strLst = document.getElementById("lblSelectedCustomer").getAttribute("value");
        if (strLst != "") {
            this.CustomerLst = JSON.parse(strLst);
        }
        this.UnitLst = [];
        strLst = document.getElementById("lblSelectedUnit").getAttribute("value");
        if (strLst != "") {
            this.UnitLst = JSON.parse(strLst);
        }
        this.EmpLst = [];
        strLst = document.getElementById("lblEmployeeValue").getAttribute("value");
        if (strLst != null && strLst != "") {
            var vrEmployee: Employee = JSON.parse(strLst);
            this.EmpLst[this.EmpLst.length] = vrEmployee;
        }

    }
    GetRemainingValue(): number
    {
        let Returned: number;
        this.SetLst();
        let dblTemp: number;
        Returned = parseInt( this.TotalValue.toString());
        Returned = Returned + parseInt((this.BonusLst.length == 0 ? 0 : this.BonusLst.map(x => parseFloat(x.Value.toString())).reduce(function (a, b) { return a + b; })).toString());
        
        dblTemp = parseInt(this.TempPaymentLst.length == 0 ? "0" : this.TempPaymentLst.map(x => parseFloat( x.Value.toString())).reduce(function (a, b) { return a + b; }).toString());
        Returned -= parseInt(this.TempPaymentLst.length == 0 ? "0" : this.TempPaymentLst.map(x => parseFloat(x.Value.toString())).reduce(function (a, b) { return a + b; }).toString());
        Returned += parseInt((this.UtilityLst.length == 0 ? 0 : this.UtilityLst.map(x => parseFloat(x.Value.toString())).reduce(function (a, b) { return a + b; })).toString());
        Returned -= parseInt((this.DiscountLst.length == 0 ? 0 : this.DiscountLst.map(x => parseFloat(x.Value.toString())).reduce(function (a, b) { return a + b; })).toString());
        Returned -= parseInt((this.InstallmentGroupLst.length == 0 ? 0 : this.InstallmentGroupLst.map(x => x.InstallmentLst.length == 0 ? 0 : x.InstallmentLst.map(objIns => parseFloat(objIns.Value.toString())).reduce(function (x, y) { return x + y; })).reduce(function (a, b) { return a + b; })).toString());
        return Returned;
    }
    GetRow(objBiz:ReservationSimple): string
    {
        let Returned: string = "";
        Returned += "<tr>";
        let vrLblReservation = "lblReservation" + objBiz.ID.toString();
        Returned += "<input type=\"hidden\" id=\"" + vrLblReservation + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.ID + "</td>";
        Returned += "<td>" + objBiz.Project + "</td>";
        Returned += "<td>" + objBiz.UnitCOde + "</td>";
        Returned += "<td>" + objBiz.CustomerName + "</td>";
        Returned += "<td>" + objBiz.StatusStr + "</td>";
        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnReservation" + objBiz.ID + "\"  onclick=\"return OnBtnReservationClick(" + objBiz.ID + ",FillReservationSimpleInstallment)\" name=\"btnReturnReservation" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        Returned += "</tr>";
        return Returned;
    }
}
function CheckReservationValidation()
{

    let dtReservation: Date = new Date((<HTMLInputElement>document.getElementById("Date")).value);
    
    let dtContracting: Date = new Date((<HTMLInputElement>document.getElementById("ContractingDate")).value);
    let dtDelivery: Date = new Date((<HTMLInputElement>document.getElementById("DeliveryDate")).value);
    var vrStatus: number = 3;
    try {
        vrStatus = Number((<HTMLInputElement>document.getElementById("lblReservationStatus")).value);
    } catch { }

    if (vrStatus>2&& dtContracting < dtReservation)
    {
        alert("تاريخ التعاقد لا يمكن ان يسبق تاريخ الحجز");
        return false;

    }
    if (vrStatus > 2 && dtDelivery < dtContracting) {
        alert("تاريخ الاستلام لا يمكن ان يسبق تاريخ لتعاقد");
        return false;

    }
    
    let dblRemaining: number;
    let objReservation: ReservationSimple = new ReservationSimple();
    
    dblRemaining = objReservation.GetRemainingValue();
    objReservation.ReservationDate = dtReservation;
    objReservation.ContractingDate = dtContracting;
    objReservation.DeliveryDate = dtDelivery;
    if (objReservation.CustomerLst.length == 0)
    {
        alert("فضلا حدد العملاء");
        return false;
    }
    if (objReservation.UnitLst.length == 0) {
        alert("فضلا حدد الوحدات");
        return false;
    }
    if (vrStatus > 2 &&objReservation.TotalValue <= 0 )
    {
        alert("فضلا حدد القيمة");
        return false;
    }
    if (vrStatus > 2 && dblRemaining>1) {
        alert("فضلا توجد قيمة غير مجدولة");
        return false;
    }
    return true;
}
function CheckDeleteAuthorization() {

    return true;
}
function OnBtnReservationClick(intReservation:number,FillInstallment:Function)
{
    let objReservation: ReservationSimple;
    let strReservation: string =(<HTMLInputElement> document.getElementById("lblReservation" + intReservation)).value;
    objReservation = JSON.parse(strReservation);
    SetReservationData(objReservation);
    FillInstallment();
}
function SetReservationData(objReservation: ReservationSimple)
{
    var lstSelected: ReservationSimple[] = [];
    if ((<HTMLInputElement>document.getElementById("lblSelectedReservation")).value != "") {
        try {
            lstSelected = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedReservation")).value);

        }
        catch { }
    }
    if (lstSelected.filter(function (x) { x.ID == objReservation.ID; }).length == 0)
    {
        lstSelected[lstSelected.length] = objReservation;
    }
    (<HTMLInputElement>document.getElementById("lblSelectedReservation")).value = JSON.stringify(lstSelected);
    (<HTMLInputElement>document.getElementById("lblReservationValue")).value = JSON.stringify(objReservation);
    (<HTMLInputElement>document.getElementById("lblSelectedReservationProject")).innerText = objReservation.Project;
    (<HTMLInputElement>document.getElementById("lblSelectedReservationUnit")).innerText = objReservation.UnitCOde;
   /* (<HTMLInputElement>document.getElementById("lblSelectedReservationUnit")).innerText = objReservation.;*/
    (<HTMLInputElement>document.getElementById("lblSelectedReservationCustomer")).innerText = objReservation.CustomerName;
    (<HTMLInputElement>document.getElementById("lblSelectedReservationStatus")).innerText = objReservation.StatusStr;
    (<HTMLInputElement>document.getElementById("lblSelectedReservationPayment")).innerText = objReservation.PaidValue.toString();
    (<HTMLInputElement>document.getElementById("lblSelectedReservationRemaining")).innerText = objReservation.RemainingValue.toString();
    try {
        SetCancelationData(objReservation);
    } catch { }
    var vrModal = document.getElementById("myReservationModal");
    vrModal.style.display = "none";


}
function SetCancelationData(objReservation: ReservationSimple) {
    try {
        (<HTMLInputElement>document.getElementById("ID")).value = objReservation.ID.toString();
    } catch { }
    try {
        (<HTMLInputElement>document.getElementById("CancelationCost")).innerText = objReservation.CancelationCost.toString();
    } catch { }
    try {
        (<HTMLInputElement>document.getElementById("CancelationNote")).innerText = objReservation.CancelationNote;
    } catch { }
    try {
        (<HTMLInputElement>document.getElementById("CancelationDate")).valueAsDate = objReservation.CancelationDate;
    } catch { }
}
function FillReservationlists()
{
    ValueLabel = "TempPayment";
    vrSimple = new SimpleValue(0, 0, "", "", 0, new Date(), ValueLabel);
    vrSimple.FillSelectedTable();
    
    var vrSimple: SimpleValue;
    var ValueLabel: string;
    ValueLabel = "Bonus";
    vrSimple = new SimpleValue(0, 0, "", "", 0, new Date(), ValueLabel);
    vrSimple.FillSelectedTable();
    ValueLabel = "Utility";
    vrSimple = new SimpleValue(0, 0, "", "", 0, new Date(), ValueLabel);
    vrSimple.FillSelectedTable();
    ValueLabel = "Discount";
    vrSimple = new SimpleValue(0, 0, "", "", 0, new Date(), ValueLabel);
    vrSimple.FillSelectedTable();
    var vrInstallmentGroup: InstallmentGroup = new InstallmentGroup();
    vrInstallmentGroup.FillInstallmentGroupTable();
    var vrCustomer: CustomerSimple = new CustomerSimple();
    vrCustomer.FillSelectedTable();
    
}

function CheckCancelationValidation():boolean {
    var Returned: boolean = true;
    if ((<HTMLInputElement>document.getElementById("ID")).value == "0") {
        alert("حدد العقد او الحجز");
        return false;
    }
   var vrTemp:string = (<HTMLInputElement>document.getElementById("CancelationCost")).value;
    if ((<HTMLInputElement>document.getElementById("CancelationCost")).value == "0") {
        if (!confirm("هل تود حقا جعل المصاريف بصفر")) {
            return false;
        }
    }
    if ((<HTMLInputElement>document.getElementById("lblReservationValue")).value != null && (<HTMLInputElement>document.getElementById("lblReservationValue")).value != "") {
        var objReservation: ReservationSimple = JSON.parse((<HTMLInputElement>document.getElementById("lblReservationValue")).value);

    }
    return Returned;
}