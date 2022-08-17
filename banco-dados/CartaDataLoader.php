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


$user = $_POST["user"];
$servernamePost = $_POST["servernamePost"];
$cartaid = $_POST["cartaid"];
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "SELECT id FROM users s WHERE s.username = '".$user."'";
				$result = mysqli_query($conn, $sql);
				
				if(mysqli_num_rows($result)>0){
					while($row = mysqli_fetch_assoc($result)){
						$users_fk = $row['id'];
					}
				}
				
				$sql = "SELECT serverid FROM servers_name WHERE serverName = '".$servernamePost."'";
				$result = mysqli_query($conn, $sql);
				
				if(mysqli_num_rows($result)>0){
					while($row = mysqli_fetch_assoc($result)){ 
						$server_fk = $row['serverid'];
					}
				}
	
	$sql = "SELECT * FROM carta WHERE users_fk = '".$users_fk."' AND server_fk = '".$server_fk."' AND carta_id = '".$cartaid."'";
	$result = mysqli_query($conn, $sql);
	
    if(mysqli_num_rows($result)>0){
    	while($row = mysqli_fetch_assoc($result)){
    		echo("dica1:".$row['dica1'] . "|dica2:".$row['dica2']. "|dica3:".$row['dica3']. "|dica4:".$row['dica4']. "|dica5:".$row['dica5']. "|resposta:".$row['resposta'] . ";"); 	
    	}
	}
?>