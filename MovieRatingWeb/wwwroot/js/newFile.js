const genreSelect = document.getElementById("genre");

genreSelect.addEventListener("change", () => {
    const selectedGenre = genreSelect.value;
    console.log(`Selected genre: ${selectedGenre}`);
});

