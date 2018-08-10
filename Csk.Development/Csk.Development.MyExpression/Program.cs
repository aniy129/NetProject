using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Csk.Development.MyExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<Person, bool>> exp;
            exp = c => c.Age > 10;
            var dele = exp.Compile();
            var rs = dele(new Person() { Age = 100 });
            var bll = new ExpressionToSql();
            string sql = bll.GetSql<Person>(c => c.Age>100 &&c.Name.DB_Like("%cc")||c.Name=="yes");
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }

    }
}
