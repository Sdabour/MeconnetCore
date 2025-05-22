const connection = new signalR.HubConnectionBuilder()
    .withUrl("/algHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.on("ReceiveMessage", (user, message) => {
    //const msg = document.createElement("div");
    //msg.textContent = `${user}: ${message}`;
    //document.getElementById("messages").appendChild(msg);
    OnReceiveMessage(user, message);

});

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();
async function SendM() {
  
    
        const user = document.getElementById("UserName").value;

        const message = document.getElementById("txtMessage").value;
        try {
            await connection.invoke("SendMessage", user, message);
        } catch (err) {
            console.error(err);
        }
    
}
async function OnReceiveMessage(user,message) {
    var vrUser = user.split(":");
    var vrMsgType = "BufV";
    if (vrUser.length > 1) {
        vrMsgType = vrUser[1];
        
        if (vrMsgType == "BufV") {
            try {
                var lstValue = JSON.parse(message);
                SetBufferSingleIDValueLst(lstValue);
            } catch
            {
            }
        }

        else if (vrMsgType == "MoReq") {
            //document.getElementById("txtMessage").value = vrMsgType;
            try {
                AddMoListByRef(JSON.parse(message));
            } catch { }
            return;
        }
        else if (vrMsgType == "EditStatus") {
            try {
                EditMOStatusByID(JSON.parse(message));
            } catch { }
            return;
        }
    }
    
    //var vrMsg = document.getElementById("txtConv").value;
    //vrMsg = user + ":" + message+ "\n" + vrMsg;
    //if (document.getElementById("txtConv") != null) {
    //    document.getElementById("txtConv").value = vrMsg;
    //}
}
function SetBufferSingleIDValueLst(lstValue) {
    if (document.getElementById("chkGroupDateRange") != null && document.getElementById("chkGroupDateRange").checked)
    {
        setTimeout(FillBufferGroup, 1000);
        return;
    }
        for (var vrIndex = 0; vrIndex < lstValue.length; vrIndex++) {
            SetSingleIDValue("lblBufferValue", lstValue[vrIndex]);

    }
}