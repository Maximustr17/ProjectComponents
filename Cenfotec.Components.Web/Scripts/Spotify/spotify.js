var clientId = "4363a32365b6472eb659f5cdd042ed62";
var urlToAcessAfterLogIn = "http%3A%2F%2Flocalhost%3A58438";
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
            "https://accounts.spotify.com/authorize?client_id=" + clientId + "&response_type=token&redirect_uri=" + urlToAcessAfterLogIn + "&scope=");

});

function AddInformationOfUser(user) {
    var image = $("<div></div>").css("background-image", "url(" + user.images[0].url + ")").addClass("profileImage");
    $("#mainBox").append(image);
    $("#txtUserName").text(user.display_name);
    console.log(user);
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