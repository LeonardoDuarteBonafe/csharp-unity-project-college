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

$servername_post = $_POST["servernamePost"];
$user = $_POST["usernamePost"];

	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "SELECT id FROM users WHERE username = '".$user."'";
	$result = mysqli_query($conn, $sql);
				
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			$users_fk = $row['id'];
		}
	}
	
	$sql = "SELECT serverid FROM servers_name WHERE serverName = '".$servername_post."'";
	$result = mysqli_query($conn, $sql);
				
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			echo "server ja existe\n";
		}
	}
	else{
		$sql = "INSERT INTO servers_name (users_fk, serverName)
		VALUES ('".$users_fk."','".$servername_post."')";
		$result = mysqli_query($conn, $sql);
		if($result){
				echo "sucesso\n";
		}
		else{
			echo "algo deu errado\n";
		}
	}
	
?>