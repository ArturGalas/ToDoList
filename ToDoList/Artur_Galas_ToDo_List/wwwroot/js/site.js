// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
textarea = document.querySelector("#DescriptionBox");
textarea = document.querySelector("#EditDescription")
textarea.addEventListener('input', autoResize, false);

function autoResize() {
    this.style.height = 'auto';
    this.style.height = (this.scrollHeight+5) + 'px';
}
function Show(str) {

    var type = document.getElementById("PasswordTxt").type;
    if (type == "password") {
        let pass = prompt("Podaj hasło", "Hasło");
        if (pass == str) {
            document.getElementById("PasswordTxt").type = "text"
            document.getElementById("PasswordTxt").value = str;
            document.getElementById("ShowPassword").value = "Ukryj hasło"
        }
    } else {
        document.getElementById("PasswordTxt").type = "password"
        document.getElementById("PasswordTxt").value = "hasłohasłohasło"
        document.getElementById("ShowPassword").value = "Pokaż hasło"
    }
}
function Unlock() {

    var type = document.getElementById("PasswordTxt").type;
    if (type == "password") {
        document.getElementById("PasswordTxt").type = "text"
        document.getElementById("PasswordTxt").removeAttribute('readonly');
        document.getElementById("ShowPassword").value = "Zablokuj hasło"
    } else {
        document.getElementById("PasswordTxt").setAttribute('readonly',true);
        document.getElementById("PasswordTxt").type = "password"
        document.getElementById("ShowPassword").value = "Odblokuj hasło"
    }
}