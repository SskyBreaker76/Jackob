using System;
using Classes;
using System.Collections.Generic;
using System.Text;

public class BongoWizard : Game
{
    public GameState currentState = GameState.Title;

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
            new int[] { 0,1,1,1,0,1,0,0,0,0,0,0,0,0,1,0 },
            new int[] { 0,0,1,0,1,1,1,0,1,1,1,0,1,1,1,0 },
            new int[] { 0,0,1,1,1,0,1,0,1,0,1,0,1,0,0,0 },
            new int[] { 0,0,0,0,0,0,1,1,1,0,1,0,1,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        testDungeon = new Dungeon(map, new Vector2(2, 2), "Test Dungeon");

        playerPosition = testDungeon.spawnPosition;
    }

    public void RenderMap()
    {
        Console.Clear();
        Console.WriteLine($"\n=====[ {testDungeon.name.ToUpper()} ]=====\n\n Use the [ARROW KEYS] to move your character\n Press [ESC] to quit the game!\n");

        for (int y = 0; y < testDungeon.dungeonLayout.Length; y++)
        {
            string l = "\t";

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

    bool noRefresh = false;

    public override void Update()
    {
        base.Update();

        ConsoleKeyInfo inf = new ConsoleKeyInfo();

        if (currentState == GameState.InLevel)
        {
            if (noRefresh == false)
                RenderMap();

            do
            {
                while (Console.KeyAvailable == false)
                {
                }

                inf = Console.ReadKey(true);
            }
            while (inf.Key != ConsoleKey.UpArrow &&
            inf.Key != ConsoleKey.DownArrow &&
            inf.Key != ConsoleKey.LeftArrow &&
            inf.Key != ConsoleKey.RightArrow &&
            inf.Key != ConsoleKey.Escape &&
            inf.Key != ConsoleKey.F3);

            Vector2 oldPos = new Vector2(playerPosition.x, playerPosition.y);

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

            if (inf.Key == ConsoleKey.Escape)
            {
                currentState = GameState.QuitConfirmation;
            }

            if (inf.Key == ConsoleKey.F3)
            {
                Console.WriteLine($"Player Position: {playerPosition.x},{playerPosition.y}");
                noRefresh = true;
            }
            else
            {
                noRefresh = false;
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
        }
        else if (currentState == GameState.Title)
        {
            Console.Clear();
            Console.WriteLine("=====[ BONGO WIZARD ]=====");
            Console.WriteLine("  ===[   THE GAME   ]===");
            Console.WriteLine("\n [N]ew Game\n [Q]uit Game");

            do
            {
                while (Console.KeyAvailable == false)
                {

                }

                inf = Console.ReadKey(true);
            }
            while (inf.Key != ConsoleKey.N && inf.Key != ConsoleKey.Q);

            if (inf.Key == ConsoleKey.N)
            {
                currentState = GameState.InLevel;
            }
            else
            {
                Program.Quit();
            }
        }
        else if (currentState == GameState.QuitConfirmation)
        {
            Console.Clear();
            Console.WriteLine("=====[ ARE YOU SURE YOU WANT TO QUIT THE GAME? ]=====");
            Console.WriteLine("\n [Y] - Yes\n [N] - No");

            do
            {
                while (Console.KeyAvailable == false)
                {

                }

                inf = Console.ReadKey(true);
            }
            while (inf.Key != ConsoleKey.Y && inf.Key != ConsoleKey.N);

            if (inf.Key == ConsoleKey.Y)
            {
                Program.Quit();
            }
            else if (inf.Key == ConsoleKey.N)
            {
                currentState = GameState.InLevel;
            }
        }
    }
}
