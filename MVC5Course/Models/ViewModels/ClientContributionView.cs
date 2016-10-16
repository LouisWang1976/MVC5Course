using System;

namespace MVC5Course.Models.ViewModels
{
    public class ClientContributionView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
    }
}