using System.Reflection.Metadata;

namespace nbcTextRPG;

class Program
{
    public enum Page
    {
        MainMenu,
        Status,
        Inventory,
        Shop
    }

    static void Main(string[] args)
    {
        Page currentPage = Page.MainMenu;


        while (true)
        {
            switch (currentPage)
            {
                case Page.MainMenu:
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");
                    Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다");
                    Console.WriteLine();
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    int pageNumMain = int.Parse(Console.ReadLine());
                    if (1 <= pageNumMain && pageNumMain <= 3)
                    {
                        currentPage = (Page)pageNumMain;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");
                    }
                    break;
                case Page.Status:
                    Console.WriteLine("상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                    Console.WriteLine();
                    Console.WriteLine("Lv. 01");
                    Console.WriteLine("Chad ( 전사 )");
                    Console.WriteLine("공격력 : 10");
                    Console.WriteLine("방어력 : 5");
                    Console.WriteLine("체  력 : 100");
                    Console.WriteLine("Gold : 1500G");
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    int pageNumStat = int.Parse(Console.ReadLine());
                    currentPage = (Page)pageNumStat;
                    break;
                case Page.Inventory:
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine();
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    int pageNumItem = int.Parse(Console.ReadLine());
                    currentPage = (Page)pageNumItem;
                    break;
                case Page.Shop:
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine();
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine("800 G");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine("1");
                    Console.WriteLine("2");
                    Console.WriteLine("3");
                    Console.WriteLine("4");
                    Console.WriteLine("5");
                    Console.WriteLine("6");
                    Console.WriteLine();
                    Console.WriteLine("1. 아이템 구매");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    int pageNumShop = int.Parse(Console.ReadLine());
                    currentPage = (Page)pageNumShop;
                    break;
            }
        }
    }
}