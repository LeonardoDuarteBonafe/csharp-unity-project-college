<?php
	$user = $_POST["user"];
	$serverPost = $_POST["server"];
	$cartasRestantes = $_POST["cartasRestantes"];
	$cartasRetiradas = $_POST["cartasRetiradas"];
	$pontuacaoGanha = $_POST["pontuacaoGanha"]; 
	$pontuacaoPerdida = $_POST["pontuacaoPerdida"];
	$carta1 = $_POST["carta1"];
	$carta2 = $_POST["carta2"];
	$carta3 = $_POST["carta3"];
	$carta4 = $_POST["carta4"];
	$carta5 = $_POST["carta5"];
	$carta6 = $_POST["carta6"];
	$carta7 = $_POST["carta7"];
	$carta8 = $_POST["carta8"];
	$carta9 = $_POST["carta9"];
	$carta10 = $_POST["carta10"];
	$carta11 = $_POST["carta11"];
	$carta12 = $_POST["carta12"];
	$carta13 = $_POST["carta13"];
	$carta14 = $_POST["carta14"];
	$carta15 = $_POST["carta15"];
	$carta16 = $_POST["carta16"];
	$carta17 = $_POST["carta17"];
	$carta18 = $_POST["carta18"];
	$carta19 = $_POST["carta19"];
	$carta20 = $_POST["carta20"];

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

            $conn = new mysqli ($servername, $server_username, $server_password, $dbName);
            
            if (mysqli_connect_error()){
                die("Connect Error (". mysqli_connect_errno() .") ". mysqli_connect_error());
            }
            else{
				$sql = "SELECT id FROM users s WHERE s.username = '".$user."'";
				$result = mysqli_query($conn, $sql);
				
				if(mysqli_num_rows($result)>0){
					while($row = mysqli_fetch_assoc($result)){
						$users_fk = $row['id'];
					}
				}
				
				$sql = "SELECT serverid FROM servers_name WHERE serverName = '".$serverPost."'";
				$result = mysqli_query($conn, $sql);
				
				if(mysqli_num_rows($result)>0){
					while($row = mysqli_fetch_assoc($result)){
						$servers_fk = $row['serverid'];
					}
				}
				$sql = "UPDATE dadossalvos SET cartasRestantes = '$cartasRestantes', cartasRetiradas = '$cartasRetiradas', pontuacaoGanha = '$pontuacaoGanha', pontuacaoPerdida = '$pontuacaoPerdida', carta1 = '$carta1', carta2 = '$carta2', carta3 = '$carta3', carta4 = '$carta4', carta5 = '$carta5', carta6 = '$carta6', carta7 = '$carta7', carta8 = '$carta8', carta9 = '$carta9', carta10 = '$carta10', carta11 = '$carta11', carta12 = '$carta12', carta13 = '$carta13', carta14 = '$carta14', carta15 = '$carta15', carta16 = '$carta16', carta17 = '$carta17', carta18 = '$carta18', carta19 = '$carta19', carta20 = '$carta20' WHERE users_fk = '$users_fk' and server_fk = '$servers_fk'";
				
				if ($conn->query($sql)){
                    echo "Dados salvos com sucesso <br>";
                }
                else{
                    echo "Error ao salvar: ". $sql ."". $conn->error;
                }
            $conn->close();
            }
?>