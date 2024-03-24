using System.Collections.Generic;
using System;
using System.Linq;
namespace MVC_Project.Models

{
    public class Departaments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departaments()
        {
        }

        public Departaments(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicial, final));
        }


    }
}

