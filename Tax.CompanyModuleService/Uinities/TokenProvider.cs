using System;
using JWT.Algorithms;
using JWT.Builder;
using Tax.ICompanyModuleService.Domain.Entities;

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

        public static string GenerateToken(string account,string md5Pwd)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim(account, md5Pwd)
                .Build();
            return token;
        }
    }
}