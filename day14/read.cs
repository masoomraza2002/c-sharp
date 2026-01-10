using System;

class Binaryy
{
    public static void binaryy()
    {

        using (BinaryReader reader = new BinaryReader(File.Open("user.bin", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadInt32());

        }
    }
}
