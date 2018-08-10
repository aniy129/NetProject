using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.Elasticsearch
{
    class Program
    {
        static OperateBook ob = new OperateBook();
        static void Main(string[] args)
        {
           // ob.IsTypeExists();
            ob.Createindex();
            //Add();
           // Search();
        }

        static void Add()
        {
            Book bk = new Book()
            {
                Id = 1,
                Author = "钱钟书",
                Isbn = "2017-12-23-34-67",
                Price = 13.56,
                PublishTime = DateTime.Now.AddYears(-20),
                Title = "围城",
                TitleSpell = "围城",
                Content = @"一直以来，看完一本书，尤其是一本大家都比较认可的书，我都曾试图写写读后感之类的，可是每次提起笔，却又不知道要写什么，总觉得不能表达读完的真实感受。在这里以后读完一本书，我就摘录一些作者原著中的话吧，倒不是说这些话是至理名言，反正就是觉得这些话有意义、有意思、有深度或者诙谐幽默。不便与人分享，自己的那点见解也难登大雅之堂，权当摘录一些留作以后翻阅的回忆。
1.辛楣道：“像咱们这样旅行，最试验得出一个人的品性。旅行是最劳烦，最麻烦，叫人本相毕现的时候。经过长期哭旅行而彼此不厌的人，才可以结交朋友。结婚以后蜜月出行是次序颠倒的，应该先同旅行一个月，一个月舟车仆仆后，双方没有彼此看破，彼此厌倦，还没有吵嘴翻脸，还要维持原来的婚约，这种夫妇保证不会离婚。”
2.有时候一个人，并不想说谎话，说话以后，环境转变，他也不得不改变原来的意向。办行政的人尤其难守信用，你只要看每天报上各国政要发言人的谈话就知道。譬如我跟某人同意一件事，甚而至于跟他定个契约，不管这契约上写的是十年二十年，我订阅的动机总根据我目前的希望，认识以及需要。不过，‘目前’最靠不住的，假使这‘目前’已经落在背后了，条约上写明‘直到世界末日’也没有用，我们随时可以反悔。第一次欧战，那位德国首相叫什么名字？他说‘条约是废纸’，你总是知道的。我有一个印象，我们在社会上一切的说话全像戏院子的入场卷，以边印着‘过期作废’，可是那一边并不注明什么日期，随我们的便可以提早或延迟。
3.“这是不是所谓的‘缘分’，两个陌生人偶然见面，慢慢地要好？”鸿渐发议论道：”譬如咱们这次同船的许多人，没有一个认识的。不知道他们的来头，为什么不先不后也乘这条船，以为这次和他们聚在一起是出于偶然。假使咱们熟悉了他们的情形和目的，就知道他们乘这只船并非偶然，和咱们一样有非乘不可的理由。“"
            };
            ob.AddBook(bk);
        }

        static void Search()
        {
            var ls = ob.Search(q => q.Query(m => m.Match(
                    mc => mc.Field(f => f.Content)
                    .Query("假使咱们熟悉了他们的情形和目的")
                    .Analyzer("ik_max_word")
                    )
                    ).Highlight(c => c.Fields(xx => xx.Field(xxx => xxx.Content))
                    .PreTags("<span style=\"color:red\">")
                    .PostTags("</span>")),
                    out ISearchResponse<Book> doc
                    );

        }
    }
}
