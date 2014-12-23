//region валидация для регистрации 

var havErrorsPass;
var havErrorsLog;
var havErrorsCompanyName;
var havErrorsRequisites;

$(document).ready(function () {
    document.getElementById("MainContent_registrationView_sendReg").disabled = true;//$("#MainContent_registrationView_sendReg").disabled = true;//
});
    

    function passwordChanged()
    {
        if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != "")
        {
            return ComparePassword();
        }
    }

    function confirmPasswordChanged()
    {
        if (document.getElementById("MainContent_registrationView_PasswordConfirm").value != "")
        {
            return ComparePassword();
        }
    }

    function ComparePassword()
    {
        if ((document.getElementById("MainContent_registrationView_regPassword").value=="")||(document.getElementById("MainContent_registrationView_PasswordConfirm").value != document.getElementById("MainContent_registrationView_regPassword").value)) {
            document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "background-color:#ff0000;");
            return false;//document.getElementById("MainContent_registrationView_sendReg").disabled = true;
            document.getElementById("MainContent_regMessagePass").setAttribute("style", "text-color:#ff0000;");
            document.getElementById("MainContent_regMessagePass").textContent += "некорректный пароль или подтверждение!";
            havErrorsPass = true;
        }
        else
        {
            document.getElementById("MainContent_registrationView_PasswordConfirm").setAttribute("style", "background-color:rgba(255, 255, 255, 0.1);");
            //document.getElementById("MainContent_regMessagePass").textContent = "";
            havErrorsPass = false;
            ClearValidateRegistration();
            return true;
        }
    }
    //MainContent_regMessage
    function validateForLogin()
    {
        if (document.getElementById("MainContent_registrationView_regLogin").value == "") {
            document.getElementById("MainContent_regMessageLog").setAttribute("style", "text-color:#ff0000;");
            document.getElementById("MainContent_regMessageLog").textContent += "Поле логин не может быть пустым!";
            return false;
            havErrorsLog = true;
        }
        else
        {
            //document.getElementById("MainContent_regMessageLog").textContent = "";
            havErrorsLog = false;
            ClearValidateRegistration();
            return true;
        }
    }

    function validateForCompanyName()
    {
        if (document.getElementById("MainContent_registrationView_regCompanyName").value == "") {
            document.getElementById("MainContent_regMessageCompanyName").setAttribute("style", "text-color:#ff0000;");
            document.getElementById("MainContent_regMessageCompanyName").textContent += "Поле Имя компании не может быть пустым!";
            document.getElementById("MainContent_registrationView_sendReg").disabled = true;
            havErrorsCompanyName = true;
        }
        else
        {
            //document.getElementById("MainContent_regMessageCompanyName").textContent = "";
            havErrorsCompanyName = false;
            ClearValidateRegistration();
        }
    }

    function validateRequisites()
    {
        if (document.getElementById("MainContent_registrationView_regRequisites").value == "") {
            document.getElementById("MainContent_regMessageRequisites").setAttribute("style", "text-color:#ff0000;");
            document.getElementById("MainContent_regMessageRequisites").textContent += "Поле Реквизиты не может быть пустым!";
            document.getElementById("MainContent_registrationView_sendReg").disabled = true;
            havErrorsRequisites = true;
        }
        else
        {
           // document.getElementById("MainContent_regMessageRequisites").textContent = "";
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

    var isListBoxClick;

    function ListBoxClick()
    {
        isListBoxClick=true;
        adressValidation();
    }
    function adressValidation()
    {
        if (!isListBoxClick)
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

    function validateOfer()
    {
        if (document.getElementById("MainContent_registrationView_regOfer").checked)
            return false;

        document.getElementById("MainContent_registrationView_sendReg").disabled = true;
        return true;

    }


    function validateRegistration()
    {
        document.getElementById("MainContent_regMessagePass").textContent = "";
        if ((!validateForLogin()) || (!passwordChanged()) || (!confirmPasswordChanged())||(!validateOfer()))
        {
            document.getElementById("MainContent_registrationView_sendReg").disabled = true;
            return false;
        }
        return true;

    }

    function validateRegistrationGur()
    {
        if ((!validateRegistration())||(!validateForCompanyName()) || (!validateRequisites()))
        {
            document.getElementById("MainContent_registrationView_sendReg").disabled = true;
            return false;
        }
        return true;
    }