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

	$servernamePost = $_POST["servernamePost"];
	
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	echo $servernamePost."\n";
	$sql = "SELECT serverid FROM servers_name WHERE serverName = '".$servernamePost."'";
	$result = mysqli_query($conn, $sql);
	
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			$server_fk = $row['serverid'];
			echo $server_fk."\n";
		}
	}
	
	$sql = "SELECT card_count c FROM cardcount WHERE server_fk = '".$server_fk."'";
	$result = mysqli_query($conn, $sql);
	
	//Get the result and confirm login 
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			if($row['c'] == '20'){
				echo "Login Success: ";
			}
			else{
				echo "Server failed: ";
			}
		}
	}
	else{
		echo "User not found";
	}
?>