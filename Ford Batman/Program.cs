namespace Ford_Batman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inf = int.MaxValue;

            //как в примере из файла в контактной работе
            int[,] mass = {{inf,1,inf,inf,3},
                           {inf,inf,8,7,1},
                           {inf,inf,inf,1,-5},
                           {inf,inf,2,inf,inf},
                           {inf,inf,inf,4,inf}};
            int[,] mass_L = new int[5, 5];

            Console.WriteLine("Введите начальную вершину");
            int choice = int.Parse(Console.ReadLine());

            for (int i = 0; i < Math.Sqrt(mass.Length); i++)
                mass_L[i, 0] = inf;

            for (int i = 0; i < Math.Sqrt(mass.Length); i++)
                mass_L[choice-1, i] = 0;


            for (int i = 1; i < Math.Sqrt(mass.Length); i++) 
            {
                for (int j = 0; j < Math.Sqrt(mass.Length); j++) 
                {


                    if (i == choice - 1)
                    {
                        mass_L[i,j] = 0;
                    }
                    else if (j == 0)
                    {
                        mass_L[i, j] = inf;
                    }
                    else
                    {
                        int min = inf;
                        int L = inf;

                        for (int k = 0; k < Math.Sqrt(mass.Length); k++) 
                        {
                            if(mass_L[k, i - 1] != inf && mass[k, j] != inf)
                                L = mass_L[k, i - 1] + mass[k,j];


                           // Console.Write(mass_L[k, i-1] + "+" + mass[k, j]+"|");
                        
                            if(L < min)
                                min = L; 
                        }
                       // Console.Write(" min = " + min);
                       if(j != choice - 1)
                           mass_L[j, i] = min;
                    }
                    
                    //Console.WriteLine("");
                }
            }

            Console.WriteLine("\nА вот и табличка длин минимальных путей");

            for (int i = 0; i < Math.Sqrt(mass.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(mass.Length); j++)
                {
                    if(mass_L[i, j] == inf)
                        Console.Write("inf ");
                    else
                        Console.Write(mass_L[i,j].ToString().PadRight(3) + " ");

                }
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}