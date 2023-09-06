//add namespace for data annotations
using System.ComponentModel.DataAnnotations;


namespace fa22ModelPracticeCompleted.Models
{
    //TODO 01: define an enum that will store the three work modalities
    //the three modalities are in-person, remote, and hybrid
    public enum Modality {[Display(Name = "In-Person")] InPerson, Remote, Hybrid }

    //TODO 02: add the code so ExtendedJobPosting inherits from JobPosting
    public class ExtendedJobPosting : JobPosting
    {
        //TODO 03: Add a property for the work modality of this posting
        //the data type for this property MUST match the enum that
        //you defined above
        [Display(Name = "Modality:")]
        public Modality JobModality { get; set; }


        //TODO 04: Add a property for the sign-on bonus for this job posting
        //TODO 05: Add the data annotations that will limit the range of the bonus
        //sign on bonuses are between $0 and $10,000 
        [Display(Name = "Sign-On Bonus:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Sign-on bonus is required!")]
        [Range(0, 10000, ErrorMessage = "Sign-on bonus must be between $0 and $10,000")]
        public Decimal SignOnBonus { get; set; }

        //TODO 06: Update the property for TotalAnnualCompensation
        //this is the other way to calculate a value that depends on other
        //properties.  This technique will calculate the value every time that
        //TotalSalary is referenced. This is best for simple or volatile calculations
        [Display(Name = "Total Annual Compensation:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public override Decimal TotalAnnualCompensation
        {
            get { return AnnualSalary + AnnualBonus + SignOnBonus; }
        }
    }
}
