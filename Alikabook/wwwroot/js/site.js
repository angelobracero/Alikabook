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

//toggle category
const headerCategoryPopup = document.getElementById('headerCategoryPopup');
const headerCategory = document.getElementById('headerCategory');
const categoryCaret = document.getElementById('categoryCaret');


headerCategory.addEventListener('click', () => {
    headerCategoryPopup.classList.toggle('show');

    if (headerCategoryPopup.classList.contains('show')) {
        categoryCaret.style.transform = 'rotate(180deg)';
    } else {
        categoryCaret.style.transform = 'rotate(0deg)';
    }
})

//Open Profile Settings
const headerSetting = document.getElementById("headerSetting");
const profilePic = document.getElementById("profilePic");

profilePic.addEventListener("click", () => {
    headerSetting.classList.toggle("show");
});

