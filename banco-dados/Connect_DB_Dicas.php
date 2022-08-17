<?php
	$user = $_POST["user"];
	$servernamePost = $_POST["servername"];
	$carta_id = $_POST["carta_id"];
	$dica1 = $_POST["dica1"];
	$dica2 = $_POST["dica2"]; 
	$dica3 = $_POST["dica3"]; 
	$dica4 = $_POST["dica4"];
	$dica5 = $_POST["dica5"]; 
	$resposta = $_POST["resposta"]; 
echo "Vamos ver o usuario daqui: " . $user . "\n";
if(!empty($dica1) && !empty($dica2) && !empty($dica3) && !empty($dica4) && !empty($dica5) && !empty($resposta)){

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

            // Create connection
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
				
				$sql = "SELECT serverid FROM servers_name WHERE serverName = '".$servernamePost."'";
				$result = mysqli_query($conn, $sql);
				
				if(mysqli_num_rows($result)>0){
					while($row = mysqli_fetch_assoc($result)){
						$server_fk = $row['serverid'];
					}
				}
				
				
                $sql = "INSERT INTO carta (users_fk, server_fk, carta_id, dica1, dica2, dica3, dica4, dica5, resposta)
                VALUES ('$users_fk', '$server_fk', '$carta_id', '$dica1','$dica2','$dica3','$dica4','$dica5', '$resposta')";
                if ($conn->query($sql)){
                    echo "Dicas inseridas com sucesso <br>";
                }
                else{
                    echo "Error: ". $sql ."". $conn->error;
                }
            $conn->close();
            }
}
else{
    echo "Dicas e respostas não podem ficar vazias";
    die();
}
?>