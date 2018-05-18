<?php
/**
 * Created by PhpStorm.
 * User: Sinan
 * Date: 4/19/2017
 * Time: 1:39 PM
 */
session_start();

$servername = "localhost";
$username = "root";
$password = "root";

try {
    $conn = new PDO("mysql:host=$servername;dbname=basicsecurity", $username, $password);
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Connection failed: " . $e->getMessage();
}

?>