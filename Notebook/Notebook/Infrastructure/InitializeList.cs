using Notebook.BL.Models;
using Notebook.BL.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;

namespace Notebook.Infrastructure
{
    public sealed class InitializeList
    {
        public static List<People> PeopleList = new List<People>();
        private static SerializationService serService = new SerializationService();
        private static string relPath = HostingEnvironment.MapPath(@"~\Content\Data\Contacts.txt");

        /// <summary>
        /// Initialization PeopleList 
        /// </summary>
        public static void Init()
        {
            PeopleList = serService.Deserializer<List<People>>();
        }

        /// <summary>
        /// Create file for Deserialize. If File no exist.
        /// </summary>
        public static void EmptyInit()
        {
            if (!File.Exists(relPath))
            {
                serService.Serializer(PeopleList);
            }
        }
    }
}