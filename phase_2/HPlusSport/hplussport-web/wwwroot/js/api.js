var url = "https://localhost:5001/products";

var productsList = document.getElementById("products-list");

if (productsList)
{
    fetch(url)
    .then(response => response.json())
    .then(data => showProducts(data))
    .catch(ex => {
        alert("Something went wrong!");
        console.log(ex);
    });
}

function showProducts(products)
{
    products.forEach( product => {
        let li = document.createElement("li");
        let text = `${product.name} ($${product.price})`;
        li.appendChild(document.createTextNode(text));
        console.log(text);
        productsList.appendChild(li);
    });
}