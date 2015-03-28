using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMaisDDD.MVC.Models.ViewModels
{
    public class DDDViewModel
    {
        [ScaffoldColumn(false)]
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Código")]
        [Required]
        public int Codigo { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public virtual ICollection<Preco> Origem { get; set; }
        public virtual ICollection<Preco> Destino { get; set; }
    }
}