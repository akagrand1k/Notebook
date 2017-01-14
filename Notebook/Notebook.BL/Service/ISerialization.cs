using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.BL.Service
{
    public interface ISerialization
    {
        /// <summary>
        /// Serialization current object in file.
        /// </summary>
        /// <typeparam name="T">Generic type params</typeparam>
        /// <param name="o">Deserialize object</param>
        void Serializer<T>(T o);

        /// <summary>
        /// Deserialization file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">Deserialize object</param>
        T Deserializer<T>();
    }
}