using HamedaniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamedaniProject.viewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }

    
        public List<Customer> customers { get; set; }
    }
}