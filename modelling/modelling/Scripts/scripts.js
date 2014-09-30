function regGurFace()
{
    if (document.getElementById("MainContent_registrationView_regForGurFace").checked) {
        document.getElementById("MainContent_registrationView_contactFace").style.display == "none";
        document.getElementById("MainContent_registrationView_contactFace").style.visibility = "visible"
    }
    else
    {
        document.getElementById("MainContent_registrationView_contactFace").style.visibility = "hidden";
    }
    //MainContent_registrationView_contactFace
}