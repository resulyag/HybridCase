using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridCase.Entities
{
    public class Order:IBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public byte IsStatus { get; set; }
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
    }
    //public enum IsStatus:byte
    //{
    //    TeslimEdildi, İade, Hazırlanıyor
    //}
}
