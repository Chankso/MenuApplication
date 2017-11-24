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
    { 


        public ProductController()
        {
        }




        [HttpGet]
        [Route("~/api/Product/")]
        public Response<List<Product>> GetProducts()
        {

            Response<List<Product>> res = new Response<List<Product>>();

            try
            {


                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data=dbContext.Products.ToList();
                   
                }
                res.IsError = false;
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
                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data = dbContext.Products.First(o => o.Name == name);

                }

                res.IsError = false;
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
                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data = dbContext.Products.FirstOrDefault(o => o.ProductId == id);

                }

                res.IsError = false;
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
                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Products.Add(prod);

                    dbContext.SaveChanges();
                }

                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";




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
                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Products.First(o=> o.ProductId==id).Equals(cpn);

                    dbContext.SaveChanges();
                }

                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";




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
                using (var dbContext = new MenuAppDBEntities3())
                {

                    var DeletedProduct = dbContext.Products.Where(o => o.ProductId == id).First();
                    dbContext.Products.Remove(DeletedProduct);

                    dbContext.SaveChanges();
                }

                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";




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

