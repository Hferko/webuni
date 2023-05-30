// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

let honapok = ["", "Január", "Február", "Március", "Április", "Május", "Június", "Július", "Augusztus", "Szeptember", "Október", "November", "Decembe"];

const datum = new Date();
const ev = datum.getFullYear();
const honap = datum.getMonth() + 1;
let honapStr = honapok[honap];
const nap = datum.getDate();

document.getElementById("datum").innerHTML = ev + ". " + honapStr + " " + nap;

const cookieValue = document.cookie
    .split("; ")
    .find((row) => row.startsWith("userNev="))
    ?.split("=")[1];

if (cookieValue === "") {
    document.getElementById("cookies").textContent = "Még nem jelentkezett be senki";
}
else {
    document.getElementById("cookies").textContent = ` ${cookieValue}`;
}

