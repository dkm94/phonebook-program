using System;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static String path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"//contacts.xml"; //sauvergarder le contact xml dans Documents
 
        public static void WriteXML(List<Contact> contacts){ // methode pour ecrire du xml // prendre en arg un contact et l'ecrire dans le fichier xml
            System.Xml.Serialization.XmlSerializer writer=
            new System.Xml.Serialization.XmlSerializer(typeof(List<Contact>)); 

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, contacts);
            file.Close();

        }

        public static void ReadXML() //methode pour charger et lire du xml
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Contact>));

                System.IO.StreamReader file=
                new System.IO.StreamReader(path);
                List<Contact> contacts = (List<Contact>)reader.Deserialize(file);
                file.Close();

                foreach(Contact c in contacts)
                {
                    Console.WriteLine(c.ToString());
                }
        }

        public static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("Joe", "0756821459"));
            contacts.Add(new Contact("Aly", "0158741236"));
            WriteXML(contacts);
            ReadXML();
            Console.ReadKey(true);
        }

        

    }
}