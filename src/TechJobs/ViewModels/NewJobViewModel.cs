﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required(ErrorMessage ="Please enter a name for the job.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please specify an employer.")]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        [Required(ErrorMessage = "Please select a location.")]
        [Display(Name = "Location")]
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Please select the desired skill.")]
        [Display(Name = "Skill")]
        public int CoreCompetencyID { get; set; }

        [Required(ErrorMessage = "Please select the type of position.")]
        [Display(Name = "Position Type")]
        public int PositionTypeID { get; set; }

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view
            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
        }
    }
}
