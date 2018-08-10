using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.MongDb
{
    public class MongdbBaseEntity
    {
        public ObjectId Id { set; get; }
    }
}
