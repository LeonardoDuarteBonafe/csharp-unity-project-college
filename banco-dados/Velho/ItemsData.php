<?php
	$servername = "localhost";
	$username = "id7533976_leonardo";
	$password = "123qwer";
	$dbName = "id7533976_testedb";
	
	//make connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//check connection 
	if(!$conn){
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "SELECT ID, Name, Type, Cost FROM Items";
	$result = mysqli_query($conn, $sql);
	
	if(mysqli_num_rows($result)>0){
		while($row = mysqli_fetch_assoc($result)){
			echo("ID:".$row['ID'] . "|Name:".$row['Name']. "|Type:".$row['Type']. "|Cost:".$row['Cost'] . ";"); 	
		}
	}
?>