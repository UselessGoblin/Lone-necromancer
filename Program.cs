using System;

namespace LoneNecromancer
{
    class Necromancer
    {
        public static string name;
        public static int health =20;
        public static int maxHealth =20;
        public static int lvl = 1;
        public static int xp = 0;
        public static int soulCount;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Lone Necromancer   by: UslessGoblin Studios ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What is your name necromancer?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Necromancer.name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            while(Necromancer.health>0)
            {
                Console.WriteLine("An enemy aproaches!");
                Console.WriteLine("(Press Button To Begin Combat)");
                Console.ReadKey();
                combat();
                while(Necromancer.xp>= Necromancer.lvl*8){
                    Necromancer.lvl ++;
                    Necromancer.xp = Necromancer.xp - Necromancer.lvl*8;
                    Necromancer.health = Necromancer.health + Necromancer.lvl*2;
                    Necromancer.maxHealth = Necromancer.maxHealth + 5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YOU LEVELED UP!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            Console.WriteLine("You Died");
            Console.WriteLine("X_X");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Game dedicated to Jamie");
            Console.ReadKey();
            Console.WriteLine("The End");
            Console.ReadKey();
           
            static void combat()
            {
                string check;
                int input;
                int dmg;
                double halfDmg = Necromancer.lvl/2;
                int display;
                //enemy creation
                int enemyHealth;
                int enemyMaxHealth;
                int enemyLevel;
                int enemyDamage;

                enemyLevel = enemyLvl();
                enemyHealth = enemyLevel * 5;
                enemyMaxHealth = enemyHealth;
                //Combat!
                while(Necromancer.health>0){
                    display = Necromancer.soulCount*(Necromancer.lvl+3);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine(Necromancer.name +" Necromancer lvl."+Necromancer.lvl+" "+Necromancer.health+"/"+Necromancer.maxHealth);
                    Console.WriteLine("Souls:"+Necromancer.soulCount);
                    Console.WriteLine("Enemy lvl."+enemyLevel+" "+enemyHealth+"/"+enemyMaxHealth );
                    Console.WriteLine("--------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("(Enter a Number to Select)");
                    Console.WriteLine("1.Necrotic Touch");
                    Console.WriteLine("2.Soul Siphon");
                    Console.WriteLine("3.Consume Soul (heal: "+display+")");
                    //selecting attack
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    check = Console.ReadLine();                     //Make sure there is an input
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    while(check.Length != 1){
                        Console.WriteLine("(Please Enter a Number)");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        check = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    input = Convert.ToInt32(check);
                    while(input != 1 && input != 2 && input != 3)                 //Make sure input is valid number
                    {
                        Console.WriteLine("(Please Enter a Number)");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        check = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        while(check.Length != 1){
                        Console.WriteLine("(Please Enter a Number)");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        check = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        input = Convert.ToInt32(check);
                    }                                               
                    if(input == 1){                   //Necrotic Touch
                            dmg = Necromancer.lvl * 3;
                            enemyHealth = enemyHealth - dmg;
                            Console.WriteLine("You attack the Enemy lvl."+enemyLevel+" with Necrotic Touch for "+ dmg +" dmg!");
                        }else if(input == 2){         //Soul Siphon
                            dmg = Necromancer.lvl;
                            enemyHealth = enemyHealth - dmg;
                            if(Necromancer.health+dmg<Necromancer.maxHealth){ //Making sure you dont heal over max health
                                Necromancer.health = Necromancer.health + dmg;
                            }else{
                                Necromancer.health = Necromancer.maxHealth;
                            }
                            Console.WriteLine("You attack the Enemy lvl."+enemyLevel+" with Soul Siphon draining "+ dmg +" health!");
                        }else if(input == 3){         //Consume
                            dmg = Necromancer.soulCount*(Necromancer.lvl+3);
                            if(Necromancer.health+dmg<Necromancer.maxHealth){ //Making sure you dont heal over max health
                                Necromancer.health = Necromancer.health + dmg;
                            }else{
                                Necromancer.health = Necromancer.maxHealth;
                            }
                            Console.WriteLine("You consume your souls and gain "+ dmg +" health!");
                            Necromancer.soulCount = 0;
                        }
                    if(enemyHealth<=0){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Necromancer.xp = Necromancer.xp + enemyLevel*4;
                        Console.WriteLine("\nYou killed the Enemy!");
                        Console.WriteLine("\n"+Necromancer.name +" Necromancer lvl."+Necromancer.lvl+"\nxp:"+Necromancer.xp+"/"+Necromancer.lvl*8);
                        Necromancer.soulCount++;
                        Console.WriteLine("Souls:"+Necromancer.soulCount+"\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                    enemyDamage = damage(enemyLevel);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Necromancer.health = Necromancer.health - enemyDamage;
                    Console.WriteLine("\nThe Enemy attacks dealing "+enemyDamage+ " dmg!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            static int damage(int lvl)
            {
                Random numberGen = new Random();
                int roll = numberGen.Next(1,20);
                int dmg = lvl;
                double dmgMod = dmg/2;
                
                if(roll==20){
                    dmg=dmg*2;
                }else if(roll==1){
                    dmg=0;
                }else if(roll>=10){
                    dmg=dmg+(int)dmgMod;
                }else{
                    dmg=dmg-(int)dmgMod;
                }
                return dmg;
            }
            static int enemyLvl()
            {
                Random numberGen = new Random();
                int enemyLevel = numberGen.Next(Necromancer.lvl-4,Necromancer.lvl+4);
                if(enemyLevel<=0){
                    enemyLevel = 1;
                }
                if(Necromancer.lvl<3){
                    enemyLevel = Necromancer.lvl;
                }
                return enemyLevel;
            }
        }
    }
}