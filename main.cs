using System;
using System.Collections;

namespace refrigerator
{
    public class main
    {
        private static String filepath = "obj";

        public static ArrayList createNewFridge()
        {
            ArrayList fridge = new ArrayList();
            return fridge;
        }

        public static ArrayList openFridge()
        {
            ArrayList fridge = (ArrayList) ObjectIO.ReadObjectFromFile(filepath);
            return fridge;
        }

        public static void addToFridge(ArrayList fridge)
        {
            while (true)
            {
                Console.Write("Enter Food Item Name: ");
                String foodItemName = Console.ReadLine(); // Read user input

                Console.Write("Enter Expiry Date: ");
                //int datestring = Integer.parseInt(myObj.next());
                DateTime datestring = DateTime.Parse(Console.ReadLine()); //converting string into sql date

                fridge.Add(new foodItem(foodItemName, datestring));
                //SQLiteTest.addUser(foodItemName, datestring);
                Console.WriteLine("Add More Items?: Y / N");
                if (Console.ReadLine() == "Y")
                {

                }
                else if (Console.ReadLine() == "N")
                {
                    ObjectIO.WriteObjectToFile(fridge, filepath);
                    break;
                }
            }
        }

        public static void editFridge(ArrayList fridge)
        {
            if (Console.ReadLine() == "Y")
            {
                foreach (foodItem f in fridge)
                {
                    Console.WriteLine(f.getItemName() + " " + f.getExpiryDate());
                    Console.WriteLine("Is this the Item?: Y / N");
                    if (Console.ReadLine() == "Y")
                    {
                        Console.WriteLine("Edit Name or Expiry Date?: N / E");
                        if (Console.ReadLine() == "N")
                        {
                            Console.Write("Enter Food Item Name: ");
                            String foodItemName = Console.ReadLine();
                        }
                        else if (Console.ReadLine() == "E")
                        {
                            Console.Write("Enter Expiry Date: ");
                            DateTime datestring = DateTime.Parse(Console.ReadLine()); //converting string into sql date
                        }
                        else if (Console.ReadLine() == "N")
                        {
                            Console.WriteLine(f.getItemName() + " " + f.getExpiryDate());
                        }
                    }
                }
            }
        }

        public static void displayFridgeContents(ArrayList fridge)
        {
            foreach (foodItem f in fridge)
            {
                Console.WriteLine(f.getItemName() + " " + f.getExpiryDate());
            }
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("Create New Fridge or Open Existing?: N / O");
            String answer = Console.ReadLine();
            if (answer == "N")
            {
                ArrayList fridge = createNewFridge();
                addToFridge(fridge);

                Console.WriteLine("Display Fridge Contents?: Y / N");
                if (Console.ReadLine() == "Y") {
                    displayFridgeContents(fridge);
                }
            }
            else if (answer == "O")
            {
                ArrayList fridge = openFridge();

                Console.WriteLine("Edit Fridge Contents?: Y / N");
                if (Console.ReadLine() == "Y") {
                    Console.WriteLine("Add Items to Fridge?: Y / N");
                    if (Console.ReadLine() == "Y")
                    {
                        addToFridge(fridge);
                    }
                    else if (Console.ReadLine() == "N")

                    {
                        Console.WriteLine("Edit Items in Fridge?: Y / N");
                        if (Console.ReadLine() == "Y") {
                            editFridge(fridge);
                        }
                    }
                }
                Console.WriteLine("Display Fridge Contents?: Y / N");
                if (Console.ReadLine() == "Y")
                {
                    displayFridgeContents(fridge);
                }
            }
        }
    }
}