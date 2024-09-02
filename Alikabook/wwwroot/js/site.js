//Navigation for small screen size
const hamburger = document.querySelector(".fa-bars");
const subHeader = document.querySelector(".header__sub");

hamburger.addEventListener("click", () => {
    if (subHeader.style.display === "none") {
        subHeader.style.display = "block";
    } else {
        subHeader.style.display = "none";
    }
});



//Open Profile Settings
const headerSetting = document.getElementById("headerSetting");
const profilePic = document.getElementById("profilePic");

profilePic.addEventListener("click", () => {
    headerSetting.classList.toggle("show");
});
