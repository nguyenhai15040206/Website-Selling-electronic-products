using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}