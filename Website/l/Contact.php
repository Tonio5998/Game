<?php

$success = false;
if(isset($_REQUEST['email']) && isset($_POST['name']) && isset($_POST['lname']) && isset($_POST['email']) && isset($_POST['message']) && isset($_POST['captcha'])) {

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
}
// redirect to success page
if ($success){
  $msg = "Votre mail à bien été envoyé";
}
else{
  $msg = "Une erreur s'est produite lors de l'envoie du mail. Veuillez réessayer";
}

?>


<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="header.css" />
    <link rel="stylesheet" href="Contact.css" />
    <link rel="stylesheet" href="Taral_websiteCSS.css" />

    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">

    <title>Contact Taral</title>

    <script>
function pop() {
window.open('Contact.php','height=100px,width=100px,scrollbars=no,resible=no');
}
  </script>
  </head>
  <body>
    <header role="header">
      <nav class="menu" role="navigation">
        <div class="inner">
          <img  class="image"src="LogoTrue.png" alt="">
          <div class="m-left">
            <h1 class="logo">
              Taral
            </h1>
          </div>
          <div class="m-right">
            <a href="Taral_website.html" class="m-link"><i class="fa fa-home" aria-hidden="true"></i> Accueil</a>
            <a href="Download.html" class="m-link"><i class="fa fa-download" aria-hidden="true"></i> Téléchargement</a>
            <a href="Contact.php" class="m-link"><i class="fa fa-address-card" aria-hidden="true"></i> Contact</a>

          </div>
        </div>
      </nav>
    </header>

    <div class="container">
      <h1 class="brand">Des problémes avec Nostromo? Contactez-nous !</h1>
      <div class="wrapper">
        <div class="company-info">
          <h3>Equipe de Taral</h3>
          <ul>
            <li><i class="fa fa-home" aria-hidden="true"></i> Espace, galaxie de Tereshkova</li>
            <li><i class="fa fa-envelope" aria-hidden="true"></i> project.taral@gmail.com</li>
            <li><i class="fa fa-space-shuttle" aria-hidden="true"></i> Nostromo</li>
            <li><i class="fa fttle" aria-hidden="true"></i></li>
            <li><i class="fa fa-suttle" aria-hidden="true"></i><?php if($success) { echo $msg; } ?></li>
          </ul>
        </div>
        <div class="contact">
          <h3>Contactez-nous</h3>
          <form  id="contact_form" class="contact_form" action="Contact.php" method="post" name="contact_form">
            <p>
              <label for="name">Prénom</label>
              <input type="text" name="name" id="name" required placeholder="Dominique" required class="required">
            </p>
            <p>
              <label for="lame">Nom</label>
              <input type="text" name="lname" id="lname" required placeholder="Roupenel" required class="required">
            </p>
            <p>
              <label for="email">Adresse email</label>
              <input type="email" name="email" id="email" required placeholder="dominique.roupenel@gmail.com" class="required email">
            </p>
            <p>
              <label for="captcha">1+1 ?</label>
              <input type="text" name="captcha" id="captcha" required class="required">
            </p>
            <p class="full">
              <label for="message">Message</label>
              <textarea name="message" id="message" rows="5" required placeholder="Tapez votre message ici..." required class="required"></textarea>
            </p>
            <p class="full">
              <button type="submit" id="submit" name="submit" class="button fright">Submit</button>
            </p>
          </form>
        </div>
      </div>
    </div>

  </body>
</html>
