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


        public DealController()
        {

        }



        /*
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
            */



        [HttpGet]
        [Route("~/api/Deal/")]
        public Response<List<Deal>> GetDeals()
        {
            Response<List<Deal>> res = new Response<List<Deal>>();

            try
            {

                List<Deal> _Deals;
                using (var dbContext = new MenuAppDBEntities3())
                {

                    _Deals = dbContext.Deals.ToList();
                }

                res.IsError = false;
                res.Data = _Deals;
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
                List<Deal> _Deals;
                using (var dbContext = new MenuAppDBEntities3())
                {

                    _Deals = dbContext.Deals.Where(o => o.CompanyId == id).ToList();

                }
                res.IsError = false;
                res.Data = _Deals;
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

                Deal _Deal;
                using (var dbContext = new MenuAppDBEntities3())
                {

                    _Deal = dbContext.Deals.Where(o => o.DealId == id).First();

                }

                res.IsError = false;
                res.Data = _Deal;
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
        [Route("~/api/Deal/Add/{Dl}")]
        public Response<string> AddDeal(Deal Dl)
        {
            Response<string> res = new Response<string>();

            try
            {

                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Deals.Add(Dl);

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
        [Route("~/api/Deal/Add/{id}?{Dl}")]
        public Response<string> EditDeal(int id, Deal Dl)
        {
            Response<string> res = new Response<string>();

            try
            {

                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Deals.First(o => o.DealId == id).Equals(Dl);

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
        [Route("~/api/Deal/Delete/{id}")]
        public Response<string> DeleteDeal(int id)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                using (var dbContext = new MenuAppDBEntities3())
                {
                    var DeletedDeal = dbContext.Deals.Where(o => o.DealId == id).First();
                    dbContext.Deals.Remove(DeletedDeal);

                    dbContext.SaveChanges();
                }



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

