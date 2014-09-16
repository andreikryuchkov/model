function passwordChanged() {

    if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != document.getElementById("MainContent_registrationView_RegPassword").value) {
        document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "border-color:#ff0000;");
        document.getElementById("MainContent_registrationView_SendReg").setAttribute("disabled", "disabled");
    }
    else {
        document.getElementById("MainContent_registrationView_SendReg").removeAttribute("disabled");
    }
}