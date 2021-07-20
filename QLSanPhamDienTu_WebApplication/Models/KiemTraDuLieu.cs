using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QLSanPhamDienTu_WebApplication.Models
{
    public class KiemTraDuLieu
    {
        public bool Regex(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        // kiểm tra số điện thoại
        public bool isPhoneNumber(string input)
        {
            if (Regex(input) && input.Length == 10 && input[0] == '0')
            {
                return true;
            }
            return false;
        }

        public bool isTextContainSPace(string input)
        {
            string str;
            for(int i=0; i < input.Length; i++)
            {
                str = input.Substring(i, 1);
                if (str == " ")
                    return false;
            }
            return true;
        }

        public string MD5Hash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text 
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
            byte[] result = md5.Hash;
            // get hash result after compute it

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // change it into 2 hexadecimal digits
                //for each byte
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}