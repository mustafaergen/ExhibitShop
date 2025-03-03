document.addEventListener("DOMContentLoaded", function () {
    const inputs = document.querySelectorAll(".form-control");

    inputs.forEach(input => {
        input.addEventListener("focus", () => {
            input.style.borderColor = "#563d7c";
        });

        input.addEventListener("blur", () => {
            input.style.borderColor = "#ddd";
        });
    });

    const updateBtn = document.querySelector(".btn-primary");

    if (updateBtn) {
        updateBtn.addEventListener("click", function () {
            updateBtn.classList.add("pulse");
            setTimeout(() => {
                updateBtn.classList.remove("pulse");
            }, 500);
        });
    }
});
document.addEventListener("DOMContentLoaded", function () {
    var successMessage = document.querySelector(".success-message");
    if (successMessage) {
        setTimeout(function () {
            successMessage.classList.add("fade-out");
        }, 3000);
    }
});


