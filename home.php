<?php
include('connect.php');
$file = null;
if(isset($_POST['submit'])){
    $file = file_get_contents($_FILES['sendFile']['tmp_name']);
    $file = unpack('C*', $file);
    echo json_encode($file);
}

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Bootstrap 3, from LayoutIt!</title>

    <meta name="description" content="Source code generated using layoutit.com">
    <meta name="author" content="LayoutIt!">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link rel="stylesheet" href="css/font-awesome.min.css">

</head>
<body>
<div class="container">
    <div id="logo">
        <i class="fa fa-cloud-upload fa-5x"></i>
    </div>
    <div class="row">
        <div id="file" style="display:none;"><?php echo $file ?></div>
        <div id="side-menu" class="col-sm-4">
            Van:
            <div id="gebruikers-van" class="list-group">
            </div>
            Naar:
            <div id="gebruikers-naar" class="list-group">
            </div>
        </div>
        <div id="content" class="col-sm-7">
            <div id="gekozen-gebruiker">
                Klik een gebruiker aan
            </div>
            <form action="" method="post" enctype="multipart/form-data">
                <div class="form-group">
                    <label for="exampleFakeFile1">File</label>

                    <div class="input-group">
                        <input type="file" id="exampleFile1" name="exampleFile1" style="display: none">
                        <label class="btn btn-default btn-file">
                            Browse <input type="file" name="sendFile" style="display: none;">
                        </label>
                    </div>
                </div>
                <input type="submit" name="submit" class="btn btn-default" value="Submit" />
            </form>
        </div>
    </div>
</div>

<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/scripts.js"></script>
</body>
</html>
<script>
    $( document ).ready(function() {
        var file = $("#file").html();
        if(file != ''){
            $.ajax({
                type: "POST",
                dataType: 'json',
                url: "http://localhost:52930/api/person/",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({Name: "Sinan3", Password: 'test'})
            })
                .done(function( msg ) {
                    alert(msg)
                });
        }

        $.ajax({
            method: "GET",
            dataType: 'json',
            url: "http://localhost:52930/api/person/"
        })
        .done(function( msg ) {
            var gebruikersnaamVan = '';
            var gebruikersnaamNaar = '';

            $.each(msg, function (key, val) {
                $("#gebruikers-van").append('<a href="#" class="list-group-item">'+val.Name+'</a>');
                $("#gebruikers-naar").append('<a href="#" class="list-group-item">'+val.Name+'</a>');
            })

            $("#gebruikers-van a").on("click", function () {
                gebruikersnaamVan = $(this).html();
                if (gebruikersnaamNaar == '') {
                    $("#gekozen-gebruiker").html(gebruikersnaamVan + " kies naar wie je een bestand wilt sturen.");
                } else {
                    $("#gekozen-gebruiker").html(gebruikersnaamVan + " stuurt een bestand naar " + gebruikersNaamNaar);
                }
            })

            $("#gebruikers-naar a").on("click", function () {
                gebruikersNaamNaar = $(this).html();
                if (gebruikersnaamVan == '') {
                    $("#gekozen-gebruiker").html("Kies van welk gebruiker het bestand komt");
                } else {
                    $("#gekozen-gebruiker").html(gebruikersnaamVan + " stuurt een bestand naar " + gebruikersNaamNaar);
                }
            })
        });
    });
</script>
