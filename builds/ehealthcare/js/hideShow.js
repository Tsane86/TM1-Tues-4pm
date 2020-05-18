function hideShow(divs) {
  console.log(divs);
  var divToToggle = document.getElementById(divs);
  console.log(divToToggle);
  if (divToToggle.style.display === "none") {
    divToToggle.style.display = "block";
  } else {
    divToToggle.style.display = "none";
  }
}
