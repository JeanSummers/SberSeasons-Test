using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using sberseasons.Models;

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
