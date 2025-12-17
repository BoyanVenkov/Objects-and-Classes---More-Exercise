using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public int TraveledDistance { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        TraveledDistance = 0;
    }

    public bool Drive(int distance)
    {
        double neededFuel = distance * FuelConsumptionPerKm;

        if (FuelAmount >= neededFuel)
        {
            FuelAmount -= neededFuel;
            TraveledDistance += distance;
            return true;
        }

        return false;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = input[0];
            double fuelAmount = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

            cars[model] = new Car(model, fuelAmount, fuelConsumption);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string carModel = parts[1];
            int distance = int.Parse(parts[2]);

            if (!cars[carModel].Drive(distance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in cars.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
        }
    }
}