using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Book
    {
        // nie pokazuje id na stronie
        [BindNever]
        public int id { set; get; }

        [Display(Name = "Tytuł książki")]
        [MinLength(1)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string name { set; get; }

        [Display(Name = "Autor")]
        [MinLength(3)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string author { set; get; }

        [Display(Name = "Data premiery")]
        [MinLength(9)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string releaseDate { set; get; }

        [Display(Name = "Opis")]
        [MinLength(10)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string desc { set; get; }

        [Display(Name = "Foto książki")]
        [MinLength(4)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string img { set; get; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Wprowadź dane")]
        public double price { set; get; }

        [BindNever]
        public bool isFavourite { set; get; }

        [BindNever]
        // czy jest towar w magazynie
        public bool available { set; get; }

        //[BindNever]
        //// nie pokazuje tego pola nawet w kodzie żródłowym
        //[ScaffoldColumn(false)]
        [Display(Name = "Kategoria książki")]
        [Required(ErrorMessage = "Wprowadź dane")]
        public int categoryID { set; get; }

        [BindNever]
        // nie pokazuje tego pola nawet w kodzie żródłowym
        [ScaffoldColumn(false)]
        public virtual Category Category { set; get; }
    }
}
