

function FillApplicant(intType)
{
    let objApplicant = new ApplicantSingle();
    var objControl = document.getElementById("txtFilterCode").value;
    var strCode = document.getElementById("txtFilterCode").value;
    var strName = document.getElementById("txtFilterName").value;
    if (strCode == null)
        strCode = "";
    if (strName == null)
        strName = "";
    var intStatus = 0;
    if (document.getElementById("rdProcessedOnlyProcessed").checked == true)
        intStatus = 1;
    if (document.getElementById("rdProcessedOnlyNotProcessed").checked == true)
        intStatus = 2;
    objApplicant.FillApplicantLst("lblApplicant","tblApplicant",strCode,strName,intStatus,intType);

}
function SetEstimationTotals(intIntElementID)
{
    let objElement = new ApplicantEstimationStatementElementSingle();
    dblValue = document.getElementById("txtEstimationValue" + intIntElementID).value;
    objElement.SetEstimationTotals(intIntElementID,dblValue);
}