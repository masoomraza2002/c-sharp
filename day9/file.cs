using System;

class Filee
{
    public static void filee()
    {
        FileStream file = null;
        try
        {
            file = new FileStream("data.txt", FileMode.Open);
            int data = file.ReadByte();
        }catch(FileNotFoundException ex)
        {
            Console.WriteLine("file not found " + ex.Message);
        }
        finally
        {
            if(file != null)
            {
                Console.WriteLine("abc");
            }
        }
    }
}