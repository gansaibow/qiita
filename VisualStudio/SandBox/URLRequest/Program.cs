using System;
using System.IO;
using System.Net;
using System.Text;

namespace URLRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding enc = Encoding.GetEncoding("UTF-8");
            string url = "http://127.0.0.1/sandbox/sample/xml/sample.xml";

            WebRequest req = WebRequest.Create(url);
            WebResponse res = req.GetResponse();

            Stream st = res.GetResponseStream();
            StreamReader sr = new StreamReader(st, enc);
            string xml = sr.ReadToEnd();
            sr.Close();
            st.Close();

            Console.WriteLine(xml);

            SampleXMLData xmlDatas = CustomXMLSeriallizer.LoadXmlDataString<SampleXMLData>(xml);

            Console.WriteLine("--------");
            Console.WriteLine("id  :" + xmlDatas.xmlData.id);
            Console.WriteLine("text:" + xmlDatas.xmlData.text);
            Console.WriteLine("--------");
            Console.ReadKey();
        }
    }
}
