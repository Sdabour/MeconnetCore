class SimpleValue
{
    /*cmb[ValueLabel]
     lblSelected[ValueLabel]
     dvSelected[ValueLabel]
     txtDesc[ValueLabel]
     txtValue[ValueLabel]
     */
    /*txtTempPaymentValue
cmbTempPaymentType
txtTempPaymentDesc
lblSelectedTempPayment
dvSelectedTempPayment
btnAddTempPayment*/
    public ID: number;
    public TypeID: number;
    public TypeName: string;
    public Desc: string;
    public Value: number;
    public Date: Date;
    public ValueLabel: string;

    public txtLabelValue: string;
    public dtLabelDate: string;
    public cmbLabelType: string;
    public txtLabelDesc: string;
    public lblSelectedLabel: string;
    public lblDeletedLabel: string;
    public dvSelectedLabel: string;
    public btnAddLabel: string;
   
    constructor(intID: number, intTypeID: number, strTypeName: string, strDesc: string, dblValue: number, dtDate: Date, strValueLabel: string)
    {
        this.ID = intID;
        this.TypeID = intTypeID;
        this.TypeName = strTypeName;
        this.Desc = strDesc;
        this.Value = dblValue;
        this.Date = dtDate;
        this.SetControls(strValueLabel);
    }
    SetControls(Label: string) {
        this.ValueLabel = Label;
        this.txtLabelValue = "txt" + Label + "Value";
        this.cmbLabelType = "cmb" + Label + "Type";
        this.txtLabelDesc = "txt" + Label + "Desc";
        this.lblSelectedLabel = "lblSelected" + Label;
        this.lblDeletedLabel = "lblDeleted" + Label;
        this.dvSelectedLabel = "dvSelected" + Label;
        this.btnAddLabel = "btnAdd" + Label;
        this.dtLabelDate = "dt" + Label;
    }
    FillSelectedTable() {
        let objBiz: SimpleValue;
        if (document.getElementById(this.lblSelectedLabel) == null)
            return;
        let vrSelectedStr = document.getElementById(this.lblSelectedLabel).getAttribute("value");
        let vrSelectedLst: SimpleValue[];
        vrSelectedLst = JSON.parse(vrSelectedStr);

        let Returned: string;
        Returned = "<table class=\"table\">";
        let vrUnitID: string;
        let intIndex: number;
        for (intIndex = 0; intIndex < vrSelectedLst.length; intIndex++) {
            Returned += "<tr>";
             objBiz = vrSelectedLst[intIndex];
            vrUnitID = "lblUnit" + objBiz.ID;
            Returned += "<input type=\"hidden\" id=\"" + vrUnitID + "\" value='" + JSON.stringify(objBiz) + "'\>";
            Returned += "<td>" + objBiz.ID + "</td>";


            Returned += "<td>" + objBiz.TypeName+ "</td>";
            Returned += "<td>" + objBiz.Desc + "</td>";



            Returned += "<td>" + objBiz.Value + "</td>";
            Returned += "<td>" + objBiz.Date + "</td>";

            Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDelete"+this.ValueLabel + intIndex + "\"  onclick=\"return onDeleteValueClick('" +this.ValueLabel+"',"+ intIndex + ")\" name=\"btnDelete"+this.ValueLabel + intIndex + "\" /></td>";
            Returned += "</tr>";
        }
        Returned += "</table>";
        document.getElementById(this.dvSelectedLabel).innerHTML = Returned;
        let objReservation: ReservationSimple = new ReservationSimple();
        let dblRemaining: Number = objReservation.GetRemainingValue();
        if (document.getElementById("txtDevidedValue") != null) {
            (<HTMLInputElement>document.getElementById("txtDevidedValue")).value = dblRemaining.toString();
        }
        return Returned;
    }
    AddValueToSelected() {
        var vrSelectedLbl = document.getElementById(this.lblSelectedLabel);
        let vrSelectedStr = vrSelectedLbl.getAttribute("value");
        let vrSelectedLst: SimpleValue[];
        if (vrSelectedStr != "")
            vrSelectedLst = JSON.parse(vrSelectedStr);
        else
            vrSelectedLst = [];

        let objBiz: SimpleValue;
        //let strDate = document.getElementById(this.dtLabelDate);
        //objBiz.TypeID = parseInt(document.getElementById(this.cmbLabelType).ej2_instances[0].value);
        //let strDateValue: string;
        //strDateValue = strDate.getAttribute("value");
        //objBiz.Date =new Date(document.getElementById(this.dtLabelDate).getAttribute("value"));
        //objBiz.Desc = document.getElementById(this.txtLabelDesc).getAttribute("value");
        //objBiz.Value = parseFloat(document.getElementById(this.txtLabelValue).getAttribute("value"));
        //objBiz.TypeID = parseInt(document.getElementById(this.cmbLabelType).getAttribute("value"));

        if (vrSelectedLst.filter(x =>x.ID >0&& x.ID == this.ID).length == 0) {
            vrSelectedLst[vrSelectedLst.length] = this;
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
            this.FillSelectedTable();
            document.getElementById(this.txtLabelValue).setAttribute("value", "0");
            document.getElementById(this.txtLabelDesc).setAttribute("value", "");
        }

    }
    DeleteValue(strLabel: string, intIndex: number)
    {
        let objBiz: SimpleValue;
        this.ValueLabel = strLabel;
        var vrSelectedLbl = document.getElementById(this.lblSelectedLabel);
        var vrDeletedLbl = document.getElementById(this.lblDeletedLabel);
        let vrSelectedStr: string = vrSelectedLbl.getAttribute("value");
        let vrDeletedStr: string = vrDeletedLbl.getAttribute("value");

        let vrSelectedLst: SimpleValue[];
        let vrDeletedLst: SimpleValue[];
        vrDeletedLst = [];
        if (vrDeletedStr != null && vrDeletedStr != "")
        {
            vrDeletedLst = JSON.parse(vrDeletedStr);

        }
        let vrNewSelectedLst: SimpleValue[];
        vrNewSelectedLst = [];
        vrSelectedLst = JSON.parse(vrSelectedStr);
        if (vrSelectedLst.length > intIndex)
        {
            let vrIndex: number;
            for (vrIndex = 0; vrIndex < vrSelectedLst.length; vrIndex++) {
                objBiz = vrSelectedLst[vrIndex];
                if (intIndex != vrIndex) {


                    vrNewSelectedLst[vrNewSelectedLst.length] = objBiz;
                }
                else if (objBiz.ID != 0){
                   
                        vrDeletedLst[vrDeletedLst.length] = objBiz;
                    
                }
            }
                vrSelectedLbl.setAttribute("value", JSON.stringify(vrNewSelectedLst));
                vrDeletedLbl.setAttribute("value", JSON.stringify(vrDeletedLst));
                this.FillSelectedTable();
            }

        
    }

}
function onDeleteValueClick(strLabel, inTIndex) {
    var vrSimpleValue = new SimpleValue(0, 0, "", "", 0, new Date("2023-01-01"), strLabel);
    vrSimpleValue.DeleteValue(strLabel, inTIndex);
}
