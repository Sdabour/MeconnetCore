var SingleIDValue = /** @class */ (function () {
    function SingleIDValue() {
    }
    return SingleIDValue;
}());
function SetSingleIDValue(strPrefix, vrValue) {
    if (document.getElementById(strPrefix + vrValue.ID.toString()) != null) {
        document.getElementById(strPrefix + vrValue.ID.toString()).innerText = vrValue.Value;
    }
}
//# sourceMappingURL=SingleIDValue.js.map