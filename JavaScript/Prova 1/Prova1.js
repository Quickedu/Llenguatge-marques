function canviText(){    
    let p = document.getElementById("a");
    p.textContent = ("Si venga, q guapo hehe god");
    canvicolor()
}
function canvicolor(){
    let p = document.getElementById("a");
    p.setAttribute("class" , "random");
}

let but = document.getElementById("but");
but.addEventListener("click",canviText);