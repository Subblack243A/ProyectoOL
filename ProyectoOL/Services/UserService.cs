﻿using ProyectoOL.Dto;
using ProyectoOL.Repositories;
using ProyectoOL.Utilities;


namespace ProyectoOL.Services
{
    public class UserService
    {
        public UserDto CreateUser(UserDto user)
        {
            if (!user.Message.Equals("1"))
            {
                EncryptUtility encryptUtility = new EncryptUtility();
                user.Contrasena = encryptUtility.Encrypt(user.Contrasena);
                user.KeySafe = encryptUtility.GetKeySafe();
                user.Iv = encryptUtility.GetIv();
            }
            UserRepository userRepository = new UserRepository();
            int result = userRepository.CreateUser(user);

            if(result == 1)
            {
                EmailUtility email = new EmailUtility();
                string destino = user.Correo_Electronico;
                string asunto = "Creación de usuario";
                string mensaje = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html dir=\"ltr\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" lang=\"es\"><head><meta charset=\"UTF-8\"><meta content=\"width=device-width, initial-scale=1\" name=\"viewport\"><meta name=\"x-apple-disable-message-reformatting\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta content=\"telephone=no\" name=\"format-detection\"><title>Copiar Nueva plantilla de correo electr%C3%B3nico 2023-11-04</title> <!--[if (mso 16)]><style type=\"text/css\">     a {text-decoration: none;}     </style><![endif]--> <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--> <!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml>\r\n<![endif]--> <!--[if !mso]><!-- --><link href=\"https://fonts.googleapis.com/css?family=Montserrat:500,800&display=swap&subset=cyrillic-ext\" rel=\"stylesheet\"> <!--<![endif]--><style type=\"text/css\">.rollover:hover .rollover-first { max-height:0px!important; display:none!important;}.rollover:hover .rollover-second { max-height:none!important; display:inline-block!important;}.rollover div { font-size:0px;}u + .body img ~ div div { display:none;}#outlook a { padding:0;}span.MsoHyperlink,span.MsoHyperlinkFollowed { color:inherit; mso-style-priority:99;}a.es-button { mso-style-priority:100!important; text-decoration:none!important;} a[x-apple-data-detectors] { color:inherit!important; text-decoration:none!important; font-size:inherit!important; font-family:inherit!important; font-weight:inherit!important; line-height:inherit!important;}\r\n.es-desk-hidden { display:none; float:left; overflow:hidden; width:0; max-height:0; line-height:0; mso-hide:all;}.es-button-border:hover > a.es-button { color:#ffffff!important;}@media only screen and (max-width:600px) {h1 { font-size:30px!important; text-align:left } h2 { font-size:24px!important; text-align:left } h3 { font-size:20px!important; text-align:left } .es-m-p0r { padding-right:0px!important } .es-m-p0 { padding:0px!important } *[class=\"gmail-fix\"] { display:none!important } p, a { line-height:150%!important } h1, h1 a { line-height:120%!important } h2, h2 a { line-height:120%!important } h3, h3 a { line-height:120%!important } h4, h4 a { line-height:120%!important } h5, h5 a { line-height:120%!important } h6, h6 a { line-height:120%!important } h4 { font-size:24px!important; text-align:left } h5 { font-size:20px!important; text-align:left } h6 { font-size:16px!important; text-align:left }\r\n .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:30px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:24px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-header-body h4 a, .es-content-body h4 a, .es-footer-body h4 a { font-size:24px!important } .es-header-body h5 a, .es-content-body h5 a, .es-footer-body h5 a { font-size:20px!important } .es-header-body h6 a, .es-content-body h6 a, .es-footer-body h6 a { font-size:16px!important } .es-menu td a { font-size:12px!important } .es-header-body p, .es-header-body a { font-size:14px!important } .es-content-body p, .es-content-body a { font-size:14px!important } .es-footer-body p, .es-footer-body a { font-size:12px!important } .es-infoblock p, .es-infoblock a { font-size:12px!important }\r\n .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3, .es-m-txt-c h4, .es-m-txt-c h5, .es-m-txt-c h6 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3, .es-m-txt-r h4, .es-m-txt-r h5, .es-m-txt-r h6 { text-align:right!important } .es-m-txt-j, .es-m-txt-j h1, .es-m-txt-j h2, .es-m-txt-j h3, .es-m-txt-j h4, .es-m-txt-j h5, .es-m-txt-j h6 { text-align:justify!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3, .es-m-txt-l h4, .es-m-txt-l h5, .es-m-txt-l h6 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-m-txt-r .rollover:hover .rollover-second, .es-m-txt-c .rollover:hover .rollover-second, .es-m-txt-l .rollover:hover .rollover-second { display:inline!important } .es-m-txt-r .rollover div, .es-m-txt-c .rollover div, .es-m-txt-l .rollover div { line-height:0!important; font-size:0!important }\r\n .es-spacer { display:inline-table } a.es-button, button.es-button { font-size:18px!important; line-height:120%!important } a.es-button, button.es-button, .es-button-border { display:inline-block!important } .es-m-fw, .es-m-fw.es-fw, .es-m-fw .es-button { display:block!important } .es-m-il, .es-m-il .es-button, .es-social, .es-social td, .es-menu { display:inline-block!important } .es-adaptive table, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .adapt-img { width:100%!important; height:auto!important } .es-mobile-hidden, .es-hidden { display:none!important } .es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important; display:table-row!important } tr.es-desk-hidden { display:table-row!important }\r\n table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } .es-social td { padding-bottom:10px } .h-auto { height:auto!important } .img-7978 { height:78px!important } }</style>\r\n </head> <body class=\"body\" style=\"width:100%;height:100%;padding:0;Margin:0\"><div dir=\"ltr\" class=\"es-wrapper-color\" lang=\"es\" style=\"background-color:#F6F6F6\"> <!--[if gte mso 9]><v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\"> <v:fill type=\"tile\" color=\"#f6f6f6\"></v:fill> </v:background><![endif]--><table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#F6F6F6\"><tr>\r\n<td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-header\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:transparent;background-repeat:repeat;background-position:center top\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-header-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#2A3C51;width:600px\"><tr><td align=\"left\" bgcolor=\"#29282D\" style=\"padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px;background-color:#29282d\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr>\r\n<td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:Montserrat, 'Google Sans', 'Segoe UI', Roboto, Arial, Ubuntu, sans-serif;line-height:18px;letter-spacing:0;color:#f0ece9;font-size:12px\">Open Library</p> </td></tr><tr><td align=\"center\" height=\"20\" style=\"padding:0;Margin:0\"></td></tr></table></td></tr></table></td></tr> <tr><td align=\"left\" bgcolor=\"#625C60\" style=\"padding:20px;Margin:0;background-color:#625c60\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr>\r\n<td class=\"es-m-p0r\" valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-bottom:10px;font-size:0px\"><a target=\"_blank\" href=\"https://viewstripo.email\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#FFFFFF;font-size:12px\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/logool.png\" alt=\"Logo\" style=\"display:block;font-size:14px;border:0;outline:none;text-decoration:none\" height=\"138\" title=\"Logo\" width=\"138\"></a> </td></tr><tr>\r\n<td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-top:15px\"><h1 style=\"Margin:0;font-family:Montserrat, 'Google Sans', 'Segoe UI', Roboto, Arial, Ubuntu, sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:30px;font-style:normal;font-weight:bold;line-height:36px;color:#f0ece9\">BIENVENIDO A OPEN LIBRARY</h1></td></tr></table></td></tr></table></td></tr></table></td></tr></table> <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tr>\r\n<td align=\"left\" bgcolor=\"#625c60\" style=\"Margin:0;padding-right:20px;padding-left:20px;padding-top:30px;padding-bottom:30px;background-color:#625c60\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:15px;padding-bottom:30px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:Montserrat, 'Google Sans', 'Segoe UI', Roboto, Arial, Ubuntu, sans-serif;line-height:21px;letter-spacing:0;color:#f0ece9;font-size:14px\">Tu registro ha sido exitoso " + user.Nombre + " " + user.Apellido + ", ya puedes ingresar en la página con tu Nombre de Usuario y Contraseña</p>\r\n </td></tr></table></td></tr></table></td></tr></table></td></tr></table> <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tr><td align=\"left\" bgcolor=\"#7c6460\" style=\"padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px;background-color:#7c6460\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr>\r\n<td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"left\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:Montserrat, 'Google Sans', 'Segoe UI', Roboto, Arial, Ubuntu, sans-serif;line-height:32px;letter-spacing:0;color:#f0ece9;font-size:21px\">Encuéntranos en:</p> </td></tr></table></td></tr></table></td></tr></table></td></tr></table> <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr>\r\n<td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#2A3C51\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#2a3c51;width:600px\" role=\"none\"><tr><td align=\"left\" bgcolor=\"#7C6460\" style=\"padding:0;Margin:0;background-color:#7c6460\"> <!--[if mso]><table style=\"width:600px\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"width:207px\" valign=\"top\"><![endif]--><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tr><td align=\"left\" style=\"padding:0;Margin:0;width:187px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr>\r\n<td align=\"center\" class=\"es-m-txt-c\" style=\"padding:20px;Margin:0;font-size:0px\"><a target=\"_blank\" href=\"https://viewstripo.email\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#2A3C51;font-size:14px\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/image_12.png\" alt style=\"display:block;font-size:14px;border:0;outline:none;text-decoration:none\" width=\"73\" height=\"69\"></a> </td></tr></table></td><td class=\"es-hidden\" style=\"padding:0;Margin:0;width:20px\"></td></tr></table> <!--[if mso]></td><td style=\"width:187px\" valign=\"top\"><![endif]--><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tr>\r\n<td align=\"left\" style=\"padding:0;Margin:0;width:187px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px;font-size:0px\"><a target=\"_blank\" href=\"https://viewstripo.email\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#2A3C51;font-size:14px\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/image_11.png\" alt style=\"display:block;font-size:14px;border:0;outline:none;text-decoration:none\" class=\"img-7978\" width=\"102\" height=\"102\"></a> </td></tr></table></td></tr></table> <!--[if mso]></td><td style=\"width:20px\"></td>\r\n<td style=\"width:186px\" valign=\"top\"><![endif]--><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tr><td align=\"left\" style=\"padding:0;Margin:0;width:186px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:5px;Margin:0;font-size:0px\"><a target=\"_blank\" href=\"https://viewstripo.email\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#2A3C51;font-size:14px\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/image_13_YXC.png\" alt style=\"display:block;font-size:14px;border:0;outline:none;text-decoration:none\" width=\"121\" height=\"93\"></a> </td></tr></table></td>\r\n</tr></table> <!--[if mso]></td></tr></table><![endif]--></td></tr></table></td></tr></table></td></tr></table></div></body></html>";
                email.SendEmail(destino, asunto, mensaje, true);
                return user;
            }
            else
            {
                return CleanUser(user);
            }
        }

        public UserDto CleanUser(UserDto user)
        {
            user.Id_Usuario = -1;
            user.Nombre_Usuario = null;
            user.Tipo_Usuario = 0;
            user.Tipo_Documento = 0;
            user.Nombre = null;
            user.Apellido = null;
            user.Correo_Electronico = null;
            user.KeySafe = null;
            user.Iv = null;
            user.Contrasena = null;
            user.Estado = 0;
            return user;
        }

        public UserDto InicioSesion(UserDto userModel)
        {
            UserRepository userRepository = new UserRepository();
            UserDto userResponse = userRepository.Login(userModel);
            if (userResponse.Id_Usuario != 0)
            {
                EmailUtility email = new EmailUtility();
                string destino = userResponse.Correo_Electronico;
                string asunto = "Ingreso a Open Library";
                string mensaje = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html dir=\"ltr\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta content=\"width=device-width, initial-scale=1\" name=\"viewport\">\r\n    <meta name=\"x-apple-disable-message-reformatting\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta content=\"telephone=no\" name=\"format-detection\">\r\n    <title></title>\r\n    <!--[if (mso 16)]>\r\n    <style type=\"text/css\">\r\n    a {text-decoration: none;}\r\n    </style>\r\n    <![endif]-->\r\n    <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]-->\r\n    <!--[if gte mso 9]>\r\n<xml>\r\n    <o:OfficeDocumentSettings>\r\n    <o:AllowPNG></o:AllowPNG>\r\n    <o:PixelsPerInch>96</o:PixelsPerInch>\r\n    </o:OfficeDocumentSettings>\r\n</xml>\r\n<![endif]-->\r\n    <!--[if !mso]><!-- -->\r\n    <link href=\"https://fonts.googleapis.com/css?family=Montserrat:500,800&display=swap&subset=cyrillic-ext\" rel=\"stylesheet\">\r\n    <!--<![endif]-->\r\n</head>\r\n\r\n<body class=\"body\">\r\n    <div dir=\"ltr\" class=\"es-wrapper-color\">\r\n        <!--[if gte mso 9]>\r\n\t\t\t<v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\">\r\n\t\t\t\t<v:fill type=\"tile\" color=\"#f6f6f6\"></v:fill>\r\n\t\t\t</v:background>\r\n\t\t<![endif]-->\r\n        <table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">\r\n            <tbody>\r\n                <tr>\r\n                    <td class=\"esd-email-paddings\" valign=\"top\">\r\n                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"esd-header-popover es-header\" align=\"center\">\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td class=\"esd-stripe\" align=\"center\">\r\n                                        <table bgcolor=\"#ffffff\" class=\"es-header-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\">\r\n                                            <tbody>\r\n                                                <tr>\r\n                                                    <td class=\"es-p20t es-p20r es-p20l esd-structure\" align=\"left\" bgcolor=\"#29282D\" style=\"background-color: #29282d;\">\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"560\" class=\"esd-container-frame\" align=\"center\" valign=\"top\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-text\">\r\n                                                                                        <p style=\"font-size: 12px; color: #f0ece9;\">Open Library</p>\r\n                                                                                    </td>\r\n                                                                                </tr>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-spacer\" height=\"20\"></td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                    </td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <td class=\"esd-structure es-p20\" align=\"left\" bgcolor=\"#625C60\" style=\"background-color: #625c60;\">\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"560\" class=\"es-m-p0r esd-container-frame\" valign=\"top\" align=\"center\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-image es-p10b\" style=\"font-size: 0px;\"><a target=\"_blank\" href=\"https://viewstripo.email\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/logool.png\" alt=\"Logo\" style=\"display: block;\" height=\"138\" title=\"Logo\"></a></td>\r\n                                                                                </tr>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-text es-m-txt-c es-p15t\">" +
                    "<h1 style=\"color: #f0ece9;\">SE HA INICIADO SESIÓN&nbsp;</h1>\r\n                                                                                    </td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                    </td>\r\n                                                </tr>\r\n                                            </tbody>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\">\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td class=\"esd-stripe\" align=\"center\">\r\n                                        <table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\">\r\n                                            <tbody>\r\n                                                <tr>\r\n                                                    <td class=\"esd-structure es-p30t es-p30b es-p20r es-p20l\" align=\"left\" bgcolor=\"#625c60\" style=\"background-color: #625c60;\">\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"560\" class=\"esd-container-frame\" align=\"center\" valign=\"top\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-text es-p15t es-p30b\">" +
                    "<p style=\"color: #f0ece9;\">" + userResponse.Nombre_Usuario + "has iniciado sesión en Open Library</p>\r\n                                                                                    </td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                    </td>\r\n                                                </tr>\r\n                                            </tbody>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\">\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td class=\"esd-stripe\" align=\"center\">\r\n                                        <table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\">\r\n                                            <tbody>\r\n                                                <tr>\r\n                                                    <td class=\"es-p20t es-p20r es-p20l esd-structure\" align=\"left\" bgcolor=\"#7c6460\" style=\"background-color: #7c6460;\">\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"560\" class=\"esd-container-frame\" align=\"center\" valign=\"top\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"left\" class=\"esd-block-text es-m-txt-c\">\r\n                                                                                        <p style=\"color: #f0ece9; font-size: 21px;\">Encuéntranos en:</p>\r\n                                                                                    </td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                    </td>\r\n                                                </tr>\r\n                                            </tbody>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content esd-footer-popover\" align=\"center\">\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td class=\"esd-stripe\" align=\"center\">\r\n                                        <table bgcolor=\"#2A3C51\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"background-color: #2a3c51;\">\r\n                                            <tbody>\r\n                                                <tr>\r\n                                                    <td class=\"esd-structure\" align=\"left\" bgcolor=\"#7C6460\" style=\"background-color: #7c6460;\">\r\n                                                        <!--[if mso]><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\"><tr><td width=\"207\" valign=\"top\"><![endif]-->\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"187\" align=\"left\" class=\"esd-container-frame\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-image es-m-txt-c es-p20\" style=\"font-size: 0px;\"><a target=\"_blank\" href=\"https://viewstripo.email\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/image_12.png\" alt style=\"display: block;\" width=\"73\"></a></td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                    <td class=\"es-hidden\" width=\"20\"></td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                        <!--[if mso]></td><td width=\"187\" valign=\"top\"><![endif]-->\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"187\" align=\"left\" class=\"esd-container-frame\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-image es-m-txt-c es-p5t es-p5b\" style=\"font-size: 0px;\"><a target=\"_blank\" href=\"https://viewstripo.email\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/image_11.png\" alt style=\"display: block;\" class=\"img-7978\" width=\"102\"></a></td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                        <!--[if mso]></td><td width=\"20\"></td><td width=\"186\" valign=\"top\"><![endif]-->\r\n                                                        <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td width=\"186\" align=\"left\" class=\"esd-container-frame\">\r\n                                                                        <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                                                            <tbody>\r\n                                                                                <tr>\r\n                                                                                    <td align=\"center\" class=\"esd-block-image es-m-txt-c es-p5\" style=\"font-size: 0px;\"><a target=\"_blank\" href=\"https://viewstripo.email\"><img src=\"https://ecntnoj.stripocdn.email/content/guids/a2f9c7c7-98f4-47cb-ac92-56e0371c2e68/images/image_13_YXC.png\" alt style=\"display: block;\" width=\"121\"></a></td>\r\n                                                                                </tr>\r\n                                                                            </tbody>\r\n                                                                        </table>\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n                                                        <!--[if mso]></td></tr></table><![endif]-->\r\n                                                    </td>\r\n                                                </tr>\r\n                                            </tbody>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</body>\r\n\r\n</html>";
                email.SendEmail(destino, asunto, mensaje, true);

                userResponse.Message = "Successful Login";
            }
            else
            {
                userResponse.Message = "Error Inicio de Sesion, Usuario o Contraseña Incorrecctos";
            }
            return userResponse;
        }
    }
}