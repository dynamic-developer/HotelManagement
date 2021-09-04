using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.Services
{
    public class WbcEmailService
    {

        public string EmailRegisterSubject = "Work By Clock | Confirm Your Account";
        public string EmailRegisterBody = @"<center><table width='920' border='0' cellspacing='0' cellpadding='0' ><tr>
<td bgcolor='#D0372F' height='8' colspan='3'></td></tr><tr><td bgcolor='#ffffff' colspan='3'><table width='860' border='0' cellspacing='0' cellpadding='0' >
<tr><td width='400' bgcolor='#ffffff'></td><td width='400' valign='bottom'><a href='http://www.workbyclock.com' target='_blank'>
<img src='http://www.workbyclock.com/images/logo-1-1.png' width='120' height='120'></a><br/>
<span style='font-family:Tahoma,Arial;font-size:14px;color:#D0372F;line-height:19px;padding-left:0px;' >Work By Clock</span></td>
<td></td><td valign='middle'><span style='font-family:Tahoma,Arial;line-height:19px' ></span></td></tr></table></td>
</tr><tr><td width='20' bgcolor='#ffffff' ></td><td><table width='720' border='0' cellspacing='0' cellpadding='0' style='padding-left:15px;'><tr>
<td width='20' bgcolor='#FFFFFF'> </td><td valign='top' bgcolor='#FFFFFF'><table width='100%' border='0' cellspacing='0' cellpadding='0'>
<tr><td height='10'></td></tr><tr><td><span style='font-family:Tahoma,Arial;color:#333333;line-height:26px' >Welcome</span><br></td></tr>
<tr><td height='6'></td></tr><tr><td height='10'><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>You have been added as a member to Work By Clock.</p>
<p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'><b>Your Username is {0} </b><br/><b> Your Password is {1} </b><br/><b>Please confirm your account by clicking <a href='{2}'> here</a>.</b></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p> <p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>Thank you and hope you have a wonderful day ahead!</p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>Work By Clock Team<br/><a href='http://www.workbyclock.com' target='_blank'>www.workbyclock.com</a></p></td></tr></table></td><td width='20' bgcolor='#FFFFFF'></td><td width='20' bgcolor='#ffffff' ></td></tr></table></td><td width='20' bgcolor='#ffffff' ></td></tr><tr><td width='20' bgcolor='#ffffff' ></td><td bgcolor='#FFFFFF'><br><br><table width='720' border='0' cellspacing='0' cellpadding='0'><tr><td width='20' bgcolor='#ffffff' ></td><td ><br><div align='center'><span style='font-family:Tahoma,Verdana,Helvetica,sans-serif;font-size:11px;color:#666666;line-height:13px'>©Copyright WorkByClock. All Rights Reserved.<br></span></div></td><td width='20' bgcolor='#ffffff' ></td></tr></table><br><br></td><td width='20' bgcolor='#ffffff' ></td></tr></table></center>";


        public string EmailForgotSubject = "Work By Clock | Reset Your Account";
        public string EmailForgotBody = @"<center><table width='920' border='0' cellspacing='0' cellpadding='0' ><tr>
<td bgcolor='#D0372F' height='8' colspan='3'></td></tr><tr><td bgcolor='#ffffff' colspan='3'><table width='860' border='0' cellspacing='0' cellpadding='0' >
<tr><td width='400' bgcolor='#ffffff'></td><td width='400' valign='bottom'><a href='http://www.workbyclock.com' target='_blank'>
<img src='http://www.workbyclock.com/images/logo-1-1.png' width='120' height='120'></a><br/>
<span style='font-family:Tahoma,Arial;font-size:14px;color:#D0372F;line-height:19px;padding-left:0px;' >Work By Clock</span></td>
<td></td><td valign='middle'><span style='font-family:Tahoma,Arial;line-height:19px' ></span></td></tr></table></td>
</tr><tr><td width='20' bgcolor='#ffffff' ></td><td><table width='720' border='0' cellspacing='0' cellpadding='0' style='padding-left:15px;'><tr>
<td width='20' bgcolor='#FFFFFF'> </td><td valign='top' bgcolor='#FFFFFF'><table width='100%' border='0' cellspacing='0' cellpadding='0'>
<tr><td height='10'></td></tr><tr><td><span style='font-family:Tahoma,Arial;color:#333333;line-height:26px' >Reset Password</span><br></td></tr>
<tr><td height='6'></td></tr><tr><td height='10'><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>You have requested to reset your password for Work By Clock.</p>
<p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'><b>Please click on this <a href='{0}' target='_blank'> link </a> to reset your password.</b><br/></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p> <p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>Thank you and hope you have a wonderful day ahead!</p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'></p><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>Work By Clock Team<br/><a href='http://www.workbyclock.com' target='_blank'>www.workbyclock.com</a></p></td></tr></table></td><td width='20' bgcolor='#FFFFFF'></td><td width='20' bgcolor='#ffffff' ></td></tr></table></td><td width='20' bgcolor='#ffffff' ></td></tr><tr><td width='20' bgcolor='#ffffff' ></td><td bgcolor='#FFFFFF'><br><br><table width='720' border='0' cellspacing='0' cellpadding='0'><tr><td width='20' bgcolor='#ffffff' ></td><td ><br><div align='center'><span style='font-family:Tahoma,Verdana,Helvetica,sans-serif;font-size:11px;color:#666666;line-height:13px'>©Copyright WorkByClock. All Rights Reserved.<br></span></div></td><td width='20' bgcolor='#ffffff' ></td></tr></table><br><br></td><td width='20' bgcolor='#ffffff' ></td></tr></table></center>";


        public bool SendHtmlEmail(string to, string subject, string msg, string from = "")
        {
            // Plug in your email service here to send an email.
            var mail = new MailMessage();
            SmtpClient client = new SmtpClient("mail.workbyclock.com");

            if (string.IsNullOrEmpty(from))
            {
                mail.From = new MailAddress("postmaster@workbyclock.com", "Work By Clock Admin");
            }
            else
            {
                mail.From = new MailAddress(from);
            }


            mail.To.Add(to);

            mail.Subject = subject;

            // Here you define your message
            mail.Body = msg;
            mail.IsBodyHtml = true;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("postmaster@workbyclock.com", "Yug$2002");
            //client.EnableSsl = true;

            client.Send(mail);
            return true;
        }
    }
}
