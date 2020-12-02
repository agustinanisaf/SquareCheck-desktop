using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SquareCheck_desktop.ListMahasiswa
{
    public class ListMahasiswaModel
    {
        public ListMahasiswaModel(string Name, int Count)
        {
            this.Name = Name;
            this.Count = Count;
        }

        public string Name { get; set; }
        public int Count { get; set; }

        public static List<ListMahasiswaModel> FromJson(JObject json)
        {
            List<ListMahasiswaModel> datas = new List<ListMahasiswaModel>();
            foreach(JObject data in json["data"])
            {
                datas.Add(new ListMahasiswaModel(data["name"].ToString(), data["count"].ToObject<int>()));
            }
            return datas;
        }
    }
}
