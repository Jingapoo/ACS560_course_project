<?php
/*
SqlObject.php
Copyright (c) 2015-2017, Jacob Psimos
All rights reserved. SqlObject.php - A SQL php helper module.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

* Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer.
* Redistributions in source or binary form must reproduce the above
  copyright notice, this list of conditions and the following disclaimer
  in the documentation and/or other materials provided with the
  distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/


class SqlObject{
	
	/* CONFIGURABLE VARIABLES - hard code these or use object contructor every time */
	private $SERVER_ADDRESS = 'localhost'; //change for custom server address
	private $SERVER_PORT = 3306; //change this if a custom port is needed
	private $DATABASE_NAME = 'bootchat'; //the database name
	private $USERNAME = 'bootchat-sql';
	private $PASSWORD = 'o2h3oihasfohasdlf23r';
	private $MYSQLI_CHARSET = 'utf8'; //change for a custom charset
	
	/* PRIVATE GLOBAL VARIABLES - SHOULD NOT CHANGE */
	private $connection = NULL;
	private $last_count = 0;
	private $last_query = '';
	const SINGLE_ROW = 0;
	const MULTI_ROW = 1;
	const ERR_DUPLICATE = 1062;
	const ERR_DEADLOCK = 1213;
	const RETRY_DEADLOCK_ATTEMPTS = 3;
	const ACCESS_DENIED_CHANGE_USER = 1873;
	const ACCESS_DENIED_DATABASE = 1044;
	const ACCESS_DENIED_USER = 1045;
	
	public function __construct($username = NULL, $password = NULL, $database = NULL){
		if($username != NULL && $password != NULL && $database != NULL){
			$this->USERNAME = $username;
			$this->PASSWORD = $password;
			$this->DATABASE = $database;
		}
		
		$this->connection = new mysqli($this->SERVER_ADDRESS, $this->USERNAME, $this->PASSWORD, $this->DATABASE_NAME, $this->SERVER_PORT);
		
		if($this->connection->connect_error){
			throw new Exception("SqlObject::construct() Connection error: " . $this->connection->connect_error);
		}else{
			mysqli_set_charset($this->connection, $this->MYSQLI_CHARSET);
			if($this->connection->error){
				throw new Exception("SqlObject::construct() Charset Error: " . $this->connection->error);
			}
		}
	}
	
	public function setData($query){
		if($this->connection){
			$result = $this->connection->query($query);
			$this->last_query = $query;
			if($result == FALSE){
				/* How to handle certain SQL errors */
				switch($this->connection->errno){
					case self::ERR_DEADLOCK:
						return $this->retry_deadlock($query);
					break;
					case self::ERR_DUPLICATE:
						return FALSE;	
					break;
					case self::ACCESS_DENIED_CHANGE_USER:
						throw new Exception($this->connection->error);
					break;
					case self::ACCESS_DENIED_USER:
						throw new Exception($this->connection->error);
					break;
					case self::ACCESS_DENIED_DATABASE:
						throw new Exception($this->connection->error);
					break;
					default:
						//file_put_contents('debug.txt', $this->connection->errno);
						throw new Exception($this->connection->error);
					break;	
				}
			}	//end error catching switch
			return TRUE;	//Successful
		}
		return FALSE;	//normally not reached
	}
	
	/* Retrieve data - An unknown return type will always return a NULL result */
	public function getData($query, $returnType = self::SINGLE_ROW){
		
		if(!$this->connection){
			throw new Exception('The Database connection is broken' . "\n" . $query);	
		}
		
		/* Run the provided query, if the query is invalid the return will be FALSE */
		$datum = $this->connection->query($query);
		$this->last_query = $query;
		
		if(!$datum){
			throw new Exception("SqlObject::getData() Error: " . $this->connection->error);
		}
		
		/* Single row (0) returns an associative array of the selected row */
		/* Multi row (1) returns an array of associative array(s) from the query */
		switch($returnType){
			case self::SINGLE_ROW:
				$result = $datum->fetch_assoc();
				$datum->free();
				return $result;
			break;
			case self::MULTI_ROW:
				$this->last_count = 0;
				$returnData = array();
				while($nextRow = $datum->fetch_assoc()){
					array_push($returnData, $nextRow);
					$this->last_count++;
				}
				$datum->free();
				if($this->last_count > 0){
					return $returnData;
				}
			break;
			default:
				throw new Exception("Invalid argument for setData(); expected returnType is invalid");
			break;
		}
		return NULL;
	}
	
	public function get_table_names($filter = NULL){
		$query = $filter != NULL ? "SHOW TABLES LIKE '$filter'" : 'SHOW TABLES';
		$datum = $this->connection->query($query);
		
		//$this->last_query = $query;
		if(!$datum){
			throw new Exception($this->connection->error);	
		}
		
		$names = array();
		while($nextRow = $datum->fetch_array(MYSQLI_NUM)){
			if(count($datum) != 0){
				array_push($names, $nextRow[0]);
			}
		}
		$datum->free();
		return $names;
	}
	
	/* gets the size of the last returned array from getData */
	function get_last_arraysize(){
		return $this->last_count;
	}
	
	/* gets the number of rows affected by the last query */
	public function get_affected_rows(){
		return $this->connection->affected_rows;
	}
	
	/* returns the ID of the last INSERT query 
	NOTE this does not return the ID from an UPDATE query */
	public function get_last_insert_id(){
		return $this->connection->insert_id;
	}
	
	public function get_last_query(){
		return $this->last_query;	
	}
	
	/* pass back the sql error number */
	public function get_error_number(){
		return $this->connection->errno;	
	}
	
	public function get_error(){
		return $this->connection->error;	
	}
	
	/* get the current database name */
	public function get_database_name(){
		return $this->DATABASE_NAME;	
	}
	
	/* get the current username */
	public function get_username(){
		return $this->USERNAME;
	}
	
	/* attempt to connect to a new database with optional different credentials */
	public function change_database($new_database, $username = NULL, $password = NULL){
		if(!$this->connection){
			throw new Exception("change_database($new_database) failed because of a broken connection");	
		}
		if($this->connection->change_user($username != NULL ? $username : $this->USERNAME,
							$password != NULL ? $password : $this->PASSWORD, $new_database)){
			$this->DATABASE_NAME = $new_database;
			$this->USERNAME = $username != NULL ? $username : $this->USERNAME;
			$this->PASSWORD = $password != NULL ? $password : $this->PASSWORD;
		}else{
			throw new Exception($this->get_error());	
		}
	}
	
	public function terminate(){
		if($this->connection){
			$this->connection->close();
			unset($this->connection);
		}
	}
	
	public static function insertQuery($table, $values){
		$query = "INSERT INTO `$table`(";
		$firstpart = '';
		$lastpart = '';
		$len = count($values);
		$i = 0;
		foreach($values as $key => $value){
			$value = str_replace("'", "\\'", $value);
			$firstpart .= ($i < $len - 1) ? "`$key`," : "`$key`) VALUES(";
			if(is_numeric($value) && $value[0] != '+'){
				$lastpart .= ($i < $len - 1) ? "$value," : "$value)";
			}else{
				$lastpart .= ($i < $len - 1) ? "'$value'," : "'$value')";
			}
			$i++;
		}
		return ($query . $firstpart . $lastpart);
	}
	
	/* automatically close the connection when the object is disposed */
	public function __destruct(){
		if(isset($this->connection)){
			$this->connection->close();
			unset($this->connection);
		}
	}
	
	/* reattempt to run the query that caused a deadlock */
	private function retry_deadlock($query){
		for($i = 0; $i < self::RETRY_DEADLOCK_ATTEMPTS; $i++){
			$result = $this->connection->query($query);
			if($result){
				return TRUE;
			}
			sleep(1);
		}
		return FALSE;
	}
	
} /* end class */

/*==============================================================================*/
/* All functions below are NOT in the scope of SqlObject class */
/*==============================================================================*/
function isSqlSafe($str){
	$select_safe = stripos($str, "SELECT `") === FALSE && stripos($str, "SELECT *") === FALSE;
	$insert_safe = stripos($str, "INSERT INTO `") === FALSE && stripos($str, "INSERT INTO *") === FALSE;
	$update_safe = stripos($str, "UPDATE `") === FALSE && stripos($str, "UPDATE *") === FALSE;
	$join_safe = stripos($str, "JOIN `") === FALSE && stripos($str, "INNER JOIN `") === FALSE;
	$bogus_quote = stripos($str, '`') === FALSE && stripos($str, '\"') === FALSE && stripos($str, "\'") === FALSE;
	return $select_safe && $insert_safe && $update_safe && $join_safe && $bogus_quote;
}

function filterText($str, $extras = NULL, $allow = NULL, $htmlify = false){
	//These phraises are to be removed from the resulting value
	$block = array(
		'<?',
		'<',
		'>',
		'?>',
		'/>',
		'`',
		'*',
		';',
		'{',
		'}',
		'\x',
		'\"',
		"\'"
	);
	
	/* Loop through all of the blacklisted phraises and remove them */
	foreach($block as $blockedchar){
		if($allow !== NULL){
			if(!in_array($blockedchar, $allow)){
				$temp = str_replace($blockedchar, '', $str);
				unset($str);
				$str = $temp;
				unset($temp);
			}
		}else{
			$temp = str_replace($blockedchar, '', $str);
			unset($str);
			$str = $temp;
			unset($temp);
		}
	}
	
	if($extras !== NULL){
		foreach($extras as $filter){
			$temp = str_replace($filter, '', $str);
			unset($str);
			$str = $temp;
			unset($temp);
		}
	}
	
	$temp = removeUnicodeCharacters($str);
	unset($str);
	
	if($htmlify === TRUE){
		return htmlspecialchars($temp, ENT_QUOTES);
	}
	return $temp;
}

	/***
		Replaces any emoji in a string with the string literal [Emoji]
		Acknowledgement::This function was made possible because of 
		the Github User<https://gist.github.com/hnq90> and his publicaly
		available PHP script 'CheckEmoji.php'
	*/
	function removeUnicodeCharacters($string){
		$regexEmoticons = '/[\x{1F600}-\x{1F64F}]/u';
		$regexSymbols = '/[\x{1F300}-\x{1F5FF}]/u';
		$regexTransport = '/[\x{1F680}-\x{1F6FF}]/u';
		$regexMisc = '/[\x{2600}-\x{26FF}]/u';
		$regexDingbats = '/[\x{2700}-\x{27BF}]/u';
		
		$string = preg_replace($regexEmoticons, "[Emoji]", $string);
		$string = preg_replace($regexSymbols, "[Symbol]", $string);
		$string = preg_replace($regexTransport, '', $string);
		$string = preg_replace($regexMisc, '', $string);
		$string = preg_replace($regexDingbats, '',  $string);
		return $string;
	}

?>
