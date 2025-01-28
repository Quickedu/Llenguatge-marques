document.getElementById('searchbtn').addEventListener('click', () => {
    const digiName = document.getElementById('diginame');
    fetchDigiData(digiName);
});

document.getElementById('rndbtn').addEventListener('click', () => {
});

async function fetchDigiData(digiName) {
    const digiInfoDiv = document.getElementById('digiinfo');
    digiInfoDiv.innerHTML = `<p>Loading ...</p>`
    try {
        const response = await fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`);
        if (!response.ok){
            throw new Error ('Digimon no trobat!');
        }
        const data = await response.json();
        displayDigiData(data);
    }
    catch (error){
        document.getElementById('digiinfo').innerHTML = `<p style="color: red">${error.message}</p>`;
    }
}
function displayDigiData (data){
    const digidocuments = `
    <h2>${data.name}</h2>
    <img src="${data.img}" alt="${data.name}">
    <p>"Level = ${data.level}"<p>
    `
    document.getElementById(digiinfo).innerHTML = digidocuments;
}