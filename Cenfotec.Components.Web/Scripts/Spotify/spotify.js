﻿var clientId = "4363a32365b6472eb659f5cdd042ed62";
var urlToAcessAfterLogIn = encodeURIComponent(window.location.origin);

var scope = "user-read-private%20user-read-email%20playlist-read-private%20user-top-read%20user-library-read%20user-read-birthdate%20user-read-currently-playing";


$(document).ready(function () {
    var accessToken = GetURLParameter("access_token");

    if (accessToken !== null)
        $.ajax({
            url: "https://api.spotify.com/v1/me",
            headers: {
                "Authorization": "Bearer " + accessToken
            },
            success: function (response) {
                AddInformationOfUser(response);
            }
        });
    else
        $("#BtnLogIn").attr("href",
            "https://accounts.spotify.com/authorize?client_id=" + clientId + "&response_type=token&redirect_uri=" + urlToAcessAfterLogIn + "&scope="+scope);
    $("#btnToSearch").click(MakeTheSearch);
});

function AddInformationOfUser(user) {
    var image = $("<div></div>").css("background-image", "url(" + user.images[0].url + ")").addClass("profileImage");
    $("#mainBox").append(image);
    $("#txtUserName").text(user.display_name);
    $("#BtnLogIn").remove();
}
function GetURLParameter(sParam) {
    var sPageUrl = window.location.hash.substring(1);
    var sUrlVariables = sPageUrl.split("&");
    for (var i = 0; i < sUrlVariables.length; i++) {
        var sParameterName = sUrlVariables[i].split("=");
        if (sParameterName[0] === sParam) {
            return sParameterName[1];
        }
    }
    return null;
}

function MakeTheSearch() {
    var accessToken = GetURLParameter("access_token");
    console.log($("#TextToSearch").val());
    $.ajax({
        url: "https://api.spotify.com/v1/search?q=" + encodeURI($("#TextToSearch").val()) + "&type=track&access_token=" + accessToken,
        success: function (response) {
            console.log(response);
            fillResultadosBusqueda(response);
        }
    });
}

function fillResultadosBusqueda(response) {
    $(".row").empty()
    $.each(response.tracks.items, function (index, value) {

        var div = $('<div id="idDiv" />').addClass("col-md-4");
        var div1 = $('<div id="idDiv1" />').addClass("card mb-4 box-shadow");
        var img = $('<img id="img1" />').addClass("card-img-top").attr("src", value.album.images[0].url);
        var div2 = $('<div id="idDiv2" />').addClass("card-body");
        var p1 = $('<p id="nameSong" />').addClass("card-text").text(value.name);
        var p2 = $('<p />').addClass("card-text");
        var div3 = $('<div id="idDiv3" />').addClass("d-flex justify-content-between align-items-center");
        var small1 = $('<p id="small1" />').addClass("text-muted").text("Duracion: " + msToTime(value.duration_ms));

        $(".row").append(div);
        $(div).append(div1);
        $(div1).append(img);
        $(div1).append(div2);
        $(div2).append(p1);
        $(div2).append(div3);
        $(div3).append(small1);
        $(div2).append(p2);

        var artists1 = "Artistas: ";

        $.each(value.artists, function (index, artist) {

            artists1 += artist.name + ' - ';

        });
        artists1 = artists1.slice(0, -2);
        $(p2).text(artists1);



    });

}

function msToTime(s) {
    var ms = s % 1000;
    s = (s - ms) / 1000;
    var secs = s % 60;
    s = (s - secs) / 60;
    var mins = s % 60;

    return mins + ':' + secs;
}

