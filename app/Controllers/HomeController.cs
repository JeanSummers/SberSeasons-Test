using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using sberseasons.Models;
using System.Xml;

namespace app.Controllers
{

    public class HomeController : Controller
    {

        // Предполагается, что новости будут подгружаться из внешнего источника
        NewsModel[] NewsList = new NewsModel[]
        {
            new NewsModel
            {
                number = 0,
                header = "Сбербанк захотел выйти из-под контроля государства",
                headerSmall = "Сбербанк захотел выйти<br> из-под контроля государства",
                mainImg = "/images/pic01.jpg",
                shortHTML = "Глава Сбербанка Герман Греф призвал<br> " +
                            "государство продать контрольную долю в крупнейшей<br> " +
                            "финансовой организации России",
                fullHTML = "News1"
            },
            new NewsModel
            {
                number = 1,
                header = "В работе трейдинговой платформы Сбербанка произошел сбой",
                headerSmall = "В работе трейдинговой платформы <br>Сбербанка произошел сбой",
                mainImg = "/images/pic02.jpg",
                shortHTML = "В работе брокера Сбербанка произошел кратковременный<br> " +
                            "технический сбой. О проблемах с проведением<br> " +
                            "операций сообщил РБК клиент банка",
                fullHTML = "News2"
            }
        };

        private string CreateItem(GetRssFeed.Models.Item item)
        {
            return "<p>" +
                "<h3>" + item.Title + "</h3><br>" +
                item.Description + "<br>" +
                "<a href=\"" + item.Link + "\">Читать далее...</a>" +
                "</p>";
        }

        public IActionResult RssFeed()
        {
            string rss = "https://lenta.ru/rss/top7";

            var channel = GetRssFeed.GetRssFeed.Get(rss, "", "").Channels[0];

            string[] data = new string[10];

            for (int i = 0; (i < channel.Items.Count) && (i < 10); i++)
                data[i] = CreateItem(channel.Items[i]);

            ViewBag.data = data;

            return View();
        }

        public IActionResult Index()
        {
            ViewBag.News = NewsList;
            return View();
        }

        public IActionResult About()
        {
            // Placeholder
            return View();
        }

        public IActionResult Contact()
        {
            // Placeholder
            return View();
        }

        public IActionResult News(int number)
        {
            ViewBag.NewsData = NewsList[number];
            return View();
        }

    public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
