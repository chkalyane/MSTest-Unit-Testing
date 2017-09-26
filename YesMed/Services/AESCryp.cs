using System;
using System.Security.Cryptography;
using System.Text;

namespace YesMed.Services
{
	public class AESCryp
	{
		public static string IV = "abnyckjksajierpe";
		public static string Key = "qwcgabnyckjksajierpeqwcgabnyckjk";

		public static string Encrypt(string message)
		{
			byte[] encbyte = Convert.FromBase64String(message);
			AesCryptoServiceProvider enc = new AesCryptoServiceProvider();
			enc.BlockSize = 128;
			enc.KeySize = 256;
			enc.Key = ASCIIEncoding.ASCII.GetBytes(Key);
			enc.IV = ASCIIEncoding.ASCII.GetBytes(IV);
			enc.Padding = PaddingMode.PKCS7;
			enc.Mode = CipherMode.CBC;

			ICryptoTransform icp = enc.CreateEncryptor(enc.Key, enc.IV);
			byte[] dec = icp.TransformFinalBlock(encbyte, 0, encbyte.Length);
			icp.Dispose();
			return ASCIIEncoding.ASCII.GetString(dec);
		}

		public static string Decrypt(string encryptedMessage)
		{
			byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(encryptedMessage);
			AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
			encdec.BlockSize = 128;
			encdec.KeySize = 256;
			encdec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
			encdec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
			encdec.Padding = PaddingMode.PKCS7;
			encdec.Mode = CipherMode.CBC;

			ICryptoTransform icp = encdec.CreateDecryptor(encdec.Key, encdec.IV);
			byte[] enc = icp.TransformFinalBlock(textBytes, 0, textBytes.Length);
			icp.Dispose();
			return Convert.ToBase64String(enc);
		}
	}
}