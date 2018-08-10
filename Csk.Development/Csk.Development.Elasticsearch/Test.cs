using System.Diagnostics;

namespace Csk.Development.Elasticsearch
{
    public class Test
    {
        private string _myName;
        private int _age;

        public int Age { get => _age; set => _age = value; }

        public string MyName
        {
            get { return _myName; }
            set { _myName = value; }
        }

        public Test(string myName, int age)
        {
            _myName = myName;
            Age = age;
        }
    }
}