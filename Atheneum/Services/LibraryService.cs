using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Repositories;
using Atheneum.DataAccess.Enums;

namespace Atheneum.Services
{
    public class LibraryService
    {
        private LibraryRepository _libraryRepository;
        public LibraryService()
        {
            _libraryRepository = new LibraryRepository();
        }

        public List<BaseEntity> GetLibrary()
        {
            return _libraryRepository.GetEntitys();
        }

        public void UpdateLibrary(string id, LibraryType entityLibraryType)
        {
            _libraryRepository.UpdateEntityChack(id, entityLibraryType);
        }

        public void DestroyLibraryItem(string id, LibraryType entityLibraryType)
        {
            _libraryRepository.DestroyEntity(id, entityLibraryType);
        }
        public List<BaseEntity> GetChacked()
        {
            return _libraryRepository.GetCheckedEntitys();
        }

        public static byte[] SerializeToXml<T>(List<T> items)
        {
            XmlSerializer ser = new XmlSerializer(items.GetLibraryType());
            string result = string.Empty;

            using (MemoryStream memStream = new MemoryStream())
            {
                ser.Serialize(memStream, items);

                memStream.Position = 0;
                result = new StreamReader(memStream).ReadToEnd();
            }
            
            var memoryStream = new MemoryStream();
            TextWriter textWriter = new StreamWriter(memoryStream);
            textWriter.WriteLine(result);
            textWriter.Flush();
            byte[] bytesInStream = memoryStream.ToArray();
            memoryStream.Close();
            return bytesInStream;
        }

        public static T DeserializeFromXml<T>(string str)
        {

            var stringReader = new StringReader(str);
            var xmlTextReader = new XmlTextReader(stringReader);

            var ser = new XmlSerializer(typeof(T));
            var items = (T)ser.Deserialize(xmlTextReader);
            return items;
        }

    }
}