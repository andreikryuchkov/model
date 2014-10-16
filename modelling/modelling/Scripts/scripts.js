function regGurFace()
{
    if (document.getElementById("MainContent_registrationView_regForGurFace").checked) {
        document.getElementById("MainContent_registrationView_familyName").textContent = "Контактное лицо:";
        document.getElementById("MainContent_registrationView_name").textContent = "Организация:";
    }
    else
    {
        document.getElementById("MainContent_registrationView_familyName").textContent = "Фамилия:";
        document.getElementById("MainContent_registrationView_name").textContent = "Имя:";
    }
}