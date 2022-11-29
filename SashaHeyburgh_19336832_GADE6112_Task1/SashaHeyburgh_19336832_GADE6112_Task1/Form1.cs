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
using MapClass;
using ShopClass;
using GameEngineClass;
using System.Net.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SashaHeyburgh_19336832_GADE6112_Task1
{
    [Serializable]
    public partial class Form1 : Form
    {
        static Boolean boolUp = false;  //booleans and variables
        static Boolean boolDown = false;
        static Boolean boolLeft = false;
        static Boolean boolRight = false;

        public static int _minWidth;   
        public static int _maxWidth;
        public static int _minHeight;
        public static int _maxHeight;
        public static GameEngine GameEngineObj;

        public Form1()
        {
            InitializeComponent();   
        }

        public ListBox getEnemyList()
        {
            return listEnemies;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _minWidth = 0;  //setting values to 0
            _maxWidth = 0;
            _minHeight = 0;
            _maxHeight = 0;
            btnShopW2.Font = new Font("Bernard MT Condensed", 15); 
        }

        public static void CanBuyCheck()
        {
            if (GameEngineObj.shopObj.CanBuy(0) == true)    //if the buyer (player) can afford it
            {
                btnShopW1.Enabled = true;  //enabling shop button
            }
            if (GameEngineObj.shopObj.CanBuy(1) == true)
            {
                btnShopW2.Enabled = true;
            }
            if (GameEngineObj.shopObj.CanBuy(2) == true)
            {
                btnShopW3.Enabled = true;
            }
        }

        public void Redraw()
        {
            for (int i = 0; i < GameEngineObj._map.mapWidth; i++)  //creating rows
            {
                for (int k = 0; k < GameEngineObj._map.mapHeight; k++)     //creating columns
                {
                    lblMap.Text = lblMap.Text + GameEngineObj._map.arr2dTileMap[i, k];    //filling the game map 2D array with ". " per the rows and columns
                }
                lblMap.Text = lblMap.Text + "\n";
            }
        }

        public static void UpdateEnemtStat()
        {
            listEnemies.Items.Clear();

            for (int i = 0; i < GameEngineObj._numEnemies; i++)     //displaying the enemies' stats in the combo box
            {
                if (GameEngineObj._map._arrEnemy[i] != null && GameEngineObj._map._arrEnemy[i].HP >= 1) //removed from listBox if enemy dies
                {
                    listEnemies.Items.Add(GameEngineObj._map._arrEnemy[i].ToString());
                }               
            }
        }

        [Serializable]
        public abstract class Tile     //abstract base class
        {
            protected int _x;   //protected member variables
            protected int _y;
            public int X { get { return _x; } set { _x = value; } } //public accessors   
            public int Y { get { return _y; } set { _y = value; } }

            public enum TileEnumType   //public enum used to define the type of tile
            {
                hero,
                enemy,
                gold,
                weapon
            }

            public Tile(int _x, int _y)   //Tile constructor
            {
                this._x = _x;    //variable initialization
                this._y = _y;
            }
        }
        [Serializable]
        abstract class Obstacle : Tile  //subclass used to border the map with obstacle tiles
        {
            Obstacle(int x, int y) : base(x, y) { }   //calling the base constructor
        }
        [Serializable]
        abstract class EmptyTile : Tile  //subclass used to denote empty tiles
        {
            EmptyTile(int _x, int _y) : base(_x, _y) { }   //calling the base constructor
        }

        [Serializable]
        public abstract class Character : Tile   //abstract base class used for the hero and goblins
        {
            protected int _HP;   //protected member variables
            protected int _maxHP;
            protected int _damage;
            private int _goldPurse;
            public string symbol;
            protected Weapon _weaponObj;

            public int HP { get { return _HP; } set { _HP = value; } }    //public accessors
            public int maxHP { get { return _maxHP; } set { _maxHP = value; } }
            public int damage { get { return _damage; } set { _damage = value; } }
            public int goldPurse { get { return _goldPurse; } set { _goldPurse = value; } }
            public Weapon weaponObj { get { return _weaponObj; } }

            public string[] arrTile = { ". ", ". ", ". ", ". " };      //array for a character's vision used to check for valid movement
            public string[] arrTileVision { get { return arrTile; } set { arrTile = value; } } 

            public enum MovementEnum    //public enum for movement
            {
                noMovement,
                up,
                down,
                left,
                right
            }
            public Character(int x, int y, string symbol, Weapon weapon) : base(x, y)  //calling the base constructor
            {
                this.symbol = symbol;
                this._weaponObj = weapon;
            }                   

            private void Equip (Weapon w)
            {
                _weaponObj = w;
            } 

            public virtual void Attack(Character target)   //method to attack the target
            {
                //nothing
            }

            public bool IsDead(Enemy enemy)    //method to check if the character is dead
            {
                if (enemy.HP <= 0)
                {
                    GameEngineObj._map.arr2dTileMap[enemy.X, enemy.Y] = ". ";     //setting enemy's position to ". "
                    return true;
                }
                else
                {
                    return false;
                }              
            }

            public virtual bool CheckRange(Character target)   //method to check if the target is within range of the character
            {
                if (target is Hero && DistanceTo(target) <= 2)      //calling method to determine the distance      
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private int DistanceTo(Character target)   //method determines the absolute distance between the character and its target
            {
                int totalDistance = 0;
                int totalX = 0;
                int totalY = 0;

                totalX = Math.Abs(this.X - target.X);   //setting X and Y values to be absolute
                totalY = Math.Abs(this.Y - target.Y);
                totalDistance = totalX + totalY;
                return totalDistance;   //returning the total distance
            }

            public void Move(MovementEnum move)     //method to edit a unit's X and Y values to move
            {
                //nothing
            }

            public abstract MovementEnum ReturnMove(MovementEnum move = 0);  //method returns direction of movement

            public abstract override string ToString();  //overrides the traditional Object ToString() method

            public void Pickup(Item i)  //method to allow items to be picked up by characters
            {
                if (i is Gold)
                {
                    Gold itemGold = i as Gold;
                    this.goldPurse = goldPurse + itemGold.gold;
                }
                else
                {
                    Weapon itemWeapon = i as Weapon;
                    this.Equip(itemWeapon);
                }
            }
        }

        [Serializable]
        public abstract class Item : Tile  //Item subclass
        {
            public Item(int x, int y) : base(x, y) { }   //calling the constructor
            public abstract override string ToString();  //overrides the traditional Object ToString() method
        }

        [Serializable]
        public class Gold : Item
        {        
            private int goldAmount; //private member variable
            public int gold { get { return goldAmount; } } //public accessor

            private Random randomGoldAmount = new Random();  //randomizer for gold
                       
            public Gold(int x, int y) : base(x, y) //calling the constructor
            {
                goldAmount = randomGoldAmount.Next(1, 6);   //random between 1 and 5
            }
            public override string ToString() { return ""; }  //overrides the traditional Object ToString() method
        }

        [Serializable]
        public abstract class Weapon : Item
        {
            public Weapon(string symbol, int x = 0, int y = 0) : base(x, y) //calling the constructor
            {

            }            

            protected int damage;   //protected member variables
            protected int range;
            protected int durability;
            protected int cost;
            protected string weaponType;

            public int _damage { get { return damage; } set { damage = value; } }   //public accessors
            public int _durability { get { return durability; } set { durability = value; } }
            public int _cost { get { return cost; } set { cost = value; } }
            public string _weaponType { get { return weaponType; } set { weaponType = value; } }
            public virtual int _range { get { return range; } set { range = value; } }
        }

        [Serializable]
        public class MeleeWeapon : Weapon
        {
            public MeleeWeapon(TypesEnum weaponTypes, string symbol, int x = 0, int y = 0) : base(symbol, x, y) //calling the constructor
            {
                if (weaponTypes == TypesEnum.Dagger)    //dagger stats
                {
                    _weaponType = "Dagger";
                    _durability = 10;
                    _damage = 3;
                    _cost = 3;
                }
                else if (weaponTypes == TypesEnum.Longsword)    //longsword stats
                {
                    _weaponType = "Longsword";
                    _durability = 6;
                    _damage = 4;
                    _cost = 5;
                }
            }

            public enum TypesEnum    //public enum
            {
                Dagger,
                Longsword
            }

            public override string ToString() { return ""; }   //overriding ToString method 
            public override int _range { get { return 1; } set { range = value; } } //overriding range accessor
        }

        [Serializable]
        public class RangedWeapon : Weapon
        {
            public RangedWeapon(TypesEnum weaponTypes, string symbol, int x = 0, int y = 0) : base(symbol, x, y) //calling the constructor
            {
                if (weaponTypes == TypesEnum.Rifle)    //rifle stats
                {
                    _weaponType = "Rifle";
                    _durability = 3;
                    _range = 3;
                    _damage = 5;
                    _cost = 7;
                }
                else if (weaponTypes == TypesEnum.Longbow)    //longbow stats
                {
                    _weaponType = "Longbow";
                    _durability = 4;
                    _range = 2;
                    _damage = 4;
                    _cost = 6;
                }
            }

            public RangedWeapon(TypesEnum weaponTypes, string symbol, int durability_) : base(symbol, 0, 0) //calling another constructor
            {
                if (weaponTypes == TypesEnum.Rifle)    //rifle stats
                {
                    _weaponType = "Rifle";
                    _durability = durability;
                    _range = 3;
                    _damage = 5;
                    _cost = 7;
                }
                else if (weaponTypes == TypesEnum.Longbow)    //longbow stats
                {
                    _weaponType = "Longbow";
                    _durability = durability;
                    _range = 2;
                    _damage = 4;
                    _cost = 6;
                }
            }

            public enum TypesEnum    //public enum
            {
                Rifle,
                Longbow
            }

            public override string ToString() { return ""; }   //overriding ToString method 
            public override int _range { get { return base._range; } set { range = value; } } //overriding range accessor
        }

        [Serializable]
        public abstract class Enemy : Character    //Enemy class inherits from Character
        {
            protected int randomNum;    //protected member variable
            

            public Enemy(int x, int y, string symbol, int dmg, int hP, int maxHp, Weapon weapon = null) : base(x, y, symbol, weapon)   //constructor initializer 
            {
                this._x = x;    //setting all member variables
                this._y = y;
                this._damage = dmg;
                this._HP = hP;
                this._maxHP = maxHp;
            }

            public override string ToString()   //overriding ToString method 
            {
                string whichEnemy = "";

                if (this.symbol == "M ")    //checking enemy type
                {
                    whichEnemy = "Mage ";
                }
                else if (this.symbol == "G ")
                {
                    whichEnemy = "Goblin ";
                }
                else if (this.symbol == "L ")
                {
                    whichEnemy = "Leader ";
                }

                if (this.weaponObj == null) //if enemy is barehanded
                {
                    return whichEnemy + " (" + _HP + "/" + _maxHP + "HP) at [" + _x + ", " + _y + "] " + "(" + _damage + " Damage)";
                }
                else     //if enemy has a weapon
                {
                    return whichEnemy + " (" + _HP + "/" + _maxHP + "HP) at [" + _x + ", " + _y + "] with " + this.weaponObj._weaponType + " " + this._weaponObj._durability + " durability and " + this._weaponObj._damage + " damage. ";
                }             
            }
        }

        [Serializable]
        public class Goblin : Enemy     //concrete Goblin class
        {
            
            public Goblin(int x, int y, Weapon dagger) : base(x, y, "G ", 1, 10, 10, dagger)    //constructor calling the Enemy constructor initializer and assigning variable values
            {
                this.goldPurse = 1;
            }

            public override MovementEnum ReturnMove(MovementEnum move = 0)  //overridden method
            {
                Random randomDirection = new Random();  //randomizer for direction
                int randomMove = randomDirection.Next(4);
                
                while (true)  //while loop to check for valid movement
                {
                    if (randomMove == 0)    //directions
                    {
                        if (this.arrTile[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ")  //positions in array
                        {
                            return MovementEnum.up;     //up
                        }
                    }
                    else if (randomMove == 1)
                    {
                        if (this.arrTile[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                        {
                            return MovementEnum.down;   //down
                        }
                    }
                    else if (randomMove == 2)
                    {
                        if (this.arrTile[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                        {
                            return MovementEnum.right;  //right
                        }
                    }
                    else if (randomMove == 3)
                    {
                        if (this.arrTile[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                        {
                            return MovementEnum.left;   //left
                        };
                    }
                    randomMove = randomDirection.Next(4);   //random "reroll"
                }                       
            }
        }

        [Serializable]
        public class Mage : Enemy     //concrete Mage class
        {
            public Mage(int x, int y, Weapon weapon = null) : base(x, y, "M ", 5, 5, 5, weapon)
            { 
                this.goldPurse = 3; 
            }

            public override MovementEnum ReturnMove(MovementEnum move = 0)  //overridden ReturnMove() method
            {
                return MovementEnum.noMovement; //Mages never move
            }

            private int MageDistanceTo(Character target)   //method determines the absolute distance between the character and its target
            {
                int totalDistance = 0;
                int totalX = 0;
                int totalY = 0;

                totalX = Math.Abs(this.X - target.X);   //setting X and Y values to be absolute
                totalY = Math.Abs(this.Y - target.Y);
                totalDistance = totalX + totalY;
                return totalDistance;   //returning the total distance
            }

            public override bool CheckRange(Character target)   //overriden CheckRange() method
            {
                if (target is Hero || target is Goblin)
                {
                    if (MageDistanceTo(target) <= 2)      //calling method to determine the distance      
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }    
        }

        [Serializable]
        public class Leader : Enemy //Leader class
        {
            private Tile target;
            public Tile _target { get { return target; } set { target = value; } } //accessors

            public Leader(int x, int y, Weapon longsword) : base(x, y, "L ", 2, 20, 20, longsword)
            { 
                this.goldPurse = 2; 
            }

            public MovementEnum MoveRandom()         //returns random eligible movement
            {
                Random randomDirection = new Random();
                int randDirection;

                while (true)
                {
                    randDirection = randomDirection.Next(0, 5);
                    if (randDirection == 0)
                    {
                        if(this.arrTileVision[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ")
                        {
                            return MovementEnum.up;
                        }                                           
                    }
                    if (randDirection == 1)
                    {
                        if (this.arrTileVision[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                        {
                            return MovementEnum.down;
                        }
                    }
                    if (randDirection == 2)
                    {
                        if (this.arrTileVision[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                        {
                            return MovementEnum.right;
                        }
                    }
                    if (randDirection == 3)
                    {
                        if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                        {
                            return MovementEnum.left;
                        }
                    }
                }
            }
            public override MovementEnum ReturnMove(MovementEnum move = 0)  //overridden ReturnMove() method
            {
                int xDist, yDist;

             
                if (GameEngineObj._map._heroObj.Y > this.Y) //right
                {
                        xDist = GameEngineObj._map._heroObj.X - this.X;
                        yDist = GameEngineObj._map._heroObj.Y - this.Y;

                        if (GameEngineObj._map._heroObj.X < this.X) //top
                        {
                            if (xDist < yDist) 
                            {
                                if (this.arrTileVision[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ") 
                                {
                                    return MovementEnum.up; //top
                                }
                                else 
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                                {
                                    return MovementEnum.right;  //right
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }

                        else if (GameEngineObj._map._heroObj.X > this.X) //bottom
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                                {
                                    return MovementEnum.down; //bottom
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                                {
                                    return MovementEnum.right;  //right
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }
                    else
                    {
                        if (this.arrTileVision[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                        {
                            return MovementEnum.right;  //right
                        }
                        else
                        {
                            return MoveRandom();
                        }
                    }                       
                }

                else if(GameEngineObj._map._heroObj.Y < this.Y) //left
                {
                        xDist = GameEngineObj._map._heroObj.X - this.X;
                        yDist = GameEngineObj._map._heroObj.Y - this.Y;

                        if (GameEngineObj._map._heroObj.X > this.X) //top
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ")
                                {
                                    return MovementEnum.up; //top
                                }
                                else
                                {
                                    if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                                    {
                                        return MovementEnum.left;  //left
                                    }
                                    else
                                    {
                                        return MoveRandom();
                                    }
                            }
                        }
                            else
                            {
                                if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                                {
                                    return MovementEnum.left;  //left
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }

                        else if (GameEngineObj._map._heroObj.X > this.X) //bottom
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                                {
                                    return MovementEnum.down; //bottom
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                                {
                                    return MovementEnum.left;  //left
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }
                        else
                        {
                            if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                            {
                                return MovementEnum.left;  //left
                            }
                            else
                            {
                                return MoveRandom();
                            }
                        }

                }

                else if(GameEngineObj._map._heroObj.X < this.X) //top
                {
                        xDist = GameEngineObj._map._heroObj.X - this.X;
                        yDist = GameEngineObj._map._heroObj.Y - this.Y;

                        if (GameEngineObj._map._heroObj.Y > this.Y) //right
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ")
                                {
                                    return MovementEnum.up; //top
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                                {
                                    return MovementEnum.right;  //right
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }

                        else if (GameEngineObj._map._heroObj.Y < this.Y) //left
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ")
                                {
                                    return MovementEnum.up; //top
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                                {
                                    return MovementEnum.left;  //left
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }
                        else
                        {
                            if (this.arrTileVision[0] == ". " || this.arrTileVision[0] == "B " || this.arrTileVision[0] == "D " || this.arrTileVision[0] == "R " || this.arrTileVision[0] == "S ")
                            {
                                return MovementEnum.up; //top
                            }
                            else
                            {
                                return MoveRandom();
                            }
                        }
                }

                else if(GameEngineObj._map._heroObj.X > this.X) //bottom
                {
                        xDist = GameEngineObj._map._heroObj.X - this.X;
                        yDist = GameEngineObj._map._heroObj.Y - this.Y;

                        if (GameEngineObj._map._heroObj.Y > this.Y) //right
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                                {
                                    return MovementEnum.down; //bottom
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[2] == ". " || this.arrTileVision[2] == "B " || this.arrTileVision[2] == "D " || this.arrTileVision[2] == "R " || this.arrTileVision[2] == "S ")
                                {
                                    return MovementEnum.right;  //right
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }

                        else if (GameEngineObj._map._heroObj.Y < this.Y) //left
                        {
                            if (xDist < yDist)
                            {
                                if (this.arrTileVision[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                                {
                                    return MovementEnum.down; //bottom
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                            else
                            {
                                if (this.arrTileVision[3] == ". " || this.arrTileVision[3] == "B " || this.arrTileVision[3] == "D " || this.arrTileVision[3] == "R " || this.arrTileVision[3] == "S ")
                                {
                                    return MovementEnum.left;  //left
                                }
                                else
                                {
                                    return MoveRandom();
                                }
                            }
                        }
                        else
                        {
                            if (this.arrTileVision[1] == ". " || this.arrTileVision[1] == "B " || this.arrTileVision[1] == "D " || this.arrTileVision[1] == "R " || this.arrTileVision[1] == "S ")
                            {
                                return MovementEnum.down; //bottom
                            }
                            else
                            {
                                return MoveRandom();
                            }
                        }   
                }
                else 
                { 
                    return MovementEnum.noMovement; 
                }
            }                                     
            
        }

        [Serializable]
        public class Hero : Character   //concrete Hero class
        {
            public Hero(int x, int y, string symbol, int hP, int maxHp, Weapon weapon = null) : base(x, y, "H ", weapon)    //constructor calling the Character constructor initializer
            {
                this._HP = hP;  //setting variables
                this._maxHP = maxHp;
                this._damage = 2;
            }

            public override MovementEnum ReturnMove(MovementEnum move = 0)  //overridden method
            {
                while (true)  //while loop to check for valid movement
                {
                    if (boolUp == true)    //directions
                    {
                        boolUp = false;
                        if (arrTile[0] == ". ")  //positions in array
                        {
                            return MovementEnum.up;     //up                          
                        }
                        else
                        {
                            return MovementEnum.noMovement;     //no movement
                        }
                    }
                    else if (boolDown == true)
                    {
                        boolUp = false;
                        if (arrTile[1] == ". ")
                        {
                            return MovementEnum.down;   //down                     
                        }
                        else
                        {
                            return MovementEnum.noMovement;     //no movement
                        }
                    }
                    else if (boolRight == true)
                    {
                        boolUp = false;
                        if (arrTile[2] == ". ")
                        {
                            return MovementEnum.right;  //right                           
                        }
                        else
                        {
                            return MovementEnum.noMovement;     //no movement
                        }
                    }
                    else if (boolLeft == true)
                    {
                        boolUp = false;
                        if (arrTile[3] == ". ")
                        {
                            return MovementEnum.left;   //left                           
                        }
                        else
                        {
                            return MovementEnum.noMovement;     //no movement
                        }
                    }
                    else
                    {
                        return MovementEnum.noMovement;     //no movement
                    }
                }
            }

            public override string ToString()   //overriding ToString method 
            {
                if (this._weaponObj == null)    //if the hero has no weapon
                {
                    return "Player Stats:" + "\r\n" + "HP: " + HP + "/" + maxHP + "\r\n" + "Current Weapon: Bare Hands" + "\r\n" + "Weapon Range: 1" + "\r\n" + "Weapon Damage: 2" + "\r\n" + "Gold: " + goldPurse + "\r\n" + "[" + _y + "," + _x + "]";    //player stats
                }
                else     //if the hero has a weapon
                {
                    return "Player Stats:" + "\r\n" + "HP: " + HP + "/" + maxHP + "\r\n" + "Current Weapon: " + this._weaponObj._weaponType + "\r\n" + "Weapon Range: " + this._weaponObj._range + "\r\n" + "Weapon Damage: " + this._weaponObj._damage + "\r\n" + "Gold: " + goldPurse + "\r\n" + "[" + _y + "," + _x + "]";
                }               
            }
        }
               
        public void btnUp_Click(object sender, EventArgs e)
        {
            boolUp = true;
            lblMap.Text = "";
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);
            GameEngineObj.MovePlayer(GameEngineObj._map._heroObj, MovementEnum.up);     //calling MovePlayer method to move the player up
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);     //calling the UpdateVision method
            Redraw();   //calling the redraw method
            lblStats.Text = GameEngineObj._map._heroObj.ToString();  //displaying the hero's stats
            UpdateEnemtStat();
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {
            boolDown = true;
            lblMap.Text = "";
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);
            GameEngineObj.MovePlayer(GameEngineObj._map._heroObj, MovementEnum.left);   //calling MovePlayer method to move the player down
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);     //calling the UpdateVision method
            Redraw();   //calling the redraw method
            lblStats.Text = GameEngineObj._map._heroObj.ToString();  //displaying the hero's stats
            UpdateEnemtStat();
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            boolRight = true;
            lblMap.Text = "";
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);
            GameEngineObj.MovePlayer(GameEngineObj._map._heroObj, MovementEnum.right);  //calling MovePlayer method to move the player right
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);     //calling the UpdateVision method
            Redraw();   //calling the redraw method
            lblStats.Text = GameEngineObj._map._heroObj.ToString();  //displaying the hero's stats
            UpdateEnemtStat();
        }

        public void btnDown_Click(object sender, EventArgs e)
        {
            boolLeft = true;
            lblMap.Text = "";
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);
            GameEngineObj.MovePlayer(GameEngineObj._map._heroObj, MovementEnum.down);   //calling MovePlayer method to move the player left
            GameEngineObj._map.UpdateVision(GameEngineObj._map._heroObj);     //calling the UpdateVision method
            Redraw();   //calling the redraw method
            lblStats.Text = GameEngineObj._map._heroObj.ToString();  //displaying the hero's stats
            UpdateEnemtStat();
        }

        public void btnMap_Click(object sender, EventArgs e)
        {
            _minWidth = Int16.Parse(txtMinWidth.Text);  //assigning textbox values to variables
            _maxWidth = Int16.Parse(txtMaxWidth.Text);
            _minHeight = Int16.Parse(txtMinHeight.Text);
            _maxHeight = Int16.Parse(txtMaxHeight.Text);
             
            GameEngineObj = new GameEngine();
            GameEngineObj.shopObj = new Shop(GameEngineObj._map._heroObj);
            lblMap.Text = "";
            Redraw();   //calling the redraw method
            lblStats.Text = GameEngineObj._map._heroObj.ToString();  //displaying the hero's stats

            btnShopW1.Enabled = false;  //disabling shop buttons
            btnShopW2.Enabled = false;
            btnShopW3.Enabled = false;

            btnShopW1.Text = GameEngineObj.shopObj.DisplayWeapon(0);    //assigning weapons to the shop buttons
            btnShopW2.Text = GameEngineObj.shopObj.DisplayWeapon(1);
            btnShopW3.Text = GameEngineObj.shopObj.DisplayWeapon(2);

            for (int i = 0; i < GameEngineObj._numEnemies; i++)     //displaying the enemies' stats in the combo box
            {
                listEnemies.Items.Add(GameEngineObj._map._arrEnemy[i].ToString());
            }

            btnMap.Enabled = false;
            UpdateEnemtStat();
        }

        private void lblStats_Click(object sender, EventArgs e)
        {

        }

        private void comboEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            int xPos = GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].X;
            int yPos = GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].Y;

            for (int i = 0; i < 1; i++) {
                if (GameEngineObj._map.arr2dTileMap[xPos, yPos + 1] == "H ")      //east or right of enemy character         
                {
                    richShowAttack.Text = richShowAttack.Text + "\n" + "You have successfully hit the enemy!" + "\n";  //rich text to display the player's success in attacking
                    
                    GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP = GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP - 2;  //subtracting the hero's damage from the enemy's HP
                    richShowAttack.Text = richShowAttack.Text + "" + GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].ToString();  //displaying the enemy's HP
                    
                    if (GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].IsDead(GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex]) == true)    //checking if the character is dead
                    {
                        richShowAttack.Text = richShowAttack.Text + "\n" + "The enemy has been defeated!" + "\n";
                        lblMap.Text = "";
                        GameEngineObj._map.arr2dTileMap[xPos, yPos] = ". ";   //replacing character with ". " if dead
                        UpdateEnemtStat();
                        Redraw();   //calling the redraw map method
                    }

                    break;
                }

                if (GameEngineObj._map.arr2dTileMap[xPos + 1, yPos] == "H ")     //south or below the enemy character
                {
                    richShowAttack.Text = richShowAttack.Text + "\n" + "You have successfully hit the enemy!" + "\n";
                    GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP = GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP - 2;
                    richShowAttack.Text = richShowAttack.Text + GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].ToString();

                    if (GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].IsDead(GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex]) == true)
                    {
                        richShowAttack.Text = richShowAttack.Text + "\n" + "The enemy has been defeated!" + "\n";
                        lblMap.Text = "";
                        GameEngineObj._map.arr2dTileMap[xPos, yPos] = ". ";
                        UpdateEnemtStat();
                        Redraw();   //calling the redraw map method
                    }

                    break;
                }

                if (GameEngineObj._map.arr2dTileMap[xPos, yPos - 1] == "H ")     //west or left of enemy character
                {
                    richShowAttack.Text = richShowAttack.Text + "\n" + "You have successfully hit the enemy!" + "\n";
                    GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP = GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP - 2;
                    richShowAttack.Text = richShowAttack.Text + GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].ToString();

                    if (GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].IsDead(GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex]) == true)
                    {
                        richShowAttack.Text = richShowAttack.Text + "\n" + "The enemy has been defeated!" + "\n";
                        lblMap.Text = "";
                        GameEngineObj._map.arr2dTileMap[xPos, yPos] = ". ";
                        UpdateEnemtStat();
                        Redraw();   //calling the redraw map method
                    }

                    break;
                }

                if (GameEngineObj._map.arr2dTileMap[xPos - 1, yPos] == "H ")     //north or above the enemy character
                {
                    richShowAttack.Text = richShowAttack.Text + "\n" + "You have successfully hit the enemy!" + "\n";
                    GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP = GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].HP - 2;
                    richShowAttack.Text = richShowAttack.Text + GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].ToString();

                    if (GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex].IsDead(GameEngineObj._map._arrEnemy[listEnemies.SelectedIndex]) == true)
                    {
                        richShowAttack.Text = richShowAttack.Text + "\n" + "The enemy has been defeated!" + "\n";
                        lblMap.Text = "";
                        GameEngineObj._map.arr2dTileMap[xPos, yPos] = ". ";
                        UpdateEnemtStat();
                        Redraw();   //calling the redraw map method
                    }

                    break;
                }
                else
                {
                    MessageBox.Show("Get closer to the enemy to attack!");  //message box and rich text to display the player's failure to attack
                    richShowAttack.Text = richShowAttack.Text + "\n" + "You have failed to hit the enemy!" + "\n";
                    break;
                }
            }

            for (int a = 0; a < GameEngineObj._numEnemies; a++)
            {
                GameEngineObj.EnemyAttacks(GameEngineObj._map._arrEnemy[a]);
            }
            UpdateEnemtStat();           
        }

        private void lblCoins_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GameEngineObj.Save();  //calling the Save method
            MessageBox.Show("Map Saved Successfully!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            GameEngineObj.Load();   //calling the Load method
            lblMap.Text = "";
            Redraw();
            UpdateEnemtStat();
            GameEngineObj._map.arr2dTileMap[GameEngineObj._map.randomObj.X, GameEngineObj._map.randomObj.Y] = ". ";
            GameEngineObj._map.randomObj = null;
           
            MessageBox.Show("Map Loaded Successfully!");
            lblStats.Text = GameEngineObj._map._heroObj.ToString();

            btnShopW1.Enabled = false;  //disabling buttons
            btnShopW2.Enabled = false;
            btnShopW3.Enabled = false;
            CanBuyCheck();  //checking if you can buy weapons
        }

            public static T DeepCopyMethod<T>( T obj)
            {
                using (var memStream = new MemoryStream())
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(memStream, obj);
                    memStream.Position = 0;
                    return (T)bf.Deserialize(memStream);
                }
            }
            //Kilhoffer. 2008. How do you do a deep copy of an object in .NET? [duplicate], stackoverflow, 24 September 2008. [Blog]. Available at: https://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-of-an-object-in-net [Accessed 29 November 2020].

        private void btnShopW1_Click(object sender, EventArgs e)
        {
            GameEngineObj.shopObj.Buy(0);
            btnShopW1.Text = GameEngineObj.shopObj.DisplayWeapon(0);
            lblStats.Text = GameEngineObj._map._heroObj.ToString();
            btnShopW1.Enabled = false;  //disabling buttons
            btnShopW2.Enabled = false;
            btnShopW3.Enabled = false;
            CanBuyCheck();  //checking if you can buy weapons
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            
        }

        private void btnShopW2_Click(object sender, EventArgs e)
        {
            GameEngineObj.shopObj.Buy(1);
            btnShopW1.Text = GameEngineObj.shopObj.DisplayWeapon(1);
            lblStats.Text = GameEngineObj._map._heroObj.ToString();
            btnShopW1.Enabled = false;
            btnShopW2.Enabled = false;
            btnShopW3.Enabled = false;
            CanBuyCheck();
        }

        private void btnShopW3_Click(object sender, EventArgs e)
        {
            GameEngineObj.shopObj.Buy(2);
            btnShopW1.Text = GameEngineObj.shopObj.DisplayWeapon(2);
            lblStats.Text = GameEngineObj._map._heroObj.ToString();
            btnShopW1.Enabled = false;
            btnShopW2.Enabled = false;
            btnShopW3.Enabled = false;
            CanBuyCheck();
        }
    }
}
