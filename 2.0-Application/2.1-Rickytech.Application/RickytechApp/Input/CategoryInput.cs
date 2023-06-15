using Rickytech.Domain.Entities;
using Rickytech.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rickytech.Application.RickytechApp.Input
{
    public class CategoryInput
    {
        [Required]
        [Display(Name = "Categoria")]
        public string Name { get; set; }

        [Display(Name = "Operação")]
        public OperationType Operation { get; set; }
    }
}
