using System;
using System.Collections.Generic;
using System.Text;

namespace CryptIO
{
    public class HKCryptString
    {
        private string strModulus = "iYcT+MYGkxW1AiYrVelK2h/18RQ19e/24czpfO01zFUjqZfw3nMjlrx4B3KepC/nBJ9PNHMJWgwDkfYo30g8EPBN92ucdthikylTn/XDS/vM82CJgFsv/Pk0nRNevjVOua/w+TZa+5D71UG5c+tsQAMFl653HhSncVpp2jycMU8=";
        private string strD = "NDdgQt1VE7VzM2ywmX7pV6Y46B7HWiiRMSxvHmqmOX29+59f6eYHhizq2dEQIMC7Uwr1tLFUxKa5GEtBO32eqDVE+k6w+muTB/oxNvyJNfdSwhl/RHyO6sAtrLrC48uNcVMMoK3OEqDJJGsVjhjU2dDvlDKdzyr7TS9M1a4KZvk=";
        private string strExponent = "AQAB";

        public string EnCrypt(string strIN)
        {
            return EncryptProcess(strIN, strD, strModulus);
        }

        public string DeCrypt(string strIN)
        {
            return DecryptProcess(strIN, strExponent, strModulus);
        }

        /*
         * 加密过程,其中d、n是RSACryptoServiceProvider生成的D、Modulus 
         * 
         */
        private string EncryptProcess(string source, string d, string n)
        {
            byte[] N = Convert.FromBase64String(n);
            byte[] D = Convert.FromBase64String(d);
            BigInteger biN = new BigInteger(N);
            BigInteger biD = new BigInteger(D);
            return EncryptString(source, biD, biN);
        }

        /* 
         * 解密过程,其中e、n是RSACryptoServiceProvider生成的Exponent、Modulus 
         * 
         */
        private string DecryptProcess(string source, string e, string n)
        {
            byte[] N = Convert.FromBase64String(n);
            byte[] E = Convert.FromBase64String(e);
            BigInteger biN = new BigInteger(N);
            BigInteger biE = new BigInteger(E);
            return DecryptString(source, biE, biN);
        }

        /*
         * 功能：用指定的私钥(n,d)加密指定字符串source 
         * 
         */
        private string EncryptString(string source, BigInteger d, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 128) == 0)
                len1 = len / 128;
            else
                len1 = len / 128 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 128)
                    blockLen = 128;
                else
                    blockLen = len;
                block = source.Substring(i * 128, blockLen);
                byte[] oText = System.Text.Encoding.Default.GetBytes(block);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(d, n);
                string temp1 = biEnText.ToHexString();
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }

        /*
         * 功能：用指定的公钥(n,e)解密指定字符串source 
         * 
         */
        private string DecryptString(string source, BigInteger e, BigInteger n)
        {
            string temp = "";

            try
            {
                int len = source.Length;
                int len1 = 0;
                int blockLen = 0;
                if ((len % 256) == 0)
                    len1 = len / 256;
                else
                    len1 = len / 256 + 1;
                string block = "";
                for (int i = 0; i < len1; i++)
                {
                    if (len >= 256)
                        blockLen = 256;
                    else
                        blockLen = len;
                    block = source.Substring(i * 256, blockLen);
                    BigInteger biText = new BigInteger(block, 16);
                    BigInteger biEnText = biText.modPow(e, n);
                    string temp1 = System.Text.Encoding.Default.GetString(biEnText.getBytes());
                    temp += temp1;
                    len -= blockLen;
                }
            }
            catch (System.Exception e0)
            {
                temp = "";
                Console.WriteLine(e0.Message);
            }

            return temp;
        }
    }
}
