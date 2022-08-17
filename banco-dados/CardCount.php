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


$servernamePost = $_POST["server"];
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	$sql = "SELECT serverid FROM servers_name WHERE serverName = '".$servernamePost."'";
	$result = mysqli_query($conn, $sql);
				
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			$server_fk = $row['serverid'];
		}
	}
	
		if (mysqli_num_rows($result)>0){
			$sql = "SELECT COUNT(*) c FROM carta d WHERE d.server_fk = '".$server_fk."'";
			$result = mysqli_query($conn, $sql);
			$row = mysqli_fetch_assoc($result);
			$sql = "SELECT * FROM cardcount WHERE server_fk = '".$server_fk."'";
			$result = mysqli_query($conn, $sql);
			
			if(mysqli_num_rows($result)>0){
				$sql = "UPDATE cardcount SET card_count = '".$row['c']."' WHERE server_fk = '".$server_fk."'";
				$result = mysqli_query($conn, $sql);
			}
			else{
				$sql = "INSERT INTO cardcount (server_fk, card_count) VALUES ('".$server_fk."','".$row['c']."')";
				$result = mysqli_query($conn, $sql);
			}
		}
		else{
			echo "Usuario nao encontrado";
		} 
?>