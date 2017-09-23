<?php
function doForgotPasswordRequest(SqlObject $sql = NULL){
	if($sql == NULL){ $sql = new SqlObject(); }
	
	if(!isset($_POST['username']) || !isset($_POST['question']) || !isset($_POST['answer']) || !isset($_POST['password'])){
		echo json_encode(array('success' => FALSE, 'exception' => 'missing argument(s)'));
		exit(0);
	}
	
	$username = filterText($_POST['username']);
	$question = filterText($_POST['question']);
	$answer = filterText($_POST['answer']);
	$password = filterText($_POST['password']);
	
	$query = "SELECT * FROM `accounts` WHERE `username` LIKE '$username'";
	$account = $sql->getData($query);
	if($account){
		if(strtolower($question) === strtolower($account['question'])){
			if(strtolower($answer) == strtolower($account['answer'])){
				$query = "UPDATE `accounts` SET `password` = '$password' WHERE `username` = '$username'";
				$result = $sql->setData($query);
				if($result){
					echo json_encode(array('success' => TRUE));
					exit(0);
				}else{
					echo json_encode(array('success' => FALSE, 'exception' => 'failed to update password'));
					exit(0);
				}
			}
		}
	}
	
	echo json_encode(array('success' => FALSE, 'exception' => 'invalid username or bad question/answer pair'));
	exit(0);
}
?>