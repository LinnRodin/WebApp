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

var formRegistration = document.getElementById('formRegistration'); //Retrieves the form element with the ID "formRegistration"

var fields = [
    { id: 'firstname', errorId: 'firstNameError', validationFn: validateRegisterName },   //Fields containing objects to be validated id, errorid and validationFn that calls the function for the field. 
    { id: 'lastname', errorId: 'lastNameError', validationFn: validateRegisterName },
    { id: 'email', errorId: 'emailError', validationFn: validateEmail },
    { id: 'password', errorId: 'passwordError', validationFn: validatePassword },
    { id: 'confirm-password', errorId: 'confirmPasswordError', validationFn: validateConfirmPassword },
    { id: 'acceptedterms', errorId: 'acceptedTermsError', validationFn: validateAcceptedTerms },
    { id: 'upload-image', errorId: 'uploadImageError', validationFn: validateImage }
];



function validateRegisterName(value) {   //Validation for the "firstname" and "lastname" fields
    var regex = /^[A-Za-z]+$/;
    if (value === '') {
        return 'Firstname is required.';
    } else if (!regex.test(value)) {
        return 'Invalid name format. Only alphabetic characters are allowed.';
    } else {
        return '';
    }
}

function validateEmail(value) {  // Validation for email field.
    if (!value.trim()) {
        return 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(value)) {
        return 'Invalid email format';
    }
    return '';
}

function validatePassword(value) {   //Validation for the Password field. 
    if (!value.trim()) {
        return 'Password is required';
    } else if (!/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}/.test(value)) {
        return 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.';
    }
    return '';
}

function validateConfirmPassword(value, passwordValue) {   //Validation for the ConfirmPassword field. 
    if (!value.trim()) {
        return 'You must confirm the password';
    } else if (value !== passwordValue) {
        return 'The password does not match';
    }
    return '';
}

function validateAcceptedTerms(value) {
    if (!value) {
        return 'You must accept the terms and agreements to proceed.';  // Validation for the "acceptedterms" field. (true or false)
    }
    return '';
}

function validateField(field) {         //takes a field object as input and performs validation for that field. It retrieves the input element, error message element, and value from the field object, calls the associated validation function, and sets the error message.
    var input = document.getElementById(field.id);
    var error = document.getElementById(field.errorId);
    var value = input.value.trim();
    var validationFn = field.validationFn;

    var errorMessage = validationFn(value, document.getElementById('password').value);
    error.textContent = errorMessage;
}

fields.forEach(function (field) {       // Loop through each field and attach a keyup event listener, to trigger the validateField function when the user types.                                                
    var input = document.getElementById(field.id);
    var validationFn = field.validationFn;

    input.addEventListener('keyup', function () {
        validateField(field);
    });
});

function validateImage() {              //Validates the condition for image types approved. 
    var allowedExtensions = ['.jpg', '.jpeg', '.png'];
    var fileInput = document.getElementById('upload-image');

    if (fileInput.files.length > 0) {
        var file = fileInput.files[0];
        var fileName = file.name.toLowerCase();
        var fileExtension = fileName.substring(fileName.lastIndexOf('.'));
        if (!allowedExtensions.includes(fileExtension)) {
            return 'Invalid image format. Allowed formats: JPG, JPEG, PNG';
        }
    }

    return '';
}


formRegistration.addEventListener('submit', function (event) {
    var hasErrors = false;

    fields.forEach(function (field) {
        validateField(field); // Call the validateField function for each field.
        var error = document.getElementById(field.errorId);
        if (error.textContent) {
            hasErrors = true;
        }
    });

    if (hasErrors) {
        event.preventDefault(); // Prevents the form from submitting if there are errors.
    }
});




// JS Validation Contactform

var formContact = document.getElementById('formContact');

var nameInput = document.querySelector('#name');
var emailInput = document.querySelector('#email');
var phoneNumberInput = document.querySelector('#phone');
var companyNameInput = document.querySelector('#company');
var messageInput = document.querySelector('#message');
var acceptedDataInput = document.querySelector('#AcceptedData');

var nameError = document.querySelector('span[data-valmsg-for="Name"]');
var emailError = document.querySelector('span[data-valmsg-for="Email"]');
var phoneNumberError = document.querySelector('span[data-valmsg-for="PhoneNumber"]');
var companyNameError = document.querySelector('span[data-valmsg-for="CompanyName"]');
var messageError = document.querySelector('span[data-valmsg-for="Message"]');
var acceptedDataError = document.querySelector('span[data-valmsg-for="AcceptedData"]');



let hasErrors = false;

// Reset error messages
var resetErrorMessages = () => {
    nameError.textContent = '';
    emailError.textContent = '';
    phoneNumberError.textContent = '';
    companyNameError.textContent = '';
    messageError.textContent = '';
    acceptedDataError.textContent = '';
};


var validateName = () => {                                             //First retrieves the value of the nameInput element (input field) and trims trailing whitespace from the value. The result is assigned to the nameValue variable. Then if (!nameValue) checks if its false so if its an empty string(name missing or not) or empty space. 
    var nameValue = nameInput.value.trim();                           // Then we check the conditions like name is required(nameError), hasErrors = true that means if any validation errors has occured, it is set to true to indicate that an error has occured. else if (!/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(nameValue)) { - If the previous condition is not met, this condition checks if nameValue does not match the specified regular expression. 
    if (!nameValue) {                                                 //nameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.'; - If nameValue does not match the pattern. Then hasErrors again to indicate if errors has been detected. 
            nameError.textContent = 'Name is required';
            hasErrors = true;
        } else if (!/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(nameValue)) {
            nameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.';
            hasErrors = true;
        }
    };

    var validateEmail = () => {
        var emailValue = emailInput.value.trim();
        if (!emailValue) {
            emailError.textContent = 'Email is required';
            hasErrors = true;
        } else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(emailValue)) {
            emailError.textContent = 'Invalid email format';
            hasErrors = true;
        }
    };

    var validatePhoneNumber = () => {
        var phoneNumberValue = phoneNumberInput.value.trim();
        if (phoneNumberValue && !/^\+?\d{5,15}$/.test(phoneNumberValue)) {
            phoneNumberError.textContent = 'Invalid phone number format. Only digits, optional leading "+" sign, and 5-15 digits allowed.';
            hasErrors = true;
        }
    };

    var validateCompanyName = () => {
        var companyNameValue = companyNameInput.value.trim();
        if (companyNameValue && !/^[a-zA-ZÅÄÖåäö\s'-]+$/.test(companyNameValue)) {
            companyNameError.textContent = 'Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.';
            hasErrors = true;
        }
    };

    var validateMessage = () => {
        var messageValue = messageInput.value.trim();
        if (messageValue.length > 500) {
            messageError.textContent = 'Message is too long. Maximum 500 characters allowed.';
            hasErrors = true;
        }
    };

    var validateAcceptedData = () => {
        var acceptedDataValue = acceptedDataInput.checked;
        if (!acceptedDataValue) {
            acceptedDataError.textContent = 'You must accept data storage to proceed.';
            hasErrors = true;
        }
    };

    // Event listeners for direct feedback for user with direct respons. 
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

    // Event listeners for the optional fields

    // Event listener for the form's submit event
    formContact.addEventListener('submit', function (event) {
        resetErrorMessages();
        hasErrors = false;

        validateName();
        validateEmail();
        validatePhoneNumber();
      

        if (hasErrors) {
            event.preventDefault();
        }
    });




//JS Validation LoginForm

var formLogin = document.getElementById('formLogin');

var emailInput = document.getElementById("Email");
var passwordInput = document.getElementById("Password");
var emailError = document.getElementById("email-error");
var passwordError = document.getElementById("password-error");



    var validateLoginForm = () => {
        let isValid = true;

        // Reset error messages
        emailError.innerText = "";
        passwordError.innerText = "";

        // Validates email
        if (emailInput.value.trim() === "") {
            emailError.innerText = "Email is required";
            isValid = false;
        } else if (!validateEmail(emailInput.value.trim())) {
            emailError.innerText = "Invalid email format";
            isValid = false;
        }

        // Validates password
        if (passwordInput.value.trim() === "") {
            passwordError.innerText = "Password is required";
            isValid = false;
        }

        return isValid;
    };

    var addEventListeners = () => {
        emailInput.addEventListener("keyup", validateLoginForm);
        passwordInput.addEventListener("keyup", validateLoginForm);
    };

    // Call the function to add event listeners
    addEventListeners();

    // Event listener for the form's submit event
    formLogin.addEventListener("submit", function (event) {
        if (!validateLoginForm()) {
            event.preventDefault(); // Prevent form submission if validation fails
        }
    });



