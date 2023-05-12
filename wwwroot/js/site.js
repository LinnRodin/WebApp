try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })
} catch { }



//JS Validation registrationform

const form = document.querySelector('form');

form.addEventListener('submit', function (event) {
    const firstName = document.querySelector('#firstName').value.trim();
    const lastName = document.querySelector('#lastName').value.trim();
    const email = document.querySelector('#email').value.trim();
    const password = document.querySelector('#password').value.trim();
    const confirmPassword = document.querySelector('#confirmPassword').value.trim();
    const acceptedTerms = document.querySelector('#acceptedTerms').checked;

    const firstNameError = document.querySelector('#firstNameError');
    const lastNameError = document.querySelector('#lastNameError');
    const emailError = document.querySelector('#emailError');
    const passwordError = document.querySelector('#passwordError');
    const confirmPasswordError = document.querySelector('#confirmPasswordError');
    const acceptedTermsError = document.querySelector('#acceptedTermsError');

    let hasErrors = false;

    if (!firstName) {
        firstNameError.textContent = 'Firstname is required';
        hasErrors = true;
    } else {
        firstNameError.textContent = '';
    }

    if (!lastName) {
        lastNameError.textContent = 'Lastname is required';
        hasErrors = true;
    } else {
        lastNameError.textContent = '';
    }

    if (!email) {
        emailError.textContent = 'Email is required';
        hasErrors = true;
    } else if (!/\S+@\S+\.\S+/.test(email)) {
        emailError.textContent = 'Invalid email format';
        hasErrors = true;
    } else {
        emailError.textContent = '';
    }

    if (!password) {
        passwordError.textContent = 'Password is required';
        hasErrors = true;
    } else if (!/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}/.test(password)) {
        passwordError.textContent = 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.';
        hasErrors = true;
    } else {
        passwordError.textContent = '';
    }

    if (!confirmPassword) {
        confirmPasswordError.textContent = 'You must Confirm Password';
        hasErrors = true;
    } else if (confirmPassword !== password) {
        confirmPasswordError.textContent = 'The password does not match';
        hasErrors = true;
    } else {
        confirmPasswordError.textContent = '';
    }

    if (!acceptedTerms) {
        acceptedTermsError.textContent = 'You must accept the terms and agreements to proceed.';
        hasErrors = true;
    } else {
        acceptedTermsError.textContent = '';
    }

    if (hasErrors) {
        event.preventDefault();
    }
});




// JS Validation Contactform 

const form = document.querySelector('form');

form.addEventListener('submit', function (event) {
    const name = document.querySelector('#Name').value.trim();
    const email = document.querySelector('#Email').value.trim();
    const phoneNumber = document.querySelector('#PhoneNumber').value.trim();
    const companyName = document.querySelector('#CompanyName').value.trim();
    const message = document.querySelector('#Message').value.trim();
    const acceptedData = document.querySelector('#AcceptedData').checked;

    const nameError = document.querySelector('#NameError');
    const emailError = document.querySelector('#EmailError');
    const phoneNumberError = document.querySelector('#PhoneNumberError');
    const companyNameError = document.querySelector('#CompanyNameError');
    const messageError = document.querySelector('#MessageError');
    const acceptedDataError = document.querySelector('#AcceptedDataError');

    let hasErrors = false;

    if (!name) {
        nameError.textContent = 'Name is required';
        hasErrors = true;
    } else if (!/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(name)) {
        nameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.';
        hasErrors = true;
    } else {
        nameError.textContent = '';
    }

    if (!email) {
        emailError.textContent = 'Email is required';
        hasErrors = true;
    } else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email)) {
        emailError.textContent = 'Invalid email format';
        hasErrors = true;
    } else {
        emailError.textContent = '';
    }

    if (phoneNumber && !/^\+?\d{5,15}$/.test(phoneNumber)) {
        phoneNumberError.textContent = 'Invalid phone number format. Only digits, optional leading "+" sign, and 5-15 digits allowed.';
        hasErrors = true;
    } else {
        phoneNumberError.textContent = '';
    }

    if (companyName && !/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(companyName)) {
        companyNameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.';
        hasErrors = true;
    } else {
        companyNameError.textContent = '';
    }

    if (message && message.length > 500) {
        messageError.textContent = 'Message is too long. Maximum 500 characters allowed.';
        hasErrors = true;
    } else {
        messageError.textContent = '';
    }

    if (!acceptedData) {
        acceptedDataError.textContent = 'You must accept data storage to proceed.';
        hasErrors = true;
    } else {
        acceptedDataError.textContent = '';
    }

    if (hasErrors) {
        event.preventDefault();
    }
});

// JS Validation Loginform 
function validateLoginForm() {
    const emailInput = document.getElementById("Email");
    const passwordInput = document.getElementById("Password");
    const emailError = document.getElementById("email-error");
    const passwordError = document.getElementById("password-error");

    let isValid = true;

    // Reset error messages
    emailError.innerText = "";
    passwordError.innerText = "";

    // Validate email
    if (emailInput.value.trim() === "") {
        emailError.innerText = "Email is required";
        isValid = false;
    } else if (!validateEmail(emailInput.value.trim())) {
        emailError.innerText = "Invalid email format";
        isValid = false;
    }

    // Validate password
    if (passwordInput.value.trim() === "") {
        passwordError.innerText = "Password is required";
        isValid = false;
    }

    return isValid;
}

function validateEmail(email) {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(email);
}
