using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Vector2
    {
        public int x;
        public int y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2 (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 Zero = new Vector2(0, 0);
        public static Vector2 One = new Vector2(1, 1);

        public static Vector2 Rand(int min, int max)
        {
            Random rand = new Random();

            int x = rand.Next(min, max);
            int y = rand.Next(min, max);

            return new Vector2(x, y);
        }
    }

    public class Settings
    {
        public char floorChar = '.';
        public char wallChar = '#';

        public char bongoChar = 'B';
        public char wizardChar = 'W';
    }

    public class Dungeon
    {
        public string name;
        public int[][] dungeonLayout { get; private set; }
        public Vector2 spawnPosition { get; private set; }

        public Dungeon()
        {

        }

        public Dungeon(int[][] dungeonLayout)
        {
            this.dungeonLayout = dungeonLayout;
            spawnPosition = Vector2.One;
        }

        public Dungeon(int[][] dungeonLayout, Vector2 spawnPosition)
        {
            this.dungeonLayout = dungeonLayout;
            this.spawnPosition = spawnPosition;
        }

        public Dungeon(int[][] dungeonLayout, Vector2 spawnPosition, string name)
        {
            this.dungeonLayout = dungeonLayout;
            this.spawnPosition = spawnPosition;
            this.name = name;
        }
    }
}
