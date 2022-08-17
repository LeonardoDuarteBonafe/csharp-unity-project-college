<?php
$username = filter_input(INPUT_POST, 'username');
$password = filter_input(INPUT_POST, 'password');
$email = filter_input(INPUT_POST, 'email');
if(!empty($email)){
    if (!empty($username)){
        if (!empty($password)){
/*
$servername = "localhost";
$server_username = "id8983768_engenhariadesoftwareusername";
$server_password = "12041272";
$dbName = "id8983768_gameengenhariadesoftware";
*/
$servername = "localhost";
$server_username = "cool_yt_rpg";
$server_password = "123qwe";
$dbName = "cool_yt_rpg";

            // Create connection
            $conn = new mysqli ($servername, $server_username, $server_password, $dbName);
            
            if (mysqli_connect_error()){
                die("Connect Error (". mysqli_connect_errno() .") ". mysqli_connect_error());
            }
            else{
                $sql = "INSERT INTO users (username, email, password)
                VALUES ('$username','$email','$password')";
                if ($conn->query($sql)){
                    echo "New record is inserted sucessfully";
                }
                else{
                    echo "Error: ". $sql ."". $conn->error;
                }
            $conn->close();
            }
        }
        else{
            echo "Password should not be empty";
            die();
        }
     }
    else{
        echo "Username should not be empty";
        die();
    }
}
else{
    echo "Email nao deve ficar em branco";
    die();
}
?>