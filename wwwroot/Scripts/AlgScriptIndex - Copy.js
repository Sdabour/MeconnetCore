var myVar;

function DisplayImageFrequently() {
    myVar = setInterval(DisplayImages, 3000);
}

function DisplayImages() 
{
    
}
var curimg=0
function rotateimages(){
    document.getElementById("slideshow").setAttribute("src", "pics/"+galleryarray[curimg])
    curimg=(curimg<galleryarray.length-1)? curimg+1 : 0
}
 
window.onload=function(){
    setInterval("rotateimages()", 2500)
}