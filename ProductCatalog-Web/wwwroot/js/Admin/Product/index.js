﻿

document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll('.btn-outline-danger');
    
    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            if (!confirm('Are you sure you want to delete this product?')) {
                event.preventDefault(); 
            }
        });
    });
});
