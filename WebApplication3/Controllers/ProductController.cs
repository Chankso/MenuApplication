using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3;
namespace WebApplication3.Controllers
{
    public class ProductController : ApiController
    { //Needs DB integration, this variable is useless and should be deleted
        private List<Product> _products;


        public ProductController()
        {
            _products = new List<Product> { new Product { ProductId = 1,CompanyId=2,Name="Nuka-Cola",Price=1.40m },
            new Product { ProductId = 2,CompanyId=1,Name="Mexican HotDog",Price=1.30m },
            new Product { ProductId = 3,CompanyId=2,Name="Small Shawarma",Price=6.00m },
            new Product { ProductId = 4,CompanyId=2,Name="Big Shawarma",Price=9.00m },};
        }




        [HttpGet]
        [Route("~/api/Product/")]
        public Response<List<Product>> GetProducts()
        {

            Response<List<Product>> res = new Response<List<Product>>();

            try
            {
                res.IsError = false;
                res.Data = _products;
                res.ErrorDetails = "Null";



            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
            }


            return res;

        }





        [HttpGet]
        [Route("~/api/Product/byname/{name}")]
        public Response<Product> GetProducts(string name)
        {
            Response<Product> res = new Response<Product>();

            try
            {
                res.IsError = false;
                res.Data = _products.First(o => o.Name == name); ;
                res.ErrorDetails = "Null";



            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
            }




            return res;
        }



        [HttpGet]
        [Route("~/api/Product/{id}")]
        public Response<Product> GetProducts(int id)
        {
            Response<Product> res = new Response<Product>();

            try
            {
                res.IsError = false;
                res.Data = _products.FirstOrDefault(o => o.ProductId == id);
                res.ErrorDetails = "Null";



            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
            }




            return res;
        }



        [HttpPost]
        public Response<string>/*??*/ AddProduct(Product prod)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";
                _products.Add(prod);




            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
                res.Data = "Everything is not fine";
            }




            return res;
        }





        [HttpPut]
        public Response<string> EditProduct(int id, Product cpn)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";

                var index = _products.FindLastIndex(o => o.ProductId == id);

                _products[index] = cpn;





            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
                res.Data = "Everything is not fine";
            }




            return res;
        }





        [HttpDelete]
        public Response<string> DeleteProduct(int id)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                var index = _products.FindLastIndex(o => o.ProductId == id);

                _products.RemoveAt(index);





            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
                res.Data = "Item Not Deleted";
            }




            return res;
        }
    }
}

