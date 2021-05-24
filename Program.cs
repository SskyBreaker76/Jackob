using System;

class Program
{
    public static Classes.Settings settings = new Classes.Settings();
    int[,] lv1 = { };
    public static Classes.Dungeon level01 = new Classes.Dungeon();

    public static Action awake = new Action(Dummy);
    public static Action update = new Action(Dummy);

    static void Dummy()
    {

    }

    static void Main(string[] args)
    {
        awake.Invoke();

        bool active = true;

        do
        {
            update.Invoke();
        }
        while (active);
    }
}