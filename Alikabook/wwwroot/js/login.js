const currentPasswordField = document.getElementById('currentPassword');
const toggleCurrentPassword = document.getElementById('toggleCurrentPassword');
if (currentPasswordField && toggleCurrentPassword) {
    toggleCurrentPassword.addEventListener('click', () => {
        const type = currentPasswordField.type === 'password' ? 'text' : 'password';
        currentPasswordField.type = type;
        toggleCurrentPassword.classList.toggle('fa-eye-slash');
    });
}

const passwordField = document.getElementById('password');
const togglePassword = document.getElementById('togglePassword');
if (passwordField && togglePassword) {
    togglePassword.addEventListener('click', () => {
        const type = passwordField.type === 'password' ? 'text' : 'password';
        passwordField.type = type;
        togglePassword.classList.toggle('fa-eye-slash');
    });
}

const confirmPasswordField = document.getElementById('confirmPassword');
const toggleConfirmPassword = document.getElementById('toggleConfirmPassword');
if (confirmPasswordField && toggleConfirmPassword) {
    toggleConfirmPassword.addEventListener('click', () => {
        const type = confirmPasswordField.type === 'password' ? 'text' : 'password';
        confirmPasswordField.type = type;
        toggleConfirmPassword.classList.toggle('fa-eye-slash');
    });
}
