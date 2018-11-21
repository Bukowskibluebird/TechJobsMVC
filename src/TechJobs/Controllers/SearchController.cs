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

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = jobs;
            }

            
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                List<Dictionary<string, string>> noJobs = new List<Dictionary<string, string>>();
                ViewBag.columns = ListController.columnChoices;
                // ViewBag.title = "Jobs with " + searchType[searchTerm] + ": " + searchTerm;

                // if () == true)

                if (jobs.Count == 0)
                {
                    ViewBag.jobs = noJobs;
                }

                else
                {
                    ViewBag.jobs = jobs;
                }

            }
            

            //x = FindByColumnAndValue(string searchType, string searchTerm); //doesn't work

            return View("Index");
        }



        //if (column.Equals("all"))
            //{
                //List<Dictionary<string, string>> jobs = JobData.FindAll();
                //ViewBag.title =  "All Jobs";
                //ViewBag.jobs = jobs;
                //return View("Jobs");
            //}
            //else
            //{
                //List<string> items = JobData.FindAll(column);
                //ViewBag.title =  "All " + columnChoices[column] + " Values";
                //ViewBag.column = column;
                //ViewBag.items = items;
                //return View();

        

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
