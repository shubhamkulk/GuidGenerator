// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('#btnGenerate').click(function () {
    $.ajax({
        url: "/Home/GetGUID",
        type: "get",
        data: {
            count: $('#guidnumber').val(),
            uppercase: $('#chkUppercase').prop('checked'),
            braces: $('#chkBrackets').prop('checked'),
            hyphens: $('#chkHypens').prop('checked'),
            base64encode: $('#chkBase64').prop('checked')
        },
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            console.log(data);
            $('#txtResults').val(data.join('\n'));
        },
        Error: function (jqXHR) {
            console.log(data)
        }
    });

});


$('#btnValidate').click(function () {
    $.ajax({
        url: "/Home/ValidateGUID",
        type: "get",
        data: {
            input: $('#txtResults').val()
        },
        cache: false,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        success: function (data) {
            console.log(data);
        },
        Error: function (jqXHR) {
            console.log(data)
        }
    });

});


$('#copy2cb').click(function () {
    var copyText = document.getElementById("txtResults");
    copyText.select();
    document.execCommand("copy");
});

    function IsFirstNameEmpty() {

        alert("LOL");
}

$("#download2txt").click(function () {
    var l = document.createElement("a");
    l.href = "data:text/plain;charset=UTF-8," + document.getElementById("txtResults").value;
    l.setAttribute("download", "guidlist");
    l.click();
});


