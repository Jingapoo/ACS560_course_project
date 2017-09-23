<?php
function doCreateNewUserRequest(SqlObject $sql = NULL){
	if($sql == NULL){ $sql = new SqlObject(); }
	
	if(!isset($_POST['username']) || !isset($_POST['question']) || !isset($_POST['answer']) || !isset($_POST['password'])){
		echo json_encode(array('success' => FALSE, 'exception' => 'missing argument(s)'));
		exit(0);
	}
	
	$username = filterText($_POST['username']);
	$password = filterText($_POST['password']);
	$question = filterText($_POST['question']);
	$answer = filterText($_POST['answer']);
	
	$query = "INSERT INTO `accounts`(`username`,`password`,`question`,`answer`) VALUES('$username','$password','$question','$answer')";
	$result = $sql->setData($query);
	
	if($result){
		echo json_encode(array('success' => TRUE));
		exit(0);
	}else{
		echo json_encode(array('success' => FALSE, 'exception' => $sql->get_error()));
		exit(0);
	}
}
	
?>