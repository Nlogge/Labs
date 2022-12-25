using System.Security.Cryptography;

int x = 10;
int y = 10;
int z;
int c;
int[,] nums2;
Console.WriteLine("Введите число");
z= Convert.ToInt32( Console.ReadLine());
Console.WriteLine("Введите число2");
c = Convert.ToInt32( Console.ReadLine());
nums2 = new int[x,y];
for (int i = 1; i < x; i++) {
    var rnd = new Random();
    nums2[i,i] = rnd.Next(z,c);
    Console.WriteLine(nums2[i,i]);
}
Console.ReadKey();
