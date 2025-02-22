document.querySelector('.btn-login').addEventListener('click', function (event) {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var errorMessage = document.getElementById("error-message");

    // Örnek: temel doğrulama (isteğe bağlı)
    if (email.trim() === "" || password.trim() === "") {
        errorMessage.textContent = "Lütfen tüm alanları doldurun!";
        event.preventDefault(); // Formun gönderilmesini engelle
        return;
    }

    // Form gönderimi için engelleme yoksa hata mesajını temizleyin
    errorMessage.textContent = "";
});
