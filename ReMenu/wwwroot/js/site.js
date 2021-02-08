!DOCTYPE html >
<html lang="en">
<head>

            <meta charset="utf-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />
            <link rel="stylesheet"
                href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"
                integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
                <script src="https://unpkg.com/axios/dist/axios.min.js"></script>
                <title>Restaurant Location</title>
</head>
            <body>
                <div class="container">
                    <h2 id="text-center">Enter Location: </h2>
                    <form id="location-form">
                        <input type="text" id="location-input" class="form-control form-control-lg" />
                        <br />
                        <button type="submit" class="btn btn-primary btn-block">Submit</button>
                    </form>
                    <div class="card-block" id="formatted-address"></div>
                    <div class="card-block" id="address-components"></div>
                    <div class="card-block" id="geometry"></div>

                </div>

                <script>
        //call geocode
        //geocode();

        // get location form
                    var locationForm = document.getElementById('location-form');

                    // listen for Submit
                    locationForm.addEventListener('submit', geocode);

        function geocode(e) {
                        // prevent actual submit
                        e.preventDefault();

            var location = document.getElementById('location-input').value;
            axios.get('https://maps.googleapis.com/maps/api/geocode/json', {
                        params: {
                        address: location,
                    key: 'AIzaSyDH-AHPkG7sqhn-wuOeBQD1QVN2KL_WwnU'
                }
            })
                .then(function (response) {
                        // log full response
                        console.log(response);

                    // formatted address
                    var formattedAddress = response.data.results[0].formatted_address;
                    var formattedAddressOutput = `
                        <ul class="list-group">
                        <li class="list-group-item">${formattedAddress}</li>
                    </ul>
                    `;

                    // address components
                    var addressComponents = response.data.results[0].address_components;
                    var addressComponentsOutput = '<ul class="list-group">';
                    for (var i = 0; i < addressComponents.length; {
                            addressComponentsOutput += `
                       <li class="list-group-item"><strong>${addressComponents[i].types[0]
                            }</strong> ${addressComponents[i].long_name}</li>
                       }
                    `;
                    }
                    addressComponentsOutput += '</ul>';

                    // geometry
                    var lat = response.data.results[0].geometry.location.lat;
                    var lng = response.data.results[0].geometry.location.lng;
                    var geometryOutput = `
                       <ul class="list-group">
                        <li class="list-group-item"><strong>Latitude</strong>:
                         ${lat}</li>
                        <li class="list-group-item"><strong>Longitude</strong>:
                         ${lng}</li>
                    </ul>
                    `;

                    // output to the app
                    document.getElementById('formatted-address').innerHTML = formattedAddressOutput;
                    document.getElementById('address-components').innerHTML = addressComponentsOutput;
                    document.getElementById('geometry').innerHTML = geometryOutput;
                })
                .catch(function (error) {
                        console.log(error);
                });
    </script>
            </body>
</html>