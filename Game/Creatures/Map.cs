﻿using Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    public class Map
    {
        public string[,] map;
        public List<Wall> wallsinmap;
        public List<NextLevel> nextleveldoors;
        public List<Door> doors;
        public List<Treasure> treasures;
        public List<Potion> potions;

        int wall_counter = 0;
        int nextleveldoors_counter = 0;
        int door_counter = 0;
        int treasures_counter = 0;
        int potions_counter = 0;
        public Map(string[,] map)
        {
            this.map = map;

            
            wallsinmap = new List<Wall>();
            nextleveldoors = new List<NextLevel>();
            doors = new List<Door>();
            treasures = new List<Treasure>();
            potions = new List<Potion>();

            //K
            int mlply = 20;
            //

            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * mlply, i * mlply), 20, 20);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = 20;
                        sciana.Body.Height = 20;

                        wallsinmap.Add(sciana);
                        
                        wall_counter++;

                    }
                    if (map[i, j] == "d")
                    {


                        NextLevel next_lvl_door = new NextLevel(new Vector2(j * mlply, i * mlply), 20, 20);
                        next_lvl_door.Body = new System.Windows.Shapes.Rectangle();

                        next_lvl_door.Body.Width = 20;
                        next_lvl_door.Body.Height = 20;

                        nextleveldoors.Add(next_lvl_door);

                        nextleveldoors_counter++;

                    }
                    if (map[i, j] == "t")
                    {


                        Treasure treasure = new Treasure(new Vector2(j * mlply, i * mlply), 20, 20);
                        treasure.Body = new System.Windows.Shapes.Rectangle();

                        treasure.Body.Width = 20;
                        treasure.Body.Height = 20;

                        treasures.Add(treasure);

                        treasures_counter++;

                    }
                    char temp = char.Parse(map[i, j]);
                    if (Char.IsDigit(temp))
                    {
                        Door door = new Door(new Vector2(j * mlply, i * mlply), 20, 20, temp-'0');
                        door.Body.Width = 20;
                        door.Body.Height = 20;

                        doors.Add(door);
                        door_counter++;
                    }

                    //K - start
                    if (map[i, j] == "p")
                    {
                        Potion potion;
                        Random random = new Random();
                        int Type = random.Next(0, 4);
                        int width = 20, height = 30;

                        if (Type == 0)
                        { 
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.HealthRegeneration);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 1)
                        { 
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.StaminaRegenerationBoost);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 2) 
                        { 
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.HigherAttackValue);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 3) 
                        { 
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.HigherDefenceValue);
                            potions.Add(potion);
                            potions_counter++;
                        }
                    }
                    // - end
                }
            }
        }

        public void changeMap(string[,] map)
        {
            this.map = map;

            wall_counter = 0;
            nextleveldoors_counter = 0;

            wallsinmap.Clear();
            nextleveldoors.Clear();
            doors.Clear();
            treasures.Clear();
            potions.Clear();

            //K
            int mlply = 20;
            //
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * mlply, i * mlply), 20, 20);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = 20;
                        sciana.Body.Height = 20;

                        wallsinmap.Add(sciana);

                        wall_counter++;

                    }
                    if (map[i, j] == "d")
                    {


                        NextLevel door = new NextLevel(new Vector2(j * mlply, i * mlply), 20, 20);
                        door.Body = new System.Windows.Shapes.Rectangle();

                        door.Body.Width = 20;
                        door.Body.Height = 20;

                        nextleveldoors.Add(door);
                        nextleveldoors_counter++;
                        //wallsinmap.Add(door);

                        //wall_counter++;

                    }
                    if (map[i, j] == "t")
                    {


                        Treasure treasure = new Treasure(new Vector2(j * mlply, i * mlply), 60, 60);
                        
                        //treasure.Body = new System.Windows.Shapes.Rectangle();
                     

                        treasure.Body.Width = 60;
                        treasure.Body.Height = 60;

                        treasures.Add(treasure);

                        treasures_counter++;

                    }
                    string temp2 = map[i, j];
                    char[] temp1 = temp2.ToCharArray();
                    char temp = temp1[0];
                    if (Char.IsDigit(temp))
                    {
                        Door door = new Door(new Vector2(j * mlply, i * mlply), 20, 20, temp - '0');
                        door.Body = new System.Windows.Shapes.Rectangle();

                        door.Body.Width = 20;
                        door.Body.Height = 20;

                        doors.Add(door);
                        door_counter++;
                    }


                    //K - start
                    if (map[i, j] == "p")
                    {
                        Potion potion;
                        Random random = new Random();
                        int Type = random.Next(0, 4);
                        int width = 20, height = 30;

                        if (Type == 0)
                        {
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.HealthRegeneration);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 1)
                        {
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.StaminaRegenerationBoost);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 2)
                        {
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.HigherAttackValue);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 3)
                        {
                            potion = new Potion(new Vector2(j * mlply, i * mlply), width, height, TypeOfPotion.HigherDefenceValue);
                            potions.Add(potion);
                            potions_counter++;
                        }
                    }
                    // - end
                }
            }
        }
    }
}
