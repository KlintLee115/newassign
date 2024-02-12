using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("\nEnter the item number of an appliance:");
            // Create long variable to hold item number
            long number;

            // Get user input as string and assign to variable.

            string input = Console.ReadLine();
            // Convert user input from string to long and store as item number variable.

            number = long.Parse(input);
            // Create 'foundAppliance' variable to hold appliance with item number

            Appliance? foundAppliance;
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            foundAppliance = null;
            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable

            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance.ItemNumber == number)
                {
                    foundAppliance = appliance;
                    break;
                }
            }


            // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.\n");
            }

            // // Otherwise (appliance was found)
            // // Test found appliance is available
            // // Checkout found appliance
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine($"Appliace \"{number}\" has been checked out.\n");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.\n");
                }
            }

            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for:");

            // Create string variable to hold entered brand
            string brand;
            // Get user input as string and assign to variable.
            brand = Console.ReadLine();
            // Create list to hold found Appliance objects

            List<Appliance> found = new List<Appliance>();

            // Iterate through loaded appliances
            // Test current appliance brand matches what user entered
            // Add current appliance in list to found list

            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance.Brand == brand)
                {
                    found.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"

            // Write "Enter number of doors: "
            Console.WriteLine("\nEnter number of doors: 0 ( Any ), 2 ( double door ), 3 ( three doors ) or 4 ( four doors ): ");

            // Create variable to hold entered number of doors
            string strNumDoors;
            // Get user input as string and assign to variable
            strNumDoors = Console.ReadLine();

            // Convert user input from string to int and store as number of doors variable.
            int numDoors = int.Parse(strNumDoors);
            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;

            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list
            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance is Refrigerator)
                {

                    Refrigerator refrigerator = (Refrigerator)appliance;

                    switch (numDoors)
                    {
                        case 0:
                            found.Add(refrigerator);
                            break;
                        default:
                            if (refrigerator.Doors == numDoors)
                            {
                                found.Add(refrigerator);
                            }
                            break;


                    }

                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            // Write "Enter voltage:"
            Console.WriteLine("Enter battery voltage value. 18V (low) or 24V (high) ");

            // Get user input as string
            // Create variable to hold voltage
            short? voltage = null;
            string inputVoltage = Console.ReadLine();

            // Test input is "0"
            // Assign 0 to voltage
            // Test input is "1"
            // Assign 18 to voltage
            // Test input is "2"
            // Assign 24 to voltage
            // Otherwise
            // Write "Invalid option."
            // Return to calling (previous) method
            // return;

            switch (inputVoltage)
            {
                case "0":
                    voltage = 0;
                    break;
                case "18":
                    voltage = 18;
                    break;
                case "24":
                    voltage = 24;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;

            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Vacuum vacuum = (Vacuum)appliance;

            // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
            // Add current appliance in list to found list

            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;

                    if (voltage != null)
                    {

                        if (vacuum.BatteryVoltage == voltage)
                        {
                            found.Add((Appliance)vacuum);
                        }
                    }
                }
                // Display found appliances
            }
            DisplayAppliancesFromList(found, 0);

        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site): ");

            // Get user input as string and assign to variable
            string input = Console.ReadLine();

            // Create character variable that holds room type
            char? roomType = null;

            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;
            switch (input.ToLower())
            {
                case "0":
                    roomType = 'A';
                    break;
                case "k":
                    roomType = 'K';
                    break;
                case "w":
                    roomType = 'W';
                    break;

                default:
                    Console.WriteLine("Invalid option.\n");
                    break;
            }


            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list
            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;

                    if (microwave.RoomType == roomType)
                    {
                        found.Add((Appliance)microwave);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }
        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or\r\nM (Moderate): ");

            // Get user input as string and assign to variable
            string input = Console.ReadLine();

            // Create variable that holds sound rating
            string? rating = null;

            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method

            switch (input)
            {
                case "0":
                    rating = "Any";
                    break;
                case "Qt":
                    rating = "Qt";
                    break;
                case "Qr":
                    rating = "Qr";
                    break;
                case "Qu":
                    rating = "Qu";
                    break;
                case "M":
                    rating = "M";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }


            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list
            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    if (dishwasher.SoundRating == rating)
                    {
                        found.Add((Appliance)dishwasher);
                    }
                }
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"

            // Get user input as string and assign to appliance type variable

            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances: ");

            // Get user input as string and assign to variable
            string strNumInput = Console.ReadLine();

            // Convert user input from string to int
            int numInput = int.Parse(strNumInput);

            // Create variable to hold list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through appliances
            // Test inputted appliance type is "0"
            // Add current appliance in list to found list
            // Test inputted appliance type is "1"
            // Test current appliance type is Refrigerator
            // Add current appliance in list to found list
            // Test inputted appliance type is "2"
            // Test current appliance type is Vacuum
            // Add current appliance in list to found list
            // Test inputted appliance type is "3"
            // Test current appliance type is Microwave
            // Add current appliance in list to found list
            // Test inputted appliance type is "4"
            // Test current appliance type is Dishwasher
            // Add current appliance in list to found list
            foreach (Appliance appliance in this.Appliances)
            {
                if (appliance.Type == Appliance.ApplianceTypes.Unknown) found.Add(appliance);
                else if (appliance.Type == Appliance.ApplianceTypes.Refrigerator) found.Add((Refrigerator)appliance);
                else if (appliance.Type == Appliance.ApplianceTypes.Vacuum) found.Add((Vacuum)appliance);
                else if (appliance.Type == Appliance.ApplianceTypes.Microwave) found.Add((Microwave)appliance);
                else if (appliance.Type == Appliance.ApplianceTypes.Dishwasher) found.Add((Dishwasher)appliance);
            }

            // Randomize list of found appliances
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, numInput);
        }
    }
}
