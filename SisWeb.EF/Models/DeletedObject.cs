using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class DeletedObject
    {
        public int DeletedObjectId { get; set; }
        public int PkValue { get; set; }
        public string ObjectType { get; set; }
        public bool Commited { get; set; }
        public DateTime? Reftime { get; set; }
    }
}
