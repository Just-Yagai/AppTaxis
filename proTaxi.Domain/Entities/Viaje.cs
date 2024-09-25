using proTaxi.Domain.Base;

namespace proTaxi.Domain.Entities
{
    public class Viaje : BaseEntity
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int Calificacion { get; set; }
    }
}
