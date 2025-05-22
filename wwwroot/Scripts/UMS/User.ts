class User
{
    public ID: number;
    public Name: string;
    public Password: string;
    public FullName: string;
    public EmpID: number;
    public EmpName: string;
    public Group: number;
    public GroupName: string;
    public IsSystemAdmin: boolean;
    public IsStopped: boolean;
    public EmpCode: string;
    public Job: string;
    public WorkGroup: number;
    public WorkGroupName: string;
    public Sector: string;

    public Branch: number;

   //region xx
 

    //endregion

}
function GetCurrentUser(): User {
    var Returned: User = new User();
    if ((<HTMLInputElement>document.getElementById("lblCurrentSimpleUser")).value != null) {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblCurrentSimpleUser")).value);
    }
    return Returned;
}
function CloseUserLoginModal() {
    document.getElementById("myUserLogInModal").style.display = "none";
   
    return false;
}
function ShowLogInModal(vrAlert:number) {
    (<HTMLInputElement>document.getElementById("lblUMSID")).value = vrAlert.toString();
    document.getElementById("myUserLogInModal").style.display = "block";

}
