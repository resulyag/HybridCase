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
    public class QuestiontwoController : ControllerBase
    {
        private readonly MyContext _myContext;

        public QuestiontwoController(MyContext myContext)
        {
            _myContext = myContext;
        }

        // 3- Api json result (Kullanıcıların Teslim edilen siparişlerinin toplam tutarını gösteren json)

        [HttpGet]
        public List<UserDeliveredOrders> Get()
        {
            var c = new List<UserDeliveredOrders>();
            var result = _myContext.Orders.Include(x=>x.Users).Include(x=>x.Products).Where(x=>x.IsStatus==1).ToList();

            foreach (var res in result)
            {
                c.Add(new UserDeliveredOrders()
                {
                    Name = res.Users[0].Name,
                    TotalPrice = res.Products[0].Price
                });
            }


            return c;
        }
    }
}
