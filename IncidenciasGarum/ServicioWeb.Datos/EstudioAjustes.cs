//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioWeb.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstudioAjustes
    {
        public int id_ajuste { get; set; }
        public string surtidor { get; set; }
        public string Manguera { get; set; }
        public Nullable<decimal> LitrosLec { get; set; }
        public Nullable<decimal> Litrosvta { get; set; }
        public Nullable<decimal> Diferencia { get; set; }
        public Nullable<System.DateTime> Fecha_estudio { get; set; }
        public Nullable<System.DateTime> Fecha_Ajustes { get; set; }
        public string Nombre_Estacion { get; set; }
        public Nullable<decimal> Contador_inicial { get; set; }
        public Nullable<decimal> Contador_Final { get; set; }
        public string Tipo_contador_inicial { get; set; }
        public string Tipo_contador_Final { get; set; }
        public Nullable<bool> revisado { get; set; }
    }
}
