using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public enum Status
    {
        Created_On_Hold,    // inicijalni status vožnje kada je kreira mušterija
        Canceled,           // vožnja koja je bila u statusu Kreirana - Na čekanju pa ju je mušterija otkazala
        Formated,           // inicijalni status vožnje kada je kreira dispečer.
        Processed,          // vožnja koja je bila u statusu Kreirana - Na čekanju pa ju je dispečer obradio i dodelio joj je vozača
        Accepted,           // vožnja koja je bila u statusu Kreirana - Na čekanju pa ju je vozač samoinicijativno preuzeo
        Unsuccessful,       // vožnja koja je bila u statusu Formirana, Obrađena ili Prihvaćena, vozač je za nju nije uspešno prevezao mušteriju
        Successful,         // vožnja koja je bila u statusu Formirana, Obrađena ili Prihvaćena, vozač je za nju uspešno prevezao mušteriju
        In_Progress         // 15. Proširiti stanje vožnje za “U toku” kako bi znali kada je koji vozač zauzet.
    };

    public class Drive
    {
        public int Id { get; set; }

        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        //[Display(Name = "Order date")]
        //[DataType(DataType.Date)]
        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        // TODO: Drive LocationId to be nullable int?
        // If drive can be without location then correct type is int?
        public Location Location { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public CarType CarType { get; set; } = CarType.PassengerCar;

        /* TODO: Mušterija za koju je kreirana vožnja (samo ako mušterija inicira kreiranje vožnje)
         * Razmisliti o ovome --> "samo ako mušterija inicira kreiranje vožnje"
         */
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }

        /* TODO: Odredište (lokacija na kojoj je vožnja uspešno završena, za ažuriranje vrednosti odgovoran je
         * vozač u trenutku kada se uspešno završi vožnja)
         * Razmisliti o ovome --> kako ovaj zahtev utice na aplikaciju?
        */
        public Location Destination { get; set; }
        [ForeignKey("Destination")]
        public int? DestinationId { get; set; }
    
        /* TODO: Dispečer (ako je formirao ili obradio vožnju, ako je vozač prihvatio onda je ovo polje prazno)
         * Razmisliti o ovome --> "ako je formirao ili obradio vožnju, ako je vozač prihvatio onda je ovo polje prazno"
        */
        public Dispatcher Dispatcher { get; set; }
        public int? DispatcherId { get; set; }

        public Driver Driver { get; set; }
        public int DriverId { get; set; }

        public decimal Amount { get; set; }

        public Comment Comment { get; set; }

        public Status Status { get; set; }

    }
}
 
 