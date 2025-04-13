using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Configurations
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } // Tokenun hangi sunucu tarafından verildiği
        public string Audience { get; set; } // Tokenin hangi sunucu tarafından kabul edildiği
        public string Key { get; set; } // Tokenin imzalanmasında kullanılan anahtar
        public int ExpireInMinutes { get; set; } // Tokenin ömrü (dakika cinsinden)
    }
}
