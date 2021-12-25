using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Net.Http;

namespace MVC.Controllers
{
    public class CricketersController : Controller
    {
        // GET: Cricketers
        public ActionResult Index()
        {
            IEnumerable<mvcCricketerModel> CricList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cricketers").Result;
            CricList = response.Content.ReadAsAsync<IEnumerable<mvcCricketerModel>>().Result;
            return View(CricList);

        }
       
        public ActionResult Add(int id=0)
        {
            if (id == 0)
                return View(new mvcCricketerModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cricketers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCricketerModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Add(mvcCricketerModel cric)
        {
            if (cric.Jersey_Number == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cricketers", cric).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Cricketers/" + cric.Jersey_Number, cric).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Cricketers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}