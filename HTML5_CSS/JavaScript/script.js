document.getElementById('searchbtn').addEventListener('click', () => {
    const Input = document.getElementById('diginame');
    const digiName = Input.value;
    fetchDigiData(digiName);
});
async function fetchDigiData(digiName) {
    const digiInfoDiv = document.getElementById('digiinfo');
    console.log(digiInfoDiv);
    digiInfoDiv.innerHTML = `<p>Loading ...</p>`
    try {
        console.log(digiName);
        const response = await fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`);
        console.log(response);
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
    const digimon = data[0];
    const digidocuments = `
    <h2 class="diginom">Name = ${digimon.name}</h2>
    <img src="${digimon.img}" alt="${digimon.name}" class="imgdigi">
    <p>Level = ${digimon.level}<p>
    `;
    document.getElementById('digiinfo').innerHTML = digidocuments;
}