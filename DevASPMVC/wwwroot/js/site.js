const PersonIDInput = document.getElementById("PersonIDInput");

function GetAllPeople(){
    $.get("/Ajax/GetPeople", null, function (data) {
        $("#AjaxContainer").html(data)
    });
}

function GetPersonById(){
    
}

function DeletePersonById(){
    
}