using Notebook.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using Notebook.Infrastructure;

namespace Notebook.Models
{
    /// <summary>
    /// dto model People
    /// </summary>
    public class PeopleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Введите фамилию!")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите имя!")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [DateValidate(ErrorMessage = "Не корректная дата.Минимальная дата рождения 01.01.1920")]
        [Display(Name = "Дата рождения")]
        public int DateBirthday { get; set; }


        [Required(ErrorMessage = "Введите номер телефона!")]
        [Display(Name = "Номер телефона")]

        public string PhoneNumber { get; set; }

        public IEnumerable<People> ContactList { get; set; }
        public PagedList.IPagedList<People> ContactPagedList { get; set; }

        public string CurrentSort { get; set; }
        public string SurnameSort { get; set; }
        public string DateBirthSort { get; set; }
        public string CurrentFilter { get; set; }
    }
}