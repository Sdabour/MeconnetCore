//SetInstallmentPaymentCheckLabel
//SowPaymentCheckModal
//GetInstallmentCahchePayment
//GetPaymentTypeCmbStr
//CloseCheckModal
//ShowCheckModal
//ClosePaymentModal
//ShowPaymentModal
//ShowInstallmentPaymentModal
class PaymentSimple
{
    public ID: number;
    public InstallmentID: number;
    public Installment: InstallmentSimple;
    public ReservationID: number;
    public Value: number;
    public Desc: string;
    public Date: Date;
    public DateStr: string;
    public Type: number;
    public TypeDesc: string;
    public CheckID: number;
    public CheckNo: string;
    public CheckDueDate: Date;
    public CheckValue: number;
    public CheckStatus: number;
    public CheckStatusDate: Date;
    public CheckBankID: number;
    public CheckBankName: string;
    public IsCollected: boolean;
    public CollectingDate: Date;
    public CollectingType: number;
    public CollectingTypeDesc: string;
    public CollectedValue: number;
    public User: number;
    public Branch: number;
    public EMployee: number;
    public ChangePaymentDateAuthorized: boolean;
    
}
function ShowInstallmentPaymentModal(intInstallment:number)
{
    var vrInstallmentLable = document.getElementById("lblInstallment" + intInstallment).getAttribute("value");
    let objInstallment: InstallmentSimple = JSON.parse(vrInstallmentLable);
    let vrDiv: string = "";
    vrDiv = "<div class=\"form-row\">";
    vrDiv += "<input type=\"hidden\" id=\"lblInstallment\" value=\""+intInstallment+"\">";
    vrDiv += "<div class=\"col-2\">" + objInstallment.TypeName + "</div>";
    vrDiv += "<div class=\"col-1\">تاريخ استحقاق</div><div class=\"col-2\">" + objInstallment.DueDateStr + "</div>";
    vrDiv += "<div class=\"col-1\">قيمة</div><div class=\"col-2\">" + objInstallment.Value + "</div>";
    vrDiv += "<div class=\"col-1\">متبقى</div><div class=\"col-2\">" + objInstallment.RemainingValue + "</div>";
    vrDiv += "</div></br>";
    vrDiv += "<div class=\"form-row\"></div>";
    vrDiv += "<div class=\"form-row\">";

    vrDiv += "<div class=\"col-1\">القيمة</div><div class=\"col-2\">" +
        "<input type=\"text\" id = \"txtPaymentValue\" name = \"txtPaymentValue\"   placeholder = \"Not Assigned\" value = \"" + objInstallment.RemainingValue + "\">" +
        "</div>";
    vrDiv += "<div class=\"col-1\">نوع السداد</div><div class=\"col-2\">" + GetPaymentTypeCmbStr("cmbPaymentType") + "</div>";
    vrDiv += "<div class=\"col-2\"><input type=\"button\" name=\"btnAddPayment\" id=\"btnAddPayment\" value=\"سداد\" onclick=\"return AddInstallmentPayment();\"></div>";
   vrDiv += "</div></br>";
    
    //lblInstallmentCheckID,lblInstallmentCheckCode,lblInstallmentCheckDate,lblInstallmentCheckBank,lblInstallmentCheckValue
    vrDiv += "<div class=\"form-row\">";
    vrDiv += "<div class=\"col-2\"  id=\"lblInstallmentCheckID\" name=\"lblInstallmentCheckID\"></div>";
    vrDiv += "<div class=\"col-2\" id=\"lblInstallmentCheckCode\" name=\"lblInstallmentCheckCode\"></div>";
    vrDiv += "<div class=\"col-2\"  id=\"lblInstallmentCheckDate\" name=\"lblInstallmentCheckDate\"></div>";
    vrDiv += "<div class=\"col-2\" id=\"lblInstallmentCheckBank\" name=\"lblInstallmentCheckBank\"></div>";
    vrDiv += "<div class=\"col-2\"  id=\"lblInstallmentCheckValue\" name=\"lblInstallmentCheckValue\"></div>";
    
    vrDiv += "</div></br>";
    
    //vrDiv += "</div>";
    vrDiv += "<div class=\"table-responsive\" id=\"dvReservation\">";
    vrDiv += "<table class=\"table\">";
    let objPayment: PaymentSimple;
    for (var vrIndex = 0; vrIndex < objInstallment.PaymentLst.length; vrIndex++)
    {
        objPayment = objInstallment.PaymentLst[vrIndex];
     //   vrDiv += "<div class\"form-row\">";

       // vrDiv += "<div class=\"col-2\">" + objInstallment.PaymentLst[vrIndex].Value + "</div>";

        //vrDiv += "</div>";
        vrDiv += "<tr>";
        vrDiv += "<td><input type=\"hidden\" id=\"lblPayment"+objPayment.ID.toString()+"\" value='"+JSON.stringify(objPayment)+"' />" + objPayment.DateStr + "</td>";
        vrDiv += "<td>" + objPayment.Value + "</td>";
        vrDiv += "<td>" + objPayment.TypeDesc + "</td>";

        vrDiv += "<td>";
        if (objPayment.CheckID > 0 && objPayment.IsCollected) {

            vrDiv += "<input type=\"button\" name=\"btnDisCollectPayment" + objPayment.ID + "\" id=\"btnDisCollectPayment" + objPayment.ID + "\" value=\"الغاء تحصيل\" onclick=\"DisCollectPayment(" + objPayment.ID + ")\"/>";
        }
        else {
            vrDiv += "<input type=\"button\" name=\"btnDeletePayment" + objPayment.ID + "\" id=\"btnDeletePayment" + objPayment.ID + "\" value=\"حذف\" onclick=\"DeletePayment(" + objPayment.ID + ")\"/>";
        }
        vrDiv += "</td>";

        vrDiv += "<td>";
        if (objPayment.CheckID > 0 && !objPayment.IsCollected) {
            vrDiv += "<input type=\"text\" name=\"txtCollectPayment" + objPayment.ID + "\" id=\"txtCollectPayment" + objPayment.ID + "\" value=\""+ objPayment.Value.toFixed(0) +"\" />";
        }
        vrDiv += "</td>";
        vrDiv += "<td>";
        let vrChangePaymentDateAuthorized: boolean = GetChangePaymentDateAuthorized();
        if (objPayment.CheckID > 0 && !objPayment.IsCollected && vrChangePaymentDateAuthorized) {

            vrDiv += "<input type=\"date\" name=\"dtCollectPayment" + objPayment.ID + "\" id=\"dtCollectPayment" + objPayment.ID + "\"/>";
        }
        vrDiv += "</td>";
        vrDiv += "<td>";
        if (objPayment.CheckID > 0)
        {
            if (!objPayment.IsCollected) {
                vrDiv += "<input type=\"button\" name=\"btnCollectPayment" + objPayment.ID + "\" id=\"btnCollectPayment" + objPayment.ID + "\" value=\"تحصيل\" onclick=\"CollectPayment(" + objPayment.ID + ")\"/>";
            }
            else {
         /*       vrDiv += "<input type=\"button\" name=\"btnDisCollectPayment" + objPayment.ID + "\" id=\"btnDisCollectPayment" + objPayment.ID + "\" value=\"الغاء تحصيل\" onclick=\"DisCollectPayment(" + objPayment.ID + ")\"/>";*/
            }
        }
        vrDiv += "</td>";

        vrDiv += "<td>";
        if (objPayment.CheckID > 0) {
            if (!objPayment.IsCollected) {
                vrDiv += "<input type=\"button\" name=\"btnDiscountPayment" + objPayment.ID + "\" id=\"btnDiscountPayment" + objPayment.ID + "\" value=\"خصم\" onclick=\"DiscountCollectedPayment(" + objPayment.ID + ")\"/>";
            }
            else {
                /*       vrDiv += "<input type=\"button\" name=\"btnDisCollectPayment" + objPayment.ID + "\" id=\"btnDisCollectPayment" + objPayment.ID + "\" value=\"الغاء تحصيل\" onclick=\"DisCollectPayment(" + objPayment.ID + ")\"/>";*/
            }
        }
        vrDiv += "</td>";
        vrDiv += "</tr>";
     
    }
    vrDiv += "</table>";
    vrDiv += "</div>";
    (<HTMLElement>document.getElementById("dvPayment")).innerHTML= vrDiv;
    ShowPaymentModal();
}
function ShowPaymentModal() {
    var vrModal = document.getElementById("myPaymentModal");
    vrModal.style.display = "block";
    return false;
}
function ClosePaymentModal() {
    var vrModal = document.getElementById("myPaymentModal");
    vrModal.style.display = "none";
    return false;
}
function ShowCheckModal() {
    var vrModal = document.getElementById("myCheckModal");
    vrModal.style.display = "block";
    return false;
}
function CloseCheckModal() {
    var vrModal = document.getElementById("myCheckModal");
    vrModal.style.display = "none";
    return false;
}
function GetPaymentTypeCmbStr(strID:string): string {
    var Returned: string = "";

    Returned += "<select id=\"" + strID + "\" name=\"" + strID +"\" onchange=\"return SowPaymentCheckModal();\">"+
        "<option value = \"0\" > كاش </option>"+
            "<option value = \"1\" > شيك </option>"+
             "<option value = \"2\" > تحويل بنكى </option>"+
             "<option value = \"3\" > فيزا </option></select>";
    return Returned;
}

function GetInstallmentCachePayment(intInstallment:number): PaymentSimple
{
    var vrUser: User=GetCurrentUser();
    let strInstallment: string = (<HTMLInputElement>document.getElementById("lblInstallment" + intInstallment)).value;
    var vrChangePaymentAuthorized: boolean = GetChangePaymentDateAuthorized();

    let objInstallment: InstallmentSimple = JSON.parse(strInstallment);
    let vrValue: number = Number((<HTMLInputElement>document.getElementById("txtInstallmentValue"+objInstallment.ID)).value);
    let Returned: PaymentSimple = new PaymentSimple();
    Returned.Installment = objInstallment;
    Returned.InstallmentID = objInstallment.ID;
    Returned.Value = vrValue;
    Returned.Type = 0;
    Returned.ChangePaymentDateAuthorized = vrChangePaymentAuthorized;
    Returned.Branch = vrUser.Branch;
    Returned.User = vrUser.ID;
    Returned.EMployee = vrUser.EmpID;
    Returned.Date = new Date();
    if (vrChangePaymentAuthorized) {
        var vrStrDate : string= (<HTMLInputElement>document.getElementById("dtPayment" + objInstallment.ID.toString())).value;
        var vrPaymentDate: Date = new Date(vrStrDate== "" ? new Date():new Date(vrStrDate));
        Returned.Date = vrPaymentDate;
    }
    return Returned;
}
function GetInstallmentPayment(): PaymentSimple {
    let strInstallment: string = (<HTMLInputElement>document.getElementById("lblInstallment")).value;
    var vrChangePaymentAuthorized: boolean = GetChangePaymentDateAuthorized();

    strInstallment = (<HTMLInputElement>document.getElementById("lblInstallment" + strInstallment)).value;

    let objInstallment: InstallmentSimple = JSON.parse(strInstallment);
    let vrValue: number = Number((<HTMLInputElement>document.getElementById("txtPaymentValue")).value);
    var vrUser: User = GetCurrentUser();
    let Returned: PaymentSimple = new PaymentSimple();
    Returned.InstallmentID = objInstallment.ID;
    Returned.Value = vrValue;
    Returned.Branch = vrUser.Branch;
    Returned.User = vrUser.ID;
    Returned.EMployee = vrUser.EmpID;
    Returned.Date = new Date();
    Returned.ChangePaymentDateAuthorized = vrChangePaymentAuthorized;

    if (vrChangePaymentAuthorized) {
        var vrPaymentDate: Date = new Date((<HTMLInputElement>document.getElementById("dtPayment" + objInstallment.ID.toString())).value);
        Returned.Date = vrPaymentDate;
    }
    Returned.CheckID = 0;
    Returned.Type = Number
        ((<HTMLInputElement>document.getElementById("cmbPaymentType")).value);
    if (Returned.Type == 1)
    {
        var vrCheck: CheckSimple = new CheckSimple();
        var vrCheckStr: string = (<HTMLInputElement>document.getElementById("lblCurrentCheck")).value;
        if (vrCheckStr != null && vrCheckStr != "")
            vrCheck = JSON.parse(vrCheckStr);
        Returned.CheckID = vrCheck.ID;


    }

    return Returned;
}
function GetPaymentForCollection(intPaymentID:number): PaymentSimple {
    
    var vrChangePaymentAuthorized: boolean = GetChangePaymentDateAuthorized();

    var vrPaymentStr: string = (<HTMLInputElement>document.getElementById("lblPayment" + intPaymentID.toString())).value;

     
    let vrValue: number = Number((<HTMLInputElement>document.getElementById("txtCollectPayment"+intPaymentID.toString())).value);
    var vrUser: User = GetCurrentUser();
    let Returned: PaymentSimple = JSON.parse(vrPaymentStr);
   // Returned.InstallmentID = objInstallment.ID;
    Returned.CollectedValue = vrValue;
    Returned.Branch = vrUser.Branch;
    Returned.User = vrUser.ID;
    Returned.EMployee = vrUser.EmpID;
    Returned.CollectingDate = new Date();
    Returned.ChangePaymentDateAuthorized = vrChangePaymentAuthorized;

    if (vrChangePaymentAuthorized) {
        var vrPaymentDate: Date = new Date((<HTMLInputElement>document.getElementById("dtCollectPayment" + intPaymentID.toString())).value);
        Returned.CollectingDate = vrPaymentDate;
    }
   
    //Returned.Type = Number
    //    ((<HTMLInputElement>document.getElementById("cmbPaymentType")).value);
   

    return Returned;
}
function SetInstallmentPaymentCheckLabel(intIndex: number) {
    var vrAllCheck: CheckSimple[] = [];
    var vrAllCheckStr: string = (<HTMLInputElement>document.getElementById("lblAllCheck")).value;
    if (vrAllCheckStr != null && vrAllCheckStr != "") { vrAllCheck = JSON.parse(vrAllCheckStr); }
    if (vrAllCheck.length > intIndex)
    {

        var vrSimple: CheckSimple = new CheckSimple();
        if(intIndex>-1)
            vrSimple = vrAllCheck[intIndex];
        (<HTMLInputElement>document.getElementById("lblCurrentCheck")).value = JSON.stringify(vrSimple);
        (<HTMLInputElement>document.getElementById("lblInstallmentCheckID")).innerText = vrSimple.ID.toString();
        (<HTMLInputElement>document.getElementById("lblInstallmentCheckCode")).innerText = vrSimple.Code;
        (<HTMLInputElement>document.getElementById("lblInstallmentCheckDate")).innerText = vrSimple.ID ==0?"": vrSimple.DueDate.toString().substring(0, 10);
        (<HTMLInputElement>document.getElementById("lblInstallmentCheckBank")).innerText = vrSimple.BankName;
        (<HTMLInputElement>document.getElementById("lblInstallmentCheckValue")).innerText = vrSimple.Value.toString();

    }
    CloseCheckModal();
}

function SowPaymentCheckModal() {
    var vrCheckStr: string = (<HTMLInputElement>document.getElementById("lblAllCheck")).value;
    var vrChkAll: CheckSimple[] = [];
    if (vrCheckStr != null && vrCheckStr != "")
    {
        vrChkAll = JSON.parse(vrCheckStr);
        if ((<HTMLInputElement>document.getElementById("cmbPaymentType")).value == "1")
            ShowCheckModal();
        else
            CloseCheckModal();
    }

}