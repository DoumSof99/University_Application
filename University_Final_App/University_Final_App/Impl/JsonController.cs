using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class JsonController {

        private const string _JsonFile = "University.json";

        public JavaScriptSerializer serializer { get; set; }
        public string path { get; set; }
        public string data { get; set; }

        public University MyUniversity = null;

        public JsonController() {
            serializer = new JavaScriptSerializer();
        }

        // Serialize
        public void SerializeToJson(University serializeObject) {
            data = serializer.Serialize(serializeObject);
            path = Path.Combine(Environment.CurrentDirectory, _JsonFile);

            File.WriteAllText(path, data);
        }

        //Deserialize
        public University DeserializeFromJson() {
            path = Path.Combine(Environment.CurrentDirectory, _JsonFile);
            data = string.Empty;

            if (File.Exists(path)) {
                data = File.ReadAllText(path);
                MyUniversity = serializer.Deserialize<University>(data);
            }
            else {
                File.Create(path).Dispose();
                MyUniversity = new University() {
                    Categories = new List<Category>(),
                    Courses = new List<Course>(),
                    Students = new List<Student>(),
                    Professors = new List<Professor>(),
                    Schedules = new List<Schedule>()
                };
                SerializeToJson(MyUniversity);
            }
            return MyUniversity;
        }
    }
}
