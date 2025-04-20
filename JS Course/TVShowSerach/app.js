const searchForm = document.querySelector("#searchForm");

searchForm.addEventListener("submit", async function (e) {
  e.preventDefault();
  const searchTerm = searchForm.elements.query.value;
  const config = { params: { q: searchTerm } };
  const res = await axios.get(
    `https://api.tvmaze.com/search/shows?q=${config}`
  );
  makeImages(res.data);
});

const makeImages = (shows) => {
  for (let result of shows) {
    if (result.show.image) {
      const img = document.createElement("img");
      img.src = result.show.image.medium;
      document.body.append(img);
    }
  }
};
