var curimg=0
var galleryarray = new Array();//("images\\Index\\Pnnel\\img-2.jpg", "images\\Index\\Pnnel\\img-3.jpg", "images\\Index\\Pnnel\\img-1.jpg");
function InitiateImage()
{
    try {

        var strImage = "";
        //  alert(strImage);
        //('<%=(Master.FindControl("lbl")).ClientID %>')
      //  alert("<%=dvDisplayPnl7.ClientID %>");
        strImage = document.getElementById("bodyHolder_dvDisplayPnl7").innerText;
        // alert(strImage);
     
        var arr = strImage.split(";", 5000);
        for (var intIndex = 0; intIndex < arr.length; intIndex++) {
            galleryarray[intIndex] = arr[intIndex];
        }}
    catch (x) {
       // alert(x);
    }
      
    }
   // alert(galleryarray.length);

function MoveForward()
{
    try{
        if (galleryarray.length == 0)
            InitiateImage();
    
        document.getElementById("bodyHolder_imgDisplayPnl").setAttribute("src", galleryarray[curimg]);
  
        curimg=(curimg<galleryarray.length-1)? curimg+1 : 0;
    } catch (x) { }
}
function MoveBack()
{
    try{
        document.getElementById("bodyHolder_imgDisplayPnl").setAttribute("src", galleryarray[curimg]);
        curimg=(curimg>0)? curimg-1 : galleryarray.length-1;
    } catch (x) { }
}
function rotateimages(){
    //InitiateImage();
   setInterval("MoveForward()",2000);
}

