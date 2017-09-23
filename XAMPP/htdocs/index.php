<?php
	header('Content-Type: text/json; charset=utf-8');
	
	require_once('SqlObject.php');
	require_once('loginRequest.php');
	require_once('createNewUserRequest.php');
	require_once('forgotPasswordRequest.php');
	
	if(!isset($_POST['request'])){
		echo json_encode(array('success' => FALSE, 'exception' => 'missing request'));
		exit(1);
	}
	
	$sql = new SqlObject();
	
	$request = $_POST['request'];
	
	if($request == 'login'){
		doLoginRequest($sql);
	}
	
	if($request == 'forgot'){
		doForgotPasswordRequest($sql);
	}
	
	if($request == 'create'){
		doCreateNewUserRequest($sql);
	}
	
	if($request == 'send'){
		
	}
	
	if($request == 'getinbox'){
		
	}
	
	echo json_encode(array('success' => FALSE, 'exception' => 'EOF'));
?>