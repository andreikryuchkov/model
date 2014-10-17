//region валидация для регистрации 

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
        ClearValidateRegistration();
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
        ClearValidateRegistration();
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
        ClearValidateRegistration();
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
        ClearValidateRegistration();
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
        ClearValidateRegistration();
    }
}

function ClearValidateRegistration()
{
    if (!havErrorsLog && !havErrorsPass && !havErrorsCompanyName && !havErrorsRequisites)
        document.getElementById("MainContent_registrationView_sendReg").disabled = false;
}
//endregion валидация для регистрации

//region валидация для корзины

function adressValidation()
{
    if (document.getElementById("MainContent_Ordering_adressList").SelectedItem == null)
    {
        if (document.getElementById("MainContent_Ordering_cityInput").value == "" ||
         document.getElementById("MainContent_Ordering_streetInput").value == "" ||
         document.getElementById("MainContent_Ordering_buildingInput").value == "")
        {
            document.getElementById("MainContent_regMessage").setAttribute("style", "text-color:#ff0000;");
            document.getElementById("MainContent_regMessage").textContent = "Выберите адресс или введите новый!";
            document.getElementById("MainContent_Ordering_orderDelivery").disabled = true;
        }
        else
        {
            ClearValidateOrder();
        }

    }
    else
    {
        ClearValidateOrder();
    }
    //if (document.getElementById("MainContent_Ordering_cityInput").textContent == null)
    //    if (document.getElementById("MainContent_Ordering_streetInput").textContent == null)
    //        if (document.getElementById("MainContent_Ordering_buildingInput").textContent == null)
}

function ClearValidateOrder()
{
    document.getElementById("MainContent_regMessage").textContent="";
    document.getElementById("MainContent_Ordering_orderDelivery").disabled = false;
}

//endregion валидация для корзины