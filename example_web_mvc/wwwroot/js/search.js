let productList = [];

// Fetch product data
fetch('/Customer/Home/GetProducts')
    .then(response => response.json())
    .then(data => {
        productList = data;
        console.log(data);
    })
    .catch(error => console.log(error));

// Handle input event
$('#searchInput').on('input', function () {
    const keyword = $(this).val().toLowerCase();
    const filteredProducts = productList.filter(p => p.title.toLowerCase().includes(keyword));

    // Build search results HTML
    let searchResultsHtml = '';
    for (let product of filteredProducts) {
        searchResultsHtml += `<li><a class="dropdown-item" href="#">${product.title} by ${product.author}</a></li>`;
    }

    // Insert search results into dropdown
    $('#searchResults').html(searchResultsHtml);

    // Show/hide the dropdown based on search results
    if (keyword && filteredProducts.length > 0) {
        $('#searchResults').addClass('show');
    } else {
        $('#searchResults').removeClass('show');
    }
});

// Handle click event on search results
$(document).on('click', '.dropdown-item', function (e) {
    e.preventDefault();
    const selectedText = $(this).text();
    $('#searchInput').val(selectedText);
    $('#searchResults').removeClass('show');
});
