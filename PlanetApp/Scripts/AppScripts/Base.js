$(document).ready(function () {


    
    $.get("api/Planet", function (data, status) {
        PopulateDOM(data);
    });
    
});


function PopulateDOM(planetList) {
    var planetList_DOM = $('#planetList');
    planetList.forEach(planet => {
        planetList_DOM.append(`
            <li class="list-group-item">
                <a id="planet-link-${planet.PK}" href="javascript:void(0);">${planet.Name}</a>
            </li>`);

        $(`#planet-link-${planet.PK}`).click(() => {
            UpdateModal(planet.PK);
        });
    });

}

function UpdateModal(planetPK) {

    $('#planetModal').modal('show');
    $.get("api/Planet/" + planetPK, function (data, status) {

        var imgElement = document.getElementById('planetImage');
        imgElement.src = "api/PlanetImage/" + data.PlanetImagePK;
        imgElement.alt = data.PlanetImageName;

        document.getElementById('planetTitle').innerText = data.Name;
        document.getElementById('planetDistanceFromSun').innerText = data.DistanceFromSun;
        document.getElementById('planetMass').innerText = data.Mass;
        document.getElementById('planetDiameter').innerText = data.Diameter;
    });
}

