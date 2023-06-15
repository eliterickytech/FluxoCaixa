using Rickytech.Domain.Entities;
using Rickytech.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rickytech.Application.RickytechApp.Input
{
    public class FlowInput
    {
        [Required]
        [Display(Name = "Data Operação")]
        public DateTime OperationDate { get; set; }

        [Required]
        [Display(Name = "Tipo Operação")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Histórico")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public decimal OperationValue { get; set; }

        public int Id { get; set; }
    }
}
