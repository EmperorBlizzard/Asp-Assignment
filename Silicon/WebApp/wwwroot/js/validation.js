let formNodeList = document.querySelectorAll('form');
let signUpForm = document.querySelector('.signup-form')
let forms = Array.from(formNodeList);
let index = forms.indexOf(signUpForm);

if (index > -1) {
    forms.splice(index, 1);
}

forms.forEach(form => {
    let inputs = form.querySelectorAll('input');

    inputs.forEach(input => {
        if (input.dataset.val === 'true') {
            input.addEventListener('keyup', (e) => {
                
                if (e.target.type === 'text') {
                    allTextValidation(e, e.target.dataset.valMinlengthMin)
                }
                else if (e.target.type === 'email') {
                    allEmailValidation(e);
                }
                else {
                    allPasswordValidation(e);
                }
            })
        }
    })
})


const handleAllValidationOutput = (isValid, e, text = "") => {
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

const allTextValidation = (e, minLength = 1) => {
    if (e.target.value.length > 0) {
        handleAllValidationOutput(e.target.value.length >= minLength, e, e.target.dataset.valMinlength)
    }
    else {
        handleAllValidationOutput(false, e, e.target.dataset.valRequired)
    }
}

const allEmailValidation = (e) => {
    const regEx = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/

    if (e.target.value.length > 0) {
        handleAllValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    }
    else {
        handleAllValidationOutput(false, e, e.target.dataset.valRequired)
    }
}

const allPasswordValidation = (e) => {
    const regEx = /^(?=.*[0-9])(?=.*[a-z\u00F6\u00E4\u00E5])(?=.*[A-Z\u00D6\u00C4\u00C5])(?=.*[\W_])(?!.*\s).{8,}$/

    let compareTo = (e.target.dataset.valEqualtoOther)

    if (compareTo === "*.Password") {
        compareTo = compareTo.replace("*.", '')

        let passwrd = document.getElementById(compareTo)
        let compareToResult
        if (e.target.value.length > 0) {
            if (passwrd.value === e.target.value) {
                compareToResult = true
            }
            else {
                compareToResult = false
            }

            handleAllValidationOutput(compareToResult, e, e.target.dataset.valEqualto)
        }
        else {
            handleAllValidationOutput(false, e, e.target.dataset.valRequired)
        }
    }
    else if (compareTo === "*.NewPassword") {
        let passwrd = document.querySelector("#ChangePassword_NewPassword")

        if (e.target.value.length > 0) {
            if (passwrd.value === e.target.value) {
                compareToResult = true
            }
            else {
                compareToResult = false
            }

            handleAllValidationOutput(compareToResult, e, e.target.dataset.valEqualto)
        }
        else {
            handleAllValidationOutput(false, e, e.target.dataset.valRequired)
        }
    }
    else {
        if (e.target.value.length > 0)
            handleAllValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
        else
            handleAllValidationOutput(false, e, e.target.dataset.valRequired)
    }
}
