﻿namespace HikingPlanAndRescue.Web.Areas.Private.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Validation;

    public class TrainingEditViewModel : IMap<Training>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy hh:mm")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy hh:mm")]
        [CompareTrainingDateValidationAttribute(OtherProperty = "StartDate", ErrorMessage = "End date must be after start date")]
        public DateTime EndDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Water (liters)")]
        public double Water { get; set; }

        [Required]
        [Display(Name = "Calories (kcal)")]
        public double Calories { get; set; }
    }
}