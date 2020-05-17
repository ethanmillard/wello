$(document).ready(() => {

    var url = window.location.href;
    var order = null;
    $.post(window.location.href + "orders",
        (data) => {
            order = data;
        });


    $("#add-small").click(() => {

        var coffeeRequest = {
            orderId: order.id,
            size: "small"
        }

        $.ajax({
            type: "POST",
            url: url + "coffees",
            data: JSON.stringify(coffeeRequest),
            contentType: "application/json",
            success: (data) => {
                $("#small-list").append(createCard(data.id));
            },
            error: (error) => {
                console.log(error);
            }
        });
    });

    $("#add-medium").click(() => {

        var coffeeRequest = {
            orderId: order.id,
            size: "medium"
        }

        $.ajax({
            type: "POST",
            url: url + "coffees",
            data: JSON.stringify(coffeeRequest),
            contentType: "application/json",
            success: (data) => {
                $("#medium-list").append(createCard(data.id));
            },
            error: (error) => {
                console.log(error);
            }
        });
    });

    $("#add-large").click(() => {

        var coffeeRequest = {
            orderId: order.id,
            size: "large"
        }

        $.ajax({
            type: "POST",
            url: url + "coffees",
            data: JSON.stringify(coffeeRequest),
            contentType: "application/json",
            success: (data) => {
                $("#large-list").append(createCard(data.id));
            },
            error: (error) => {
                console.log(error);
            }
        });
    });

    $("#coffees").on("click", ".remove", ((event) => {
        var coffeeId = event.target.value;

        $.ajax({
            type: "DELETE",
            url: url + "coffees/" + coffeeId,
            contentType: "application/json",
            success: () => {
                removeCard(coffeeId);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }));
});

removeCard = (id) => {
    $("#coffees").find("#" + id).remove();
};

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
						                    <span class="input-group-text" id="cream">Cream</span> \
					                    </div> \
					                    <input type="number" min="0" max="3" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"> \
				                    </div> \
			                    </li> \
			                    <li class="list-group"> \
				                    <div class="input-group input-group-sm mb-3"> \
					                    <div class="input-group-prepend"> \
						                    <span class="input-group-text" id="sugar">Sugar</span> \
					                    </div> \
					                    <input type="number" min="0" max="3" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"> \
				                    </div> \
			                    </li> \
			                    <li class="list-group"> \
				                    <button type="button" class="btn btn-danger remove" value="' + id + '">Remove</button> \
			                    </li> \
		                    </ul> \
	                    </div> \
                    </div> \
                </li> \
            </div>';
};