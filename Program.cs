namespace Encapsulation
{
   public class BeerEncapsulator
    {
        private float _availableVolume;
        private int _availableBottles;
        private int _availableCapsules;

        public float AvailableVolume
        {
            get { return _availableVolume; }
        }

        public int AvailableBottles
        {
            get { return _availableBottles; }
        }

        public int AvailableCapsules
        {
            get { return _availableCapsules; }
        }

        public BeerEncapsulator(float initialVolume, int initialBottles, int initialCapsules)
        {
            _availableVolume = initialVolume;
            _availableBottles = initialBottles;
            _availableCapsules = initialCapsules;
        }

        public void addBeer(float beerToAdd)
        {
            _availableVolume += beerToAdd;
        }

        private bool componentsAvailable(int requiredBottles, float requiredVolume, int requiredCapsules)
        {
            if (_availableBottles >= requiredBottles && _availableVolume>= requiredVolume && _availableCapsules >= requiredCapsules)
            {
                return true;
            } else
            {
                if (_availableBottles < requiredBottles)
                {
                    Console.WriteLine($"Add {_availableBottles - requiredBottles} bottles to the machine.");
                }
                if (_availableCapsules < requiredCapsules)
                {
                    Console.WriteLine($"Add {_availableCapsules - requiredCapsules} capsules to the machine.");
                }
                if (_availableVolume < requiredVolume)
                {
                    Console.WriteLine($"Add {_availableVolume - requiredVolume} cl of the beer machine");
                }
                return false;
            }
        }

        public int produceEncapsulatedBeerBottles(int numberBottles)
        {
            int bottlesProduction = 0;  
            if (componentsAvailable(numberBottles, numberBottles *33, numberBottles))
            {
                bottlesProduction = numberBottles;
                _availableBottles -= numberBottles; 
                _availableVolume -= numberBottles * 33;
                _availableCapsules -= numberBottles;
            }
            return bottlesProduction;   
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the initial Volume of beer in centiliters :");
            float initialVolume = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter initial number of empty Bottles :");
            int initialBottles = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Enter the number of capsules");
            int initialCapsules = int.Parse(Console.ReadLine());    

            BeerEncapsulator wildMachine = new BeerEncapsulator(initialVolume, initialBottles, initialCapsules);
            while (true)
            {
                Console.WriteLine("Choose an option please :");
                Console.WriteLine("1. Add beer");
                Console.WriteLine("2. Produce encapsulated beer bottles");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the volume of beer you wanna add ");
                        float beerToAdd = float.Parse(Console.ReadLine());
                        wildMachine.addBeer(beerToAdd);
                        Console.WriteLine($"You added {beerToAdd} cl of beer. Total beer volume : {wildMachine.AvailableVolume} cl");
                        break;

                        case 2:
                        Console.WriteLine("Enter number of bottles you wanna produce :");
                        int bottlesProduction= int.Parse(Console.ReadLine());   
                        int producedBottles= wildMachine.produceEncapsulatedBeerBottles(bottlesProduction);
                        if (producedBottles > 0)
                        {
                            Console.WriteLine($"Produced {producedBottles} bottles.");
                        } else
                        {
                            Console.WriteLine("Not enough to produce bottles.");
                        }break;
                        case 3:
                        Console.WriteLine("Exit the program");
                        return;
                        default:    Console.WriteLine("Invalid option, please choose again.");
                        break;
                       
                }
            }
        }
    }
}
