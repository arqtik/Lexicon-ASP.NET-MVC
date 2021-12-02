const PersonIDInput = document.getElementById("PersonIDInput");

function GetAllPeople(){
    $.get("/Ajax/GetAllPeople", null, function (data) {
        $("#AjaxContainer").html(data)
    });
}

function GetPersonById(){
    $.post("/Ajax/GetPersonById", { id: PersonIDInput.value }, function (data) {
        $("#AjaxContainer").html(data)
    });
}

function DeletePersonById(){
    $.post("/Ajax/RemovePersonById", { id: PersonIDInput.value }, null)
        .done(function (){
            $("#ErrorMessages").html("Successfully deleted person");
            GetAllPeople();
        })
        .fail(function (){
            $("#ErrorMessages").html("Failed to delete person");
        });
}

function GetCitiesInCountry() {
    let citySelect = $("#CreatePerson_CityID");
    let countrySelect = $("#CreatePerson_CountryID");

    citySelect.empty();

    $.get('/City/GetCities', { countryId: countrySelect.val() }, function (data) {
        citySelect.html(data);
    });
    
}