function draw()
var canvas = document.getElementById("table");
canvas.addEventListener("mousedown",drawCircle, false);
}
function drawCircle(){
var canvas = document.getElementById("table");
//canvas.addEventListener("mousedown",drawCircle, false);
    var ctx = canvas.getContext("2d");
    x=event.pageX;
    y=event.pageY;
    ctx = fillStyle = "black";
    ctx.beginPath();
    ctx.arc(x,y,25,0,2*)
}