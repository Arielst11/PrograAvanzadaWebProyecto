﻿namespace FrontEnd.ApiModels
{
    public class Asistencias
    {
        public int ConsecutivoAsistencia { get; set; }

        public DateOnly? Fecha { get; set; }

        public bool? Asistencia { get; set; }

        public int? PorcentajeAsistencia { get; set; }

        public int? FkConsecutivoUsuario { get; set; }

        //public virtual Usuario? FkConsecutivoUsuarioNavigation { get; set; }


    }
}
