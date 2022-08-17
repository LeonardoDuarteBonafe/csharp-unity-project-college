<?php
//Variables for connection
	$servername = "localhost";
	$server_username = "id7533976_leonardo";
	$server_password = "123qwe";
	$dbName = "id7533976_testedb";
//Variables for user 	
	$username = $_POST["usernamePost"]; //"Lucas Test AC";
	$email = $_POST["emailPost"]; //"test email";
	$password = $_POST["passwordPost"]; //"123456";
	
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "INSERT INTO users (username, email, password) 
			VALUES ('".$username."','".$email."','".$password."')";
	$result = mysqli_query($conn, $sql);
	
	if(!result) echo "There was an error";
	else echo "Everything ok";
	
?>