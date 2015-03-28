using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Entities
{
    public class Administrador
    {
        protected Administrador() {  }

        public Administrador(string _Login, string _Senha, bool _Ativo)
        {
            this.Id = Guid.NewGuid();
            this.Login = _Login;
            this.Senha = _Senha;
            this.Ativo = _Ativo;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
       
    }
}
