<?php
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

$user = $_POST["usersamePost"];

	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	$sql = "SELECT id FROM users s WHERE s.username = '".$user."'";
	$result = mysqli_query($conn, $sql);
				
	if(mysqli_num_rows($result)>0){
		echo("Usuário existente"); 
		/*while($row = mysqli_fetch_assoc($result)){
			$users_fk = $row['id'];
		}*/
	}
	
	/*$sql = "SELECT card_count c FROM cardcount cc WHERE cc.users_fk = '".$users_fk."'";
	$result = mysqli_query($conn, $sql);
	
    if(mysqli_num_rows($result)>0){
    	while($row = mysqli_fetch_assoc($result)){
    		echo("Count:".$row['c']); 	
    	}
	}*/
	
?>