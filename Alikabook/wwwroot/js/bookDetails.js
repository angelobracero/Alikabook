const itemQty = document.getElementById('itemQty');
const decrease = document.getElementById('btnDecrease');
const increase = document.getElementById('btnIncrease');

// Update quantity with increase button
increase.addEventListener('click', () => {
    let qty = parseInt(itemQty.value, 10) || 1;
    itemQty.value = qty + 1;
});

// Update quantity with decrease button
decrease.addEventListener('click', () => {
    let qty = parseInt(itemQty.value, 10) || 1;
    if (qty > 1) {
        itemQty.value = qty - 1;
    }
});

// Ensure input value is valid when manually changed
itemQty.addEventListener('input', () => {
    let qty = parseInt(itemQty.value, 10);
    if (isNaN(qty) || qty < 1) {
        itemQty.value = 1; // Reset to 1 if input is invalid
    }
});



//For Item Rating
const itemRating = document.getElementById('itemRating');
const rating = document.getElementById('rating');
const ratingButtons = document.querySelectorAll('input[name="rating"]');


ratingButtons.forEach(button => {
    button.addEventListener('change', () => {
        itemRating.textContent = button.value;
        rating.value = button.value;
        console.log(rating.value);
    });
});