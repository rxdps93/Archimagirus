namespace LoadRecipeTestData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationHelper.SetupConfiguration();
            if (!ConfigurationHelper.ValidateConfigurations())
            {
                Console.WriteLine("Invalid configuration");
                return;
            }

            Console.WriteLine("Loading recipe data");
            // todo
        }
    }
}