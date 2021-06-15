using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace EntityFramework.Models.ViewModels
{
    public class PersonListIndexViewModel
    {

        public List<IPerson> PersonList { get; set; }
    }
}
