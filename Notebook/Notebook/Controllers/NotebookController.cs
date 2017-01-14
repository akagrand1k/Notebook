using Notebook.BL.Models;
using Notebook.BL.Service;
using Notebook.Infrastructure;
using Notebook.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Notebook.Controllers
{
    public class NotebookController : Controller
    {
        SerializationService serService = new SerializationService();
        NavigateService navService = new NavigateService();
        
        public ActionResult Index(string sortCritery,string searchCritery,string currentFilter,int? page)
        {
            PeopleViewModel model = new PeopleViewModel();
            model.CurrentSort = sortCritery;
            model.SurnameSort = String.IsNullOrEmpty(sortCritery) ? "surname_desc" : "";
            model.DateBirthSort = sortCritery == "DateBirthday" ? "date_birth" : "DateBirthday";
            model.ContactList = InitializeList.PeopleList;
            

            if (searchCritery != null) page = 1;
            else searchCritery = currentFilter;

            if (!String.IsNullOrEmpty(searchCritery))
            model.ContactList = navService.Search(searchCritery);

            switch (sortCritery)
            {
                case "surname_desc": model.ContactList = model.ContactList.OrderByDescending(s => s.Surname);
                    break;

                case "DateBirthday":
                    model.ContactList = model.ContactList.OrderBy(s =>
                    DateTime.ParseExact(DateService.ReplaceDate(s.DateBirthday), "dd.MM.yyyy",
                    null, System.Globalization.DateTimeStyles.None)
                    );
                    break;

                case "date_birth":
                    model.ContactList = model.ContactList.OrderByDescending(s =>
                    DateTime.ParseExact(DateService.ReplaceDate(s.DateBirthday), "dd.MM.yyyy",
                    null, System.Globalization.DateTimeStyles.None)
                    );
                    break;

                default: model.ContactList = model.ContactList.OrderBy(s => s.Surname); break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            model.ContactPagedList = model.ContactList.ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContact(PeopleViewModel model)
        {
            People ppl = new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = model.Surname,
                Name = model.Name,
                DateBirthday = model.DateBirthday,
                PhoneNumber = model.PhoneNumber
            };
            if (ModelState.IsValid)
            {
                InitializeList.PeopleList.Add(ppl);
                return RedirectToAction("Index", "Notebook");
            }

            return View();
        }

        public ActionResult DeleteContact(string id)
        {
            var delRecord = InitializeList.PeopleList.Find(x => x.Id == id);
            InitializeList.PeopleList.Remove(delRecord);
            return RedirectToAction("Index","Notebook");
        }
       
        /// <summary>
        /// Initialize modified List, after close page.
        /// </summary>
        /// <returns></returns>
        public EmptyResult Save()
        {
            serService.Serializer(InitializeList.PeopleList);
            return new EmptyResult();
        }
    }
}