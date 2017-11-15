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
        private List<Sale> _Sales;


        public SaleController()
        {

            //Strings should only take numbers

            _Sales = new List<Sale> { new Sale {SaleId=1, ProductId=1, CompanyId=1, IsOnSale=true, Percentile=1.00f, StartDate=new DateTime(2017,11,2), EndDate= new DateTime(2017,11,4) },
            new Sale {SaleId=2, ProductId=1, CompanyId=1,IsOnSale=true, Percentile=1.00f, StartDate=new DateTime(2017,11,2), EndDate= new DateTime(2017,11,4) },
            new Sale {SaleId=3, ProductId=1,CompanyId=1, IsOnSale=true, Percentile=1.00f, StartDate=new DateTime(2017,11,2), EndDate= new DateTime(2017,11,4) },
            new Sale {SaleId=4, ProductId=1, CompanyId=1,IsOnSale=true, Percentile=1.00f, StartDate=new DateTime(2017,11,2), EndDate= new DateTime(2017,11,4) },
            new Sale {SaleId=5, ProductId=1,CompanyId=1, IsOnSale=true, Percentile=1.00f, StartDate=new DateTime(2017,11,2), EndDate= new DateTime(2017,11,4) },};
        }




        [HttpGet]
        [Route("~/api/Sale/")]
        public Response<List<Sale>> GetSales()
        {

            Response<List<Sale>> res = new Response<List<Sale>>();

            try
            {
                res.IsError = false;
                res.Data = _Sales;
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
        [Route("~/api/Sale/current/{id}")]
        public Response<bool> GetIsOnSale(int id)
        {

            Response<bool> res = new Response<bool>();

            try
            {
                res.IsError = false;

                res.Data = _Sales.First(o=>o.SaleId==id).IsOnSale;
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
                res.IsError = false;
                res.Data = _Sales.Where(o => o.ProductId == id).ToList();
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
                res.IsError = false;
                res.Data = _Sales.Where(o => o.CompanyId == id).ToList();
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
        public Response<Sale> GetSales(int id, int productId)
        {
            Response<Sale> res = new Response<Sale>();

            try
            {
                res.IsError = false;
                res.Data = _Sales.First(o => o.SaleId == id && o.ProductId == productId);
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
        public Response<string> AddSale(Sale Sale)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";
                _Sales.Add(Sale);




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
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";

                var index = _Sales.FindLastIndex(o => o.SaleId == id);

                _Sales[index] = Sale;





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
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                var index = _Sales.FindLastIndex(o => o.SaleId == id);

                _Sales.RemoveAt(index);





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
