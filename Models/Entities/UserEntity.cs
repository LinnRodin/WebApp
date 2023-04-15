﻿using System.Security.Cryptography;
using System.Text;

namespace WebApp.Models.Entities;

public class UserEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public byte[] Password { get; private set; } = null!;
    public byte[] SecurityKey { get; private set; } = null!;


    public void GenerateSecurePassword(string password)     //Generera lösenord 
    {
        using var hmac = new HMACSHA512();
        SecurityKey = hmac.Key;
        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifySecurePassword(string password)
    {
        using var hmac = new HMACSHA512();
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  // verifiera lösenord

        for (int i = 0; i < hash.Length; i++)
        {
            if (hash[i] != Password[i])
                return false;

        }

        return true;
    }
}
