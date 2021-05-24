using System;
using Classes;
using System.Collections.Generic;
using System.Text;

public class BongoWizard : Game
{
    public Vector2 playerPosition = new Vector2();
    public Dungeon testDungeon = new Dungeon();

    public override void Awake()
    {
        base.Awake();

        int[][] map =
        {
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,1,1,1,0,1,1,1,1,1,1,1,1,0,2,0 },
            new int[] { 0,1,1,1,0,1,0,0,0,0,0,0,0,0,1,0 },
            new int[] { 0,1,1,0,0,1,1,1,0,0,0,0,0,0,1,0 },
            new int[] { 0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        testDungeon = new Dungeon(map, new Vector2(2, 1), "Test Dungeon");

        playerPosition = testDungeon.spawnPosition;
    }

    public void RenderMap()
    {
        Console.Clear();
        Console.WriteLine($"\n=====[ {testDungeon.name.ToUpper()} ]=====\n\n\n");

        for (int y = 0; y < testDungeon.dungeonLayout.Length; y++)
        {
            string l = "";

            for (int x = 0; x < testDungeon.dungeonLayout[y].Length; x++)
            {
                try
                {
                    if (y == 0 || y == testDungeon.dungeonLayout.Length - 1 || x == 0 || x == testDungeon.dungeonLayout[y].Length)
                    {
                        l += settings.wallChar;
                    }
                    else
                    {
                        if (x == playerPosition.x && y == playerPosition.y)
                        {
                            l += settings.wizardChar;
                        }
                        else
                        {
                            if (testDungeon.dungeonLayout[y][x] == 0)
                            {
                                l += settings.wallChar;
                            }
                            else if (testDungeon.dungeonLayout[y][x] == 1)
                            {
                                l += settings.floorChar;
                            }
                            else if (testDungeon.dungeonLayout[y][x] == 2)
                            {
                                l += settings.bongoChar;
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine(l);
                    Console.ReadKey();
                }
            }

            Console.WriteLine(l);
        }
    }

    public override void Update()
    {
        base.Update();

    repeatLoop:

        ConsoleKeyInfo inf = new ConsoleKeyInfo();

        do
        {
            while (Console.KeyAvailable == false)
            {
            }

            inf = Console.ReadKey(false);
        }
        while (inf.Key != ConsoleKey.UpArrow &&
        inf.Key != ConsoleKey.DownArrow &&
        inf.Key != ConsoleKey.LeftArrow &&
        inf.Key != ConsoleKey.RightArrow);

        Vector2 oldPos = playerPosition;

        if (inf.Key == ConsoleKey.UpArrow)
        {
            playerPosition.y -= 1;
        }
        else if (inf.Key == ConsoleKey.DownArrow)
        {
            playerPosition.y += 1;
        }

        if (inf.Key == ConsoleKey.RightArrow)
        {
            playerPosition.x += 1;
        }
        else if (inf.Key == ConsoleKey.LeftArrow)
        {
            playerPosition.x -= 1;
        }

        try
        {
            if (testDungeon.dungeonLayout[playerPosition.y][playerPosition.x] == 0) 
            {
                playerPosition = oldPos;
            } 
        }
        catch
        {

        }

        RenderMap();

        goto repeatLoop;
    }
}
