document.addEventListener("DOMContentLoaded", function () {
    var sidebar = document.getElementById("sidebar");
    var menuToggle = document.getElementById("menu-toggle");

    menuToggle.addEventListener("click", function () {
        sidebar.classList.toggle("hidden");
    });
});
