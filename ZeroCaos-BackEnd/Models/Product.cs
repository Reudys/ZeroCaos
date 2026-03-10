using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ZeroCaos_BackEnd.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public TypeStock TypeStock { get; set; }
        //public BitArray Foto { get; set; }
        public string Code { get; set; }
        public DateTime? ExpirationDate { get; set; }
        //prop int BarraCode { get; set; }
    }
}
