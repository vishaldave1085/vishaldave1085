<?php
$novalue=false;
$name="";
$email="";
$fromsubject="";
$msg="";

if(isset($_POST["name"]) && trim($_POST["name"])!=""){
	$name=trim($_POST["name"]);
}
else{
	$novalue=true;
}
if(isset($_POST["email"]) && trim($_POST["email"])!=""){
	$email=trim($_POST["email"]);
}

if(isset($_POST["subject"]) && trim($_POST["subject"])!=""){
	$fromsubject=trim($_POST["subject"]);
}
else{
	$novalue=true;
}
if(isset($_POST["msg"]) && trim($_POST["msg"])!=""){
	$msg=trim($_POST["msg"]);
}
if(!$novalue){
	
$message="<html><head></head><body><br/><span>Dear <strong>".$name.",</strong></span><br/><br/>
<p>
Thank you for writing to us. We have received your message about real estate Investment and we will get back to you with in 24 hours. Until then you can give us call any time at <a href=\"tel:(248) 679-2714\">(248) 679-2714</a> or <a href=\"tel:(313) 317-6008\">(313) 317-6008</a> or <a href=\"mailto:Info@TheInvesteer.com\">Info@TheInvesteer.com</a>.</p><br/>
<br/><p>Sincerely,</p><p>TheInvesteer Team</p></body>
</html>";
$to = $email; // <– replace with your address here
   $subject = "Thanks for Getting in Touch!";
   $from = "info@theinvesteer.com";
 
   $headers = "From: TheInvesteer<" . $from.">";
   $headers .= "MIME-Version: 1.0\r\n";
$headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";
   $output=mail($to,$subject,$message,$headers);
	
	$message="<html><head></head><body><br/><span>Dear <strong>Team,</strong></span><br/><br/>
<p>We have received message from:</p><br/><br/>
<table border=\"1\">
	<tr>
	<td><strong>Name</strong></td>
	<td>".$name."</td>
	</tr>
	<tr>
	<td><strong>Subject</strong></td>
	<td>".$fromsubject."</td>
	</tr>
	
	<tr>
	<td><strong>Email ID</strong></td>
	<td>".$email."</td>
	</tr>
	<tr>
	<td><strong>Message</strong></td>
	<td>".$msg."</td>
	</tr>
</table>
<br/>
<p>Sincerely,<br/>
TheInvesteer WebMaster</p>
</body>
</html>";

   $to = "Perry@alerteer.com"; // <– replace with your address here
   $subject = "TheInvesteer | Contact";
   $from = "info@theinvesteer.com";
	$headers = "From: TheInvesteer<" . $from.">";
   $headers .= "MIME-Version: 1.0\r\n";
	$headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";  
/*    $output=mail($to,$subject,$message,$headers);
   $to = "Jay@sattrixusa.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "mgmodi1@gmail.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "Info@TheInvesteer.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "niravmscit@gmail.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers); */
   $to = "ParasS@alerteer.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "bhavin.mehta@sattrixusa.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
}
$response["success"]=(!$novalue)?1:0;
$response["error"]="";
echo json_encode($response);
?>