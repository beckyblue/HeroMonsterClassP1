using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClassP1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hero Character "specs"
            Character hero = new Character();
            hero.Name = "Thor";
            hero.Health = 35;
            hero.DamageMaximum = 20;
            hero.AttackBonus = false;

            //Monster Character "specs"
            Character monster = new Character();
            monster.Name = "Shinigami";
            monster.Health = 21;
            monster.DamageMaximum = 25;
            monster.AttackBonus = true;

            
            int damage = hero.Attack();//attack from hero
            monster.Defend(damage);

            damage = monster.Attack();//attack from monster
            monster.Defend(damage);

            printStats(hero);
            printStats(monster);

        }

        private void printStats(Character character)
        {
            resultLabel.Text += String.Format("<p> Name: {0} | Health: {1} | Damage: {2} | Attack Bonus: {3} </p>",
                character.Name, 
                character.Health, 
                character.DamageMaximum.ToString(), 
                character.AttackBonus.ToString());
        }
    }

    class Character//Class w/Properties Name, Health, DamageMaximum, AttackBonus
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()//Attack method
        {
            Random random = new Random();
            int damage = random.Next(0, this.DamageMaximum); // return value for the damage this "attack" will do. 

            return damage;//value sent to damage method
        }

        public void Defend(int damage)//Defend method
        {
            this.Health -= damage;// 'this' links to Health properties to take from "health" of the hero/monster who called it
        }

    }


}