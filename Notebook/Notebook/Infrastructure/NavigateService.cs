using Notebook.BL.Models;
using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notebook.Infrastructure
{
    public sealed class NavigateService
    {
        /// <summary>
        /// search method for Index view
        /// </summary>
        /// <param name="searchCritery"></param>
        /// <returns></returns>
        public IEnumerable<People> Search(string searchCritery)
        {
           return InitializeList.PeopleList.
                Where(x => x.Surname.Contains(searchCritery)
                || x.Name.Contains(searchCritery)
                || x.PhoneNumber.Contains(searchCritery)
                ).ToList();
        }
    }
}