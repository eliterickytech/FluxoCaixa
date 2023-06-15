using Rickytech.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Domain.Entities
{
    public class Flow
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime OperationDate { get; set; }

        public decimal OperationValue { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public OperationType Operation { get; set; }


    }
}
