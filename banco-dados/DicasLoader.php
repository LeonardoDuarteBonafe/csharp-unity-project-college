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

$servernamePost = $_POST["user"];
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
	
	$sql = "SELECT * FROM carta WHERE server_fk = '".$server_fk."'";
	$result = mysqli_query($conn, $sql);
	
    if(mysqli_num_rows($result)>0){
    	while($row = mysqli_fetch_assoc($result)){
    		echo("index:".$row['carta_id']. "|Dica1:".$row['dica1']. "|Dica2:".$row['dica2']. "|Dica3:".$row['dica3']. "|Dica4:".$row['dica4']. "|Dica5:".$row['dica5'] . "|Resposta:".$row['resposta'] . ";"); 	
    	}
	}
?>