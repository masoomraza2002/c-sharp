using System;

class Button
{
    public delegate void clickHandler();

    public event clickHandler clicked;

    public Click()
    {
        Clicked?.Invoked();
    }


}

class Program
{
    public static void Main()
    {
        Button btn = new Button();
        btn.clicked += () => Console.WriteLine("button was clicked");
    }
}