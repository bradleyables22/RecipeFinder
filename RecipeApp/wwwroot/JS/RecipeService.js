function getRecipe(id) {
    return $.ajax({
        url: "https://localhost:7040/api/recipes/Get",
        type: "GET",
        dataType: "json",
        headers: { "recipeID": id }
    });
}


