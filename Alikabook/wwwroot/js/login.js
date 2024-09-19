const currentPasswordField = document.getElementById('currentPassword');
const toggleCurrentassword = document.getElementById('toggleCurrentPassword');
const passwordField = document.getElementById('password');
const togglePassword = document.getElementById('togglePassword');
const confirmPasswordField = document.getElementById('confirmPassword');
const toggleConfirmPassword = document.getElementById('toggleConfirmPassword');

toggleCurrentassword.addEventListener('click', () => {
    const type = currentPasswordField.type === 'password' ? 'text' : 'password';
    currentPasswordField.type = type;
});

togglePassword.addEventListener('click', () => {
    const type = passwordField.type === 'password' ? 'text' : 'password';
    passwordField.type = type;
});

toggleConfirmPassword.addEventListener('click', () => {
    const type = confirmPasswordField.type === 'password' ? 'text' : 'password';
    confirmPasswordField.type = type;
});
