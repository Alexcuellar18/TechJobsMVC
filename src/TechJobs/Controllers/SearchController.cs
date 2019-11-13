using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        private static List<Dictionary<string, string>> searchResults = new List<Dictionary<string, string>>();

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = searchResults;
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpPost]
        [Route("/Search")]
        public IActionResult Results(string searchType,string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            searchType = searchType.ToLower();
            searchTerm = searchTerm.ToLower();


            
            
            if (searchType == "all")
            {
                searchResults = JobData.FindByValue(searchTerm);
              
            }
            else
            {
                searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                
            }
            ViewBag.jobs = searchResults;
            //TempData["jobs"] = searchResults;

            return View("Index");
        }
    }
}
