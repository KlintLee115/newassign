namespace ModernAppliances
{
    internal class Program
    {
        /// <summary>
        /// Entry point to program
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            ModernAppliances modernAppliances = new MyModernAppliances();
            ModernAppliances.Options option = ModernAppliances.Options.None;

            while (option != ModernAppliances.Options.SaveExit)
            {
                modernAppliances.DisplayMenu();

                option = Enum.Parse<ModernAppliances.Options>(Console.ReadLine());

                switch (option)
                {
                    /// <summary>

                    /// Option 1: Performs a checkout

                    /// This method makes the user enter the appliance item number,

                    /// then we can find the appliance from the list using a foreach loop 

                    /// and appliance can be checked out also if it is unsuccessful the user is notified.

                    /// </summary>
                    case ModernAppliances.Options.Checkout:
                        {
                            modernAppliances.Checkout();

                            break;
                        }

                    /// <summary>
                    /// Option 2: Finds appliances
                    /// This method prompts the user to enter a brand and searches for appliances in the
                    /// list of loaded appliances whose brand matches the entered brand. The comparison
                    /// is case-insensitive to ensure accurate results. The found appliances are then
                    /// displayed using the DisplayAppliancesFromList method.
                    /// </summary>
                    case ModernAppliances.Options.Find:
                        {
                            modernAppliances.Find();

                            break;
                        }
                    case ModernAppliances.Options.DisplayType:
                        {
                            modernAppliances.DisplayType();

                            break;
                        }

                    case ModernAppliances.Options.RandomList:
                        {
                            modernAppliances.RandomList();
                            break;
                        }
                    case ModernAppliances.Options.SaveExit:
                        {
                            modernAppliances.Save();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option entered. Please try again.");
                            break;
                        }
                }
            }


        }
    }
}