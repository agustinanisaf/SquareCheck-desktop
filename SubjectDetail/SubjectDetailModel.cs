using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SquareCheck_desktop.SubjectDetail
{
    public class SubjectDetailModel
    {
        public SubjectDetailModel(string Subject, string Date)
        {
            this.Subject = Subject;
            this.Date = Date;
        }

        public string Subject { get; set; }
        public string Date { get; set; }

        public static List<SubjectDetailModel> FromJson(JObject json)
        {
            List<SubjectDetailModel> datas = new List<SubjectDetailModel>();
            foreach (JObject data in json["data"])
            {
                datas.Add(new SubjectDetailModel(data["subject"].ToString(), data["date"].ToString()));
            }
            return datas;
        }
    }
}
