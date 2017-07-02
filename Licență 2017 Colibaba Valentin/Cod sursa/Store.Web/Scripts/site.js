$(window).ready(function () {
    var createSuggestionItem = function (sugestionText) {
        //SearchByName
        var baseUrl = $('#baseUrl').val();
        var url = baseUrl + "Product/SearchByName?name=" + sugestionText;
        //var suggestion = $('<li class="list-group-item suggestion-item"></li>');
        var suggestion = $('<a href="' +
            url +
            '">' +
            '<li class="list-group-item suggestion-item">' +
            sugestionText +
            '</li>' +
            '</a>');
        return suggestion;
    }

    var updateProductSugestionsConstainer = function (data, container) {
        container.empty();
        for (var i = 0; i < data.length; i++) {
            var item = data[i];
            var sugestion = createSuggestionItem(item);
            container.append(sugestion);
        }
    }


    var getSugestionsFor = function (name) {
        var container = $("#product-search-suggestions-content");
        container.empty();
        container.append($("<span>Please wait...</span>"));
        var baseUrl = $('#baseUrl').val();
        var url = baseUrl + "api/Product/getSugestion?productName=" + name;
        $.get(url, function (data) {
            updateProductSugestionsConstainer(data, container);
        });
    };

    $("#search-product").on('keyup', function (e) {
        var searchText = e.target.value;
        console.log(searchText);
        if (searchText.length > 0) {
            $("#product-search-suggestions").css('display', 'block');
            getSugestionsFor(searchText);
        } else {
            $("#product-search-suggestions").css('display', 'none');
        }
    })
});