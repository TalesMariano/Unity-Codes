using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;
using System.Security;
using System.Text;

public class MD5 : MonoBehaviour
{
    public string timeHash;
    private void Start()
    {
        CalculateMD5Hash(timeHash);
    }
    public string CalculateMD5Hash(string stringToParse)
    {
        // step 1, calculate MD5 hash from input
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(stringToParse);
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        print(sb.ToString());
        return sb.ToString();
    }
}
