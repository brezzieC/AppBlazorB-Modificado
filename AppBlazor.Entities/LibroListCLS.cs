﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class LibroListCLS
    {
        public int idLibro { get; set; }
        public string titulo { get; set; } = null!;
        public string resumen { get; set; } = string.Empty;
        public string nombreTipoLibro { get; set; }
        public byte[]? imagen { get; set; }
        public byte[]? archivo { get; set; }
        public string nombrearchivo { get; set; } = string.Empty;

    }
}
