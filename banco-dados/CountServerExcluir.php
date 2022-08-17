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
			echo ("ID USER HERE: ".$users_fk."\n");
		}
	}
	
	$sql = "SELECT * FROM servers_name WHERE users_fk = '".$users_fk."'";
	$result = mysqli_query($conn, $sql);
				
	if(mysqli_num_rows($result)>0){
		echo ("sucesso -");
		while($row = mysqli_fetch_assoc($result)){
			$server_fk = $row['serverid'];
			echo  $row['serverName'].";";
		}
	}
	else{
		echo ("Fracasso, nao ha serve para editar");
	}
	
?>