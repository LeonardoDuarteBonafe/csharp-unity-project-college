<?php
/*
	$servername = "localhost";
	$username = "id7533976_leonardo";
	$password = "123qwe";
	$dbName = "id7533976_testedb";
	*/
	$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "cool_yt_rpg";
	//make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//check connection 
	
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "SELECT ID, Name, Type, Cost FROM items";
	$result = mysqli_query($conn, $sql);
	
    if(mysqli_num_rows($result)>0){
    	while($row = mysqli_fetch_assoc($result)){
    		echo("ID:".$row['ID'] . "|Name:".$row['Name']. "|Type:".$row['Type']. "|Cost:".$row['Cost'] . ";"); 	
    	}
	}
?>