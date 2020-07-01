
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Identity;
using WebNetCoreDataLib.Models;

namespace WebNetCoreDataLib.WNCCommonHelper
{
    
        public class WNCPasswordHasher : IPasswordHasher<ApplicationUser>
        {
            public string HashPassword(ApplicationUser user, string password)
            {
                string hashedPassword = HashData(password);

                return hashedPassword;

                //throw new NotImplementedException();
            }

            public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
            {

                if (hashedPassword == HashData(providedPassword))
                {
                    return PasswordVerificationResult.Success;
                }

                return PasswordVerificationResult.Failed;
            }

        public static string HashData(string value)
        {
            string encrypted = "";
            SHA512 sha512 = SHA512.Create();
            sha512.ComputeHash(Encoding.ASCII.GetBytes(value.ToString()));
            encrypted = Encoding.ASCII.GetString(sha512.Hash);
            if (encrypted.Length > 50) { encrypted = encrypted.Substring(0, 50); }
            return encrypted;
        }

    }
    
}
