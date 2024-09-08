//For Item Quantity
const itemQty = document.getElementById('itemQty');
const hiddenQty = document.getElementById('hiddenQty');
const decrease = document.getElementById('btnDecrease');
const increase = document.getElementById('btnIncrease');

let qty = 1;

increase.addEventListener('click', () => {
    qty++;
    itemQty.textContent = qty
    hiddenQty.value = qty;
})

decrease.addEventListener('click', () => {
    if (qty <= 1) {
        itemQty.textContent = 1
        hiddenQty.value = 1;
    }
    else {
        qty--;
        itemQty.textContent = qty
        hiddenQty.value = qty;
    }
})

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