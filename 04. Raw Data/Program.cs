using System;
using System.Collections.Generic;
using System.Linq;

namespace CarCargo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Car car = new Car(
                    model,
                    new Engine(engineSpeed, enginePower),
                    new Cargo(cargoWeight, cargoType)
                );

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var result = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Cargo.Weight < 1000);

                foreach (var car in result)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                var result = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);

                foreach (var car in result)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }

    class Car
    {
        public string Model { get; }
        public Engine Engine { get; }
        public Cargo Cargo { get; }

        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }
    }

    class Engine
    {
        public int Speed { get; }
        public int Power { get; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Cargo
    {
        public int Weight { get; }
        public string Type { get; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}