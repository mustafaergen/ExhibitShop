document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".faq-question").forEach(item => {
        item.addEventListener("click", function () {
            let answer = this.nextElementSibling;
            let icon = this.querySelector("i");

            if (answer.style.display === "block") {
                answer.style.display = "none";
                icon.classList.remove("fa-minus");
                icon.classList.add("fa-plus");
            } else {
                answer.style.display = "block";
                icon.classList.remove("fa-plus");
                icon.classList.add("fa-minus");
            }
        });
    });
});