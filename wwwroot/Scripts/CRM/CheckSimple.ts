class CheckSimple
{
    public ID: number;
    public Direction: boolean;
    public DirectionDesc: string;
    public EditorName: string;
    public BeneficiaryName: string;
    public Bank: number;
    public BankName: string;
    public Code: string;
    public CodeFrom: number;
    public CodeTo: number;

    public Type: number;
    public TypeName: string;
    public Value: number;
    public CollectedValue: number;
    public TotalPayment: number;
    public Currency: number;
    public CurrencyName: string;
    public IssueDate: Date;
    public  DueDate: Date;
    public DueDateMonthNo: number;

    public PaymentDate: Date;
    public Note: string;
    public CurrentStatus: number;
    public CurrentStatusDesc: string;
    public ParentID: number;
    public IsBankOriented: boolean;
    public IsBankOrientedDesc: string;
    public BankSubmissionDate: Date;
    public Person: number;
    public PersonType: number;
    public GLAccount: number;
    public Customer: number;
    public CustomerName: string;
    public Place: number;
    public PlaceName: string;
    GetRow(objBiz: CheckSimple): string {
        let Returned: string;
       
        Returned = "";
        let vrCheckID: string;
        vrCheckID = "lblCheck" + objBiz.ID;
        let strBtn: string = "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnCheck" + objBiz.ID + "\"  onclick=\"return onReturnCheckClick('" + vrCheckID + "')\" name=\"btnReturnCheck" + objBiz.ID + "\" /></td>"
        Returned += GetCheckInitialRow(objBiz,strBtn);

        return Returned;
    }
    
    GetNewCheckRow(vrIndex:number): string {
        let Returned: string;
        var objBiz: CheckSimple = this;
        Returned = "";
        Returned += "<tr>";
        let vrCheckID: string;
        vrCheckID = "lblCheck" + vrIndex.toString();
        var vrTemp: string = "";
        vrTemp = objBiz.DueDate.toString();
        vrTemp = objBiz.DueDate.toString().substring(0, 10);
    /*    Returned += "<input type=\"hidden\" id=\"" + vrCheckID + "\" value='" + JSON.stringify(objBiz) + "'\>";*/
       


     
        Returned += "<td>" + objBiz.Code + "</td>";



        Returned += "<td>" + objBiz.EditorName + "</td>";
        Returned += "<td>" + objBiz.BeneficiaryName + "</td>";
        
        Returned += "<td><input type=\"number\" id=\"txtCheckValue" + vrIndex.toString() + "\" name=\"txtCheckValue" + vrIndex.toString() + "\"  value=\"" + objBiz.Value + "\"/></td>";
        Returned += "<td> <input type=\"date\" id=\"dtDueDate" + vrIndex.toString() + "\" value=\"" + objBiz.DueDate.toISOString().substring(0, 10) + "\" /></td>";
       
        Returned += "<td><input type=\"button\" id=\"btnEditCheck" + vrIndex.toString() + "\" name=\"btnEditCheck" + vrIndex.toString() + "\" onclick=\"EditCheck(" + vrIndex.toString() + ")\" value=\"E\"/></td>";
        Returned += "</tr>";

        return Returned;
    }
    FillSelectedTable() {
        let objBiz: CheckSimple;
        let vrSelectedStr = document.getElementById("lblSelectedCheck").getAttribute("value");
        let vrSelectedLst: CheckSimple[];
        vrSelectedLst = JSON.parse(vrSelectedStr);

        let Returned: string;
        Returned = "<table class=\"table\">";
        let vrCheckID: string;
        let intIndex: number;
        for (intIndex = 0; intIndex < vrSelectedLst.length; intIndex++) {
            Returned += "<tr>";
            objBiz = vrSelectedLst[intIndex];
            vrCheckID = "lblCheck" + objBiz.ID;
            Returned += "<input type=\"hidden\" id=\"" + vrCheckID + "\" value='" + JSON.stringify(objBiz) + "'\>";
            Returned += "<td>" + objBiz.ID + "</td>";


            Returned += "<td>" + objBiz.ID + "</td>";
            Returned += "<td>" + objBiz.Code + "</td>";



            Returned += "<td>" + objBiz.EditorName + "</td>";

            Returned += "<td>" + objBiz.Value + "</td>";
            Returned += "<td>" + objBiz.DueDate + "</td>";
            Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDeleteCheck" + intIndex + "\"  onclick=\"return onDeleteCheckClick(" + intIndex + ")\" name=\"btnDeleteCheck" + intIndex + "\" /></td>";
            Returned += "</tr>";
        }
        Returned += "</table>";
        document.getElementById("dvSelectedCheck").innerHTML = Returned;
        return Returned;
    }
    AddCheckToSelected(intID: number) {
        var vrSelectedLbl = document.getElementById("lblSelectedCheck");
        let vrSelectedStr = vrSelectedLbl.getAttribute("value");
        let vrSelectedLst: CheckSimple[];

        vrSelectedLst = JSON.parse(vrSelectedStr);
        let objBiz: CheckSimple;
        let vrCheckStr = document.getElementById("lblCheck" + intID).getAttribute("value");
        objBiz = JSON.parse(vrCheckStr);
        if (vrSelectedLst.filter(x => x.ID == objBiz.ID).length == 0) {
            vrSelectedLst[vrSelectedLst.length] = objBiz;
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
            this.FillSelectedTable();
        }

    }
    DeleteCheck(intIndex: number) {
        let objBiz: CheckSimple;
        var vrSelectedLbl = document.getElementById("lblSelectedCheck");
        let vrSelectedStr = vrSelectedLbl.getAttribute("value");
        let vrSelectedLst: CheckSimple[];
        let vrNewSelectedLst: CheckSimple[];
        vrNewSelectedLst = [];
        vrSelectedLst = JSON.parse(vrSelectedStr);
        if (vrSelectedLst.length > intIndex) {
            let vrIndex: number;
            for (vrIndex = 0; vrIndex < vrSelectedLst.length; vrIndex++) {
                if (intIndex != vrIndex) {

                    objBiz = vrSelectedLst[vrIndex];
                    vrNewSelectedLst[vrNewSelectedLst.length] = objBiz;
                }
                vrSelectedLbl.setAttribute("value", JSON.stringify(vrNewSelectedLst));
                this.FillSelectedTable();
            }

        }
    }
    GetCheckCopy(): CheckSimple {

        var Returned: CheckSimple =new CheckSimple();
        Returned.Bank = this.Bank;
        Returned.BankName = this.BankName;
        Returned.BankSubmissionDate = this.BankSubmissionDate;
        Returned.BeneficiaryName = this.BeneficiaryName;
        Returned.Code = this.Code;
        Returned.Currency = this.Currency;
        Returned.CurrencyName = this.CurrencyName;
        Returned.CurrentStatus = this.CurrentStatus;
        Returned.CurrentStatusDesc = this.CurrentStatusDesc;
        Returned.Customer = this.Customer;
        Returned.CustomerName = this.CustomerName;
        Returned.Direction = this.Direction;
        Returned.DirectionDesc = this.DirectionDesc;
        Returned.DueDate =new Date(this.DueDate.toString());
        Returned.DueDateMonthNo = this.DueDateMonthNo;
        Returned.EditorName = this.EditorName;
        Returned.IsBankOriented = this.IsBankOriented;
        Returned.IsBankOrientedDesc = this.IsBankOrientedDesc;
        Returned.IssueDate =new Date(this.IssueDate.toString());
        Returned.Note = this.Note;
        Returned.Place = this.Place;
        Returned.PlaceName = this.PlaceName;
        Returned.Type = this.Type;
        Returned.TypeName = this.TypeName;
        Returned.Value = this.Value;
        return Returned;
    }
    GetCheckLst(): CheckSimple[]
    {
        var Returned: CheckSimple[];
        var vrCheck: CheckSimple;
        Returned = [];
        var vrCheckNo: number = this.CodeFrom;
        var vrCurrentMonth: number;
        var vrDueDate: string =this.DueDate.getDate().toString();
        vrCurrentMonth = this.DueDate.getMonth();
        var vrIndex: number = 0;
        var vrDays: number = 0;
        var vrDate: Date;
        vrDate = this.DueDate;
        while (vrCheckNo <= this.CodeTo)
        {
            let vrCheck = this.GetCheckCopy();
            vrCheck.Code = vrCheckNo.toString();
            /*vrCheck.DueDate.setDate((vrIndex * this.DueDateDaysNo));*/

            /*vrDate = new Date(vrDate.getFullYear(),  vrDate.setMonth(vrDate.getMonth() + vrMonthes));*/
            vrCurrentMonth = this.DueDate.getMonth();
            vrCurrentMonth += this.DueDateMonthNo;
            vrDate.setMonth(vrCurrentMonth);
            vrCheck.DueDate = new Date(vrDate.toString());
            Returned[vrIndex] = vrCheck;
            vrIndex++;
            vrCheckNo++;
        }
        return Returned;
    }
}
function CheckCheckValidation() {
    if ((<HTMLInputElement>document.getElementById("EditorName")).value == "") {
        alert("فضلا حدد اسم المحرر");
        return false;
    }
    if ((<HTMLInputElement>document.getElementById("BeneficiaryName")).value == "") {
        alert("فضلا حدد اسم المستفيد");
        return false;
    }
    if ((<HTMLInputElement>document.getElementById("Code")).value == null ||(<HTMLInputElement>document.getElementById("Code")).value == "") {
        alert("فضلا حدد رقم الشيك");
        return false;
    }
    if ((<HTMLInputElement>document.getElementById("Value")).value == null || (<HTMLInputElement>document.getElementById("Value")).value == "" || (<HTMLInputElement>document.getElementById("Value")).value=="0") {
        alert("فضلا حدد قيمة الشيك");
        return false;
    }
    return true;
}
function CheckCheckMultipleValidation() {
    if ((<HTMLInputElement>document.getElementById("lblCheck")).value == "") {
        alert("فضلا حدد مجموعة الشيكات");

        return false;
    }
    var vrCheckLst: CheckSimple[] = [];
    try {
        vrCheckLst = JSON.parse((<HTMLInputElement>document.getElementById("lblCheck")).value);
    } catch { }
    if (vrCheckLst.length == 0)
    {
        alert("فضلا حدد مجموعة الشيكات");
        return false;
    }
    return true;
}
function GetPaymentCheckRow(intIndex: number, objBiz: CheckSimple): string {
    var Returned: string;
    Returned = "";
    var vrBtn: string = "<td><input type=\"button\" value=\"+\" id=\"btnReturnWithCheck" + intIndex + "\"  onclick=\"return SetInstallmentPaymentCheckLabel(" + intIndex + ")\" name=\"btnReturnWithCheck" + intIndex + "\" /></td>";
    var vrAllCheck: CheckSimple[] = [];
    var vrCheckStr: string = (<HTMLInputElement>document.getElementById("lblAllCheck")).value;
    if (vrCheckStr != null && vrCheckStr != "") {
        vrAllCheck = JSON.parse(vrCheckStr);
        if (vrAllCheck.length > intIndex) {
            {
                var vrCheckSimple: CheckSimple = vrAllCheck[intIndex];
                Returned += GetCheckInitialRow(vrCheckSimple, vrBtn);
            }
        }
    }
   
    return Returned;
}
function ReturnCheck(intIndex: number, strAllCheckLbl: string, strCheckLbl: string) {
    var vrCheckLstStr: string = (<HTMLInputElement>document.getElementById(strAllCheckLbl)).value;
    var vrChekLst: CheckSimple[] = JSON.parse(vrCheckLstStr);
    if (vrChekLst.length <= intIndex)
        return;
    var vrBiz: CheckSimple = vrChekLst[intIndex];
    (<HTMLElement>document.getElementById(strCheckLbl)).innerText = vrBiz.Code;

}
function FillPaymentCheckTable():string
{
    var vrCheckLstStr: string = (<HTMLInputElement>document.getElementById("lblAllCheck")).value;
    var vrChekLst: CheckSimple[] = JSON.parse(vrCheckLstStr);
    var Returned = "<table class=\"table\">";
    for (var vrIndex: number = 0; vrIndex < vrChekLst.length; vrIndex++)
    {
      Returned+=  GetPaymentCheckRow(vrIndex, vrChekLst[vrIndex]);
    }
    Returned += "</table>";
    (<HTMLInputElement>document.getElementById("dvCheck")).innerHTML = Returned;
    return Returned;
}
function GetCheckSimpleMultiple(): CheckSimple
{
    var Returned: CheckSimple = new CheckSimple();
    Returned.Bank = Number( (<HTMLInputElement>document.getElementById("Bank")).value);
    Returned.BankName = (<HTMLInputElement>document.getElementById("Bank")).value;
    Returned.BeneficiaryName = (<HTMLInputElement>document.getElementById("BeneficiaryName")).value;
    
    Returned.CodeFrom = Number((<HTMLInputElement>document.getElementById("CodeFrom")).value);
    Returned.CodeTo = Number((<HTMLInputElement>document.getElementById("CodeTo")).value);
    Returned.Currency = Number((<HTMLInputElement>document.getElementById("Currency")).value);
    var vrControl = document.getElementById("Currency");
   
    var vrTemp: string = "";
    vrTemp = (<HTMLInputElement>document.getElementById("Currency")).value;
    Returned.CurrencyName = (<HTMLInputElement>document.getElementById("Currency")).innerText;
    Returned.CurrentStatus = Number((<HTMLInputElement>document.getElementById("lblStatus")).value);//
    var vrCustomerStr: string = (<HTMLInputElement>document.getElementById("lblCustomerValue")).value; 
    var vrCustomer: CustomerSimple = JSON.parse(vrCustomerStr);

  Returned.Customer = vrCustomer.ID;
    Returned.CustomerName = vrCustomer.Name;

    vrTemp = (<HTMLInputElement>document.getElementById("lblDirection")).value;
    Returned.Direction = (<HTMLInputElement>document.getElementById("lblDirection")).value == "true";
    Returned.Direction = true;
    Returned.EditorName = (<HTMLInputElement>document.getElementById("EditorName")).value;
    Returned.IsBankOriented = (<HTMLInputElement>document.getElementById("IsBankOriented")).checked;
    Returned.IssueDate = new Date((<HTMLInputElement>document.getElementById("IssueDate")).value);
    Returned.DueDate = new Date((<HTMLInputElement>document.getElementById("DueDate")).value);
    Returned.Note = (<HTMLInputElement>document.getElementById("Note")).value;
    Returned.Place = Number((<HTMLInputElement>document.getElementById("Coffer")).value);
    Returned.Type = Number((<HTMLInputElement>document.getElementById("Type")).value);
    Returned.Value = Number((<HTMLInputElement>document.getElementById("Value")).value);
    Returned.DueDateMonthNo = Number((<HTMLInputElement>document.getElementById("DueDateMonthNo")).value);
    return Returned;
}
function FillNewMultipleCheck()
{
    var vrCheckSimple: CheckSimple = GetCheckSimpleMultiple();
    var arrCheck: CheckSimple[] = vrCheckSimple.GetCheckLst();
    FillMultipleCheckLst(arrCheck);
}
function FillMultipleCheckLst(arrCheck: CheckSimple[]) {
    var vrCheckLstStr: string = "";
    for (var vrIndex = 0; vrIndex < arrCheck.length; vrIndex++) {
        vrCheckLstStr += arrCheck[vrIndex].GetNewCheckRow(vrIndex);
    }
    document.getElementById("tblCheck").innerHTML = vrCheckLstStr;
    (<HTMLInputElement>document.getElementById("lblCheck")).value = JSON.stringify(arrCheck);
}
function EditCheck(vrIndex: number)
{
     
    var vrCheck: CheckSimple = new CheckSimple();
    var vrCheckStr: string = (<HTMLInputElement>document.getElementById("lblCheck")).value;
    var vrCheckLst:CheckSimple[] = JSON.parse(vrCheckStr);
    if (vrCheckLst.length > 0) {
        vrCheck = vrCheckLst[vrIndex];
        vrCheck.DueDate = new Date((<HTMLInputElement>document.getElementById("dtDueDate" + vrIndex.toString())).value);
        vrCheck.Value = Number((<HTMLInputElement>document.getElementById("txtCheckValue" + vrIndex.toString())).value);
        vrCheckLst[vrIndex] = vrCheck;
    }
    (<HTMLInputElement>document.getElementById("lblCheck")).value = JSON.stringify(vrCheckLst);
    //FillMultipleCheckLst(vrCheckLst);
    
}

function GetCheckInitialRow(vrCheck:CheckSimple ,strBtns: string): string {
    let Returned: string;

    Returned = "";
    Returned += "<tr>";
    let vrCheckID: string;
    vrCheckID = "lblCheck" + vrCheck.ID;
    Returned += "<input type=\"hidden\" id=\"" + vrCheckID + "\" value='" + JSON.stringify(vrCheck) + "'\>";
    


    Returned += "<td>" + vrCheck.ID + "</td>";
    Returned += "<td>" + vrCheck.Code + "</td>";



    Returned += "<td>" + vrCheck.EditorName + "</td>";
    Returned += "<td>" + vrCheck.BeneficiaryName + "</td>";
    Returned += "<td>" + vrCheck.Value + "</td>";
    Returned += "<td>" +  vrCheck.DueDate.toString().substring(0,10) + "</td>";
    Returned += strBtns;
    Returned += "</tr>";

    return Returned;
}