class InstallmentSimple
{
    ID: number;
    TypeID: number;
    TypeName: string;
    DueDate: Date;
    DueDateStr: string;
    Value: number;
     PaidValue:number;
     DiscountVaue:number;
    RemainingValue:number;
    Note: string = "";
    StatusStr: string = "";

    PaymentLst: PaymentSimple[] = [];
    DiscountLst: DiscountSimple[] = [];
    GetInstallmentPaymentRow(objBiz: InstallmentSimple): string{
        var vrDiscountStr: string = (<HTMLInputElement>document.getElementById("lblDiscountType")).value;
        var blChangeDateAuthorized: boolean = GetChangePaymentDateAuthorized();
        var vrCmbDiscount: string = GetDiscountTypeCmbStr("cmbDiscountType"+objBiz.ID);

        let Returned: string = "";
        Returned += "<div class=\"form-row\" >" +
            "<input type=\"hidden\" id = \"lblInstallment" + objBiz.ID + "\" value = '" + JSON.stringify(objBiz) + "' /> ";
        Returned += "<div class=\"col-1\" >" +
            "<label class=\"label-danger\" style = \"width:100%; text-align:center;background-color:ghostwhite;\">" + objBiz.TypeName + "</label>" +
            "</div>";
        
        Returned += "<div class=\"col-1\" >" +
            "<label class=\"label-danger\" style = \"width:100%; text-align:center;background-color:ghostwhite;\">" +
            objBiz.DueDateStr + "</label></div> ";
        Returned += "<div class=\"col-1\">" +
            "<label class=\"label-danger\" style = \"width:100%; text-align:center;background-color:ghostwhite;\">" +
            objBiz.Value + "</label></div>";
        ///
        if (objBiz.RemainingValue > 0) {
            Returned += "<div class=\"col-1\">" +
                "<input type=\"number\" id = \"txtInstallmentValue" + objBiz.ID + "\" name = \"txtInstallmentValue" + objBiz.ID + "\"  class=\"form-control bg-slate-600 border-slate-600 border-1\" placeholder = \"Not Assigned\" value = \"" + objBiz.RemainingValue + "\">" +
                "</div>";
            if (blChangeDateAuthorized) {
                Returned += "<div class=\"col-2\">";

                Returned += "<input type=\"date\" id = \"dtPayment" + objBiz.ID + "\" name = \"dtPayment" + objBiz.ID + "\"  class=\"form-control\" placeholder = \"Not Assigned\" value = \"" + objBiz.RemainingValue + "\">";

                Returned += "</div>";
            }
            Returned += "<div class=\"col-1\" > " +
                "<input type=\"button\" value = \"سداد\" id = \"btnPay" + objBiz.ID + "\" onclick=\"AddCacheInstallmentPayment(" + objBiz.ID + ")\" />" +
                "</div>";
        }
        else {
            Returned += "<div class=\"col-2\">" + objBiz.StatusStr + "</div>" ;
        }
        ///////
        Returned += "<div class=\"col-1\" > " +
            "<input type=\"button\" value = \"مدفوعات\" id = \"btnInstallmentPayment" + objBiz.ID + "\" onclick=\"return ShowInstallmentPaymentModal(" + objBiz.ID + ");\" />" +
            "</div>";

        Returned += "<div class=\"col-1\" > " +
            vrCmbDiscount + "</div>";


        Returned += "<div class=\"col-1\" > ";
        Returned += "<input type=\"text\" id = \"txtDiscountDesc" + objBiz.ID + "\" name = \"txtDiscountDesc" + objBiz.ID + "\"  class=\"form-control bg-slate-600 border-slate-600 border-1\" placeholder = \"سبب الخصم\" value = \"\">";
       Returned+= "</div>";


        Returned += "<div class=\"col-1\" > " +
            "<input type=\"button\" value = \"خصم\" id = \"btnDiscount" + objBiz.ID + "\" onclick=\"AddInstallmentDiscount(" + objBiz.ID + ")\" />" +
            "</div>";

        Returned += "<div class=\"col-1\" > " +
            "<input type=\"button\" value = \"خصومات\" id = \"btnInstallmentDiscount" + objBiz.ID + "\" onclick=\"return ShowInstallmentDiscountModal(" + objBiz.ID + ");\" />" +
            "</div>";

        Returned += "</div>";
        return Returned;

    }
   static GetDataRow(objBiz:InstallmentSimple,intIndex:number): string
    {
        let Returned: string;
       Returned = "<tr>";
       Returned += "<td>" + (intIndex+1) + "</td>";
        Returned += "<td>" + objBiz.TypeName + "</td>";
       Returned += "<td> <input type+=\"date\" id=\"dtDueDate"+intIndex+"\" value=\"" + objBiz.DueDate.toString().substring(0,10) + "\" /></td>";
        //Returned += "<td>" + objBiz.Value + "</td>";
       Returned += "<td><input type=\"number\" id=\"txtInstallmentValue"+intIndex+"\" name=\"txtInstallmentValue"+intIndex+"\"  value=\""+ objBiz.Value +"\"/></td>";
       // Returned += "<td>" + objBiz.Note + "</td>";
       Returned += "<td><input type=\"text\" id=\"txtInstallmentNote" + intIndex + "\" name=\"txtInstallmentNote" + intIndex + "\"  value=\"" + objBiz.Note + "\"/></td>";
       Returned += "<td><input type=\"button\" id=\"btnEditInstallment" + intIndex + "\" name=\"btnEditInstallment" + intIndex + "\" onclick=\"EditInstallment("+intIndex+")\" value=\"E\"/></td>";
        Returned += "</tr>";
        return Returned;
    }
}

function EditInstallment(intIndex: number)
{
    let intGroup: number;
    intGroup = Number((<HTMLInputElement>document.getElementById("lblCurrentGroupIndex")).value);
    let vrNote: string = (<HTMLInputElement>document.getElementById("txtInstallmentNote" + intIndex.toString())).value;
    let vrDate: Date = new Date((<HTMLInputElement>document.getElementById("dtDueDate" + intIndex.toString())).value);
    let vrValue: number = Number((<HTMLInputElement>document.getElementById("txtInstallmentValue" + intIndex.toString())).value);
    let vrInstallmentGroupLst: InstallmentGroup[];
    let vrInstallmentGroupStr: string = document.getElementById("lblInstallmentGroup").getAttribute("value");
    vrInstallmentGroupLst = JSON.parse(vrInstallmentGroupStr);
    let vrGroup:InstallmentGroup = vrInstallmentGroupLst[intGroup];
   

    let vrInstallment: InstallmentSimple;
    vrInstallment = vrGroup.InstallmentLst[intIndex];
    vrInstallment.Note = vrNote;
    vrInstallment.Value = vrValue;
    vrInstallment.DueDate = vrDate;
    vrInstallmentGroupStr = JSON.stringify(vrInstallmentGroupLst);
    document.getElementById("lblInstallmentGroup").setAttribute("value", vrInstallmentGroupStr);
    vrGroup.FillInstallmentGroupTable();
}
function GetChangePaymentDateAuthorized(): boolean {

    var blChangeDateAuthorized: boolean = true;
    if (document.getElementById("lblChangeDateAuthorized") != null) {
        blChangeDateAuthorized = (<HTMLInputElement>document.getElementById("lblChangeDateAuthorized")).value == "1";
    }
    return blChangeDateAuthorized;
}