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

namespace MapClass;
{
public class Map    //map class
{
    private string[,] arr2dTile;     //private member arrays and variables          
    Enemy[] arrEnemy;
    Item[] arrItem;
    private int width;
    private int height;
    int X;
    int Y;
    public static Hero heroObj;    //objects          
    Hero randomObj;
    Enemy enemyObj;
    Gold goldObj;

    public string[,] arr2dTileMap { get { return arr2dTile; } set { arr2dTile = value; } }  //public accessors
    public Hero _heroObj { get { return heroObj; } set { heroObj = value; } }
    public Enemy[] _arrEnemy { get { return arrEnemy; } set { arrEnemy = value; } }
    public int mapWidth { get { return width; } set { width = value; } }
    public int mapHeight { get { return height; } set { height = value; } }
    public Enemy _enemyObj { get { return enemyObj; } set { enemyObj = value; } }

    public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int goldAmount)    //constructor for Map class
    {
        arrItem = new Item[goldAmount]; //Item array
        Random randomHeight = new Random();  //randomizer for height
        height = randomHeight.Next(minHeight, maxHeight + 1);

        Random randomWidth = new Random();  //randomizer for width
        width = randomWidth.Next(minWidth, maxWidth + 1);

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
            Create(Tile.TileEnumType.gold);
            arrItem[i] = goldObj;
        }
    }

    private Tile Create(Tile.TileEnumType type)     //method to create objects (hero and enemy) and place them on the map
    {
        Random randomX = new Random();  //randomizer for X value
        X = randomX.Next(1, width - 1);

        Random randomY = new Random();  //randomizer for Y value
        Y = randomY.Next(1, height - 1);

        Random randomEnemy = new Random();  //randomizer for enemies
        int randEnem = randomEnemy.Next(0, 2);

        if (type == Tile.TileEnumType.gold)
        {
            arr2dTile[X, Y] = "© ";
            goldObj = new Gold(X, Y);
            goldObj.X = X;
            goldObj.Y = Y;
        }

        while (true)
        {
            if (type == Tile.TileEnumType.hero)
            {
                if (arr2dTile[X, Y] == ". ")    //checking the 2D tile array (game map) at the X and Y position to ensure that it is blank for hero
                {
                    arr2dTile[X, Y] = "H ";    //assigning the letter H for Hero to the 2d array Tile at a specified position                         
                    Map.heroObj.X = X;
                    Map.heroObj.Y = Y;
                    heroObj = UpdateHp();   //calling the UpdateHp method to return values to be assigned to the hero object
                    return heroObj;
                }
            }
            else if (type == Tile.TileEnumType.enemy)
            {
                if (arr2dTile[X, Y] == ". " && randEnem == 0)    //checking the 2D tile array (game map) at the X and Y position to ensure that it is blank for enemy
                {
                    arr2dTile[X, Y] = "G ";    //assigning the letter G for Goblin to the 2d array Tile at a specified position
                    enemyObj = new Goblin(X, Y);     //creating enemy object                          
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
            }
            X = randomX.Next(1, width - 1);    //random "reroll"
            Y = randomY.Next(1, height - 1);
        }
    }

    public void UpdateVision(Character Hero)  //method to update the character vision array called arrTile
    {
        if (arr2dTile[Hero.X, Hero.Y + 1] == "G " || arr2dTile[Hero.X, Hero.Y + 1] == "X " || arr2dTile[Hero.X, Hero.Y + 1] == ". ")      //east or right of hero character         
        {
            Hero.arrTile[2] = arr2dTile[Hero.X, Hero.Y + 1];
        }

        if (arr2dTile[Hero.X + 1, Hero.Y] == "G " || arr2dTile[Hero.X + 1, Hero.Y] == "X " || arr2dTile[Hero.X, Hero.Y + 1] == ". ")     //south or below the hero character
        {
            Hero.arrTile[1] = arr2dTile[Hero.X + 1, Hero.Y];
        }

        if (arr2dTile[Hero.X, Hero.Y - 1] == "G " || arr2dTile[Hero.X, Hero.Y - 1] == "X " || arr2dTile[Hero.X, Hero.Y + 1] == ". ")     //west or left of hero character
        {
            Hero.arrTile[3] = arr2dTile[Hero.X, Hero.Y - 1];
        }

        if (arr2dTile[Hero.X - 1, Hero.Y] == "G " || arr2dTile[Hero.X - 1, Hero.Y] == "X " || arr2dTile[Hero.X, Hero.Y + 1] == ". ")     //north or above the hero character
        {
            Hero.arrTile[0] = arr2dTile[Hero.X - 1, Hero.Y];
        }
    }

    public Hero UpdateHp()  //method to randomize player's HP
    {
        Random randomX = new Random();  //randomizer for HP
        int hP = randomX.Next(75, 100 + 1);

        randomObj = new Hero(X, Y, "H ", hP, hP);   //updating Hero object with values
        return randomObj;
    }
}