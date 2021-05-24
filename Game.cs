using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class Game
{
    public Game()
    {
        Program.awake += Awake;
        Program.update += Update;
    }

    public virtual void Awake()
    {

    }

    public virtual void Update()
    {

    }
}
