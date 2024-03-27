using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MacroNutrientCalculatorV2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MacroNutrientUser class
public class MacroNutrientUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}

