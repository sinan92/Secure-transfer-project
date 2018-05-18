<?php
/**
 * Created by PhpStorm.
 * User: Sinan
 * Date: 4/19/2017
 * Time: 1:44 PM
 */

function login($conn, $username, $password){

    $stmt = $conn->prepare("SELECT name, password FROM users WHERE name = ? AND password = ?");
    $stmt->execute(array($username, $password));

    $count = $stmt->rowCount();

    if($count > 0){
        // Store Session Data
        $_SESSION['login_user']= $username;  // Initializing Session with value of PHP Variable
        return true;
    }
    else{
        return false;
    }
}