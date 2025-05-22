class MeasureAlert {
    public ID: number;
    public Meter: number;
    public MeasureType: number;
    public Time: Date;
    public TimeStr: string;
    public MinValue: number;
    public MaxValue: number;
    public Value: number;
    public Reason: number;
    public ReasonStr: string;
    public Stop: boolean;
    public StopTime: Date;
    public Ack: boolean;
    public Stopped: boolean;
    public AckUser: number;
    public AckTime: Date;
    public StopTimeStr: string;
    public SnoozeTime: Date;
    public EMeasureTypeNameA: string;
    public EMeasureTypeNameE: string;
    public EMeasureTypeUnit: string;
    public EMeasureTypeAccumulated: boolean;
    public EMeterDesc: string;
    public UFN: string;
    public UN: string;
    static context:AudioContext;
    public static oscillator: OscillatorNode;
    static InitializeOscilator() {
        if (this.oscillator == null) {
        this.context = new AudioContext();
            this.oscillator = this.context.createOscillator();
        }
            this.oscillator.type = "sine";
            this.oscillator.frequency.value = 800;
            this.oscillator.connect(this.context.destination);
        //}
    }
    GetRow(objBiz:MeasureAlert): string{
        var Returned = "<tr>";
        Returned += "<td>" + objBiz.EMeterDesc + "</td>";
        Returned += "<td>" + objBiz.EMeasureTypeNameA + "</td>";
        Returned += "<td>" + objBiz.ReasonStr + "</td>";
        Returned += "<td>" + objBiz.TimeStr + "</td>";
        var vrStopStr = !objBiz.Stopped ? "" : (objBiz.Ack ? objBiz.UN : "Stop");
        Returned += "<td>" + vrStopStr + "</td>";
        Returned += "<td>" + objBiz.StopTimeStr + "</td>";
        Returned += "</tr>";
        return Returned;
    }
}
function GetAlertShort(objBiz: MeasureAlert) {
     
    var vrImage: string =objBiz.Stopped ? "success.png" : "warning.png";
    //vrImage = objBiz.Stopped ? "Seen.png" : "Unseen.png";
    //"pnotify""placeholders"
    let Returned: string = "<li class=\"media\">" +
        "<div class=\"md-3 position-relative\" >" +
        "<img src=\"../wwwroot/images/pnotify/" + vrImage + "\" width = \"36\" height = \"36\" class=\"rounded-circle\" style=\"width: 18px; height: 18px;\" alt = \"\" >" +
        "</div>";
    
        Returned += "<div class=\"media-body\">" +
        "<div class=\"media-title\" >";
   
    Returned += "<span class=\"font-weight-semibold\" >" + objBiz.EMeasureTypeNameA + " </span>" +
        "<span class=\"text-muted float-right font-size-sm\" > " + objBiz.TimeStr + " </span>" +

        "</div>" +
        "<span class=\"text-muted\">" + objBiz.EMeterDesc + "</span>" ;
    if (!objBiz.Stopped) {
        Returned += "<a href=\"#\" onclick=\"ShowLogInModal(" + objBiz.ID + ")\" >-Ack-</a>";

      
    }
    Returned += "</div></li>";
    return Returned;
}
function OldBeep1() {
    var context = new AudioContext();
    var oscillator = context.createOscillator();
    oscillator.type = "sine";
    oscillator.frequency.value = 800;
    oscillator.connect(context.destination);
    oscillator.start();
   // oscillator.stop();
}
function Beep() {
    MeasureAlert.InitializeOscilator();
    MeasureAlert.oscillator.start();
    //setTimeout(function () {
    //    MeasureAlert.oscillator.stop();
    //}, 100);
}
function Beep21() {
    var vrSnd = new Audio("beep-12.wav");
    vrSnd.play();
}
function StopBeep() {
    //MeasureAlert.InitializeOscilator();
    try {
        MeasureAlert.oscillator.stop();
    } catch { }
}
function ShowMeasureAlertModal() {
    (<HTMLInputElement>document.getElementById('lblShowMeasureAlertModal')).value = "1";
    document.getElementById("myAlertModal").style.display = "block";
    return false;
}