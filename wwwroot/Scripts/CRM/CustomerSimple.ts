class CustomerSimple
{
 
    public ID: number;
    public Name: string;
    public UnitCode: string;
    public TowerCode: string;
    public ProjectCode: string;
    public Project: string;
    public ProjectName: string;
    public Mobile1: string;
    public Mobile2: string;
    public Phone1: string;
    public Phone2: string;
    GetRow(objBiz: CustomerSimple): string {
        let Returned: string;
        Returned = "";
        Returned += "<tr>";
        let vrCustomerID: string;
        vrCustomerID = "lblCustomer" + objBiz.ID;
        Returned += "<input type=\"hidden\" id=\"" + vrCustomerID + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.ID + "</td>";


        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td>" + objBiz.ProjectName + "</td>";



        Returned += "<td>" + objBiz.UnitCode + "</td>";
        Returned += "<td>" + objBiz.Mobile1 + "</td>";
    

        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnCustomer" + objBiz.ID + "\"  onclick=\"return onReturnCustomerClick('" + vrCustomerID + "')\" name=\"btnReturnCustomer" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";

        return Returned;
    }
    FillSelectedTable(){
        let objBiz: CustomerSimple;
        let vrSelectedStr = document.getElementById("lblSelectedCustomer").getAttribute("value");
        let vrSelectedLst: CustomerSimple[];
        vrSelectedLst = JSON.parse(vrSelectedStr);

        let Returned: string;
        Returned = "<table class=\"table\">";
        let vrCustomerID: string;
        let intIndex: number;
        for (intIndex = 0; intIndex < vrSelectedLst.length; intIndex++) {
            Returned += "<tr>";
            objBiz = vrSelectedLst[intIndex];
            vrCustomerID = "lblCustomer" + objBiz.ID;
            Returned += "<input type=\"hidden\" id=\"" + vrCustomerID + "\" value='" + JSON.stringify(objBiz) + "'\>";
            Returned += "<td>" + objBiz.ID + "</td>";


            Returned += "<td>" + objBiz.Name + "</td>";
            Returned += "<td>" + objBiz.UnitCode + "</td>";



            Returned += "<td>" + objBiz.Mobile1 + "</td>";


            Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDeleteCustomer" + intIndex + "\"  onclick=\"return onDeleteCustomerClick(" + intIndex + ")\" name=\"btnDeleteCustomer" + intIndex + "\" /></td>";
            Returned += "</tr>";
        }
        Returned += "</table>";
        document.getElementById("dvSelectedCustomer").innerHTML = Returned;
        //return Returned;
    }
    AddCustomerToSelected(intID: number) {
        var vrSelectedLbl = document.getElementById("lblSelectedCustomer");
        let vrSelectedStr = vrSelectedLbl.getAttribute("value");
        let vrSelectedLst: CustomerSimple[]=[];
        if (vrSelectedStr != "") {
            vrSelectedLst = JSON.parse(vrSelectedStr);
        }
            let objBiz: CustomerSimple;
        let vrCustomerStr = document.getElementById("lblCustomer" + intID).getAttribute("value");
        objBiz = JSON.parse(vrCustomerStr);
        if (vrSelectedLst.filter(x => x.ID == objBiz.ID).length == 0) {
            vrSelectedLst[vrSelectedLst.length] = objBiz;
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
            this.FillSelectedTable();
        }

    }
    DeleteCustomer(intIndex: number) {
        let objBiz: CustomerSimple;
        var vrSelectedLbl = document.getElementById("lblSelectedCustomer");
        let vrSelectedStr = vrSelectedLbl.getAttribute("value");
        let vrSelectedLst: CustomerSimple[];
        let vrNewSelectedLst: CustomerSimple[];
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

}
