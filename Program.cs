using System;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire // Note: actual namespace depends on the project name.
{
    public class Program
    {       
        //CHEMIN DANS LA MACHINE
        static String path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"//contacts.xml"; //sauvergarder le contact xml dans Documents
        //Environment.GetFolderPath: obtient le chemin d'accès au dossier spécial du système identifié par l'énumération spécifiée.
        // + nom du fichier qu'on veut créer
        // Le XML permet de structurer l'information dans des fichiers textes. On peut l'utiliser typiquement comme fichier de configuration pour des programmes mais aussi pour enregistrer des résultats (mesures, carnet d'adresse, liste de pièces,...)


        // METHODE POUR ECRIRE
        public static void WriteXML(List<Contact> contacts){ // methode pour créer une liste de contacts
            // List<> représente une liste fortement typée d'objets accessibles par index. Fournit des méthodes de recherche, de tri et de manipulation de listes.
            // <Contact> = Type d'éléments de la liste
            System.Xml.Serialization.XmlSerializer writer= //Sérialise et désérialise des objets vers et depuis des documents XML. XmlSerializer permet de contrôler le mode d'encodage des objets en langage XML grâce à la var writer
            new System.Xml.Serialization.XmlSerializer(typeof(List<Contact>)); // nouvelle instance de type Contact

            System.IO.FileStream file = System.IO.File.Create(path); // Fournit un élément Stream pour un fichier, prenant en charge les opérations en lecture et en écriture aussi bien synchrones qu'asynchrones.
            // la fonction Create permet de créer ou remplacer un fichier dans le chemin d'accès spécifié.

            writer.Serialize(file, contacts);
            file.Close();

        }

        //METHODE POUR LIRE
        public static void ReadXML() //methode pour charger et lire du xml
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Contact>));

                System.IO.StreamReader file=
                new System.IO.StreamReader(path);
                List<Contact> contacts = (List<Contact>)reader.Deserialize(file);
                file.Close();

                foreach(Contact contact in contacts)
                { // boucle
                    Console.WriteLine(contact.ToString());
                }
        }

        public static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("Joe", "0756821459"));
            contacts.Add(new Contact("Aly", "0158741236"));
            WriteXML(contacts);
            ReadXML();
            Console.ReadKey(true); // sortir du programme en appuyant sur n'importe quelle touche
        }

        

    }
}