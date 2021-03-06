﻿// Write your JavaScript code.

// The location of Uluru
var uluru = { lat: -25.344, lng: 131.036 };
// The map, centered at Uluru
var map = new google.maps.Map(
    document.getElementById('map'), { zoom: 4, center: uluru });
// The marker, positioned at Uluru
var marker = new google.maps.Marker({ position: uluru, map: map });

$(function () {
    d3.select(".chart")
        .selectAll("div")
        .data(data)
        .enter().append("div")
        .style("width", function (d) { return d * 10 + "px"; })
        .text(function (d) {
            return d;
        });
});

function eqfeed_callback(response) {
    map.data.addGeoJson(response);
}