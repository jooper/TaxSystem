using System;
using System.Security.Cryptography;
using System.Text;
using JWT.Algorithms;
using JWT.Builder;

namespace Tax.CompanyModuleService.Uinities
{
    public class TokenProvider
    {
        private const string Secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public static string ResolveToken(string token)
        {
            var json = new JwtBuilder()
                .WithSecret(Secret)
                .MustVerifySignature()
                .Decode(token);
            return json;
        }

        public static string GenerateToken(string account, string md5Pwd)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim(account, md5Pwd)
                .Build();
            return token;
        }


        public static string Hash(string value)
        {
            var src = Encoding.UTF8.GetBytes(value);
            var md5 = MD5.Create();
            var hashed = md5.ComputeHash(src);

            var res = new StringBuilder(64);
            foreach (var b in hashed)
                res.Append(b.ToString("x2"));

            return res.ToString();
        }
    }
}