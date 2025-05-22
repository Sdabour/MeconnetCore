function SetSubData(intSubID)
{
    var strSubID = "sub" ;
    var strHeaderID = "PageHeader";
    document.getElementById(strSubID).innerHTML = document.getElementById(strSubID + "-" + intSubID).innerHTML;
    document.getElementById(strHeaderID).innerHTML = document.getElementById(strHeaderID + "-" + intSubID).innerHTML;

}