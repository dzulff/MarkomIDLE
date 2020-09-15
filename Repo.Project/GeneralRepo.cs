using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Model.Project;


namespace Repo.Project
{
    public class GeneralRepo
    {
        public static List<VMGeneral> ListYear()
        {


            int year = (System.DateTime.Now.Year);
            List<VMGeneral> alldata = new List<VMGeneral>();
            for (int intCount = year; intCount >= 2000; intCount--)
            {
                VMGeneral data = new VMGeneral();
                data.value = intCount.ToString();
                data.text = intCount.ToString();
                alldata.Add(data);
            }
            return alldata;
        }

        public static List<VMGeneral> ListMonth()
        {
            DateTime month = new DateTime(1999, 1, 1);
            List<VMGeneral> alldata = new List<VMGeneral>();
            for (int i = 1; i <= 12; i++)
            {
                VMGeneral data = new VMGeneral();
                CultureInfo ind = new CultureInfo("id-ID");
                string monthname = month.ToString("MMMM", ind);
                data.value = i.ToString();
                data.text = monthname;
                month = month.AddMonths(1);

                alldata.Add(data);
            }
            return alldata;
        }

      
    }

    public class VMGeneral
    {
        public int id { get; set; }
        public string value { get; set; }
        public string text { get; set; }
    }
}

