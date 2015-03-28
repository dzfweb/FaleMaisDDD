using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMaisDDD.MVC.Models.ViewModels
{
    public class AdministradorViewModel
    {
        [ScaffoldColumn(false)]
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Login")]
        [MaxLength(50)]
        [Required]
        public string Login { get; set; }
        [Display(Name = "Senha")]
        [MaxLength(20)]
        public string Senha { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}