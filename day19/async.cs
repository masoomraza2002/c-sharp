using System;

class Main5
{
    public static async Task main5()
    {
        async Task<int> GetDataAsync()
        {
            await Task.Delay(1000);
            return 42;
        }
        int result = await GetDataAsync();
        Console.WriteLine(result);
    }
}