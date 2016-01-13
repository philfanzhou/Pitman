using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Pitman.RESTful.Client
{
    internal class JsonSerializer
    {
        private Encoding _encoding = Encoding.UTF8;

        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        public string Serialize<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(ms, obj);
                StringBuilder sb = new StringBuilder();
                sb.Append(_encoding.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }

        public T Deserialize<T>(string jsonString)
        {
            using (MemoryStream ms = new MemoryStream(_encoding.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T returnOjbect = (T)serializer.ReadObject(ms);
                return returnOjbect;
            }
        }
    }
}
