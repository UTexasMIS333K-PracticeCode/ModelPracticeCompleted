using Microsoft.AspNetCore.Mvc;

//you need to give the controllers namespace access to your models
using fa22ModelPracticeCompleted.Models;

namespace fa22ModelPracticeCompleted.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Example()
        {
            //create a new instance of the product class
            Product product = new Product();

            //set the properties of the object
            product.ProductID = 100042;
            product.ProductName = "An example product";
            product.ProductCost = 5.99m;
            product.InventoryOnHand = 1000;

            //call methods to calculate properties
            product.CalculateValueOfInventory();
            
            //return the object to the view
            return View(product);
        }

        public IActionResult Index()
        {
            //Create a new instance of the job posting class
            JobPosting jobPosting = new JobPosting();

            //Set the properties of the object
            jobPosting.JobPostingID = 22207;
            jobPosting.MonthlySalary = 6000;
            jobPosting.AnnualBonus = 10000;
            jobPosting.JobPostingName = "Sample Job Posting";

            //Call methods to calculate properties
            jobPosting.CalculateAnnualSalary();

            //Update the return statement to include the object
            return View(jobPosting);
        }


        //new method to create a basic job posting
        public IActionResult CreateNewPosting()
        {
            //this displays the blank form to create a new posting
            return View();
        }

        //new method to display the new posting with fields calculated
        public IActionResult DisplayJobPosting (JobPosting jobPosting)
        { 
            //validate that the information in the posting is correct
            TryValidateModel(jobPosting);

            //if model state is not correct, send user back to the view
            if (ModelState.IsValid == false) //something is wrong
            {
                //go back to the create view
                return View("CreateNewPosting");
            }

            //if code gets this far, we need to calculate the values
            jobPosting.CalculateAnnualSalary();

            //display the posting in the Index view
            //we do not need another view, since Index is already 
            //set up to display a job posting
            return View("Index", jobPosting);
        }


        //method to display blank form for extended job posting
        public IActionResult CreateNewExtendedPosting()
        {
            //TODO 07: Complete the ExtendedJobPosting model FIRST
            //TODO 08: Once you have finished the model, scaffold a view
            //You will need to use the CREATE template
            //TODO 08A: Be sure to remove any properties that are calculated from the new view
            //TODO 08B: Update the view so that modality is a drop-down list
            return View();
        }

        //method to display the new EXTENDED job posting with calculated values
        public IActionResult DisplayExtendedJobPosting(ExtendedJobPosting extendedJobPosting)
        {
            //TODO 10: Write this method using the DisplayJobPosting example
            //validate that the information in the posting is correct
            TryValidateModel(extendedJobPosting);

            //if model state is not correct, send user back to the view
            if (ModelState.IsValid == false) //something is wrong
            {
                //go back to the create view
                return View("CreateNewExtendedPosting");
            }

            //if code gets this far, we need to calculate the values
            extendedJobPosting.CalculateAnnualSalary();

            //TODO 11: Once you have finished this method, scaffold a view
            //You will need to use the DETAILS template
            //TODO 12: Update the return View() method to include the object
            return View(extendedJobPosting);
        }
        
    }
}
