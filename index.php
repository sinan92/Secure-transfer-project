<?php
include('connect.php');
include('functions.php');
$error = '';
if(isset($_SESSION['login_user'])){
    header('Location: home.php');
}

if(isset($_POST['submit'])){
    if(login($conn, $_POST['username'], $_POST['password'])){
        header("Location: home.php");
    }
    else{
        $error = "Foutief login";
    }
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
    <div class="container-fluid">
	<div id="logo">
		<i class="fa fa-cloud-upload fa-5x"></i>
	</div>
	<div class="row">
		<div class="col-md-12">
			<form role="form" action="" method="post">
				<div class="form-group">
					 
					<label for="exampleInputEmail1">
						Username
					</label>
					<input name="username" type="text" class="form-control" id="exampleInputEmail1">
				</div>
				<div class="form-group">
					 
					<label for="exampleInputPassword1">
						Password
					</label>
					<input name="password" type="password" class="form-control" id="exampleInputPassword1">
				</div>
                <?php
                    if(!empty($error)){
                        echo '<div class="alert alert-danger">'
                                .$error.
                              '</div> ';
                    }
                ?>
				<input type="submit" id="submit" class="btn btn-info" name="submit" value="Submit" />
			</form>
		</div>
	</div>
</div>

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/scripts.js"></script>
  </body>
</html>