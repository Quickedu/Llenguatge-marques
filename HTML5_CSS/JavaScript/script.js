document.getElementById('searchbtn').addEventListener('click', () => {
    const alienName = document.getElementById('alienname').value.toLowerCase();
    fetchAlienData(alienname);
});

document.getElementById('rndbtn').addEventListener('click', () => {
})

async function fetchAlienData(alienname) {
    const alienInfoDiv = document.getElementById('alieninfo');
    alienInfoDiv.innerHTML = `<p>Loading ...</p>`
    try {
        const response = await fetch(`https://ben10-api.herokuapp.com/aliens/6078370439565863c09f4486`)
    }

}