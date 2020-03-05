window.onload = function () {
    getData();
};
var country = "";
var divWeather = document.getElementById("weatherContent");
var divCountry = document.getElementById("country");
var divValidations = document.getElementById("validations");

function fillSelect(countries) {
    for (let country of countries) {
        divCountry.innerHTML += `<option value="${country.name}">${country.name}</option>`
    }
};

function getData() {
    fetch("https://restcountries.eu/rest/v2/all")
        .then(res => res.json())
        .then(data => {
            fillSelect(data);
        });
};

function validateCountry() {
    divValidations.innerHTML = "";
    divWeather.innerHTML = "";
    if ((divCountry.value === "")) {
        divValidations.innerHTML += `<div class="alert alert-warning" role="alert">
            Please select any country from the list or click on the Geolocation icon to use your current location
        </div>`
        return;
    }
    country = divCountry.value
    let apiuri = "../api/Weather/?country=" + country;
    getWeatherData(apiuri);
};

function validateLocalitation(position) {
    divCountry.value = "";
    divValidations.innerHTML = "";
    divWeather.innerHTML = "";
    latitude = position.coords.latitude;
    longitude = position.coords.longitude;
    let apiuri = "../api/Weather/?latitude=" + latitude + "&longitude=" + longitude ;
    getWeatherData(apiuri);
};

function printWeather(data) {
    divWeather.innerHTML = "";
    divWeather.innerHTML += `<div class="card" style="width: 25rem;">
            <img src="${data.WeatherImage}" style="width: 20%" alt="...">
            <div class="card-body">
                <h5 class="card-title">${data.Temperature}°</h5>
                <h6 class="card-subtitle mb-2 text-muted">${data.Country}</h6>
                <p class="card-text">${data.Descriptions}</p>
                <p class="card-text">Precipitation: ${data.Precip}%</p>
                <p class="card-text small">As of ${data.Localtime}</p>
            </div>
        </div>`
};

function getWeatherData(url) {
    fetch(url)
        .then(res => res.json())
        .then(data => {
            printWeather(data)
        })
};

function getWeatherByCountry() {
    validateCountry();
};

function getWeatherByLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(validateLocalitation);
    } else {
        divValidations.innerHTML = "";
        divWeather.innerHTML = "";
        if ((divCountry.value === "")) {
            divValidations.innerHTML += `<div class="alert alert-warning" role="alert">
            Your browser doesn´t support Geolocation
        </div>`
        };
    };
}