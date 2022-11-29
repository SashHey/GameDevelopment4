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
using static SashaHeyburgh_19336832_GADE6112_Task1.Form1.Character;
using static SashaHeyburgh_19336832_GADE6112_Task1.Form1.Tile;
using static SashaHeyburgh_19336832_GADE6112_Task1.Form1;

namespace MapClass
{
    [Serializable]
    public class Map    //map class
    {
        private string[,] arr2dTile;     //private member arrays and variables          
        Enemy[] arrEnemy;
        Item[] arrItem;
        private int width;
        private int height;
        int X;
        int Y;
        private static Hero heroObj;    //objects          
        public Hero randomObj;
        Enemy enemyObj;
        Gold goldObj;
        Weapon weaponObj;

        public string[,] arr2dTileMap { get { return arr2dTile; } set { arr2dTile = value; } }  //public accessors
        public Hero _heroObj { get { return heroObj; } set { heroObj = value; } }
        public Enemy[] _arrEnemy { get { return arrEnemy; } set { arrEnemy = value; } }
        public int mapWidth { get { return width; } set { width = value; } }
        public int mapHeight { get { return height; } set { height = value; } }
        public Enemy _enemyObj { get { return enemyObj; } set { enemyObj = value; } }

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int goldAmount, int weaponAmount)    //constructor for Map class
        {
            arrItem = new Item[goldAmount + weaponAmount]; //Item array
            Random randomHeightWidth = new Random();  //randomizer for height
            height = randomHeightWidth.Next(minHeight, maxHeight + 1);
            width = randomHeightWidth.Next(minWidth, maxWidth + 1);

            this.arr2dTile = new string[width, height];  //creating 2D Tile array and enemy array
            this.arrEnemy = new Enemy[numEnemies];

            for (int i = 0; i < width; i++)  //creating rows
            {
                for (int k = 0; k < height; k++)     //creating columns
                {
                    this.arr2dTile[i, k] = ". ";    //filling the map (2D array) with ". " and "X "
                    this.arr2dTile[i, 0] = "X ";
                    this.arr2dTile[0, k] = "X ";
                    this.arr2dTile[width - 1, k] = "X ";
                    this.arr2dTile[i, height - 1] = "X ";
                }
            }

            heroObj = new Hero(0, 0, "H ", 0, 0);
            Create(Tile.TileEnumType.hero);   //calling the Create method for hero

            for (int e = 0; e < numEnemies; e++)    //for loop to loop through the number of enemies
            {
                Create(Tile.TileEnumType.enemy);    //calling the Create method for enemy
                arrEnemy[e] = enemyObj;
            }
            UpdateVision(heroObj);     //calling the UpdateVision method for heros

            for (int i = 0; i < goldAmount; i++)
            {
                System.Threading.Thread.Sleep(250); //pause thread to allow for more randomized gold amounts
                Create(Tile.TileEnumType.gold);
                arrItem[i] = goldObj;
            }

            for (int i = goldAmount; i < arrItem.Length; i++)
            {
                System.Threading.Thread.Sleep(250); //pause thread to allow for more randomized gold amounts
                Create(Tile.TileEnumType.weapon);
                arrItem[i] = weaponObj;
            }
        }
        
        private Tile Create(Tile.TileEnumType type)     //method to create objects (hero and enemy) and place them on the map
        {
            Random randomGen = new Random();  //randomizer object created
            X = randomGen.Next(1, width - 1);           
            Y = randomGen.Next(1, height - 1);
           
            int randEnem = randomGen.Next(0, 2);
            
            while (true)
            {
                X = randomGen.Next(1, width - 1);    //random "reroll"
                Y = randomGen.Next(1, height - 1);

                if (type == Tile.TileEnumType.gold) //adding gold to the map
                {
                    if (arr2dTile[X, Y] == ". ")
                    {                                            
                        arr2dTile[X, Y] = "© ";
                        goldObj = new Gold(X, Y);
                        return goldObj;
                    }
                }

                if (type == Tile.TileEnumType.hero)
                {
                    if (arr2dTile[X, Y] == ". ")    //checking the 2D tile array (game map) at the X and Y position to ensure that it is blank for hero
                    {
                        arr2dTile[X, Y] = "H ";    //assigning the letter H for Hero to the 2d array Tile at a specified position                         
                        this._heroObj.X = X;
                        this._heroObj.Y = Y;
                        heroObj = UpdateHp();   //calling the UpdateHp method to return values to be assigned to the hero object
                        return heroObj;
                    }
                }
                else if (type == Tile.TileEnumType.enemy)
                {
                    randEnem = randomGen.Next(3);

                    if (arr2dTile[X, Y] == ". " && randEnem == 0)    //checking the 2D tile array (game map) at the X and Y position to ensure that it is blank for enemy
                    {
                        arr2dTile[X, Y] = "G ";    //assigning the letter G for Goblin to the 2d array Tile at a specified position
                        Weapon woopen = new MeleeWeapon(MeleeWeapon.TypesEnum.Dagger, "D ");
                        enemyObj = new Goblin(X, Y, woopen);     //creating enemy object                          
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return enemyObj;
                    }
                    else if (arr2dTile[X, Y] == ". " && randEnem == 1)
                    {
                        arr2dTile[X, Y] = "M ";    //assigning the letter M for Mage to the 2d array Tile at a specified position
                        enemyObj = new Mage(X, Y);     //creating enemy object                          
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return enemyObj;
                    }
                    else if (arr2dTile[X, Y] == ". " && randEnem == 2)
                    {
                        arr2dTile[X, Y] = "L ";    //assigning the letter L for Leader to the 2d array Tile at a specified position
                        Weapon woopen = new MeleeWeapon(MeleeWeapon.TypesEnum.Longsword, "S ");
                        enemyObj = new Leader(X, Y, woopen);     //creating enemy object                          
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return enemyObj;
                    }
                }
                if (type == Tile.TileEnumType.weapon) //adding weapons to the map
                {
                    randEnem = randomGen.Next(4);

                    if (arr2dTile[X, Y] == ". " && randEnem == 0)    //checking the 2D tile array (game map) at the X and Y position to ensure that it is blank 
                    {                       
                        weaponObj = new MeleeWeapon(MeleeWeapon.TypesEnum.Dagger, "D ", X, Y);     //creating weapon object  
                        arr2dTile[X, Y] = "D ";    //assigning the letter D for Dagger to the 2d array Tile at a specified position
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return weaponObj;
                    }
                    else if (arr2dTile[X, Y] == ". " && randEnem == 1)
                    {
                        weaponObj = new MeleeWeapon(MeleeWeapon.TypesEnum.Longsword, "S ", X, Y);     //creating weapon object       
                        arr2dTile[X, Y] = "S ";    //assigning the letter S for Longsword to the 2d array Tile at a specified position
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return weaponObj;
                    }
                    else if (arr2dTile[X, Y] == ". " && randEnem == 2)
                    {
                        weaponObj = new RangedWeapon(RangedWeapon.TypesEnum.Longbow, "B ", X, Y);     //creating weapon object    
                        arr2dTile[X, Y] = "B ";    //assigning the letter B for Longbow to the 2d array Tile at a specified position
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return weaponObj;
                    }
                    else if (arr2dTile[X, Y] == ". " && randEnem == 3)
                    {
                        weaponObj = new RangedWeapon(RangedWeapon.TypesEnum.Rifle, "R ", X, Y);     //creating weapon object 
                        arr2dTile[X, Y] = "R ";    //assigning the letter R for Rifle to the 2d array Tile at a specified position
                        enemyObj.X = X;
                        enemyObj.Y = Y;
                        return weaponObj;
                    }
                }
            }
        }

        public void UpdateVision(Character Hero)  //method to update the character vision array called arrTile
        {
            if (Hero != null)
            {
                Hero.arrTile[2] = arr2dTile[Hero.X, Hero.Y + 1];    //right
                Hero.arrTile[1] = arr2dTile[Hero.X + 1, Hero.Y];    //down
                Hero.arrTile[3] = arr2dTile[Hero.X, Hero.Y - 1];    //left
                Hero.arrTile[0] = arr2dTile[Hero.X - 1, Hero.Y];    //up
            }               
        }

        public Hero UpdateHp()  //method to randomize player's HP
        {
            Random randomX = new Random();  //randomizer for HP
            int hP = randomX.Next(75, 100 + 1);

            randomObj = new Hero(X, Y, "H ", hP, hP);   //updating Hero object with values
            return randomObj;
        }

        public Item GetItemAtPosition(int x, int y) //GetItemAtPosition() method to search the Item array for an existing item at position X,Y
        {
            for (int i = 0; i < arrItem.Length; i++)
            {
                if (arrItem[i] != null && arrItem[i].X == x && arrItem[i].Y == y)
                {
                    Item placeHolderItem = arrItem[i];  //creates a temporary item to return 
                    arrItem[i] = null;
                    return placeHolderItem;
                }          
            }
            return null;
        }
    }
}