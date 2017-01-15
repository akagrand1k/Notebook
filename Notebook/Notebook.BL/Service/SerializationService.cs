using Notebook.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;

namespace Notebook.BL.Service
{
    public sealed class SerializationService : ISerialization
    {
        private string relPath = HostingEnvironment.MapPath(@"~\Content\Data\Contacts.txt");
     
        /// <summary>
        /// Deserialize binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        public void Serializer<T>(T o) where T: class,new ()
        {
            BinaryFormatter binSer = new BinaryFormatter();
            using (var fs = new FileStream(relPath, FileMode.OpenOrCreate))
            {
                binSer.Serialize(fs, o);
            }
        }

        /// <summary>
        /// Serialize object in binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Deserializer<T>() where T : class, new()
        {
            BinaryFormatter binSer = new BinaryFormatter();
            using (var fs = new FileStream(relPath, FileMode.OpenOrCreate))
            {
                return (T)binSer.Deserialize(fs);
            }
        }
    }
}