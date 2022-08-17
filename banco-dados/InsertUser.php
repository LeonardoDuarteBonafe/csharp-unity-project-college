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

//Variables for connection
//Variables for user 	
	$username = $_POST["usernamePost"]; 
	$email = $_POST["emailPost"]; 
	$password = $_POST["passwordPost"]; 
	
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "SELECT id FROM users s WHERE s.username = '".$username."'";
	$result = mysqli_query($conn, $sql);
				
	if(mysqli_num_rows($result)>0){
			echo("Fail"); 
	}
	else{
		$sql = "INSERT INTO users (username, email, password) 
			VALUES ('".$username."','".$email."','".$password."')";
		$result = mysqli_query($conn, $sql);
		
	
	if(!result) echo "There was an error";
	else echo "Everything ok";
	}
?>