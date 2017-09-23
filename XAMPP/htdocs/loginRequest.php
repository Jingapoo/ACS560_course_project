<?php

function doLoginRequest(SqlObject $sql = NULL){
	if($sql == NULL){ $sql = new SqlObject(); }
	
	if(!isset($_POST['username']) || !isset($_POST['password'])){
		echo json_encode(array('success' => FALSE, 'exception' => 'missing argument(s)'));
		exit(0);
	}
	$username = filterText($_POST['username']);
	$password = filterText($_POST['password']);
	
	$query = "SELECT `password` FROM `accounts` WHERE `username` = '$username'";
	$sqlResult = $sql->getData($query, SqlObject::SINGLE_ROW);
	if($sqlResult){
		if($sqlResult['password'] === $password){
			echo json_encode(array('success' => TRUE));
			exit(0);
		}
	}
	echo json_encode(array('success' => FALSE, 'exception' => 'unknown username or invalid password'));
	exit(0);
}

?>