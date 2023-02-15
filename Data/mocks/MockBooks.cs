using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockBooks : IAllBooks
    {
        private readonly IBooksCategory _categoryBooks = new MockCategory();
        public IEnumerable<Book> Books {
            get
            {
                return new List<Book>
                {
                    new Book {
                    name = "Linie na twarzy babuni",
                    author = "Ciraolo Simona",
                    releaseDate = "2023-01-11",
                    desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                    img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                    price = 33.98,
                    isFavourite = false,
                    available = true,
                    Category = _categoryBooks.AllCategories.First()
                    },
                    new Book {
                    name = "Linie na twarzy babuni",
                    author = "Ciraolo Simona",
                    releaseDate = "2023-01-11",
                    desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                    img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                    price = 33,
                    isFavourite = false,
                    available = true,
                    Category = _categoryBooks.AllCategories.First()
                    },
                    new Book {
                    name = "Linie na twarzy babuni",
                    author = "Ciraolo Simona",
                    releaseDate = "2023-01-11",
                    desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                    img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                    price = 33,
                    isFavourite = false,
                    available = true,
                    Category = _categoryBooks.AllCategories.First()
                    },
                    new Book {
                    name = "Linie na twarzy babuni",
                    author = "Ciraolo Simona",
                    releaseDate = "2023-01-11",
                    desc = "Zmarszczki to o wiele więcej, niż widać na pierwszy rzut oka. Z każdą z nich wiąże się inna historia. W ciepłej opowieści Simony Ciraolo, laureatki wielu nagród, mała dziewczynka poznaje najważniejsze wspomnienia swojej babci. Zmarszczki, które powstają na twarzy, kiedy człowiek się starzeje, okazują się magiczną bramą do podróży w przeszłość. Dociekliwa wnuczka wypytuje babunię o każdą linię.Za jedną kryją się zachwyt i zdziwienie, za inną pełnia radości, za kolejną strach, za następną smutek, za ostatnią – bezgraniczna miłość i szczęście. Poznajemy najważniejsze momenty z życia babci, śledzimy emocje, które tym chwilom towarzyszyły. W ten sposób tworzy się niezwykła mapa wspomnień, schowana w pomarszczonej twarzy.",
                    img = "https://ecsmedia.pl/c/linie-na-twarzy-babuni-b-iext123172350.jpg",
                    price = 33,
                    isFavourite = false,
                    available = true,
                    Category = _categoryBooks.AllCategories.First()
                    },
                };
            }
        }

        public IEnumerable<Book> getFavBooks { get; set; }

        public Book getObjectBook(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
