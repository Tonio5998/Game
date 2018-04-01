<?php

$success = false;
if(isset ...) {

  $EmailFrom = $_REQUEST['email'];
  $EmailTo = "antoine.caille1@free.fr"; // Your email address here
  $Subject = "Contact form";
  $Name = Trim(stripslashes($_POST['name']));
  $LName = Trim(stripslashes($_POST['lname']));
  $Email = Trim(stripslashes($_POST['email']));
  $Message = Trim(stripslashes($_POST['message']));
  $Captcha = Trim(stripslashes($_POST['captcha']));

  // validation
  $validationOK=true;
  if (!$validationOK) {
    echo "Error";
    exit;
  }

  // prepare email body text
  $Body = "";
  $Body .= "Name: ";
  $Body .= $Name;
  $Body .= "\n";
  $Body .= "Last Name: ";
  $Body .= $LName;
  $Body .= "\n";
  $Body .= "Email: ";
  $Body .= $Email;
  $Body .= "\n";
  $Body .= "Message: ";
  $Body .= "\n";
  $Body .= "\n";
  $Body .= $Message;
  $Body .= "\n";

  // send email
  if($Captcha=="2")
  {
  $success = mail($EmailTo, $Subject, $Body, "From: <$EmailFrom>");

}
// redirect to success page
if ($success){
  echo "Succes";
}
else{
  echo "Error";
}
}
?>
