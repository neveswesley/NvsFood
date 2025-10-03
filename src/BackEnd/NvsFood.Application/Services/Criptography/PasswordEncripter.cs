﻿using System.Security.Cryptography;
using System.Text;

namespace NvsFood.Application.Services.Criptography;

public class PasswordEncripter
{
    public string Encrypt(string password)
    {
        var addictionalKey = "ABC";

        var newPassword = $"{addictionalKey}{password}";

        var bytes = Encoding.UTF8.GetBytes(newPassword);

        var hashBytes = SHA512.HashData(bytes);

        return StringBytes(hashBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}