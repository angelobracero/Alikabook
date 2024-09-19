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
