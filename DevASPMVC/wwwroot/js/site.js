const PersonIDInput = document.getElementById("PersonIDInput");

function GetAllPeople(){
    $.get("/Ajax/GetAllPeople", null, function (data) {
        $("#AjaxContainer").html(data)
    });
}

function GetPersonById(){
    $.get("/Ajax/GetPersonById", { id: PersonIDInput.value }, function (data) {
        $("#AjaxContainer").html(data)
    });
}

function DeletePersonById(){
    
}