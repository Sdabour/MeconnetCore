var galleryArray = new Array();
var galleryLrgArray = new Array();
var arrIndex = new Array();

var _SubID;
var _DisplayIndex;
//dvImageStr small image str 
//dvLargeImageStr LargeImageStr
//dvImageCount Display Image Count
//imgDisplayPnl the display image +index

function SetSubData(intSubID)
{
   
    _SubID = intSubID;

    var strSubID = "sub";
    var strHeaderID = "PageHeader";
    var strBody = document.getElementById(strSubID + "-" + intSubID).innerHTML.replace("imgDisplayPnlHidden", "imgDisplayPnl");
    while(strBody.indexOf("inner-slider-panel-hidden")!=-1)
    strBody = strBody.replace("inner-slider-panel-hidden", "inner-slider-panel")
    while (strBody.indexOf("inner-slider-content-hidden") != -1)
    strBody = strBody.replace("inner-slider-content-hidden", "inner-slider-content");
    while (strBody.indexOf("inner-slider-image-hidden") != -1)
    strBody = strBody.replace("inner-slider-image-hidden", "inner-slider-image");
    
    while (strBody.indexOf("imgDisplayPnlHidden") != -1)
        strBody = strBody.replace("imgDisplayPnlHidden", "imgDisplayPnl");
   // document.getElementById('bodyHolder_' + strSubID).innerHTML = "";
    document.getElementById('bodyHolder_' + strSubID).innerHTML = strBody; // document.getElementById(strSubID + "-" + intSubID).innerHTML.replace("imgDisplayPnlHidden", "imgDisplayPnl");
    document.getElementById('bodyHolder_'+strHeaderID).innerHTML = document.getElementById(strHeaderID + "-" + intSubID).innerHTML;
 
}
function SetParagraphData(intSubID,strParagraph) {

    SetSubData(intSubID);
    var strSubID = "sub";
    var strHeaderID = "PageHeader";
    var intImageCount = document.getElementById("dvImageCount" + intSubID).innerText;
    var intStart = 0;
    var strImagePnl = "";
    var elmnt;
    var strTemp = "";
    //for (var intIndex = 0; intIndex < intImageCount; intIndex++) {
        elmnt = document.getElementById("dvLargeImageStr" + intSubID );
        strTemp = elmnt.outerHTML;
        elmnt = document.getElementById("dvImageStr" + intSubID );
        strTemp += elmnt.outerHTML;
        strImagePnl = strImagePnl + strTemp;
        
        var intIndex = 0;
    
    elmnt = document.getElementById(strParagraph);
    if (elmnt != null)
    {
        var strNextDev = "<div><a onclick=MovePreviousParagraph("+ intSubID+",'"+strParagraph +"')>[Previous]</a></div>";
        intIndex = elmnt.getAttribute("index");
        strTemp = strNextDev;
        strTemp += elmnt.innerHTML; //document.getElementById('bodyHolder_' + strSubID).innerHTML;
        elmnt = document.getElementById("SubParagraphIDs" + intSubID);
        if (elmnt != null)
            strTemp += elmnt.outerHTML;
        while (strTemp.indexOf("imgDisplayPnlHidden") != -1)
            strTemp = strTemp.replace("imgDisplayPnlHidden", "imgDisplayPnl");
        strNextDev = "<div><a onclick=MoveNextParagraph(" + intSubID + ",'" + strParagraph + "')>[Next]</a></div>";
        strTemp += strNextDev;
        document.getElementById('bodyHolder_' + strSubID).innerHTML = strTemp;//elmnt.innerHTML;
        document.getElementById('bodyHolder_' + strSubID).innerHTML = document.getElementById('bodyHolder_' + strSubID).innerHTML + strImagePnl;
        document.getElementById('bodyHolder_' + strHeaderID).innerHTML = "";
    }
  

}
function MoveNextParagraph(intSubID, strParagraph)
{
    elmnt = document.getElementById("SubParagraphIDs" + intSubID);
    if (elmnt == null)
        return;
    
        var arrIndex = elmnt.innerText.split(";", 50000);
        elmnt = document.getElementById(strParagraph);
        if (elmnt == null)
            return;
        var intIndex = parseInt( elmnt.getAttribute("index"),0);
    
        if (intIndex == null)
            return;
        if (intIndex >= (arrIndex.length-1))
            return;
        intIndex += 1;
        var strNewParagraph =  arrIndex[intIndex].toString();
        strNewParagraph = "s" + strNewParagraph;
        SetParagraphData(intSubID, strNewParagraph);

    
}
function MovePreviousParagraph(intSubID, strParagraph) {
    elmnt = document.getElementById("SubParagraphIDs" + intSubID);
    if (elmnt == null)
        return;

    var arrIndex = elmnt.innerText.split(";", 50000);
    elmnt = document.getElementById(strParagraph);
    if (elmnt == null)
        return;
    var intIndex =parseInt( elmnt.getAttribute("index"));
    if (intIndex == null)
        return;
    if (intIndex <=0)
        return;

    var strNewParagraph = "s" + arrIndex[intIndex - 1].toString();

    SetParagraphData(intSubID, strNewParagraph);


}
function GoToElement1(intSubID, strElementID)
{
 //  SetSubData(intSubID);
    var elmnt = document.getElementById(strElementID);
   
    elmnt.scrollIntoView();
    //$('#' + strElementID).scrollIntoView();

}
function getPosition(el) {
    var xPos = 0;
    var yPos = 0;

    while (el) {
        if (el.tagName == "BODY") {
            // deal with browser quirks with body/window/document and page scroll
            var xScroll = el.scrollLeft || document.documentElement.scrollLeft;
            var yScroll = el.scrollTop || document.documentElement.scrollTop;

            xPos += (el.offsetLeft - xScroll + el.clientLeft);
            yPos += (el.offsetTop - yScroll + el.clientTop);
        } else {
            // for all other non-BODY elements
            xPos += (el.offsetLeft - el.scrollLeft + el.clientLeft);
            yPos += (el.offsetTop - el.scrollTop + el.clientTop);
        }

        el = el.offsetParent;
    }
    return {
        x: xPos,
        y: yPos
    };
}
 
function InitiateImage(intSub)
{
    var strImage = "";
   
    strImage = document.getElementById("dvImageStr" + intSub).innerText;

    
   

    var arr = strImage.split(";", 5000);
    for (var intIndex = 0; intIndex < arr.length; intIndex++) {
        galleryArray[intIndex] = arr[intIndex];
        
    }

    strImage = document.getElementById("dvLargeImageStr" + intSub).innerText;
        arr = strImage.split(";", 5000);
        for (var intIndex = 0; intIndex < arr.length; intIndex++) {
            galleryLrgArray[intIndex] = arr[intIndex];
        }
        var intImageCount = document.getElementById("dvImageCount" + intSub).innerText;
        var intStart = 0;
        var strTemp = "";
        var varElement;
        for (var intIndex = 0; intIndex < intImageCount; intIndex++)
        {
            strTemp = "imgDisplayPnl" + intSub + "-" + intIndex;
            varElement = document.getElementById(strTemp);
            if (varElement == null) {
                strTemp = "imgDisplayPnlHidden" + intSub + "-" + intIndex;
                varElement = document.getElementById(strTemp);
               
            }
            if (varElement == null)
                continue;
            //imgDisplayPnlHidden
            intStart = varElement.getAttribute("startIndex");
            arrIndex[intIndex] = intStart;
        }

    }
   

function MoveForward(intSub, intDisplayIndex) {
       if (galleryArray.length == 0)
           InitiateImage(intSub);
   
    var intStart = 0;
    var intEnd = 0;
    var strImageID = "imgDisplayPnl" + intSub + "-" + intDisplayIndex;
    intStart = parseInt( document.getElementById(strImageID).getAttribute("startIndex"));
    intEnd =parseInt( document.getElementById(strImageID).getAttribute("endIndex"));

    arrIndex[intDisplayIndex] = arrIndex[intDisplayIndex] >= intEnd ? intStart : parseInt(arrIndex[intDisplayIndex]) + 1;
    var intCur = parseInt(arrIndex[intDisplayIndex]);
   // alert(document.getElementById(strImageID).getAttribute("src"));
    //alert(document.getElementById(strImageID).getAttribute("startIndex"));
var strImgType = "s";
strImgType =document.getElementById(strImageID).getAttribute("ImgType"); 
if(strImgType="s")   
 document.getElementById(strImageID).setAttribute("src", galleryArray[intCur]);
else
 document.getElementById(strImageID).setAttribute("src", galleryLrgArray[intCur]);

}
function MoveBack(intSub, intDisplayIndex) {
    if (galleryArray.length == 0)
        InitiateImage(intSub);

    var intStart = 0;
    var intEnd = 0;
    var strImageID = "imgDisplayPnl" + intSub + "-" + intDisplayIndex;
    intStart = parseInt(document.getElementById(strImageID).getAttribute("startIndex"));
    intEnd = parseInt(document.getElementById(strImageID).getAttribute("endIndex"));

    arrIndex[intDisplayIndex] = arrIndex[intDisplayIndex] <= intStart? intEnd : parseInt(arrIndex[intDisplayIndex]) - 1;
    var intCur = parseInt(arrIndex[intDisplayIndex]);
    // alert(document.getElementById(strImageID).getAttribute("src"));
    //alert(document.getElementById(strImageID).getAttribute("startIndex"));
//var strImgType = "s";
strImgType =document.getElementById(strImageID).getAttribute("ImgType"); 
 
 document.getElementById(strImageID).setAttribute("src", galleryArray[intCur]);
 
}
function MoveLargeImgForward()
{
    MoveForward(_SubID, _DisplayIndex);
    var strImageID = "imgDisplayPnl" + _SubID + "-" + _DisplayIndex;
    var intCur = parseInt(arrIndex[_DisplayIndex]);

    strImgType = document.getElementById(strImageID).getAttribute("ImgType");
    
    

    if (strImgType == "L") {
       // document.getElementById("bodyHolder_dvEnlarge").setAttribute("class", "tag");


        document.getElementById("bodyHolder_imgLarge").setAttribute("src", galleryLrgArray[intCur]);
    }
}
function MoveLargeImgBack() {
    MoveBack(_SubID, _DisplayIndex);
    var strImageID = "imgDisplayPnl" + _SubID + "-" + _DisplayIndex;
    var intCur = parseInt(arrIndex[_DisplayIndex]);

    strImgType = document.getElementById(strImageID).getAttribute("ImgType");



    if (strImgType == "L") {
        //document.getElementById("bodyHolder_dvEnlarge").setAttribute("class", "tag");


        document.getElementById("bodyHolder_imgLarge").setAttribute("src", galleryLrgArray[intCur]);
    }
}
function Enlarge(intSub, intDisplayIndex) {
    if (intSub == -1)
        intSub = _SubID;
    if (intSub == -1)
        return;
   // if (galleryArray.length == 0)
        InitiateImage(intSub);
    var strImgType = "";
 
    if (intDisplayIndex == -1)
        intDisplayIndex = _DisplayIndex;
    var strImageID = "imgDisplayPnl" + intSub + "-" + intDisplayIndex;
    //var intCur = parseInt(arrIndex[intDisplayIndex]);
    var intCur = arrIndex[intDisplayIndex];// intCur = parseInt(arrIndex[intDisplayIndex]);
    if (document.getElementById(strImageID) == null)
        return;
    strImgType = document.getElementById(strImageID).getAttribute("ImgType");
    //inner-slider-panel 
    //inner-slider-content
    //inner-slider-image 
    _SubID = intSub;
    _DisplayIndex = intDisplayIndex;

    if (strImgType == "s") {
        document.getElementById("bodyHolder_dvEnlarge").setAttribute("class", "tag");
        

        document.getElementById("bodyHolder_imgLarge").setAttribute("src", galleryLrgArray[intCur]);
        document.getElementById("bodyHolder_dvCol2").setAttribute("class", "HiddenDiv");
        document.getElementById(strImageID).setAttribute("ImgType", "L");
    }
    else {
        document.getElementById("bodyHolder_dvEnlarge").setAttribute("class", "HiddenDiv");
        document.getElementById(strImageID).setAttribute("ImgType", "s");
        document.getElementById("bodyHolder_dvCol2").setAttribute("class", "col2");
    }

}
function Enlarge1(intSub, intDisplayIndex)
{
    if (galleryArray.length == 0)
        InitiateImage(intSub);
    var strImgType = "";
    var strImageID = "imgDisplayPnl" + intSub + "-" + intDisplayIndex;
    var intCur = parseInt(arrIndex[intDisplayIndex]);

    strImgType = document.getElementById(strImageID).getAttribute("ImgType");
    //inner-slider-panel 
    //inner-slider-content
    //inner-slider-image 
    _SubID = intSub;
    _DisplayIndex = intDisplayIndex;

    if (strImgType == "s")
    {
        document.getElementById("inner-slider-panel"+intSub +"-"+intDisplayIndex).setAttribute("class", "inner-slider-panel");
        document.getElementById("inner-slider-content" + intSub + "-" + intDisplayIndex).setAttribute("class", "inner-slider-content");
        document.getElementById("inner-slider-image" + intSub + "-" + intDisplayIndex).setAttribute("class", "inner-slider-image");

        document.getElementById(strImageID).setAttribute("src", galleryArray[intCur]);
        document.getElementById(strImageID).setAttribute("ImgType", "L");
    }
    else
    {
        document.getElementById("inner-slider-panel" + intSub + "-" + intDisplayIndex).setAttribute("class", "inner-slider-panel_L");
        document.getElementById("inner-slider-content" + intSub + "-" + intDisplayIndex).setAttribute("class", "inner-slider-content_L");
        document.getElementById("inner-slider-image" + intSub + "-" + intDisplayIndex).setAttribute("class", "inner-slider-image_L");

        document.getElementById(strImageID).setAttribute("src", galleryLrgArray[intCur]);
        document.getElementById(strImageID).setAttribute("ImgType", "s");
    }

}
function rotateimages() {
    //InitiateImage();
    setInterval("MoveForward()", 2000);
}
