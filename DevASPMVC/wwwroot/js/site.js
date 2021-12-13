﻿const PersonIDInput = document.getElementById("PersonIDInput");

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
    let citySelect = $("select[data-select='city']");
    let countrySelect = $("select[data-select='country']");

    citySelect.empty();

    $.get('/City/GetCities', { countryId: countrySelect.val() }, function (data) {
        citySelect.html(data);
    });
    
}

$("#PeopleSearch").submit(function(e){
    e.preventDefault();
    let queryString = $("#PeopleSearch > input:first")[0].value;

    $.get("/People/Search", { query: queryString }, function (data) {
        $("#PeopleList").html(data);
    });
});