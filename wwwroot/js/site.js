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

const fields = [
    { id: 'firstname', errorId: 'firstNameError', validationFn: validateName },
    { id: 'lastname', errorId: 'lastNameError', validationFn: validateName },
    { id: 'email', errorId: 'emailError', validationFn: validateEmail },
    { id: 'password', errorId: 'passwordError', validationFn: validatePassword },
    { id: 'confirm-password', errorId: 'confirmPasswordError', validationFn: validateConfirmPassword },
    { id: 'AcceptedTerms', errorId: 'acceptedTermsError', validationFn: validateAcceptedTerms },
    { id: 'upload-image', errorId: 'uploadImageError', validationFn: validateImage }
];

function validateName(value) {
    if (!value.trim()) {
        return 'Field is required';
    }
    return '';
}

function validateEmail(value) {
    if (!value.trim()) {
        return 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(value)) {
        return 'Invalid email format';
    }
    return '';
}

function validatePassword(value) {
    if (!value.trim()) {
        return 'Password is required';
    } else if (!/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}/.test(value)) {
        return 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.';
    }
    return '';
}

function validateConfirmPassword(value, passwordValue) {
    if (!value.trim()) {
        return 'You must confirm the password';
    } else if (value !== passwordValue) {
        return 'The password does not match';
    }
    return '';
}

function validateAcceptedTerms(value) {
    if (!value) {
        return 'You must accept the terms and agreements to proceed.';
    }
    return '';
}

function validateField(field) {
    const input = document.querySelector(`#${field.id}`);
    const error = document.querySelector(`#${field.errorId}`);
    const value = input.value.trim();
    const validationFn = field.validationFn;

    const errorMessage = validationFn(value, password.value);
    error.textContent = errorMessage;
}

fields.forEach((field) => {
    const input = document.querySelector(`#${field.id}`);
    const validationFn = field.validationFn;

    input.addEventListener('keyup', function () {
        validateField(field);
    });
});

function validateImage() {
    const allowedExtensions = ['.jpg', '.jpeg', '.png'];
    const fileInput = document.querySelector('#upload-image');
    const file = fileInput.files[0];

    if (file) {
        const fileName = file.name.toLowerCase();
        const fileExtension = fileName.substring(fileName.lastIndexOf('.'));
        if (!allowedExtensions.includes(fileExtension)) {
            return 'Invalid image format. Allowed formats: JPG, JPEG, PNG';
        }
    }

    return '';
}

form.addEventListener('submit', function (event) {
    let hasErrors = false;

    fields.forEach((field) => {
        validateField(field);
        const error = document.querySelector(`#${field.errorId}`);
        if (error.textContent) {
            hasErrors = true;
        }
    });

    if (hasErrors) {
        event.preventDefault();
    }
});




// JS Validation Contactform

const form = document.querySelector('form');

const nameInput = document.querySelector('#name');
const emailInput = document.querySelector('#email');
const phoneNumberInput = document.querySelector('#phone');
const companyNameInput = document.querySelector('#company');
const messageInput = document.querySelector('#message');
const acceptedDataInput = document.querySelector('#AcceptedData');

const nameError = document.querySelector('span[data-valmsg-for="Name"]');
const emailError = document.querySelector('span[data-valmsg-for="Email"]');
const phoneNumberError = document.querySelector('span[data-valmsg-for="PhoneNumber"]');
const companyNameError = document.querySelector('span[data-valmsg-for="CompanyName"]');
const messageError = document.querySelector('span[data-valmsg-for="Message"]');
const acceptedDataError = document.querySelector('span[data-valmsg-for="AcceptedData"]');

let hasErrors = false;

// Reset error messages
const resetErrorMessages = () => {
    nameError.textContent = '';
    emailError.textContent = '';
    phoneNumberError.textContent = '';
    companyNameError.textContent = '';
    messageError.textContent = '';
    acceptedDataError.textContent = '';
};

const validateName = () => {
    const nameValue = nameInput.value.trim();
    if (!nameValue) {
        nameError.textContent = 'Name is required';
        hasErrors = true;
    } else if (!/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(nameValue)) {
        nameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.';
        hasErrors = true;
    }
};

const validateEmail = () => {
    const emailValue = emailInput.value.trim();
    if (!emailValue) {
        emailError.textContent = 'Email is required';
        hasErrors = true;
    } else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(emailValue)) {
        emailError.textContent = 'Invalid email format';
        hasErrors = true;
    }
};

const validatePhoneNumber = () => {
    const phoneNumberValue = phoneNumberInput.value.trim();
    if (phoneNumberValue && !/^\+?\d{5,15}$/.test(phoneNumberValue)) {
        phoneNumberError.textContent = 'Invalid phone number format. Only digits, optional leading "+" sign, and 5-15 digits allowed.';
        hasErrors = true;
    }
};

const validateCompanyName = () => {
    const companyNameValue = companyNameInput.value.trim();
    if (companyNameValue && !/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(companyNameValue)) {
        companyNameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.';
        hasErrors = true;
    }
};

const validateMessage = () => {
    const messageValue = messageInput.value.trim();
    if (messageValue.length > 500) {
        messageError.textContent = 'Message is too long. Maximum 500 characters allowed.';
        hasErrors = true;
    }
};

const validateAcceptedData = () => {
    const acceptedDataValue = acceptedDataInput.checked;
    if (!acceptedDataValue) {
        acceptedDataError.textContent = 'You must accept data storage to proceed.';
        hasErrors = true;
    }
};

// Event listeners for direct feedback for the user
nameInput.addEventListener('keyup', function () {
    resetErrorMessages();
    validateName();
});

emailInput.addEventListener('keyup', function () {
    resetErrorMessages();
    validateEmail();
});

phoneNumberInput.addEventListener('keyup', function () {
    resetErrorMessages();
    validatePhoneNumber();
});



// JS Validation LoginForm 

const emailInput = document.getElementById("Email");
const passwordInput = document.getElementById("Password");
const emailError = document.getElementById("email-error");
const passwordError = document.getElementById("password-error");

const validateLoginForm = () => {
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
};

const addEventListeners = () => {
    emailInput.addEventListener("keyup", validateLoginForm);
    passwordInput.addEventListener("keyup", validateLoginForm);
};

// Call the function to add event listeners
addEventListeners();
