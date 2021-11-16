//JavaScript

const getPeopleList = (actionUrl) => {
    $.get(actionUrl, (response) => {
        document.getElementById("result").innerHTML = response;
    });
}

const postDetailsId = (actionUrl, inputId) => {
    let inputElement = $("#" + inputId);
    const data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    $.post(actionUrl, data, (response) => {
        console.log("response:", response);
        document.getElementById("result").innerHTML = response;
    })
}