function login() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var errorMessage = document.getElementById("error-message");

    if (email === "admin@restaurant.com" && password === "123456 ") {
        alert("Giriş başarılı! Admin paneline yönlendiriliyorsunuz...");
        console.log("Admin Girişi:", { email, password });
        window.location.href = "dashboard.html";
    } else {
        errorMessage.textContent = "Geçersiz e-posta veya şifre!";
    }
}