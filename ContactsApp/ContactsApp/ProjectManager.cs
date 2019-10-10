using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ContactsApp
{

    public static class Projectmanager
    {

        public static string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ContactsApp.notes";
        ///<summary>
        ///сохраняет список контактов в файл 
        ///</summary>
        public static void Serialization(Project saveProject) //сериализация
        {
            JsonSerializer serializer = new JsonSerializer()

            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            };
            ///<summary>
            ///Открываем поток для записи в файла с указанием пути
            ///</summary>
            using (StreamWriter sw = new StreamWriter(FilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))

                serializer.Serialize(writer, saveProject);
        }
        ///<summary>
        ///выгружает список контактов из файла 
        ///</summary>
        public static Project Deserialization()   //десериализация
        {
            ///<summary>
            ///Создаём переменную, в которую поместим результат десериализации
            ///</summary>
            Project DeserilFile = null;
            ///<summary>
            ///Создаём экземпляр сериализатора
            ///</summary>
            JsonSerializer serializer = new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            };
            try
            {
                ///<summary>
                ///Открываем поток для чтения из файла с указанием пути
                ///</summary>
                using (StreamReader sr = new StreamReader(FilePath))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    ///<summary>
                    ///Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                    ///</summary>
                    var deserializedObject = serializer.Deserialize(reader);
                    DeserilFile = (Project)deserializedObject;
                }
            }
            catch (Exception e)
            {
                DeserilFile = new Project();
            }
            if (DeserilFile == null)
                DeserilFile = new Project();
            return DeserilFile;
        }
    }
}