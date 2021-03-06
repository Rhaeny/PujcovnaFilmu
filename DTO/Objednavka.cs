﻿using System;

namespace DTO
{
    public class Objednavka
    {
        public int IdObj { get; set; }
        public DateTime DatumObj { get; set; }
        public int DobaPujceni { get; set; }
        public bool Vydano { get; set; }
        public DateTime? DatumVydani { get; set; }
        public bool Vraceno { get; set; }
        public DateTime? DatumVraceni { get; set; }
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public int IdVydejce { get; set; }
    }
}
