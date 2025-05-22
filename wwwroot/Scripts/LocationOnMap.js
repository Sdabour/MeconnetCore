(() => {
    //var vrLang = "";
    //if (navigator.geolocation) {
    //    navigator.geolocation.getCurrentPosition(success, error);
    //} else {
    //    alert("Geolocation is not supported by this browser");
    //}
    var vrLong = document.getElementById("lblLong").value;
    var vrLat = document.getElementById("lblLat").value;
    if (vrLong == null || vrLong == "")
        return;
    getMap(vrLat, vrLong);
})();


function success(position) {
    const latitude = position.coords.latitude;
    const longitude = position.coords.longitude;
    getMap(latitude, longitude);
}
function error() {
    alert("Unable to retrieve location");
}
function DrawLongLatOnMap()
{
    var vrLong = document.getElementById("lblLong").value;
    var vrLat = document.getElementById("lblLat").value;
    if (vrLong == null || vrLong == "")
        return;
    getMap(vrLat, vrLong);
}

function getMap(latitude, longitude) {
    const map = L.map("map").setView([latitude, longitude], 30);
    L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png").addTo(map);
    L.marker([latitude, longitude]).addTo(map);
}