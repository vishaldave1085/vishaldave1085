<?php
$novalue=false;
$fname="";
$lname="";
$cnumber="";
$email="";
$amount="";
$period="";
$msg="";
$propname="";

if(isset($_POST["fname"]) && trim($_POST["fname"])!=""){
	$fname=trim($_POST["fname"]);
}
else{
	$novalue=true;
}
if(isset($_POST["hdproperty"]) && trim($_POST["hdproperty"])!=""){
	$propname=trim($_POST["hdproperty"]);
}

if(isset($_POST["lname"]) && trim($_POST["lname"])!=""){
	$lname=trim($_POST["lname"]);
}
else{
	$novalue=true;
}
if(isset($_POST["cnumber"]) && trim($_POST["cnumber"])!=""){
	$cnumber=trim($_POST["cnumber"]);
}
else{
	$novalue=true;
}
if(isset($_POST["email"]) && trim($_POST["email"])!=""){
	$email=trim($_POST["email"]);
}
else{
	$novalue=true;
}
if(isset($_POST["amount"]) && trim($_POST["amount"])!=""){
	$amount=trim($_POST["amount"]);
}
else{
	$novalue=true;
}
if(isset($_POST["period"]) && trim($_POST["period"])!=""){
	$period=trim($_POST["period"]);
}
else{
	$novalue=true;
}
if(isset($_POST["msg"]) && trim($_POST["msg"])!=""){
	$msg=trim($_POST["msg"]);
}
if(!$novalue){
	
$message="<html><head></head><body><br/><span>Dear <strong>".$lname." ".$fname.",</strong></span><br/><br/>
<p>
Thank you for writing to us. We have received your message about ".$propname." and we will get back to you with in 24 hours. Until then you can give us call any time at <a href=\"tel:(248) 679-2714\">(248) 679-2714</a> or <a href=\"tel:(313) 317-6008\">(313) 317-6008</a> or <a href=\"mailto:Info@TheInvesteer.com\">Info@TheInvesteer.com</a>.</p><br/>
<br/></body>
</html>";
$to = $email; // <– replace with your address here
   $subject = "Thanks for Getting in Touch!";
   $from = "info@theinvesteer.com";
   $headers = "From: TheInvesteer<" . $from.">";
   $headers .= "MIME-Version: 1.0\r\n";
$headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";
   $output=mail($to,$subject,$message,$headers);
	
	$message="<html><head></head><body><br/><span>Dear <strong>Team,</strong></span><br/><br/>
<p>We have received inquiry for ".$propname." from:</p><br/><br/>
<table border=\"1\">
	<tr>
	<td><strong>First Name</strong></td>
	<td>".$fname."</td>
	</tr>
	<tr>
	<td><strong>Last Name</strong></td>
	<td>".$lname."</td>
	</tr>
	<tr>
	<td><strong>Contact Number</strong></td>
	<td>".$cnumber."</td>
	</tr>
	<tr>
	<td><strong>Email ID</strong></td>
	<td>".$email."</td>
	</tr>
	<tr>
	<td><strong>Desired Investment Amount</strong></td>
	<td>".$amount."</td>
	</tr>
	<tr>
	<td><strong>Desired Investment Period</strong></td>
	<td>".$period."</td>
	</tr>
	<tr>
	<td><strong>Message</strong></td>
	<td>".$msg."</td>
	</tr>
</table>
<br/>
<p>If you have any queries or questions feel free to contact me.</p>
</body>
</html>";

   $to = "Perry@alerteer.com"; // <– replace with your address here
   $subject = "TheInvesteer | ".$propname." Inquiry ";
   $from = "info@theinvesteer.com";
	$headers = "From: TheInvesteer<" . $from.">";
   $headers .= "MIME-Version: 1.0\r\n";
	$headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";  
   $output=mail($to,$subject,$message,$headers);
  $to = "Jay@sattrixusa.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "mgmodi1@gmail.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "Info@TheInvesteer.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   $to = "niravmscit@gmail.com"; // <– replace with your address here
   $output=mail($to,$subject,$message,$headers);
   
}
$response["success"]=(!$novalue)?1:0;
$response["error"]="";
echo json_encode($response);
?>