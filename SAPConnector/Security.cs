using System.Security.Cryptography;

namespace SAPConnector
{
    class Security
    {
        const string SALT = "m73kd$73&reU*2p0ENch@kSiuw7#sOwpR625teYh"; //Change this for your own security
        private static byte[] getKey()
        {
            string hid = libc.hwid.HwId.Generate();
            Rfc2898DeriveBytes keyBytes = new Rfc2898DeriveBytes(hid,System.Text.UTF8Encoding.UTF8.GetBytes(SALT));
            return keyBytes.GetBytes(32);
        }
        private static byte[] getIV()
        {
            string base64 = System.Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(System.Environment.UserName));
            Rfc2898DeriveBytes ivBytes = new Rfc2898DeriveBytes(base64, System.Text.UTF8Encoding.UTF8.GetBytes(SALT));
            return ivBytes.GetBytes(16);
        }

        public static string Encrypt(string text)
        {
            string encrypted_text = "";
            if (text == "") return "";

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = getKey();
                aes.IV = getIV();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(cs))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted_text = System.Convert.ToBase64String(ms.ToArray());
                    }
                }
            }

            return encrypted_text;
        }
        public static string Decrypt(string encrypted_text)
        {
            string text = "";
            if (encrypted_text == "") return "";

            using (Aes aes = Aes.Create())
            {
                aes.Key = getKey();
                aes.IV = getIV();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] encrypted_bytes = System.Convert.FromBase64String(encrypted_text);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Convert.FromBase64String(encrypted_text)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(cs))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }
            return text;
        }
    }
}
