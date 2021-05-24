using System;
using System.Collections.Generic;
using System.Text;

public class BongoWizard : Game
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();

    repeatLoop:

        ConsoleKey key;

        do
        {

        }
        while (!Console.KeyAvailable);

        goto repeatLoop;
    }
}
