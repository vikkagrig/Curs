function ShowHidePassword(elem) {
    if (elem.classList.contains('show')) {
        elem.classList.remove('show');
        elem.classList.add('hide');
        elem.querySelector('input').setAttribute('type', 'password');
    } else {
        elem.classList.remove('hide');
        elem.classList.add('show');
        elem.querySelector('input').setAttribute('type', 'text');
    }
}

document.querySelectorAll('.form__password').forEach(el => {
    el.querySelector('a').addEventListener('click', () => {
        ShowHidePassword(el);
    })
});

//const selectElements = document.querySelectorAll(".faculties__select select");

//selectElements.forEach(selectElement => {
//    selectElement.addEventListener("change", async (event) => {
//        value = event.target.value; //Получаешь значение селекта
//        response = await fetch('/Home/List', {
//            method: 'POST',
//            body: params
//        });
//        for (const item of response) {
//            //Создание элементов
//        }
//        //Добавление элементов
//    });
//})