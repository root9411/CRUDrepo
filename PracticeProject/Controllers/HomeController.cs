using PracticeProject.Data.Common;
using PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {


            var process = new ProcessServices();
            var dicparam = new Dictionary<string, object>();
            var result = await process.List_of_ResponseData<EmployeeModel>(dicparam, "sp_getEmployee");
            var EmployeeList = result.data;


            return View(EmployeeList);
        }


        [HttpPost]
        public async Task<JsonResult> DeleteEmployee(int id)
        {
            var process = new ProcessServices();
            var dicparam = new Dictionary<string, object>();
            dicparam.Add("id", id);

            var result = await process.Get_ResponseData<EmployeeModel>(dicparam, "sp_deleteEmployee");

            if (result.Status == "1" & result.Message== "success")  
            {
                return Json(new { success = true, message = "Employee deleted successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete employee" });
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}