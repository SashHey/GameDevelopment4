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
using MapClass;
using GameEngineClass;
using System.Net.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShopClass
{
    [Serializable]
    public class Shop
    {
        private Weapon[] arrWeapon; //weapon array
        private Character charObj;  //character object      

        static Random randomNumber;//random number generator
        private int randomNum;

        public Shop(Character buyer)    //shop class constructor
        {
            arrWeapon = new Weapon[3];
            randomNumber = new Random();
            charObj = buyer;

            for (int i = 0; i<=2; i++)
            {
                arrWeapon[i] = RandomWeapon();
            }
        }

        private Weapon RandomWeapon()
        {
            randomNum = randomNumber.Next(0, 4);
            Weapon weaponObj;

            if (randomNum == 0)
            {
                weaponObj = new MeleeWeapon(MeleeWeapon.TypesEnum.Dagger, "D");    //returning dagger
                return weaponObj;
            }
            else if (randomNum == 1)
            {
                weaponObj = new MeleeWeapon(MeleeWeapon.TypesEnum.Longsword, "S");    //returning longsword
                return weaponObj;
            }
            else if (randomNum == 2) 
            {
                weaponObj = new RangedWeapon(RangedWeapon.TypesEnum.Longbow, "B");   //returning longbow
                return weaponObj;
            }
            else if (randomNum == 3)
            {
                weaponObj = new RangedWeapon(RangedWeapon.TypesEnum.Rifle, "R");   //returning rifle
                return weaponObj;
            }
            else
            {
                return null;
            }           
        }

        public bool CanBuy(int num) 
        { 
            if (arrWeapon[num] != null)
            {
                if (charObj.goldPurse >= arrWeapon[num]._cost)  //if the character's purse holds enough gold to buy a weapon
                {
                    return true;
                }
            }
            return false;
        }

        public void Buy(int num)
        {
            if (arrWeapon[num] != null)
            {
                if (CanBuy(num) == true)
                {
                    charObj.goldPurse = charObj.goldPurse - arrWeapon[num]._cost;   //decrements buyer's gold amount
                    charObj.Pickup(arrWeapon[num]);
                    arrWeapon[num] = RandomWeapon();
                }
            }
        }

        public string DisplayWeapon(int num)
        {           
                return "Buy " + arrWeapon[num]._weaponType + " (" + arrWeapon[num]._cost + " Gold)";
        }
    }
}
