
function rejectOffer(offerId) {
    if (confirm('Are you sure you want to reject this offer?')) {
        $.ajax({
            url: '@Url.Action("RejectOffer", "Offers")',
            type: 'POST',
            data: { id: offerId },
            success: function (response) {
                alert('Offer rejected successfully.');
                location.reload();
            },
            error: function () {
                alert('An error occurred while rejecting the offer.');
            }
        });
    }
}
$(document).on('change', 'input[id^="counterPrice_"]', function () {
    var newCounterPrice = $(this).val();
    var offerId = $(this).data('id');

    $.ajax({
        url: '@Url.Action("UpdateCounterPrice", "Offers")',
        type: 'POST',
        data: {
            id: offerId,
            counterPrice: newCounterPrice
        },
        success: function (response) {
            alert('Counter Price updated successfully.');
        },
        error: function () {
            alert('An error occurred while updating the counter price.');
        }
    });
});