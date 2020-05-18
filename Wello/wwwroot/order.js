$(document).ready(() => {

    var order = {
        id: 0,
        coffees: []
    };

    $.post(window.location.href + "orders",
        (data) => {
            order.id = data.id;
        });

    $("#add-small").click(() => {
        addCoffee("#small-list", "small", order);
    });

    $("#add-medium").click(() => {
        addCoffee("#medium-list", "medium", order);
    });

    $("#add-large").click(() => {
        addCoffee("#large-list", "large", order);
    });

    $("#nickle").click(() => {
        addFunds(order.id, "nickle");
    });

    $("#dime").click(() => {
        addFunds(order.id, "dime");
    });

    $("#quarter").click(() => {
        addFunds(order.id, "quarter");
    });

    $("#loonie").click(() => {
        addFunds(order.id, "loonie");
    });

    $("#toonie").click(() => {
        addFunds(order.id, "toonie");
    });

    $("#purchase").click(() => {
        var url = window.location.href;
        $.ajax({
            type: "POST",
            url: url + "orders/" + order.id + "/submit",
            contentType: "application/json",
            success: (data) => {
                $("#coffees").hide();
                $("#order").show();

                updateBanner(data);
            },
            error: (error) => {
                console.log(error);
            }
        });
    });

    $("#coffees").on("change", ".update-cream", (event) => {
        var coffeeId = event.target.id;

        var coffee = order.coffees.find(coffee => coffee.id.toString() === coffeeId);
        coffee.amountOfCream = parseInt(event.target.value);

        updateCoffee(coffee);
    });

    $("#coffees").on("change", ".update-sugar", (event) => {
        var coffeeId = event.target.id;

        var coffee = order.coffees.find(coffee => coffee.id.toString() === coffeeId);
        coffee.amountOfSugar = parseInt(event.target.value);

        updateCoffee(coffee);
    });

    $("#coffees").on("click", ".remove", (event) => {
        var coffeeId = event.target.id;
        var url = window.location.href;

        $.ajax({
            type: "DELETE",
            url: url + "coffees/" + coffeeId,
            contentType: "application/json",
            success: () => {
                order.coffees = order.coffees.filter(coffee => coffee.id.toString() !== coffeeId);
                $("#coffees").find("#" + coffeeId).remove();
            },
            error: (error) => {
                console.log(error);
            }
        });
    });
});

addCoffee = (listId, size, order) => {
    var url = window.location.href;
    var coffeeRequest = {
        orderId: order.id,
        size: size
    }

    $.ajax({
        type: "POST",
        url: url + "coffees",
        data: JSON.stringify(coffeeRequest),
        contentType: "application/json",
        success: (data) => {
            order.coffees.push(data);
            $(listId).append(createCard(data.id));
        },
        error: (error) => {
            console.log(error);
        }
    });
};

updateCoffee = (coffeeRequest) => {
    var url = window.location.href;

    $.ajax({
        type: "PUT",
        url: url + "coffees",
        data: JSON.stringify(coffeeRequest),
        contentType: "application/json",
        error: (error) => {
            console.log(error);
        }
    });
};

addFunds = (orderId, amount) => {
    var url = window.location.href;

    $.ajax({
        type: "POST",
        url: url + "orders/" + orderId + "/" + amount,
        contentType: "application/json",
        success: (data) => {
            updateBanner(data);
        },
        error: (error) => {
            console.log(error);
        }
    });
}

updateBanner = (order) => {
    if (order.amountDue <= order.amountPaid) {
        $("#owning-banner").hide();
        $("#currency").hide();
        $("#success-banner").show();
        
        $("#success-banner").text("Order complete. Making coffee and dispensing your change of $" + (order.amountPaid - order.amountDue).toFixed(2) + ".");
    }

    $("#owning-banner").text("Order total: $" + order.amountDue.toFixed(2) + ". Amount paid: $" + order.amountPaid.toFixed(2) + ".");
}

createCard = (id) => {
    return '<div id="' + id + '"> \
                <li class="list-group-item"> \
                    <div class="card"> \
	                    <div class="card-body"> \
		                    <h5 class="card-title">Coffee ' + id + '</h5> \
		                    <ul class="list-group"> \
			                    <li class="list-group"> \
				                    <div class="input-group input-group-sm mb-3"> \
					                    <div class="input-group-prepend"> \
						                    <span class="input-group-text">Cream</span> \
					                    </div> \
					                    <input type="number" min="0" max="3" class="form-control update-cream" aria-label="Small" aria-describedby="inputGroup-sizing-sm" id="' + id + '"> \
				                    </div> \
			                    </li> \
			                    <li class="list-group"> \
				                    <div class="input-group input-group-sm mb-3"> \
					                    <div class="input-group-prepend"> \
						                    <span class="input-group-text">Sugar</span> \
					                    </div> \
					                    <input type="number" min="0" max="3" class="form-control update-sugar" aria-label="Small" aria-describedby="inputGroup-sizing-sm" id="' + id + '"> \
				                    </div> \
			                    </li> \
			                    <li class="list-group"> \
				                    <button type="button" class="btn btn-danger remove" id="' + id + '">Remove</button> \
			                    </li> \
		                    </ul> \
	                    </div> \
                    </div> \
                </li> \
            </div>';
};