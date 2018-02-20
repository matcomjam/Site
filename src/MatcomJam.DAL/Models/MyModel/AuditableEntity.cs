using System;
using System.Collections.Generic;
using System.Text;
using MatcomJamDAL.Models.MyModel.interfaces;

namespace MatcomJamDAL.Models.MyModel
{
    class AuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        //TODO: poner a heredar de esta clase a todas las entidades
    }
}
