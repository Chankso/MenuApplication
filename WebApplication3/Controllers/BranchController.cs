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
        //Needs DB integration, this variable is useless and should be deleted
        private List<Branch> _branches;


        public BranchController()
        {

            //Strings should only take numbers

            _branches = new List<Branch> { new Branch { BranchId = 1, CompanyId = 1, Latitude=3.14f, Longitude=4.13f, OpenClose="09:00/22:00", PhoneNumber="55724esProblemaa", PhysAddress="addressHere" },
            new Branch { BranchId = 2, CompanyId = 3, Latitude=3.14f, Longitude=4.13f, OpenClose="09:00/22:00", PhoneNumber="55724esProblemaa", PhysAddress="addressHere" },
            new Branch { BranchId = 3, CompanyId = 2, Latitude=3.14f, Longitude=4.13f, OpenClose="09:00/22:00", PhoneNumber="55724esProblemaa", PhysAddress="addressHere" },
            new Branch { BranchId = 4, CompanyId = 5, Latitude=3.14f, Longitude=4.13f, OpenClose="09:00/22:00", PhoneNumber="55724esProblemaa", PhysAddress="addressHere" },
            new Branch { BranchId = 5, CompanyId = 4, Latitude=3.14f, Longitude=4.13f, OpenClose="09:00/22:00", PhoneNumber="55724esProblemaa", PhysAddress="addressHere" },};
        }




        [HttpGet]
        [Route("~/api/Branch/")]
        public Response<List<Branch>> GetBranches()
        {

            Response<List<Branch>> res = new Response<List<Branch>>();

            try
            {
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
                res.IsError = false;
                res.Data = _branches.Where(o => o.CompanyId == id).ToList();
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
                res.IsError = false;
                res.Data = _branches.First(o => o.BranchId == id&&o.CompanyId==companyId);
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
        public Response<string> AddBranch(Branch brnch)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";
                _branches.Add(brnch);




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
        public Response<string> EditBranch(int id, Branch brnch)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";

                var index = _branches.FindLastIndex(o => o.BranchId == id);

                _branches[index] = brnch;





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
        public Response<string> DeleteBranch(int id)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                var index = _branches.FindLastIndex(o => o.BranchId == id);

                _branches.RemoveAt(index);





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
