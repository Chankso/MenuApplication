using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3;

namespace WebApplication3.Controllers
{
    public class SaleController : ApiController
    {

        //Needs DB integration, this variable is useless and should be deleted


        public SaleController()
        {

            //Strings should only take numbers

        }




        [HttpGet]
        [Route("~/api/Sale/")]
        public Response<List<Sale>> GetSales()
        {

            Response<List<Sale>> res = new Response<List<Sale>>();

            try
            {
                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data = dbContext.Sales.ToList();
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
        [Route("~/api/Sale/onSale/{id}")]
        public Response<bool> GetIsOnSale(int id)
        {

            Response<bool> res = new Response<bool>();

            try
            {
                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data = dbContext.Sales.First(o => o.SaleId == id).IsOnSale;
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
        [Route("~/api/Sale/byproduct/{id}")]
        public Response<List<Sale>> GetSales(int id)
        {
            Response<List<Sale>> res = new Response<List<Sale>>();

            try
            {
                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data = dbContext.Sales.Where(o => o.ProductID == id).ToList();
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
        [Route("~/api/Sale/bycompany/{id}")]
        public Response<List<Sale>> GetCompanySales(int id)
        {
            Response<List<Sale>> res = new Response<List<Sale>>();

            try
            {
                using (var dbContext = new MenuAppDBEntities3())
                {

                    res.Data = dbContext.Sales.Where(o => o.CompanyId == id).ToList();
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
        [Route("~/api/Sale/{id}")]
    



        [HttpPost]
        public Response<string> AddSale(Sale Sale)
        {
            Response<string> res = new Response<string>();

            try
            {
                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Sales.Add(Sale);
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
        public Response<string> EditSale(int id, Sale Sale)
        {
            Response<string> res = new Response<string>();

            try
            {
                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Sales.Where(o=>o.SaleId==id).Equals(Sale);
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
        public Response<string> DeleteSale(int id)
        {
            Response<string> res = new Response<string>();

            try
            {

                using (var dbContext = new MenuAppDBEntities3())
                {
                    var DeletedSale = dbContext.Sales.Where(o => o.SaleId == id).First();
                    dbContext.Sales.Remove(DeletedSale);

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
