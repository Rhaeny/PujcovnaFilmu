﻿namespace NullDTO
{
    public class OsZamFilmNull
    {
        public int? IdFilm { get; set; }
        public int? IdZam { get; set; }
        public int? IdOsoba { get; set; }

        public OsZamFilmNull()
        {
            IdFilm = null;
            IdZam = null;
            IdOsoba = null;
        }
    }
}
