class SingleIDValue {
    public ID: number;
    public Value: string;
}
function SetSingleIDValue(strPrefix: string, vrValue: SingleIDValue) {
    if (document.getElementById(strPrefix + vrValue.ID.toString()) != null) {
        (<HTMLInputElement>document.getElementById(strPrefix + vrValue.ID.toString())).innerText = vrValue.Value;
    }
}