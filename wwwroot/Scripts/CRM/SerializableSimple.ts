class SerializableSimple {

     ID:number;
    Code:string;
   Name:string;
    ForeignKey: number;
    
}
function GetSerializableCmbStr(arrSerializable: SerializableSimple[],strCmbID:string):string
{
    var Returned: string = "";
    Returned = "<select class=\"form-control form-control-uniform multiselect-filter\" name=\"" + strCmbID + "\" id=\"" + strCmbID + "\">";
    var objBiz : SerializableSimple =new SerializableSimple();
    for (var vrIndex = 0; vrIndex < arrSerializable.length; vrIndex++)
    {
        objBiz = arrSerializable[vrIndex];
        Returned += "<option value="+objBiz.ID +">"+objBiz.Name + "</option>";
    }
    Returned += "</select>";
    return Returned;

}