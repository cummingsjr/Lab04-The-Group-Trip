/*
* Name: James Cummings
* Course: CSCI 1250, Section 001
* Assignment: Lab 4, The Group Trip
* Date: October 3, 2023
* Description: Writing methods, arrays and for loops.
*/

const int slicesPerPizza = 8;
const double taxRate = 0.18;

Console.WriteLine("====Fuel Costs==== ");
Console.WriteLine("How many miles did you travel");
double miles = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Miles per gallon: ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Price per gallon: ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("How many pizzas: ");
int pizzas = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Price per pizza: ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

// Fuel Costs
Console.WriteLine("=======Fuel Cost=======");

double fuelCost = FuelCost(miles, milesPerGallon, pricePerGallon);
double pizzaCost = pizzas * pricePerPizza;
double tripTotal = fuelCost + pizzaCost;

Console.WriteLine($"Fuel cost: {fuelCost:C2}");
Console.WriteLine($"Pizza cost: {pizzaCost:C2}");
Console.WriteLine($"Trip total: {tripTotal:C2}");

// Pizza Party
Console.WriteLine("====Attendees====");

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

int attendees = names.Length;
double totalSlices = pizzas * slicesPerPizza;
double slicesEach = totalSlices / attendees;
double costPerPerson = tripTotal / attendees;

Console.WriteLine($"People going: {attendees}");
Console.WriteLine($"Slices each: {slicesEach:F1}");
Console.WriteLine($"Cost per person: {costPerPerson:C2}");

// Part 3: Hours
Console.WriteLine("====Hours needed====");

double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

for (int i = 0; i < names.Length; i++)
{
    double takeHome = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHome / hoursWorked[i];
    double hoursNeeded = HoursToCover(costPerPerson, takeHomePerHour);

    Console.WriteLine(
        $"{names[i]}: takes home {takeHome:C2} for {hoursWorked[i]:F0} hours, " +
        $"{takeHomePerHour:C2} per hour, must work {hoursNeeded:F2} hours");

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHome;
    longest = Math.Max(longest, hoursNeeded);
}

Console.WriteLine($"Total hours worked: {totalHours:F0}");
Console.WriteLine($"Total take home pay: {totalTakeHomePay:C2}");
Console.WriteLine($"Longest anyone must work: {longest:F2}");

// Methods
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    return grossPay * (1 - taxRate);
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}
