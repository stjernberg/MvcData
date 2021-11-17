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
        document.getElementById("result").innerHTML = response;
    })

        .fail(() => {
            document.getElementById("message").innerHTML = "A person with that id doesn't exist.";
        })
}

const postDeleteId = (actionUrl, inputId) => {
    let inputElement = $("#" + inputId);
    const data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    $.post(actionUrl, data, (response) => {
        document.getElementById("result").innerHTML = response;
        document.getElementById("message").innerHTML = "The person was successfully deleted!";

    })

        .fail(() => {
            document.getElementById("message").innerHTML = "A person with that id doesn't exist.";
        })


}