//Sasha_Heyburgh_19336832_GADE6112

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SashaHeyburgh_19336832_GADE6112_Task1;
using static SashaHeyburgh_19336832_GADE6112_Task1.Form1.Character;
using static SashaHeyburgh_19336832_GADE6112_Task1.Form1.Tile;
using static SashaHeyburgh_19336832_GADE6112_Task1.Form1;
using MapClass;
using ShopClass;
using System.Net.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace GameEngineClass
{
    [Serializable]
    public class GameEngine
    {
        BinaryFormatter binaryForm = new BinaryFormatter();
        private Map map;     //declaring variables and accessors
        public Map _map { get { return map; } set { map = value; } }

        int numEnemies;
        int numWeapons;

        public int _numEnemies { get { return numEnemies; } set { numEnemies = value; } }

        public Shop shopObj;

        public GameEngine()     //constructor for GameEngine
        {
            Random randomEW = new Random();  //randomizer for the number of enemies and weapons
            numEnemies = randomEW.Next(3, 6);
            numWeapons = randomEW.Next(1, 4);

            int goldAmount = numEnemies;
            map = new Map(_minWidth, _maxWidth, _minHeight, _maxHeight, numEnemies, goldAmount, numWeapons);     //creating map object              
        }

        public bool MovePlayer(Character hero, MovementEnum direction)
        {
            CanBuyCheck();
            while (true)  //while loop to check for valid movement
            {
                CanBuyCheck();
                if (direction == MovementEnum.up)    //directions
                {
                    if (hero.arrTile[0] == ". " || hero.arrTile[0] == "© " || hero.arrTile[0] == "B " || hero.arrTile[0] == "D " || hero.arrTile[0] == "R " || hero.arrTile[0] == "S ")  //positions in array
                    {
                        GameEngineObj._map.arr2dTileMap[hero.X, hero.Y] = ". ";     //setting Hero's initialize position to ". "
                        GameEngineObj._map.arr2dTileMap[hero.X - 1, hero.Y] = "H ";    //setting Hero's new position to display "H "
                        if (hero.arrTile[0] != ". ")
                        {
                            hero.Pickup(GameEngineObj._map.GetItemAtPosition(hero.X - 1, hero.Y));
                            CanBuyCheck();
                        }
                        hero.X = hero.X - 1;
                        map = GameEngineObj._map;
                        GameEngineObj._map.UpdateVision(hero);

                        for (int e = 0; e < GameEngineObj._numEnemies; e++)    //for loop to loop through the number of enemies
                        {
                            if (GameEngineObj._map._arrEnemy[e] is Goblin || GameEngineObj._map._arrEnemy[e] is Leader)
                            {
                                MoveEnemies(e);
                                EnemyAttacks(GameEngineObj._map._arrEnemy[e]);
                                UpdateEnemtStat();
                                GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[e]);
                            }
                        }

                        return true;     //up                          
                    }
                    else
                    {
                        map = GameEngineObj._map;
                        return false;     //no movement
                    }
                }
                else if (direction == MovementEnum.down)
                {
                    if (hero.arrTile[1] == ". " || hero.arrTile[1] == "© " || hero.arrTile[1] == "B " || hero.arrTile[1] == "D " || hero.arrTile[1] == "R " || hero.arrTile[1] == "S ")
                    {
                        GameEngineObj._map.arr2dTileMap[hero.X, hero.Y] = ". ";
                        GameEngineObj._map.arr2dTileMap[hero.X + 1, hero.Y] = "H ";
                        if (hero.arrTile[1] != ". ")
                        {
                            hero.Pickup(GameEngineObj._map.GetItemAtPosition(hero.X + 1, hero.Y));
                            CanBuyCheck();
                        }
                        hero.X = hero.X + 1;
                        map = GameEngineObj._map;
                        GameEngineObj._map.UpdateVision(hero);

                        for (int e = 0; e < GameEngineObj._numEnemies; e++)    //for loop to loop through the number of enemies
                        {
                            if (GameEngineObj._map._arrEnemy[e] is Goblin || GameEngineObj._map._arrEnemy[e] is Leader)
                            {
                                MoveEnemies(e);
                                EnemyAttacks(GameEngineObj._map._arrEnemy[e]);
                                UpdateEnemtStat();
                                GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[e]);
                            }
                        }

                        return true;   //down                     
                    }
                    else
                    {
                        map = GameEngineObj._map;
                        return false;     //no movement
                    }
                }
                else if (direction == MovementEnum.right)
                {
                    if (hero.arrTile[2] == ". " || hero.arrTile[2] == "© " || hero.arrTile[2] == "B " || hero.arrTile[2] == "D " || hero.arrTile[2] == "R " || hero.arrTile[2] == "S ")
                    {
                        GameEngineObj._map.arr2dTileMap[hero.X, hero.Y] = ". ";
                        GameEngineObj._map.arr2dTileMap[hero.X, hero.Y + 1] = "H ";
                        if (hero.arrTile[2] != ". ")
                        {
                            hero.Pickup(GameEngineObj._map.GetItemAtPosition(hero.X, hero.Y + 1));
                            CanBuyCheck();
                        }
                        hero.Y = hero.Y + 1;
                        map = GameEngineObj._map;
                        GameEngineObj._map.UpdateVision(hero);

                        for (int e = 0; e < GameEngineObj._numEnemies; e++)    //for loop to loop through the number of enemies
                        {
                            if (GameEngineObj._map._arrEnemy[e] is Goblin || GameEngineObj._map._arrEnemy[e] is Leader)
                            {
                                MoveEnemies(e);
                                EnemyAttacks(GameEngineObj._map._arrEnemy[e]);
                                UpdateEnemtStat();
                                GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[e]);
                            }
                        }

                        return true;  //right                           
                    }
                    else
                    {
                        map = GameEngineObj._map;
                        return false;     //no movement
                    }
                }
                else if (direction == MovementEnum.left)
                {
                    if (hero.arrTile[3] == ". " || hero.arrTile[3] == "© " || hero.arrTile[3] == "B " || hero.arrTile[3] == "D " || hero.arrTile[3] == "R " || hero.arrTile[3] == "S ")
                    {
                        GameEngineObj._map.arr2dTileMap[hero.X, hero.Y] = ". ";
                        GameEngineObj._map.arr2dTileMap[hero.X, hero.Y - 1] = "H ";
                        if (hero.arrTile[3] != ". ")
                        {
                            hero.Pickup(GameEngineObj._map.GetItemAtPosition(hero.X, hero.Y - 1));
                            CanBuyCheck();
                        }
                        hero.Y = hero.Y - 1;
                        map = GameEngineObj._map;
                        GameEngineObj._map.UpdateVision(hero);

                        for (int e = 0; e < GameEngineObj._numEnemies; e++)    //for loop to loop through the number of enemies
                        {
                            if (GameEngineObj._map._arrEnemy[e] is Goblin || GameEngineObj._map._arrEnemy[e] is Leader)
                            {
                                MoveEnemies(e);
                                EnemyAttacks(GameEngineObj._map._arrEnemy[e]);
                                UpdateEnemtStat();
                                GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[e]);
                            }
                        }

                        return true;   //left                           
                    }
                    else
                    {
                        map = GameEngineObj._map;
                        return false;     //no movement
                    }
                }
                else
                {
                    map = GameEngineObj._map;
                    return false;     //no movement
                }
            }
        }

        public void EnemyAttacks(Character attacker)    //method for the enemy to attack
        {
            if (attacker is Mage)
            {
                for (int t = 0; t < numEnemies; t++)
                {
                    if (attacker.CheckRange(GameEngineObj._map._arrEnemy[t]) == true)   //calling CheckRange method
                    {
                        GameEngineObj._map._arrEnemy[t].HP = GameEngineObj._map._arrEnemy[t].HP - attacker.damage;    //setting the hero's HP to subtract the enemy's damage during attack
                    }
                }
            }
            if (attacker != null)
            {
                if (attacker.CheckRange(GameEngineObj._map._heroObj) == true)
                {
                    GameEngineObj._map._heroObj.HP = GameEngineObj._map._heroObj.HP - attacker.damage;
                }
            }
        }

        public bool MoveEnemies(int Enemy)  //method for the enemies to move
        {
            int enemX = GameEngineObj._map._arrEnemy[Enemy].X;
            int enemY = GameEngineObj._map._arrEnemy[Enemy].Y;
            Enemy actualEnemy = GameEngineObj._map._arrEnemy[Enemy];

            GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[Enemy]);            

            while (true)
            {
                MovementEnum direct = actualEnemy.ReturnMove();
                if (direct == MovementEnum.up) //checking for obstacles (up)
                {
                    if (actualEnemy.arrTile[0] == "B " || actualEnemy.arrTile[0] == "D " || actualEnemy.arrTile[0] == "R " || actualEnemy.arrTile[0] == "S ")
                    {
                        GameEngineObj._map._arrEnemy[Enemy].Pickup(GameEngineObj._map.GetItemAtPosition(enemX - 1, enemY));
                    }
                    
                    GameEngineObj._map.arr2dTileMap[enemX, enemY] = ". ";     //setting Goblin's initialize position to ". "
                    GameEngineObj._map.arr2dTileMap[enemX - 1, enemY] = actualEnemy.symbol;    //setting Goblin's new position to display "G "
                                      
                    GameEngineObj._map._arrEnemy[Enemy].X = enemX - 1;
                    map = GameEngineObj._map;
                    GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);

                    for (int a = 0; a < GameEngineObj._numEnemies; a++) //for loop to update the enemy's vision
                    {
                        GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[a]);
                    }

                    return true;
                }
                else if (direct == MovementEnum.down) //(down)
                {
                    if (actualEnemy.arrTile[1] == "B " || actualEnemy.arrTile[1] == "D " || actualEnemy.arrTile[1] == "R " || actualEnemy.arrTile[1] == "S ")
                    {
                        GameEngineObj._map._arrEnemy[Enemy].Pickup(GameEngineObj._map.GetItemAtPosition(enemX + 1, enemY));
                    }

                    GameEngineObj._map.arr2dTileMap[enemX, enemY] = ". ";
                    GameEngineObj._map.arr2dTileMap[enemX + 1, enemY] = actualEnemy.symbol;
                    
                    GameEngineObj._map._arrEnemy[Enemy].X = enemX + 1;
                    map = GameEngineObj._map;
                    GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);

                    for (int a = 0; a < GameEngineObj._numEnemies; a++)
                    {
                        GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[a]);
                    }

                    return true;
                }
                else if (direct == MovementEnum.right) //(right)
                {
                    if (actualEnemy.arrTile[2] == "B " || actualEnemy.arrTile[2] == "D " || actualEnemy.arrTile[2] == "R " || actualEnemy.arrTile[2] == "S ")
                    {
                        GameEngineObj._map._arrEnemy[Enemy].Pickup(GameEngineObj._map.GetItemAtPosition(enemX, enemY + 1));
                    }

                    GameEngineObj._map.arr2dTileMap[enemX, enemY] = ". ";
                    GameEngineObj._map.arr2dTileMap[enemX, enemY + 1] = actualEnemy.symbol;                    

                    GameEngineObj._map._arrEnemy[Enemy].Y = enemY + 1;
                    map = GameEngineObj._map;
                    GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);

                    for (int a = 0; a < GameEngineObj._numEnemies; a++)
                    {
                        GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[a]);
                    }

                    return true;
                }
                else if (direct == MovementEnum.left) //(left)
                {
                    if (actualEnemy.arrTile[3] == "B " || actualEnemy.arrTile[3] == "D " || actualEnemy.arrTile[3] == "R " || actualEnemy.arrTile[3] == "S ")
                    {
                        GameEngineObj._map._arrEnemy[Enemy].Pickup(GameEngineObj._map.GetItemAtPosition(enemX, enemY - 1));
                    }

                    GameEngineObj._map.arr2dTileMap[enemX, enemY] = ". ";
                    GameEngineObj._map.arr2dTileMap[enemX, enemY - 1] = actualEnemy.symbol;                   

                    GameEngineObj._map._arrEnemy[Enemy].Y = enemY - 1;
                    map = GameEngineObj._map;
                    GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);

                    for (int a = 0; a < GameEngineObj._numEnemies; a++)
                    {
                        GameEngineObj._map.UpdateVision(GameEngineObj._map._arrEnemy[a]);
                    }

                    return true;
                }
                else if (direct == MovementEnum.noMovement)
                {
                    return true;
                }
            }
        }

        public void Save()  //method to save the entire map (serializing)
        {           
            FileStream fileStream = new FileStream("Save.dat", FileMode.Create, FileAccess.Write);   //save file directory
            binaryForm.Serialize(fileStream, map);  //serializing map to file
            fileStream.Close();
        }

        public void Load()  //method to load the entire map (deserializing)
        {
            if (File.Exists("Save.dat"))  //checking if the file exists
            {
                FileStream fileStream = new FileStream("Save.dat", FileMode.Open, FileAccess.Read);
                this.map = (Map)binaryForm.Deserialize(fileStream);
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }
    }
}
