



function callAPI(url, data, type = "POST") {
    $.ajax({
        type: type,
        url: url,
        data: data,
        success: function (response) {
            console.log("Success");
            total = updateCart(response);
        },
        error: function (message) {
            console.log(message);
        }
    });
    return false;
}
function removeFromCart(data) {
    callAPI('/Cart/Delete', data, "DELETE");
    return false;
}
function getCart(url) {
    callAPI(url, null, "GET");
    return false;
}
function updateCart(data) {
    var str = "";
    if (data.games == null || data.games.length < 1) {
        str += `<h2> No items here</h2>

                       

`;
        $("#cart").html(str);
        return;
    }
    else {
        str += `                    <div class="table-responsive">
                    <table class="table nk-store-cart-products">
                        <tbody>`;
    }
    var total = 0;
    for (var i in data.games) {
        var game = data.games[i];
        str += `
        <tr>
                                <td class="nk-product-cart-thumb">
                                    <a href="store-product.html" class="nk-post-image">
                                        <img src="`+ game.coverPath + `" alt="Men Tshirt" class="nk-img">
                                    </a>
                                </td>
                                <td class="nk-product-cart-title">
                                    <h2 class="nk-post-title h5">
                                        <a href="store-product.html">`+ game.name + `</a>
                                    </h2>
                                </td>
                                <td class="nk-product-cart-price">$`+ game.price + `</td>
                                <td class="nk-product-cart-remove"><a href="#" onclick="removeFromCart({gameId:`+ game.id + `})"><span class="ion-trash-b"></span></a></td>
                            </tr>
    `;
        total += game.price;
    }
    str += `

                        </tbody>
                    </table>
                </div>

                <div class="nk-gap-2"></div>
                <div class="nk-cart-total">
                    Total <span>$`+ total + `</span>
                </div>
                <div class="nk-gap-3"></div>
                <div class="nk-cart-btns">
                    <a href="#" class="nk-btn nk-btn-lg nk-btn-color-main-1 link-effect-4" onclick="buy({price :ethers.utils.parseEther('${total}')})">
                        Buy
                    </a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="#" class="nk-btn nk-btn-lg link-effect-4 nk-cart-toggle">
                        Continue Shopping
                    </a>
                </div>
    
`
    $("#cart").html(str);
    var leng = data.games.length;
    if (leng === undefined || leng=== null)
        leng = 0;
    $("#totalOfCartItems").html(leng.toString());
}
