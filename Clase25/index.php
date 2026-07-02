<?php
$sql = "SELECT * FROM $user_table WHERE email = '$myemail' AND password = '$mypassword'";
$login_result = mysql_query($sql, $connection);

$count = mysql_num_rows($login_result);

if ($count == 1) {

    // Successfully verified login information

    session_start();

    if (!isset($_SESSION['is_logged_in'])) {
        $_SESSION['is_logged_in'] = 1;
    }

    if (!isset($_SESSION['email'])) {
        $_SESSION['email'] = $myemail;
    }
    if (!isset($_SESSION['password'])) {
        $_SESSION['password'] = $mypassword;
    }

    // Register user's name and ID
    if ((!isset($_SESSION['name'])) && (!isset($_SESSION['user_id'])))  {
        $row = mysql_fetch_assoc($login_result);
        $_SESSION['name'] = $row['name'];
        $_SESSION['user_id'] = $row['user_id'];
    }

    header("Location: http://localhost:8080/meet2eat/index.php");

} else {
    // Not logged in. Redirect back to login page
    header("Location: http://localhost:8080/meet2eat/php/login.php?err=1");

}
?>