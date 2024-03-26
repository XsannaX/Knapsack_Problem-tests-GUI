namespace Plecak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of items");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine+"Number of seeds" + Environment.NewLine);
            int seed = int.Parse(Console.ReadLine());
            Mochila problem=new Mochila(n,seed);
            Console.WriteLine(problem.ToString());
            Console.WriteLine("Capasity is " + Environment.NewLine);
            int capasity=int.Parse(Console.ReadLine());
            Console.WriteLine(problem.Solve(capasity).ToString());
            Console.ReadLine();


        }
    }
    
}
