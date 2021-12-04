using System;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire // Nom du projet
{
    
    [Serializable()] // une methode serializable ne peux pas exister sans constructeur sans arguments
    public class Contact{
        private String name; // champ
        public String Name {get => name; set => name = value;} // propriété
        private String number;// champ
        public string Number {get => number; set => number = value;} // propriété

        public Contact(){ // Annuaire.Contact a besoin d'un constructeur dans paramètre pour être sérialisé
        }
        public Contact(string name, string number){ //constructeur
            this.name = name;
            this.number = number;
        }

        public override string ToString()
        {
            return this.name+" : "+ this.number;
        }

    }
}