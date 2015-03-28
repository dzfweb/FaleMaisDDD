using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMaisDDD.MVC.Models.ViewModels
{
    public class PlanoViewModel
    {
        [ScaffoldColumn(false)]
        [Key]        
        [Display(Name="Id")]
        public Guid Id { get; set; }
        [Display(Name="Descrição")]
        [Required]
        public string Descricao { get; set; }
        [Display(Name="Minutos")]
        [Required]
        public decimal Minutos { get; set; }
        [Display(Name="Preço")]
        [Required]
        public decimal Preco { get; set; }
        [Display(Name="Tarifa Excedente")]
        [Required]
        public decimal TarifaExcedente { get; set; }
        [Display(Name="Ativo")]
        public bool Ativo { get; set; }
    }
}