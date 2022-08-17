<?php
$servername = "localhost";
$server_username = "id8983768_engenhariadesoftwareusername";
$server_password = "software";
$dbName = "id8983768_gameengenhariadesoftware";
/*
$servername = "localhost";
$server_username = "engenharia_de_software";
$server_password = "123qwe";
$dbName = "engenharia_de_software";
*/

    use PHPMailer\PHPMailer\PHPMailer;
    require_once "functions.php";

    if (isset($_POST['email'])) {
        $conn = new mysqli($servername, $server_username, $server_password, $dbName);

        $email = $conn->real_escape_string($_POST['email']);

        $sql = $conn->query("SELECT id FROM users WHERE email='$email'");
        if ($sql->num_rows > 0) {

            $token = generateNewString();

	        $conn->query("UPDATE users SET token='$token', 
                      tokenExpire=DATE_ADD(NOW(), INTERVAL 5 MINUTE)
                      WHERE email='$email'
            ");

	        require_once "PHPMailer/PHPMailer.php";
	        require_once "PHPMailer/Exception.php";

	        $mail = new PHPMailer();
	        $mail->addAddress($email);
	        $mail->setFrom("leo_nardo136@hotmail.com","LEO");
	        $mail->Subject = "Resetar senha";
	        $mail->isHTML(true);
	        $mail->Body = "
	            Olá,<br><br>
	            
	            Para resetar sua senha, clique no link abaixo:<br>
	            <a href='
	            http://localhost/ResetPassword/resetPassword.php?email=$email&token=$token
	            '>http://localhost/ResetPassword/resetPassword.php?email=$email&token=$token</a><br><br>
	            
	            Abraços,<br>
	            Leonardo.
	        ";

	        if ($mail->send())
    	        exit(json_encode(array("status" => 1, "msg" => 'Por favor cheque o seu email!')));
    	    else
    	        exit(json_encode(array("status" => 0, "msg" => 'Algo deu errado, tente novamente!')));
        } else
            exit(json_encode(array("status" => 0, "msg" => 'Verifique seus dados!')));
    }
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Forgot Password System</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
    <div class="container" style="margin-top: 100px;">
        <div class="row justify-content-center">
            <div class="col-md-6 col-md-offset-3" align="center">
                <img src="images/logo.png"><br><br>
                <input class="form-control" id="email" placeholder="Digite seu email"><br>
                <input type="button" class="btn btn-primary" value="Resetar senha">
                <br><br>
                <p id="response"></p>
            </div>
        </div>
    </div>
    <script src="http://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        var email = $("#email");

        $(document).ready(function () {
            $('.btn-primary').on('click', function () {
                if (email.val() != "") {
                    email.css('border', '1px solid green');

                    $.ajax({
                       url: 'forgotPassword.php',
                       method: 'POST',
                       dataType: 'json',
                       data: {
                           email: email.val()
                       }, success: function (response) {
                            if (!response.success)
                                $("#response").html(response.msg).css('color', "red");
                            else
                                $("#response").html(response.msg).css('color', "green");
                        }
                    });
                } else
                    email.css('border', '1px solid red');
            });
        });
    </script>
</body>
</html>
