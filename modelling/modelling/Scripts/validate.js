function passwordChanged()
{
    if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != "")
    {
        ComparePassword();
    }
}

function confirmPasswordChanged()
{
    if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != "")
    {
        ComparePassword();
    }
}

function ComparePassword()
{
    if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != document.getElementById("MainContent_registrationView_regPassword").value)
    {
        document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "background-color:#ff0000;");
        document.getElementById("MainContent_registrationView_sendReg").disabled = true;
        document.getElementById("MainContent_regMessage").value = "Пароли не совпадают!";
    }
    else
    {
        document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "background-color:rgba(255, 255, 255, 0.1);");
        document.getElementById("MainContent_registrationView_sendReg").disabled = false;
    }
}
//MainContent_regMessage
function validateForLogin()
{
    if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != "")
    {
        document.getElementById("MainContent_registrationView_regLogin").disabled = true;
    }
    else
    {
        document.getElementById("MainContent_registrationView_regLogin").disabled = false;
    }
}
