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
$servernamePost = $_POST["servernamePost"];

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
	
	$sql = "SELECT * FROM dadossalvos ds WHERE ds.users_fk = '".$users_fk."' AND ds.server_fk = '".$server_fk."'";
	$result = mysqli_query($conn, $sql);
	
    if(mysqli_num_rows($result)>0){
    	while($row = mysqli_fetch_assoc($result)){
    		echo("Existente -");	
			echo("restantes:".$row['cartasRestantes']. "|retiradas:".$row['cartasRetiradas']. "|ganha:".$row['pontuacaoGanha']. "|perdida:".$row['pontuacaoPerdida']. "|carta1:".$row['carta1']. "|carta2:".$row['carta2'] . "|carta3:".$row['carta3'] . "|carta4:".$row['carta4']. "|carta5:".$row['carta5']. "|carta6:".$row['carta6']. "|carta7:".$row['carta7']. "|carta8:".$row['carta8']. "|carta9:".$row['carta9']. "|carta10:".$row['carta10']. "|carta11:".$row['carta11']. "|carta12:".$row['carta12']. "|carta13:".$row['carta13']. "|carta14:".$row['carta14']. "|carta15:".$row['carta15']. "|carta16:".$row['carta16']. "|carta17:".$row['carta17']. "|carta18:".$row['carta18']. "|carta19:".$row['carta19']. "|carta20:".$row['carta20'] .";"); 	
    	}
	}
	else{
		echo("Errando");
		$sql = "INSERT INTO dadossalvos (users_fk, server_fk, cartasRestantes, cartasRetiradas, pontuacaoGanha, pontuacaoPerdida, carta1, carta2, carta3, carta4, carta5, carta6, carta7, carta8, carta9, carta10, carta11, carta12, carta13, carta14, carta15, carta16, carta17, carta18, carta19, carta20)
		VALUES ('".$users_fk."','".$server_fk."','20','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0')";
		$result = mysqli_query($conn, $sql);
	}
	
?>