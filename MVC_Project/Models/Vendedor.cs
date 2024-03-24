using Microsoft.Extensions.Primitives;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Project.Models
{
    public class Vendedor
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc {  get; set; }
        public double SalarioBase { get; set; }
        public Departaments Departaments { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();
        public Vendedor()
        {
            
        }

        public Vendedor(int id, string name, string email, DateTime dataNasc, double salarioBase, Departaments departaments)
        {
            Id = id;
            Name = name;
            Email = email;
            DataNasc = dataNasc;
            SalarioBase = salarioBase;
            Departaments = departaments;
        }
        public void AddVendas(RegistroVendas rv)
        {
            Vendas.Add(rv);
        }
        public void RemoveVendas(RegistroVendas rv)
        {
            Vendas.Remove(rv);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.Data >= inicial && rv.Data <= final).Sum(rv => rv.Quantia);
        }

    }
}
