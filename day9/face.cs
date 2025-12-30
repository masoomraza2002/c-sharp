using System;
using System.Collections.Generic;

class FacialFeatures
{
    public string EyeColor;
    public decimal PhiltrumWidth;

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        FacialFeatures other = obj as FacialFeatures;
        if (other == null) return false;

        return EyeColor == other.EyeColor &&
               PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return EyeColor.GetHashCode() ^ PhiltrumWidth.GetHashCode();
    }
}

class Identity
{
    public string Email;
    public FacialFeatures Face;

    public Identity(string email, FacialFeatures face)
    {
        Email = email;
        Face = face;
    }

    public override bool Equals(object obj)
    {
        Identity other = obj as Identity;
        if (other == null) return false;

        return Email == other.Email &&
               Face.Equals(other.Face);
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode() ^ Face.GetHashCode();
    }
}

class Authenticator
{
    HashSet<Identity> registered = new HashSet<Identity>();

    Identity admin = new Identity(
        "admin@exerc.ism",
        new FacialFeatures("green", 0.9m)
    );

    public static bool AreSameFace(FacialFeatures a, FacialFeatures b)
    {
        return a.Equals(b);
    }

    public bool IsAdmin(Identity id)
    {
        return id.Equals(admin);
    }

    public bool Register(Identity id)
    {
        if (registered.Contains(id))
            return false;

        registered.Add(id);
        return true;
    }

    public bool IsRegistered(Identity id)
    {
        return registered.Contains(id);
    }

    public static bool AreSameObject(object a, object b)
    {
        return Object.ReferenceEquals(a, b);
    }
}

class Program
{
    static void Main()
    {
        Authenticator auth = new Authenticator();

        
        Console.WriteLine(
            Authenticator.AreSameFace(
                new FacialFeatures("green", 0.9m),
                new FacialFeatures("green", 0.9m)
            )
        );

        
        Identity admin = new Identity(
            "admin@exerc.ism",
            new FacialFeatures("green", 0.9m)
        );
        Console.WriteLine(auth.IsAdmin(admin));

        
        Identity user = new Identity(
            "tunde@thecompetition.com",
            new FacialFeatures("blue", 0.9m)
        );

        Console.WriteLine(auth.Register(user));   
        Console.WriteLine(auth.IsRegistered(user)); 
        Console.WriteLine(auth.Register(user));   

        
        Identity a = user;
        Identity b = user;
        Console.WriteLine(Authenticator.AreSameObject(a, b)); 
    }
}
