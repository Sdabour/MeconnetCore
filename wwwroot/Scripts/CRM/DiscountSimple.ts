
class DiscountSimple {
    public ID: number;
    public InstallmentID: number;
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
    public User: number;
    public Branch: number;
    public EMployee: number;
}
function ShowInstallmentDiscountModal(intInstallment: number) {
    var vrInstallmentLable = document.getElementById("lblInstallment" + intInstallment).getAttribute("value");
    let objInstallment: InstallmentSimple = JSON.parse(vrInstallmentLable);
    let vrDiv: string = "";
    vrDiv = "<div class=\"form-row\">";
    vrDiv += "<div class=\"col-2\">" + objInstallment.TypeName + "</div>";
    vrDiv += "<div class=\"col-1\">تاريخ استحقاق</div><div class=\"col-2\">" + objInstallment.DueDateStr + "</div>";
    vrDiv += "<div class=\"col-1\">قيمة</div><div class=\"col-2\">" + objInstallment.Value + "</div>";
    vrDiv += "<div class=\"col-1\">متبقى</div><div class=\"col-2\">" + objInstallment.RemainingValue + "</div>";
    vrDiv += "</div></br>";
    
   

    //vrDiv += "</div>";
    vrDiv += "<div class=\"table-responsive\" id=\"dvReservationDiscount\">";
    vrDiv += "<table class=\"table\">";
    let objDiscount: DiscountSimple;
    for (var vrIndex = 0; vrIndex < objInstallment.DiscountLst.length; vrIndex++) {
        objDiscount = objInstallment.DiscountLst[vrIndex];
        //   vrDiv += "<div class\"form-row\">";

        // vrDiv += "<div class=\"col-2\">" + objInstallment.DiscountLst[vrIndex].Value + "</div>";

        //vrDiv += "</div>";
        vrDiv += "<tr>";
        vrDiv += "<td>" + objDiscount.DateStr + "</td>";
        vrDiv += "<td>" + objDiscount.Value + "</td>";
        vrDiv += "<td>" + objDiscount.TypeDesc + "</td>";
        vrDiv += "<td><input type=\"button\" name=\"btnDeleteDiscount" + objDiscount.ID + "\" id=\"btnDeleteDiscount" + objDiscount.ID + "\" value=\"حذف\" onclick=\"DeleteDiscount(" + objDiscount.ID+","+ objDiscount.InstallmentID + ")\"/></td>";
        vrDiv += "</tr>";

    }
    vrDiv += "</table>";
    vrDiv += "</div>";
    (<HTMLElement>document.getElementById("dvDiscount")).innerHTML = vrDiv;
    ShowDiscountModal();
}
function ShowDiscountModal() {
    var vrModal = document.getElementById("myDiscountModal");
    vrModal.style.display = "block";
    return false;
}
function CloseDiscountModal() {
    var vrModal = document.getElementById("myDiscountModal");
    vrModal.style.display = "none";
    return false;
}

 


function GetInstallmentDiscount(intInstallment: number): DiscountSimple {
    let strInstallment: string = (<HTMLInputElement>document.getElementById("lblInstallment" + intInstallment)).value;
    let objInstallment: InstallmentSimple = JSON.parse(strInstallment);
    let vrValue: number = Number((<HTMLInputElement>document.getElementById("txtInstallmentValue" + objInstallment.ID)).value);
   
    let Returned: DiscountSimple = new DiscountSimple();
    Returned.InstallmentID = objInstallment.ID;
    Returned.Value = vrValue;
    Returned.Desc = (<HTMLInputElement>document.getElementById("txtDiscountDesc" + objInstallment.ID)).value;
    Returned.Type = 0;

    return Returned;
}
function GetDiscountTypeCmbStr(strType: string): string {
    var Returned: string;
    var vrDiscountLst:SerializableSimple[] = JSON.parse((<HTMLInputElement>document.getElementById("lblDiscountType")).value);
    Returned = GetSerializableCmbStr(vrDiscountLst, strType);
    return Returned;
}