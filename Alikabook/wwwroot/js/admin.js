/* 
For Hamburger Menu
*/
const body = document.body;
const sidebar = document.querySelector(".sidebar");
const menuButton = document.querySelector(".header__menu");
const closeButton = document.querySelector(".sidebar__exit");

menuButton.addEventListener("click", () => {
    if (window.innerWidth < 1024) {
        sidebar.classList.add("show");
    } else {
        sidebar.classList.toggle("big-show");

        if (sidebar.classList.contains("big-show")) {
            body.style.marginLeft = "0";
        } else {
            body.style.marginLeft = "300px";
        }
    }
});

closeButton.addEventListener("click", () => {
    sidebar.classList.remove("show");
});

/* 
For Sidebar Menu Button
*/
sidebarMenus = document.querySelectorAll(".sidebar__menu button");
arrows = document.querySelectorAll(".fa-angle-right");

sidebarMenus.forEach((menuButton) => {
    menuButton.addEventListener("click", () => {
        const submenu = menuButton.nextElementSibling;
        const arrow = menuButton.querySelector(".fa-angle-right");

        if (submenu && submenu.classList.contains("sidebar__submenu")) {
            submenu.classList.toggle("show");

            if (submenu.classList.contains("show")) {
                arrow.style.transform = "rotate(90deg)";
            } else {
                arrow.style.transform = "rotate(0deg)";
            }
        }
    });
});
