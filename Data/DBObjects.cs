using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void initial(AppDBContent content)
        {           
            // sprawdzanie istnienia BD
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Book.Any())
            {
                content.AddRange(
                    new Book
                    {
                        name = "Linie na twarzy babuni",
                        author = "Ciraolo Simona",
                        releaseDate = "2023-01-11",
                        desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                        img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                        price = 33.98,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Dla dzieci"]
                    },
                    new Book
                    {
                        name = "Linie na twarzy babuni",
                        author = "Ciraolo Simona",
                        releaseDate = "2023-01-11",
                        desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                        img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                        price = 33,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Dla dzieci"]
                    },
                    new Book
                    {
                        name = "Linie na twarzy babuni",
                        author = "Ciraolo Simona",
                        releaseDate = "2023-01-11",
                        desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                        img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                        price = 33,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Dla dzieci"]
                    },
                    new Book
                    {
                        name = "Linie na twarzy babuni",
                        author = "Ciraolo Simona",
                        releaseDate = "2023-01-11",
                        desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                        img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                        price = 33,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Dla dzieci"]
                    }
                );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName="Biografie"},
                        new Category { categoryName="Dla dzieci"},
                        new Category { categoryName="Historia"},
                        new Category { categoryName="Komiks"},
                        new Category { categoryName="Kryminał, sensacja, thriller"},
                        new Category { categoryName="Kuchnia i diety"},
                        new Category { categoryName="Literatura obyczajowa"},
                        new Category { categoryName="Literatura piękna obca"},
                        new Category { categoryName="Lliteratura piękna polska"},
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;
            }
        }
    }
}
