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

	$user_username = $_POST["usernamePost"];
	$user_password = $_POST["passwordPost"];
	
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "SELECT password FROM users WHERE username = '".$user_username."'";
	$result = mysqli_query($conn, $sql);
	
	//Get the result and confirm login 
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			if($row['password'] == $user_password){
				echo "Login Success: ";
				echo $row['password'];
			}
			else{
				echo "Login Failed: ";
				echo "Password is: ". $row['password'];
			}
		}
	}
	else{
		echo "User not found";
	}
?>