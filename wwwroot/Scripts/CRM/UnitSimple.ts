 class UnitSimple
{
    public ID: number;
     public Code: string;
     public Survey: number;
    public Order: number;
    public TowerID: number;
    public Tower: string;
    public ProjectID: number;
    public Project: string;
    public FloorID: number;
    public Floor: string;
    public StatusStr: string;
    public Customer: string;
    public PricePerMeter: number;
    public TotalPrice: number;
    UnitSimple()
    {
    }
    GetRow(objBiz:UnitSimple): string
    {
        let Returned: string;
        Returned = "";
        Returned += "<tr>";
        let vrUnitID: string;
        vrUnitID = "lblUnit" + objBiz.ID;
        Returned += "<input type=\"hidden\" id=\"" + vrUnitID + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.ID + "</td>";


        Returned += "<td>" + objBiz.Project + "</td>";
        Returned += "<td>" + objBiz.Tower + "</td>";
        Returned += "<td>" + objBiz.Code + "</td>";

        Returned += "<td>" + objBiz.Survey + "</td>";
        
        
        Returned += "<td>" + objBiz.StatusStr + "</td>";
        Returned += "<td>" + objBiz.Customer + "</td>";

        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnUnit" + objBiz.ID + "\"  onclick=\"return onReturnUnitClick('"+vrUnitID +"')\" name=\"btnReturnUnit" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
      
        return Returned;
     }
     FillSelectedTable(){
         let objBiz: UnitSimple = new  UnitSimple();
         let vrSelectedStr = document.getElementById("lblSelectedUnit").getAttribute("value");
         let vrSelectedLst: UnitSimple[] = [];
         if (vrSelectedStr != "") {
             vrSelectedLst = JSON.parse(vrSelectedStr);
         }
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


             Returned += "<td>" + objBiz.Project + "</td>";
             Returned += "<td>" + objBiz.Tower + "</td>";
             Returned += "<td>" + objBiz.Code + "</td>";

             Returned += "<td>" + objBiz.Survey + "</td>";

             


             Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDeleteUnit" + intIndex + "\"  onclick=\"return onDeleteUnitClick(" + intIndex + ")\" name=\"btnDeleteUnit" +intIndex + "\" /></td>";
             Returned += "</tr>";
         }
         Returned += "</table>";
         document.getElementById("dvSelectedUnit").innerHTML = Returned;
         return Returned;
     }
     AddUnitToSelected(intID: number)
     {
         var vrSelectedLbl = document.getElementById("lblSelectedUnit");
         let vrSelectedStr = vrSelectedLbl.getAttribute("value");
         let vrSelectedLst: UnitSimple[];
        
         vrSelectedLst = JSON.parse(vrSelectedStr);
         let objBiz: UnitSimple;
         let vrUnitStr = document.getElementById("lblUnit" + intID).getAttribute("value");
         objBiz = JSON.parse(vrUnitStr);
         if (vrSelectedLst.filter(x => x.ID == objBiz.ID).length == 0) {
             vrSelectedLst[vrSelectedLst.length] = objBiz;
             vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
             this.FillSelectedTable();
         }

     }
     DeleteUnit(intIndex: number)
     {
         let objBiz: UnitSimple;
         var vrSelectedLbl = document.getElementById("lblSelectedUnit");
         let vrSelectedStr = vrSelectedLbl.getAttribute("value");
         let vrSelectedLst: UnitSimple[];
         let vrNewSelectedLst: UnitSimple[];
         vrNewSelectedLst = [];
         vrSelectedLst = JSON.parse(vrSelectedStr);
         if (vrSelectedLst.length > intIndex)
         {
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