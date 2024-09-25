using proTaxi.Domain.Base;

namespace proTaxi.Domain.Entities
{
    public class DetalleViaje : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
