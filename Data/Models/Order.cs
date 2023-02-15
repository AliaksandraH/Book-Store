using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        // nie pokazuje id na stronie
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Imię")]
        [MinLength(3)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string name { get; set; }

        [Display(Name = "Nazwisko")]
        [MinLength(3)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string surname { get; set; }

        [Display(Name = "Adres (Miasto/ Ulica/ Dom/ Apartament/ Indeks)")]
        [MinLength(15)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string adress { get; set; }

        [Display(Name = "Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(9)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(10)]
        [Required(ErrorMessage = "Wprowadź dane")]
        public string email { get; set; }

        [BindNever]
        // nie pokazuje tego pola nawet w kodzie żródłowym
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
