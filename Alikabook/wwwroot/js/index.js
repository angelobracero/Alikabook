//Left and Right arrow in index for navigating between books
const arrowLeft1 = document.getElementById("arrowLeft1");
const arrowRight1 = document.getElementById("arrowRight1");
const scrollContainer1 = document.getElementById("scrollContainer1");

const arrowLeft2 = document.getElementById("arrowLeft2");
const arrowRight2 = document.getElementById("arrowRight2");
const scrollContainer2 = document.getElementById("scrollContainer2");

const arrowLeft3 = document.getElementById("arrowLeft3");
const arrowRight3 = document.getElementById("arrowRight3");
const scrollContainer3 = document.getElementById("scrollContainer3");

const arrowLeft4 = document.getElementById("arrowLeft4");
const arrowRight4 = document.getElementById("arrowRight4");
const scrollContainer4 = document.getElementById("scrollContainer4");

const arrowLeft5 = document.getElementById("arrowLeft5");
const arrowRight5 = document.getElementById("arrowRight5");
const scrollContainer5 = document.getElementById("scrollContainer5");

const arrowLeft6 = document.getElementById("arrowLeft6");
const arrowRight6 = document.getElementById("arrowRight6");
const scrollContainer6 = document.getElementById("scrollContainer6");

const arrowLeft7 = document.getElementById("arrowLeft7");
const arrowRight7 = document.getElementById("arrowRight7");
const scrollContainer7 = document.getElementById("scrollContainer7");

const arrowLeft8 = document.getElementById("arrowLeft8");
const arrowRight8 = document.getElementById("arrowRight8");
const scrollContainer8 = document.getElementById("scrollContainer8");

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

arrowLeft1.addEventListener("click", () => {
    smoothScroll(scrollContainer1, -200, 500);
});
arrowRight1.addEventListener("click", () => {
    smoothScroll(scrollContainer1, 200, 500);
});
arrowLeft2.addEventListener("click", () => {
    smoothScroll(scrollContainer2, -200, 500);
});
arrowRight2.addEventListener("click", () => {
    smoothScroll(scrollContainer2, 200, 500);
});
arrowLeft3.addEventListener("click", () => {
    smoothScroll(scrollContainer3, -200, 500);
});
arrowRight3.addEventListener("click", () => {
    smoothScroll(scrollContainer3, 200, 500);
});
arrowLeft4.addEventListener("click", () => {
    smoothScroll(scrollContainer4, -200, 500);
});
arrowRight4.addEventListener("click", () => {
    smoothScroll(scrollContainer4, 200, 500);
});
arrowLeft5.addEventListener("click", () => {
    smoothScroll(scrollContainer5, -200, 500);
});
arrowRight5.addEventListener("click", () => {
    smoothScroll(scrollContainer5, 200, 500);
});
arrowLeft6.addEventListener("click", () => {
    smoothScroll(scrollContainer6, -200, 500);
});
arrowRight6.addEventListener("click", () => {
    smoothScroll(scrollContainer6, 200, 500);
});
arrowLeft7.addEventListener("click", () => {
    smoothScroll(scrollContainer7, -200, 500);
});
arrowRight7.addEventListener("click", () => {
    smoothScroll(scrollContainer7, 200, 500);
});
arrowLeft8.addEventListener("click", () => {
    smoothScroll(scrollContainer8, -200, 500);
});
arrowRight8.addEventListener("click", () => {
    smoothScroll(scrollContainer8, 200, 500);
});