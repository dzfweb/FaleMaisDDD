using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMaisDDD.MVC.Models.ViewModels
{
    public class PrecoViewModel
    {
        [ScaffoldColumn(false)]
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Valor por Minuto")]
        [Required]
        public decimal ValorMinuto { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        [Display(Name = "DDD Origem")]
        [Required]
        public Guid IdOrigem { get; set; }
        [Display(Name = "DDD Destino")]
        [Required]
        public Guid IdDestino { get; set; }
        [Display(Name = "DDD Origem")]
        public virtual DDD Origem { get; set; }

        [Display(Name = "DDD Destino")]
        public virtual DDD Destino { get; set; }
    }
}