using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using CryptIO;

namespace ReginfoRepository
{
    public class ValidResult
    {
        public ValidResult()
        {
            IsValid = false;
        }

        public RegInfo RegInfo { get; set; }

        public bool IsValid { get; set; }

        public string Message { get; set; }
    }

    public class RegInfo
    {
        public RegInfo()
        {
            LifeStartTime = LifeEndTime = ImportStartTime = ImportEndTime = DateTime.Now;
        }

        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }

        public string PcSn { get; set; }

        public DateTime LifeStartTime { get; set; }
        public DateTime LifeEndTime { get; set; }

        public DateTime ImportStartTime { get; set; }
        public DateTime ImportEndTime { get; set; }
        
    }

    public class Common
    {
        #region 主机序列号相关

        private struct NetworkConfig
        {
            public string ip;
            public string mac;
            public string name;

            public NetworkConfig(string ip, string mac, string name)
            {
                this.ip = ip;
                this.mac = mac;
                this.name = name;
            }

            public override string ToString()
            {
                return System.String.Format("{0}:   IP地址[{1}]  物理地址: {2}", name, ip, mac);
            }
        }

        private static List<NetworkConfig> GetMacNo()
        {
            List<NetworkConfig> list = new List<NetworkConfig>();
            string strMac = "";

            //
            //方法1
            //
            NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in fNetworkInterfaces)
            {
                if (adapter.OperationalStatus.Equals(OperationalStatus.Up))
                {
                    strMac = "";
                    strMac = adapter.GetPhysicalAddress().ToString();
                    if (strMac.Length != 0)
                    {
                        NetworkConfig netConfig = new NetworkConfig();
                        netConfig.mac = strMac;
                        netConfig.name = adapter.Name;

                        IPInterfaceProperties fIPInterfaceProperties = adapter.GetIPProperties();
                        UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = fIPInterfaceProperties.UnicastAddresses;
                        foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection)
                        {
                            if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                                netConfig.ip = UnicastIPAddressInformation.Address.ToString();
                        }

                        list.Add(netConfig);
                    }
                }
            }


            return list;
        }

        public static List<string> GetMachineCode()
        {
            List<string> list = new List<string>();
            List<NetworkConfig> macList = GetMacNo();

            foreach (NetworkConfig netConfig in macList)
            {
                string hash = getMd5Hash(netConfig.mac);
                list.Add(hash.ToUpper());
            }

            return list;
        }

        private static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        #endregion

        #region 生成注册码
        
        /// <summary>
        /// 生成注册码
        /// </summary>
        public static string MakeKey(RegInfo regInfo)
        {
            string strInput = regInfo.CompanyCode + "*";
            strInput += regInfo.CompanyName + "*";

            strInput += regInfo.PcSn + "*";

            strInput += regInfo.LifeStartTime.Ticks + "*";
            strInput += regInfo.LifeEndTime.Ticks + "*";

            strInput += regInfo.ImportStartTime.Ticks + "*";
            strInput += regInfo.ImportEndTime.Ticks;
  
            HKCryptString rsa = new HKCryptString();

            return rsa.EnCrypt(strInput);
        }
        #endregion

        #region 解析注册码

        public static RegInfo GetKeyInfo(bool bPlain, string keyInfo)
        {
            var result = new RegInfo();

            string keyInfoPlain = keyInfo;

            if (!bPlain)
            {
                keyInfoPlain = ParseKey(keyInfo);
            }

            if (keyInfoPlain.Length < 54)
            {
                throw new Exception("注册码无效，注册码长度不够");
            }

            string[] strTemp = keyInfoPlain.Split('*');
            if (strTemp.Length < 7)
            {
                throw new Exception("注册码无效，注册码信息不完整");
            }

            int nIndex = 0;
            result.CompanyCode = strTemp[nIndex].ToUpper();
            nIndex++;
            result.CompanyName = strTemp[nIndex].ToUpper();
            nIndex++;

            result.PcSn = strTemp[nIndex].ToUpper();
            nIndex++;

            result.LifeStartTime = new DateTime(long.Parse(strTemp[nIndex]));
            nIndex++;
            result.LifeEndTime = new DateTime(long.Parse(strTemp[nIndex]));
            nIndex++;

            result.ImportStartTime = new DateTime(long.Parse(strTemp[nIndex]));
            nIndex++;
            result.ImportEndTime = new DateTime(long.Parse(strTemp[nIndex]));

            return result;
        }

        /// <summary>
        /// 解析注册码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ParseKey(string inputCipher)
        {
            HKCryptString rsa = new HKCryptString();

            return rsa.DeCrypt(inputCipher);
        }

        #endregion

        #region 验证注册码
       
        /// <summary>
        /// 验证key的有效性
        /// </summary>
        /// <param name="bPlain">是否为明文</param>
        /// <param name="keyInfo"></param>
        public static ValidResult ValidKey(bool bPlain, string keyInfo)
        {
            var regInfo = GetKeyInfo(bPlain, keyInfo);

            return ValidRegInfo(regInfo);
        }

        public static ValidResult ValidRegInfo(RegInfo regInfo)
        {
            ValidResult result = new ValidResult();

            result.RegInfo = regInfo;

            //验证机器码
            List<string> list = GetMachineCode();
            bool bFlag = false;
            foreach (var item in list)
            {
                if (!regInfo.PcSn.ToUpper().Equals(item.ToUpper()))
                {
                    bFlag = true;
                    break;
                }
            }
            if (!bFlag)
            {
                result.Message = "非本机器注册码";
                return result;
            }
            

            //验证时间
            DateTime tmCurrent = DateTime.Now;

            if (regInfo.LifeEndTime.CompareTo(tmCurrent) < 0)
            {
                result.Message = "注册码已经过期";
                return result;
            }

            if (regInfo.LifeStartTime.CompareTo(tmCurrent) > 0)
            {
                result.Message = "注册码尚未生效";
                return result;
            }

            result.Message = "注册码有效期为：" +
                result.RegInfo.LifeStartTime.ToString("yyyy-MM-dd hh:mm:ss") +
                " 至 " +
                result.RegInfo.LifeEndTime.ToString("yyyy-MM-dd hh:mm:ss");

            result.IsValid = true;
            return result;

        }

        #endregion

        #region 保存注册信息
        private static string DefaultRegistryKey = @"Software\SDCM";
        private static string DefaultRegistryName = "sdcm";

        public static bool SaveKey(string keyInfo)
        {
            return SaveKey(keyInfo, DefaultRegistryKey);
        }

        public static bool SaveKey(string keyInfo, string strRegistryKey)
        {
            return SaveKey(keyInfo, strRegistryKey, DefaultRegistryName);
        }

        public static bool SaveKey(string keyInfo, string strRegistryKey, string strRegistrySubName)
        {
            return WriteStringToReg(strRegistryKey, strRegistrySubName, keyInfo);
        }

        #endregion

        #region 获取本地保存的注册信息
        public static string GetLocalKey()
        {
            return GetLocalKey(DefaultRegistryName);
        }

        public static string GetLocalKey(string productName)
        {
            return GetLocalKey(DefaultRegistryKey, productName);
        }

        /// <summary>
        /// 获取本地key
        /// </summary>
        /// <returns></returns>
        public static string GetLocalKey(string strRegistryKey, string productName)
        {
            return ReadStringFromReg(strRegistryKey, productName);
        }

        #endregion

        #region 注册表操作
        private static bool WriteStringToReg(string strSubKey, string strSubName, string strValue)
        {
            var subKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(strSubKey);
            if (subKey == null)
            {
                return false;
            }

            subKey.SetValue(strSubName, strValue, Microsoft.Win32.RegistryValueKind.String);
            subKey.Close();

            return true;
        }

        private static string ReadStringFromReg(string strSubKey, string strSubName)
        {
            string strRet = "";
            var subKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strSubKey);
            if (subKey == null)
            {
                return strRet;
            }

            var oValue = subKey.GetValue(strSubName);

            if (oValue != null)
            {
                strRet = oValue.ToString();
            }

            subKey.Close();
            return strRet;
        }

        #endregion

    }
}
