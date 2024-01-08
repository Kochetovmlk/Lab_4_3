using System;
using System.Collections;

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }
}

class CarCatalog : IEnumerable<Car>
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public IEnumerator<Car> GetEnumerator()
    {
        return cars.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<Car> GetCarsByProductionYear(int year)
    {
        return cars.Where(car => car.ProductionYear == year);
    }

    public IEnumerable<Car> GetCarsByMaxSpeed(int speed)
    {
        return cars.Where(car => car.MaxSpeed == speed);
    }

    public IEnumerable<Car> Reverse()
    {
        for (int i = cars.Count - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("BMW", 2000, 150);
        Car car2 = new Car("Audi", 2010, 180);
        Car car3 = new Car("Mercedes-Benz", 1995, 130);

        CarCatalog catalog = new CarCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        Console.WriteLine("Прямая итерация:");
        foreach (Car car in catalog)
        {
            Console.WriteLine($"Name: {car.Name}, Year: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
        }

        Console.WriteLine("\nОбратная итерация:");
        foreach (Car car in catalog.Reverse())
        {
            Console.WriteLine($"Name: {car.Name}, Year: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
        }

        int filterYear = 2000;
        Console.WriteLine($"\nФильтровать по году выпуска ({filterYear}):");
        foreach (Car car in catalog.GetCarsByProductionYear(filterYear))
        {
            Console.WriteLine($"Name: {car.Name}, Year: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
        }

        int filterSpeed = 130;
        Console.WriteLine($"\nФильтровать по максимальной скорости ({filterSpeed}):");
        foreach (Car car in catalog.GetCarsByMaxSpeed(filterSpeed))
        {
            Console.WriteLine($"Name: {car.Name}, Year: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
        }
    }
}
