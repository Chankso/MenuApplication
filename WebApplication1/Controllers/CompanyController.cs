using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{

    public class CompanyController : ApiController
    {
        private List<Company> _companies;


   

        [HttpGet]
        [Route("~/companies")]
        public Response<List<Company>> GetCompanies()
        {
            Response<List<Company>> res = new Response<List<Company>>();

            try
            {
                res.Data = _companies;
                res.ErrorDetails = "None";
                res.IsError = false;



            }
            catch (Exception ex)
            {

                res.Data = null;
                res.ErrorDetails = ex.Message;
                res.IsError = true;
            }



            return res;
        }

        [HttpGet]
        [Route("~/company/companybyid/{id}")]
        public Response<Company> GetCompanies(int Id)
        {
            Response<Company> res = new Response<Company>();

            try
            {
                res.Data = _companies.Single(o => o.CompanyId == Id);


            }
            catch (Exception ex)
            {
                res.Data = null;
                res.ErrorDetails = ex.Message;
                res.IsError = true;
            }



            return res;
        }

        [HttpGet]
        [Route("~/company/companybyname/{name}")]
        public Response<Company> GetCompanies(string name)
        {
            Response<Company> res = new Response<Company>();

            try
            {
                res.Data = _companies.Single(o => o.Name == name);


            }
            catch (Exception ex)
            {
                res.Data = null;
                res.ErrorDetails = ex.Message;
                res.IsError = true;
            }



            return res;
        }

        [HttpPost]
        [Route("~/company/addcompany/{name}")]
        public Response<string> AddCompany(Company cpn)
        {
            Response<string> res = new Response<string>();

            try
            {
                _companies.Add(cpn);
                res.Data = "Everything is fine";
                res.ErrorDetails = "Everything is fine";
                res.IsError = false;

            }
            catch (Exception ex)
            {
                res.Data = null;
                res.ErrorDetails = ex.Message;
                res.IsError = true;
            }



            return res;
        }

        [HttpPut]
        [Route("~/company/edit/{id}")]
        public Response<string> EditCompanies(Company cpn)
        {
            Response<string> res = new Response<string>();

            try
            {
                var tmp=_companies.Single(o => o.CompanyId == cpn.CompanyId)
                res.Data = "Everything is fine";
                res.ErrorDetails = "Everything is fine";
                res.IsError = false;

            }


            catch (Exception ex)
            {
                res.Data = null;
                res.ErrorDetails = ex.Message;
                res.IsError = true;
            }
        }
    }
}
