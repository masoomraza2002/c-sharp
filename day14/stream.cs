using System;

class Stream
{
    public static void stream()
    {
        using(StreamWriter writer  =  new StreamWriter("log.txt"))
        {
            writer.WriteLine("app started");
            writer.WriteLine("app written");
            writer.WriteLine("app completed");
        }

        using(StreamReader reader =  new StreamReader("log.txt"))
        {
            String line;
            while((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}