using project1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        DataLayer dl = new DataLayer();
        [HttpGet]
        public ActionResult create(int EMPId = 0)
        {
            emplyeename empmodel = new emplyeename();
            try
            {
                DataTable dt = new DataTable();
                dt = dl.GetAllEmployee(EMPId);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            empmodel.name_of_employee = dr["FirstName"].ToString();
                            empmodel.login_id = Convert.ToInt32(dr["Id"].ToString());
                            empmodel.password = dr["password"].ToString();
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return View(empmodel);
        }

        [HttpPost]
        public ActionResult create(FormCollection FC)

        {
            int statusCode = 0;
            emplyeename model = new emplyeename();

            model.name_of_employee = FC["name_of_employee"].ToString();
            model.login_id = Convert.ToInt32(FC["login_id"].ToString());
            model.password = FC["password"].ToString();


            return RedirectToAction("GetAllEmployee");


        }
        //[HttpPost]
        //public ActionResult GetAllEmployee(FormCollection FC)

        //int statusCode = 0;

    }





}




