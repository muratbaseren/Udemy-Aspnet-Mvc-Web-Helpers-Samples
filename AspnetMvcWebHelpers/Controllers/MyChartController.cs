using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspnetMvcWebHelpers.Controllers
{
    public class MyChartController : Controller
    {
        public ActionResult ChartGoster()
        {
            return View();
        }


        public ActionResult ChartOlustur(string tip = "Column",string cache = "chart1")
        {
            Chart chart = Chart.GetFromCache(cache);

            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer - Ürün Satış Detay Grafiği");
                chart.AddLegend("Ürünler");

                chart.AddSeries(name: "Bilgisayar A", chartType: tip,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 800, 1200, 2300 });

                chart.AddSeries(name: "Bilgisayar B", chartType: tip,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 900, 1600, 3300 });

                string dir = Server.MapPath("~/charts/");

                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }

                string imagePath = dir + "chart1.jpeg";
                string xmlPath = dir + "chart1.xml";

                chart.Save(imagePath, format: "jpeg");
                chart.SaveXml(xmlPath);
                chart.SaveToCache(cache, 10, true);
            }


            return View(chart);
        }


        public ActionResult ChartOlustur2(string tip = "Pie", string cache = "chart2")
        {
            Chart chart = Chart.GetFromCache(cache);

            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer - Ürün Satış Detay Grafiği");
                chart.AddLegend("Ürünler");

                chart.AddSeries(name: "Ürünler", chartType: tip,
                    xValue: new[] { "Bilgisayar", "Fare", "Klavye" },
                    yValues: new[] { 100, 200, 500 });

                string dir = Server.MapPath("~/charts/");

                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }

                string imagePath = dir + "chart2.jpeg";
                string xmlPath = dir + "chart2.xml";

                chart.Save(imagePath, format: "jpeg");
                chart.SaveXml(xmlPath);
                chart.SaveToCache(cache, 1, true);
            }


            return View("ChartOlustur", chart);
        }
    }
}