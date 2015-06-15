using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace HKBrowser.Plugs
{
    public class XmlRequest
    {
        public string Url { get; set; }
        
        public XmlDocument GetXmlResponse(string param)
        {

            WebRequest client = WebRequest.Create(Url + param);
            var response = client.GetResponse();
            return GetXmlFromResponse(response);
        }

        private XmlDocument GetXmlFromResponse(WebResponse response)
        {
            Stream stream = response.GetResponseStream();

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            stream.Close();
            response.Close();
            return doc;
        }

        public XmlDocument PostData(string param, NameValueCollection data)
        {
            WebRequest req = WebRequest.Create(string.Format("{0}{1}", Url, param));
            req.Method = "POST";

            string postData = string.Empty;
            foreach (string key in data.Keys)
            {
                postData += string.Format("{0}={1}&", key, HttpUtility.UrlEncode(data[key]));
            }
            byte[] byte1 = UTF8Encoding.UTF8.GetBytes(postData);


            req.ContentType = "application/x-www-form-urlencoded";

            req.ContentLength = byte1.Length;

            Stream newStream = req.GetRequestStream();

            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            var response = req.GetResponse();

            return GetXmlFromResponse(response);
        }


        public T GetPostResponse<T>(string param, NameValueCollection datas) where T : class
        {
            var doc = PostData(param, datas);
            return Deserialize<T>(doc);
        }

        public T GetObjectResponse<T>(string param) where T : class
        {
            XmlDocument doc = GetXmlResponse(param);

            return Deserialize<T>(doc);
        }
        
        private static T Deserialize<T>(XmlDocument doc) where T : class
        {
            XmlSerializer seri = new XmlSerializer(typeof(T));
            StringWriter sw = new StringWriter();

            XmlTextWriter writer = new XmlTextWriter(sw);

            doc.WriteTo(writer);

            StringReader sr = new StringReader(sw.ToString());

            var obj = seri.Deserialize(sr);
            return (T)obj;

        }

    }
}
