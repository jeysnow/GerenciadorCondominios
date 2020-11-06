using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage ="O campo {0} é Obrigatório")]
        [StringLength(40,ErrorMessage ="Use menos Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é Obrigatório")] 
        public string Foto { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(40, ErrorMessage = "Use menos Caracteres")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é Obrigatório")] 
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [DataType(DataType.Password)] 
        [Display(Name ="Confirme sua senha")]
        [Compare("Senha",ErrorMessage ="As senhas não conferem")]
        public string SenhaConfirmada { get; set; }
    }
}
