


function carouselFitContent(elementId) {
    var carousels = document.getElementsByClassName('product-cards-carousel');
    if (carousels) {
        for (var i = 0; i < carousels.length; i++) {
            var cards = carousels[i].querySelectorAll(".product-card");
            if (cards.length > 0) {
                var height = cards[0].clientHeight;
                height -= 5;
                carousels[i].setAttribute("style", `height:${height}px`);
                console.log(height);
            }
        }
    }
}

