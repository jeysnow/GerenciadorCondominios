﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciadorCondominiosBLL.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(50,ErrorMessage ="Use menos caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public DateTime Data { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
