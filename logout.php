<?php
/**
 * Created by PhpStorm.
 * User: Sinan
 * Date: 4/19/2017
 * Time: 2:10 PM
 */
session_start();
session_destroy();

header("Location: index.php");