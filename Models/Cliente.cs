﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente : Pessoa
    {
        public Decimal Renda { get; set; }
        public string Documento { get; set; }
    }
}
