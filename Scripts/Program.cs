using System;

class Program
{
    public static Classes.Settings settings = new Classes.Settings();
    int[,] lv1 = { };
    public static Classes.Dungeon level01 = new Classes.Dungeon();

    public static Action awake;
    public static Action update;

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