//isNaN()
document.getElementById("div3").innerHTML = "isNaN('Hola') = " + isNaN("Hola"); 
document.getElementById("div4").innerHTML = "isNaN('12') = " + isNaN("12"); 
document.getElementById("div5").innerHTML = "isNaN(12.5) = " + isNaN(12.5); 
document.getElementById("div6").innerHTML = "isNaN('Hola12.5') = " + isNaN("Hola12.5"); 
//parseInt()
document.getElementById("div7").innerHTML = "parseInt('Hola') = " + parseInt("HOLA");
document.getElementById("div8").innerHTML = "parseInt('12') = " + parseInt("12");
document.getElementById("div9").innerHTML = "parseInt('12.5') = " + parseInt(12.5);
document.getElementById("div10").innerHTML = "parseInt('Hola12.5X') = " + parseInt("12.5");



var mivalor = "32"; 

if (isNaN(mivalor)) { 
    document.getElementById("div1").innerHTML = mivalor + " es un número"; 
    
} else {
    document.getElementById("div1").innerHTML = "HOLA, " + mivalor + " no es un número válido."; 
}
    let numero = parseInt(mivalor); 
    numero = numero * 10; 
    document.getElementById("div2").innerHTML = "El número convertido y multiplicado por 10 es: " + numero;  
