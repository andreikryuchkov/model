var havErrorsPass;
var havErrorsLog;
var havErrorsCompanyName;
var havErrorsRequisites;

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
    if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != document.getElementById("MainContent_registrationView_regPassword").value) {
        document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "background-color:#ff0000;");
        document.getElementById("MainContent_registrationView_sendReg").disabled = true;
        document.getElementById("MainContent_regMessagePass").setAttribute("style", "text-color:#ff0000;");
        document.getElementById("MainContent_regMessagePass").textContent = "Пароли не совпадают!";
        havErrorsPass = true;
    }
    else
    {
        document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "background-color:rgba(255, 255, 255, 0.1);");
        document.getElementById("MainContent_regMessagePass").textContent = "";
        havErrorsPass = false;
        ClearValidate();
    }
}
//MainContent_regMessage
function validateForLogin()
{
    if (document.getElementById("MainContent_registrationView_regLogin").value == "") {
        document.getElementById("MainContent_regMessageLog").setAttribute("style", "text-color:#ff0000;");
        document.getElementById("MainContent_regMessageLog").textContent = "Поле логин не может быть пустым!";
        document.getElementById("MainContent_registrationView_sendReg").disabled = true;
        havErrorsLog = true;
    }
    else
    {
        document.getElementById("MainContent_regMessageLog").textContent = "";
        havErrorsLog = false;
        ClearValidate();
    }
}

function validateForCompanyName()
{
    if (document.getElementById("MainContent_registrationView_regCompanyName").value == "") {
        document.getElementById("MainContent_regMessageCompanyName").setAttribute("style", "text-color:#ff0000;");
        document.getElementById("MainContent_regMessageCompanyName").textContent = "Поле Имя компании не может быть пустым!";
        document.getElementById("MainContent_registrationView_sendReg").disabled = true;
        havErrorsCompanyName = true;
    }
    else
    {
        document.getElementById("MainContent_regMessageCompanyName").textContent = "";
        havErrorsCompanyName = false;
        ClearValidate();
    }
}

function validateRequisites()
{
    if (document.getElementById("MainContent_registrationView_regRequisites").value == "") {
        document.getElementById("MainContent_regMessageRequisites").setAttribute("style", "text-color:#ff0000;");
        document.getElementById("MainContent_regMessageRequisites").textContent = "Поле Реквизиты не может быть пустым!";
        document.getElementById("MainContent_registrationView_sendReg").disabled = true;
        havErrorsRequisites = true;
    }
    else
    {
        document.getElementById("MainContent_regMessageRequisites").textContent = "";
        havErrorsRequisites = false;
        ClearValidate();
    }
}

function changeForGurFace()
{
    if (document.getElementById("MainContent_registrationView_regForGurFace").checked)
    {
        validateForCompanyName();
        validateRequisites();
    }
    else
    {
        document.getElementById("MainContent_regMessageCompanyName").textContent = "";
        document.getElementById("MainContent_regMessageRequisites").textContent = "";
        havErrorsCompanyName = false;
        havErrorsRequisites = false;
        ClearValidate();
    }
}

function ClearValidate()
{
    if (!havErrorsLog && !havErrorsPass && !havErrorsCompanyName && !havErrorsRequisites)
        document.getElementById("MainContent_registrationView_sendReg").disabled = false;
}
