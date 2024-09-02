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