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
$cartaid = $_POST["cartaid"];
$dica1 = $_POST["dica1"];
$dica2 = $_POST["dica2"];
$dica3 = $_POST["dica3"];
$dica4 = $_POST["dica4"];
$dica5 = $_POST["dica5"];
$resposta = $_POST["resposta"];
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
	
	$sql = "UPDATE carta SET dica1 = '$dica1', dica2 = '$dica2', dica3 = '$dica3', dica4 = '$dica4', dica5 = '$dica5', resposta = '$resposta' WHERE carta_id = '$cartaid' AND server_fk = '".$server_fk."'";
	
	if ($conn->query($sql)){
                    echo "Valores atualizados com sucesso";
                }
	else{
		echo "Deu erro";
	}
?>