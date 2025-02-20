// DOM elemanlarını seç
const body = document.querySelector("body");
const sidebar = body.querySelector(".sidebar");
const toggle = body.querySelector(".toggle");
const searchBtn = body.querySelector(".search-box input");
const modeSwitch = body.querySelector(".toggle-switch");
const modeText = body.querySelector(".mode-text");

// Karanlık mod geçişi için olay dinleyici ekle
modeSwitch.addEventListener("click", () => {
    body.classList.toggle("dark");

    if (body.classList.contains("dark")) {
        modeText.textContent = "Aydınlık Mod"; // Dark mode active
        document.querySelector('.sun').style.opacity = "1"; // Show sun icon
        document.querySelector('.moon').style.opacity = "0"; // Hide moon icon
    } else {
        modeText.textContent = "Karanlık Mod"; // Dark mode inactive
        document.querySelector('.sun').style.opacity = "0"; // Hide sun icon
        document.querySelector('.moon').style.opacity = "1"; // Show moon icon
    }
});


// Kenar çubuğunu açıp kapatma
toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
});