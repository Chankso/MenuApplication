using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3;
namespace WebApplication1.Controllers
{
    public class CompanyController : ApiController
    {   //Needs DB integration, this variable is useless and should be deleted
        private List<Company> _companies;


        public CompanyController()
        {
            _companies = new List<Company>{ new Company {Name="asd1",CompanyId=1,LogoURL="asf",Rating=5 },
            new Company {Name="asd2",CompanyId=2,LogoURL="asf",Rating=5 },
            new Company {Name="asd3",CompanyId=3,LogoURL="asf",Rating=5 },
            new Company {Name="asd4",CompanyId=4,LogoURL="asf",Rating=5 },
            new Company {Name="asd5",CompanyId=5,LogoURL="asf",Rating=5 } };
        }




        [HttpGet]
        [Route("~/api/company/")]
        public Response<List<Company>> GetCompanies() {

            Response<List<Company>> res = new Response<List<Company>>();

            try
            {
                res.IsError = false;
                res.Data = _companies;
                res.ErrorDetails = "Null";



            }
            catch(Exception ex)
            {
                res.IsError = true;
                res.ErrorDetails = ex.Message;
            }


            return res;
           
        }





        [HttpGet]
        [Route("~/api/company/byname/{name}")]
        public Response<Company> GetCompanies(string name)
        {
            Response<Company> res = new Response<Company>();

            try
            {
                res.IsError = false;
                res.Data = _companies.First(o => o.Name == name); ;
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
        [Route("~/api/company/{id}")]
        public Response<Company> GetCompanies(int id)
        {
            Response<Company> res = new Response<Company>();

            try
            {
                res.IsError = false;
                res.Data = _companies.FirstOrDefault(o => o.CompanyId==id);
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
        public Response<string>/*??*/ AddCompany(Company compn)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";
                _companies.Add(compn);




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
        public Response<string> EditCompany(int id, Company cpn)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Everything is fine";
                res.ErrorDetails = "Null";

                var index=_companies.FindLastIndex(o => o.CompanyId == id);

                _companies[index] = cpn;





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
        public Response<string> DeleteCompany(int id)
        {
            Response<string> res = new Response<string>();

            try
            {
                res.IsError = false;
                res.Data = "Item Deleted";
                res.ErrorDetails = "Null";

                var index = _companies.FindLastIndex(o => o.CompanyId == id);

                _companies.RemoveAt(index);





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
