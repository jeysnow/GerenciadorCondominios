﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciadorCondominiosBLL.Models
{
    public class Aluguel
    {
        public int AluguelId { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Range(0,int.MaxValue,ErrorMessage ="Valor inválido")]
        public decimal Valor { get; set; }
        [Display(Name ="Mês")]
        public int MesId { get; set; }
        public Mes Mes { get; set; }


        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Range(2010, 2050, ErrorMessage = "Valor inválido")]
        public int Ano { get; set; }

        public virtual ICollection<Pagamento> Pagamentos { get; set; }

    }
}
