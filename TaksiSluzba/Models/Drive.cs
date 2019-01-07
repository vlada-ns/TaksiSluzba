using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    // TODO: is enum best solution for Status - enum is bad for run-time editing!
    public enum Status
    {
        Created_On_Hold,
        Canceled,
        Formated,
        Processed,
        Accepted,
        Unsuccessful,
        Successful
    };

    public class Drive
    {
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Location Location { get; set; }
        public CarType CarType { get; set; } = CarType.PassengerCar;
        
        /* TODO: Mušterija za koju je kreirana vožnja (samo ako mušterija inicira kreiranje vožnje)
         * Razmisliti o ovome --> "samo ako mušterija inicira kreiranje vožnje"
         */
        public User User { get; set; }
        
        /* TODO: Odredište (lokacija na kojoj je vožnja uspešno završena, za ažuriranje vrednosti odgovoran je
         * vozač u trenutku kada se uspešno završi vožnja)
         * Razmisliti o ovome --> kako ovaj zahtev utice na aplikaciju?
        */
        public Location Destination { get; set; }

        /* TODO: Dispečer (ako je formirao ili obradio vožnju, ako je vozač prihvatio onda je ovo polje prazno)
         * Razmisliti o ovome --> "ako je formirao ili obradio vožnju, ako je vozač prihvatio onda je ovo polje prazno"
        */
        public Dispatcher Dispatcher { get; set; }
        public Driver Driver { get; set; }
        public decimal Amount { get; set; }
        public Comment Comment { get; set; }
        public Status Status { get; set; }
        
    }
}
 
 