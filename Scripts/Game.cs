using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class Game
{
    public Classes.Settings settings { get; private set; }

    public Game()
    {
        Program.awake += Awake;
        Program.update += Update;
    }

    public virtual void Awake()
    {
        settings = Program.settings;
    }

    public virtual void Update()
    {

    }
}
