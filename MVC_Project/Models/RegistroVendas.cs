using MVC_Project.Models.Enums;

namespace MVC_Project.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public RegistroVendas()
        {

        }

        public RegistroVendas(int id, DateTime data, double quantia, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
