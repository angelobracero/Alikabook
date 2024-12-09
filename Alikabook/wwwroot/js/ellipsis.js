const showProofModalBtn = document.querySelectorAll("[id='showProofModalBtn']");
const proofModal = document.getElementById("proofModal");
const closeModal = document.getElementById("closeModal");
const proofImage = document.getElementById("proofImage");

// Hidden inputs in the forms
const declineOrderIdInput = document.getElementById("declineOrderId");
const acceptOrderIdInput = document.getElementById("acceptOrderId");

// Show modal on button click
showProofModalBtn.forEach(button => {
    button.addEventListener("click", () => {
        // Get the proof of payment file name from the data-* attribute
        const proofImagePath = "/images/proofofpayment/" + button.getAttribute("data-proof-of-payment");
        proofImage.src = proofImagePath;

        const orderId = button.getAttribute("data-id") 
        declineOrderIdInput.value = orderId;
        acceptOrderIdInput.value = orderId;

        proofModal.style.display = "flex";
    });
});

// Close modal on close button click
closeModal.addEventListener("click", () => {
    proofModal.style.display = "none";
});

// Close modal if clicked outside the modal content
window.addEventListener("click", (event) => {
    if (event.target === proofModal) {
        proofModal.style.display = "none";
    }
});

//
// For dropdown
//
function toggleDropdown(event) {
    event.stopPropagation(); // Prevent the event from bubbling up
    const dropdown = event.target.nextElementSibling;
    const isStatusDropdown = dropdown && dropdown.classList.contains('dropdown-item-status-items');

    // Toggle visibility for the status dropdown
    if (isStatusDropdown) {
        const isVisible = dropdown.style.display === 'block';
        dropdown.style.display = isVisible ? 'none' : 'block';

        // Add or remove the "focus" class from the status item based on visibility
        if (dropdown.style.display === 'block') {
            event.target.classList.add('focus');
        } else {
            event.target.classList.remove('focus');
        }
    } else {
        // Toggle visibility of the main dropdown
        const isVisible = dropdown.style.display === 'block';
        document.querySelectorAll('.dropdown').forEach(d => d.style.display = 'none');
        dropdown.style.display = isVisible ? 'none' : 'block';
    }
}

document.addEventListener('click', () => {
    // Close all dropdowns if clicking outside
    document.querySelectorAll('.dropdown').forEach(d => d.style.display = 'none');

    // Remove "focus" class from any dropdown-item-status when dropdowns are closed
    document.querySelectorAll('.dropdown-item-status').forEach(item => item.classList.remove('focus'));
});


//
// For changing status
//

function setStatus(orderDetailId, orderStatus) {
    const orderId = document.getElementById('orderId');
    const status = document.getElementById('status');

    orderId.value = orderDetailId;
    status.value = orderStatus;
}
