using HybridCase.API.DTO;
using HybridCase.Data;
using HybridCase.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HybridCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly MyContext _myContext;

        public QuestionController(MyContext myContext)
        {
            _myContext = myContext;
        }

        // 2- Api json result (Bir ürünün kaç tane İade siparişlerini gösteren json)

        [HttpGet]
        public List<ProductReturn> Get()
        {
            var c = new List<ProductReturn>();
            var result = _myContext.Orders.Include(x => x.Products).Where(x => x.IsStatus == 3).ToList();
            var a = result.GroupBy(x=>x.ProductId).ToList();
            //var result2 = _myContext.Orders.Include(x => x.Products).GroupBy(x=>x.ProductId).ToList();

            foreach (var res in result)
            {
                c.Add(new ProductReturn()
                {
                    ProductName = res.Products[0].ProductName,
                    OrderCount = res.Products.Count()
                });
            }

            return c;
        }


    }
}
