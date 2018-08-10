using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.Elasticsearch
{
    [ElasticsearchType(IdProperty = "Id", Name = "Book")]
    public class Book
    {
        public long Id { get; set; }
        [Nest.Text(Name = "Title", Index = true, Analyzer = "ik_max_word")]
        public string Title { get; set; }
        [Nest.Text(Name = "Content", Index = true, Analyzer = "ik_max_word")]
        public string Content { get; set; }

        [Keyword]
        public string Isbn { get; set; }

        public DateTime PublishTime { get; set; }
        public double Price { get; set; }
        [Keyword]
        public string Author { get; set; }
        [Text(Analyzer ="pinyin")]
        public string TitleSpell { get; set; }

    }
}
