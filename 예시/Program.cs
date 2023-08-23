using System;
using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Reflection.Emit;
using System.Transactions;

namespace 예시
{
    internal class Program
    {
        private static Character player;
        private static Item item;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
            DisplayMyInfo();
            Inventory();
            Puton();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            item = new Item("[E] ", 0, 0 ,0);
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요.: ");

            //if (int=0,int=1) 
            //{

            //}

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    Inventory();
                    break;

            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("상태보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보르 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요.: ");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }
        static void Inventory()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("낡은검| 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
            Console.WriteLine("무쇠 갑옷| 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷");
            Console.WriteLine("알라의 요술봉 | 공격력 +100 | 신앙의 힘으로 ");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요.: ");

            int input = CheckValidInput(0, 1);
            switch (input)
            {   
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    Puton();
                    break;                   
    
            }
            
        }

        static void Puton() 
        {
            int input;
            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("인벤토리");
                Console.ResetColor();
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine($"-{(item.Sword > 0 ? item.Wear : "")}{item.Sword}| 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
                Console.WriteLine($"-{(item.Ironarmor > 0 ? item.Wear : "")}{item.Ironarmor}| 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷");
                Console.WriteLine($"-{(item.Boom > 0 ? item.Wear : "")}{item.Boom}| 공격력 +100 | 신앙의 힘으로");
                Console.WriteLine();
                Console.WriteLine("1. 검 착용하기");
                Console.WriteLine("2. 검 벗기");
                Console.WriteLine("3. 갑옷 착용하기");
                Console.WriteLine("4. 갑옷 벗기");
                Console.WriteLine("5. 요술봉 착용하기");
                Console.WriteLine("6. 요술봉 벗기");
                Console.WriteLine("0.처음로 나가기");
                Console.Write("원하시는 행동을 입력해주세요.: ");

                input = CheckValidInput(0, 6);
                switch (input)
                {
                    case 0:
                        DisplayGameIntro();
                        break;
                    case 1:
                        SwordOn();
                        break;
                    case 2:
                        SwordOff();
                        break;
                    case 3:
                        ArmorOn();
                        break;
                    case 4:
                        ArmorOff();
                        break;
                    case 5:
                        MagicOn();
                        break;
                    case 6:
                        MagicOff();
                        break;
                }
            }
            while (input != 0);
        }


        
        static void SwordOn()
        {
            
            if((item.Sword) >= 0)
            {
                (item.Sword) ++;
                (player.Atk) += 2;      
            }
        }
        static void SwordOff()
        {
            
            if ((item.Sword) < 100 && (item.Sword) > 0)
            {
                (item.Sword) -- ;
                (player.Atk) -= 2;
            }
        }

        static void ArmorOn()
        {
            
            if((item.Ironarmor) >= 0)
            {
                item.Ironarmor++;
                player.Def += 5;
            }
        }

        static void ArmorOff()
        {           
            if ((item.Ironarmor) <100 && (item.Ironarmor) > 0)
            {
                item.Ironarmor--;
                player.Def -= 5;
            }
        }

        static void MagicOn()
        {

            if ((item.Boom) >= 0)
            {
                item.Boom++;
                player.Atk += 100;
            }
        }

        static void MagicOff()
        {
            if ((item.Boom) < 100 && (item.Boom) > 0)
            {
                item.Boom--;
                player.Atk -= 100;
            }
        }

        

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Item
    {
        public string Wear { get; }

        public int Sword { get; set; }
        public int Ironarmor { get; set; }

        public int Boom { get; set; }

        public Item(string wear, int sword, int ironarmor, int boom)
        {
            Wear = wear;    
            Sword = sword;
            Ironarmor = ironarmor;
            Boom = boom;
        }

    }
}