let form = document.querySelector('.signup-form');

let showPasswordBtn = document.querySelector(".show-password");
let showConfirmPasswordBtn = document.querySelector(".show-confirmpassword");
let passwordInput = document.querySelector("#Password")
let confirmInput = document.querySelector("#Confirm")
let passwordChecklist = document.querySelectorAll(".list-item")



if (form !== null) {

    showPasswordBtn.addEventListener("click", () => {
        showPasswordBtn.classList.toggle("fa-eye");
        showPasswordBtn.classList.toggle("fa-eye-slash");

        passwordInput.type = passwordInput.type === "password" ? "text" : "password";
    })

    showConfirmPasswordBtn.addEventListener("click", () => {
        showConfirmPasswordBtn.classList.toggle("fa-eye");
        showConfirmPasswordBtn.classList.toggle("fa-eye-slash");

        confirmInput.type = confirmInput.type === "password" ? "text" : "password";
    })

    let inputs = form.querySelectorAll('input');
    inputs.forEach(input => {
        if (input.dataset.val === 'true') {
            input.addEventListener('keyup', (e) => {
                if (e.target.type === "text") {
                    if (e.target.name === "Password") {
                        passwordValidation(e)
                    }
                    else if (e.target.name === "ConfirmPassword") {
                        passwordValidation(e)
                    }
                    else {
                        textValidation(e, e.target.dataset.valMinlengthMin)
                    }
                }
                else if (e.target.type === "email") {
                    emailValidation(e)
                }
                else {
                    passwordValidation(e)
                }

            })
        }
    })
}


const handleValidationOutput = (isValid, e, text = "") => {
    let span = document.querySelector(`[data-valmsg-for="${e.target.name}"]`)
    if (isValid) {        
        e.target.classList.remove('input-validation-error')
        span.classList.remove('field-validation-error')
        span.classList.add('field-validation-valid')
        span.innerHTML = ""
    }
    else {
        e.target.classList.add('input-validation-error')
        span.classList.add('field-validation-error')
        span.classList.remove('field-validation-valid')
        span.innerHTML = text
    }
}

const textValidation = (e, minLength = 1) => {
    if (e.target.value.length > 0) {
        handleValidationOutput(e.target.value.length >= minLength, e, e.target.dataset.valMinlength)
    }
    else {
        handleValidationOutput(false, e, e.target.dataset.valRequired)
    }
}

const emailValidation = (e) => {
    const regEx = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/

    if (e.target.value.length > 0) {
        handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    }
    else {
        handleValidationOutput(false, e, e.target.dataset.valRequired)
    }
}


const passwordValidation = (e) => {
    const regEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$/
    let compareTo = (e.target.dataset.valEqualtoOther)
    if (compareTo === "*.Password") {

        let passwrd = document.getElementById(compareTo.replace("*.", ''))
        let compareToResult
        if (e.target.value.length > 0) {
            if (passwrd.value === e.target.value) {
                compareToResult = true
            }
            else {
                compareToResult = false
            }

            handleValidationOutput(compareToResult, e, e.target.dataset.valEqualto)
        }
        else {
            handleValidationOutput(false, e, e.target.dataset.valRequired)
        }
    }
    else {
        
        let validationRegex = [
            { regex: /.{8,}/ },
            { regex: /[0-9]/ },
            { regex: /[a-z\u00F6\u00E4\u00E5]/ },
            { regex: /[A-Z\u00D6\u00C4\u00C5]/ },
            { regex: /[$&+,:;=?@#|'<>.^*()%!-]/ }
        ]

        passwordInput.addEventListener("keyup", () => {
            validationRegex.forEach((item, i) => {
                let isValid = item.regex.test(passwordInput.value);
                if (isValid) {
                    passwordChecklist[i].classList.add('checked');
                }
                else {
                    passwordChecklist[i].classList.remove("checked");
                }
            })
        })
        
    }

    
}

