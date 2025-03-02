document.getElementById("offerBtn").addEventListener("click", function () {
    let btn = this;
    btn.style.transform = "scale(1.1)";
    setTimeout(() => btn.style.transform = "scale(1)", 150);
});