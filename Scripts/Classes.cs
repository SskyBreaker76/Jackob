using System;
using System.Collections.Generic;
using System.Text;

public class Classes
{
    public class Settings
    {
        public char floorChar = ' ';
        public char wallChar = '#';

        public char bongoChar = 'B';
        public char wizardChar = 'W';
    }

    public class Dungeon
    {
        public int[,] dungeonLayout { get; private set; }

        public Dungeon()
        {

        }

        public Dungeon(int[,] dungeonLayout)
        {
            this.dungeonLayout = dungeonLayout;
        }
    }
}
