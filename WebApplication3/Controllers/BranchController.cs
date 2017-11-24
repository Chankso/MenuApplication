using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3;
namespace WebApplication3.Controllers
{
    public class BranchController : ApiController
    {


        public BranchController()
        {
        }




        [HttpGet]
        [Route("~/api/Branch/")]
        public Response<List<Branch>> GetBranches()
        {
            Response<List<Branch>> res = new Response<List<Branch>>();
            
            try
            {

                List<Branch> _branches;
                using (var dbContext = new MenuAppDBEntities3())
                {

                    _branches = dbContext.Branches.ToList();
                }

                res.IsError = false;
                res.Data = _branches;
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
        [Route("~/api/Branch/bycompany/{id}")]
        public Response<List<Branch>> GetBranches(int id)
        {
            Response<List<Branch>> res = new Response<List<Branch>>();

            try
            {
                List<Branch> _branches;
                using (var dbContext = new MenuAppDBEntities3())
                {

                    _branches = dbContext.Branches.Where(o => o.CompanyId == id).ToList();
                    
                }
                    res.IsError = false;
                res.Data = _branches;
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
        [Route("~/api/Branch/{id}")]
        public Response<Branch> GetBranches(int id, int companyId)
        {
            Response<Branch> res = new Response<Branch>();

            try
            {

                Branch _branch;
                using (var dbContext = new MenuAppDBEntities3())
                {

                    _branch = dbContext.Branches.Where(o => o.BranchId == id).First();

                }

                res.IsError = false;
                res.Data = _branch;
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
        [Route("~/api/Branch/Add/{brnch}")]
        public Response<string> AddBranch(Branch brnch)
        {
            Response<string> res = new Response<string>();

            try
            {

                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Branches.Add(brnch);

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
        [Route("~/api/Branch/Add/{id}?{brnch}")]
        public Response<string> EditBranch(int id, Branch brnch)
        {
            Response<string> res = new Response<string>();

            try
            {

                using (var dbContext = new MenuAppDBEntities3())
                {

                    dbContext.Branches.First(o=>o.BranchId==id).Equals(brnch);

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
        [Route("~/api/Branch/Delete/{id}")]
        public Response<string> DeleteBranch(int id)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                using (var dbContext = new MenuAppDBEntities3())
                {
                    var DeletedBranch = dbContext.Branches.Where(o => o.BranchId == id).First();
                    dbContext.Branches.Remove(DeletedBranch);

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
