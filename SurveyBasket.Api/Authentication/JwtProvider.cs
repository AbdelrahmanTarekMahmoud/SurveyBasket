﻿
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.Api.Authentication
{
    public class JwtProvider : IJwtProvider
    {

        public (string token, int expiresIn) GenerateToken(ApplicationUser user)
        {
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sub , user.Id),
                new(JwtRegisteredClaimNames.Email , user.Email!),
                new(JwtRegisteredClaimNames.GivenName , user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName , user.LastName),
                new(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            ];

            //key to coding and decoding
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("awgvoEXPYkgCzDy6pry6bpP8n3SQrA83"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey , SecurityAlgorithms.HmacSha256);

            var expiresIn = 30;
            var expirationDate = DateTime.UtcNow.AddMinutes(expiresIn);

            //token structure
            var token = new JwtSecurityToken(
                issuer : "SurveyBasketApp",
                audience: "SurveyBasketApp User",
                claims : claims,
                expires : expirationDate,
                signingCredentials : signingCredentials
            );
            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresIn * 60 );
        }

    }
}