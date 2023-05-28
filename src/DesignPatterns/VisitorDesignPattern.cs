namespace DesignPatterns;

public static class VisitorDesignPattern
{
    /*
     * The visitor design pattern is a behavioral design pattern that allows to separate the algorithm or behavior
     * from the objects it operates on. It enables you to define new operations or behaviors to be performed on a group of
     * objects without modifying their classes
     */

     /*
      * Analogy:
      * Let's imagine you're the owner of a zoo, and you have different types of animals living there: Lions, Elephants, Monkeys
      * Now let's say you want to perform a health check on all the animals in your zoo.
      *
      * Instead of going to check each animals health individually, you can hire some veterinarians to perform this task.
      *
      * Each veterinarians will have their own set of procedures to verify the animals health, but the animals don't need to
      * anything about it, but they know that veterinarians are allowed to verify their health.
      *
      */

     public static void Execute()
     {
         var animals = new List<IAnimal>
         {
             new Lion(1),
             new Lion(2),
             new Lion(3),
             new Elephant(4),
             new Elephant(5)
         };

         var veterinarian = new Veterinarian();

         foreach (var animal in animals)
         {
             animal.AcceptVisitor(veterinarian);
         }
     }
     
}

interface IVisitor
{
    void VisitLion(Lion lion);
    void VisitElephant(Elephant lion);
}

interface IAnimal
{
    void AcceptVisitor(IVisitor visitor);
}

internal class Lion : IAnimal
{
    private readonly int _id;

    public Lion(int id)
    {
        _id = id;
    }

    public void AcceptVisitor(IVisitor visitor)
    {
        visitor.VisitLion(this);
    }

    public override string ToString()
    {
        return $"{nameof(Lion)} #{_id}";
    }
}

internal class Elephant : IAnimal
{
    private readonly int _id;

    public Elephant(int id)
    {
        _id = id;
    }

    public void AcceptVisitor(IVisitor visitor)
    {
        visitor.VisitElephant(this);
    }

    public override string ToString()
    {
        return $"{nameof(Elephant)} #{_id}";
    }
}

internal class Veterinarian : IVisitor
{
    public void VisitLion(Lion lion)
    {
        Console.WriteLine($"Performing health check of {lion}");
    }

    public void VisitElephant(Elephant elephant)
    {
        Console.WriteLine($"Performing health check of {elephant}");
    }
}