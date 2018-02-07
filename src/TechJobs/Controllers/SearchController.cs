using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }



        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            
            ViewBag.columns = ListController.columnChoices;
            ViewBag.fields = ListController.jobFields;

            if (searchTerm == null)
            {
                return View("Index");
            }
                if (searchType == "all")
            {
                List<Dictionary<string, string>> Jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = Jobs;
                ViewBag.title = "Search Results for ALL";
            }
                                  
            else
             { 
                List<Dictionary<string, string>> Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);

                ViewBag.jobs = Jobs;
                string term = searchTerm;
                ViewBag.title = "Search Results for" + " " + term;
            }      
           
            return View("Index");
        }

       

    }
}
