document.addEventListener("DOMContentLoaded", () => {
    darkModeSwitch();
    select();
    contactSelect();
    search();
    handleProfileImageUpload();
})


function darkModeSwitch() {
    try {
        let sw = document.querySelector('#switch-mode');

        sw.addEventListener('change', function() {
            let mode = this.checked ? 'dark' : 'light'

            console.log(mode);

            fetch(`/sitesettings/theme?mode=${mode}`)
                .then(res => {
                    if (res.ok)
                        window.location.reload()
                    else
                        console.log('unable to switch theme mode');
                })
        })

    }
    catch { }
}

function select() {
    try {
        let select = document.querySelector("#course-select");

        let selected = select.querySelector("#course-selected");

        let selectOptions = select.querySelector("#course-select-options")

        selected.addEventListener("click", function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block';
        })

        let options = selectOptions.querySelectorAll("#course-option");

        options.forEach(function (option) {
            option.addEventListener("click", function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')

                updateCoursesByFilter(category)
            })
        })
    }
    catch { }
}

function contactSelect() {
    try {
        let select = document.querySelector("#contact-select")

        let selected = document.querySelector("#contact-selected")

        let selectOptions = select.querySelector("#contact-select-options")
        let inputService = document.querySelector(".input-service")

        selected.addEventListener("click", function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block';
        })


        let options = selectOptions.querySelectorAll("#contact-option");

        options.forEach(function (option) {
            option.addEventListener("click", function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let service = this.getAttribute('data-value')

                if (service !== "none") {
                    inputService.value = service;
                }
                else {
                    inputService.value = null;
                }
            })
        })
    }
    catch { }
}



function search() {
    try {
        document.querySelector("#searchQueary").addEventListener('keyup', function () {
            const searchValue = this.value
            const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
            console.log(searchValue)
            const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

            fetch(url)
                .then(res => res.text()
                .then(data => {
                    const parser = new DOMParser()
                    const dom = parser.parseFromString(data, "text/html")
                    document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

                    const pagination = dom.querySelector('pagination') ? dom.querySelector('.pagination').innerHTML : ''
                    document.querySelector(".pagination").innerHTML = pagination;
                }))
        })
    }
    catch { }
}

function updateCoursesByFilter(category) {

    try {
        const searchValue = document.getElementById('searchQuery').value
        const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

        fetch(url)
            .then(res => res.text())
            .then(data => {
                const parser = new DOMParser()
                const dom = parser.parseFromString(data, "text/html")
                document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

                const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
                document.querySelector(".pagination").innerHTML = pagination;
            })
    }
    catch { }
}


function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector("#fileUploader");
        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit();
                }
            })
        }

    }
    catch { }
}