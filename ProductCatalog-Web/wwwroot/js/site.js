async function getWeather(city) {
    const apiKey = "d2ea8afe48cf68f825420f9d8c8b89e0";
    const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric&lang=tr`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        if (!response.ok) {
            throw new Error(`API Hatası (${city}): ${data.message}`);
        }

        document.getElementById(`weatherCity_${city}`).textContent = data.name;
        document.getElementById(`weatherTemp_${city}`).textContent = `${Math.round(data.main.temp)} °C`;
        document.getElementById(`weatherDesc_${city}`).textContent =
            data.weather[0].description.charAt(0).toUpperCase() + data.weather[0].description.slice(1);
        document.getElementById(`weatherIcon_${city}`).src =
            `https://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;

    } catch (error) {
        console.error(error);
        document.getElementById(`weatherDesc_${city}`).textContent = "Bilgi alınamadı";
        document.getElementById(`weatherTemp_${city}`).textContent = "-- °C";
        document.getElementById(`weatherIcon_${city}`).src = "";
    }
}

document.addEventListener("DOMContentLoaded", () => {
    const cityElements = document.querySelectorAll(".weather-card h2");
    cityElements.forEach(cityEl => getWeather(cityEl.textContent.trim()));
});


