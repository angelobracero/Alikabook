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


//scroll the sub header
const scrollLeft = document.getElementById('scrollLeft');
const scrollRight = document.getElementById('scrollRight');
const scrollContainer = document.querySelector('.header__sub');

function smoothScroll(container, distance, duration) {
    let start = container.scrollLeft;
    let startTime = null;

    function scrollStep(timestamp) {
        if (!startTime) startTime = timestamp;
        let progress = timestamp - startTime;
        let percent = Math.min(progress / duration, 1);
        container.scrollLeft = start + distance * percent;
        if (percent < 1) {
            window.requestAnimationFrame(scrollStep);
        }
    }
    window.requestAnimationFrame(scrollStep);
}

scrollLeft.addEventListener('click', () => {
    smoothScroll(scrollContainer, -2500, 1000);
});

scrollRight.addEventListener('click', () => {
    smoothScroll(scrollContainer, 2500, 1000);  
});

// Save the scroll position of the .header__sub element
window.addEventListener("beforeunload", function () {
    const subHeader = document.querySelector(".header__sub");
    if (subHeader) {
        localStorage.setItem("subHeaderScrollPosition", subHeader.scrollLeft);
    }
});

// Restore the scroll position of the .header__sub element
window.addEventListener("load", function () {
    const subHeader = document.querySelector(".header__sub");
    const savedPosition = localStorage.getItem("subHeaderScrollPosition");

    if (subHeader && savedPosition !== null) {
        subHeader.scrollLeft = parseInt(savedPosition, 10);
    }
});


//Open Profile Settings
const headerSetting = document.getElementById("headerSetting");
const profilePic = document.getElementById("profilePic");

profilePic.addEventListener("click", () => {
    headerSetting.classList.toggle("show");
});

