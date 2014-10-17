function regGurFace()
{
    if (!document.getElementById("MainContent_registrationView_regForGurFace").checked) {
        document.getElementById("companyFieldsNames").setAttribute("style", "visibility: hidden;");
        document.getElementById("companyFields").setAttribute("style", "visibility: hidden;");
    }
    else
    {
        document.getElementById("companyFieldsNames").setAttribute("style", "visibility: visible;");
        document.getElementById("companyFields").setAttribute("style", "visibility: visible;");
    }
}