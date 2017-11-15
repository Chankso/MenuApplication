using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3;
namespace WebApplication3.Controllers
{
    public class DealController : ApiController
    {
        //Needs DB integration, this variable is useless and should be deleted
        private List<Deal> _deals;


        public DealController()
        {

            //Strings should only take numbers

            _deals = new List<Deal> { new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) },
            new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) },
            new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) },
            new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) },
            new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) },
            new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) },
            new Deal { DealId = 1, Details = "details", CompanyId = 1, StartDate = new DateTime(2017, 2, 13), EndDate = new DateTime(2017, 2, 17) }};
        }




        [HttpGet]
        [Route("~/api/Deal/")]
        public Response<List<Deal>> GetDeals()
        {

            Response<List<Deal>> res = new Response<List<Deal>>();

            try
            {
                res.IsError = false;
                res.Data = _deals;
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
        [Route("~/api/Deal/bycompany/{id}")]
        public Response<List<Deal>> GetDeals(int id)
        {
            Response<List<Deal>> res = new Response<List<Deal>>();

            try
            {
                res.IsError = false;
                res.Data = _deals.Where(o => o.CompanyId == id).ToList();
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
        [Route("~/api/Deal/{id}")]
        public Response<Deal> GetDeals(int id, int companyId)
        {
            Response<Deal> res = new Response<Deal>();

            try
            {
                res.IsError = false;
                res.Data = _deals.First(o => o.DealId == id && o.CompanyId == companyId);
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
        public Response<string> AddDeal(Deal deal)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";
                _deals.Add(deal);




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
        public Response<string> EditDeal(int id, Deal deal)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";

                var index = _deals.FindLastIndex(o => o.DealId == id);

                _deals[index] = deal;





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
        public Response<string> DeleteDeal(int id)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                var index = _deals.FindLastIndex(o => o.DealId == id);

                _deals.RemoveAt(index);





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

