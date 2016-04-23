var zgoda = confirm("Witaj! Chciałbyś sie podrapac po glowie?");

if (zgoda) {
    var wiek = prompt("Wpisz swój wiek");
    var regx = new RegExp("[0-9]");

    if (wiek.match(regx)) {
        var modulo = wiek % 3.14;

        document.write("Twój wiek modulo PI wynosi: <strong>" + modulo + "</strong>");
    }
    else {
        document.write("Nie wpisano nic!");
    }
}
else {
    alert("Nie rozmawiam z robotami!");
}