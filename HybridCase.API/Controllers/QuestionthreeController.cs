using HybridCase.API.DTO;
using HybridCase.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HybridCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionthreeController : ControllerBase
    {
        private readonly MyContext _mycontext;

        public QuestionthreeController(MyContext myContext)
        {
            _mycontext = myContext;
        }

        // 1- Api json result (Kullanıcı ürün ve sipariş ilişkisi. Bir kullanıcının hazırlanan siparişlerini gösteren json)


        [HttpGet]
        public List<UserOrdersPrepar> Get()
        
        {
            var c = new List<UserOrdersPrepar>();

            var result = _mycontext.Orders.Include(x => x.Products).Include(x => x.Users).Where(x => x.IsStatus == 2).ToList();


            foreach (var res in result)
            {
                c.Add(new UserOrdersPrepar()
                {
                    FullName = res.Users[0].Name + " " + res.Users[0].Surname,
                    ProductName = res.Products[0].ProductName,
                    ProductPrice = res.Products[0].Price,
                    OrderCount = result.Count,
                });
            }

            return c;
        }

    }
}
