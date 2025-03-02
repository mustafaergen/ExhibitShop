document.getElementById("rejectOffer").addEventListener("click", function () {
    if (confirm("Are you sure you want to reject this offer?")) {
        document.getElementById("offerStatus").value = "Passive";
        document.forms[0].submit();
    }
});
await Html.RenderPartialAsync("_ValidationScriptsPartial");