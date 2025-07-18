﻿using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Collections;

namespace nbcTextRPG;

class Program
{
    public enum Page
    {
        MainMenu,
        Status,
        Inventory,
        Shop,
        Exit,
        EquipInventory,
        BuyShop
    }

    public class PlayerDB
    {
        public List<Player> AllPlayer = new List<Player>
        {
            new Player {
                PlayerNum=1,
                PlayerLv=1,
                PlayerName="Chad",
                PlayerJob="전사",
                PlayerAtk=10,
                PlayerDef=5,
                PlayerHP=100,
                PlayerGold=99999
            }
        };
    }

    public class ItemDB
    {
        public List<Item> AllItems = new List<Item>
        {
            new Item {
                ItemNum = 1,
                ItemName = "수련자 갑옷",
                ItemType="Armor",
                ItemDef=5,
                ItemGold=1000,
                ItemInfo="수련에 도움을 주는 갑옷입니다."
            },
            new Item {
                ItemNum = 2,
                ItemName = "무쇠갑옷",
                ItemType="Armor",
                ItemDef=9,
                ItemGold=1800,
                ItemInfo="무쇠로 만들어져 튼튼한 갑옷입니다."
            },
            new Item {
                ItemNum = 3,
                ItemName = "스파르타의 갑옷",
                ItemType="Armor",
                ItemDef=15,
                ItemGold=3500,
                ItemInfo="스파르타의 전사들이 사용했다는 전설의 갑옷입니다."
            },
            new Item {
                ItemNum = 4,
                ItemName = "낡은 검",
                ItemType="Weapon",
                ItemAtk=2,
                ItemGold=600,
                ItemInfo="쉽게 볼 수 있는 낡은 검 입니다."
            },
            new Item {
                ItemNum = 5,
                ItemName = "청동 도끼",
                ItemType="Weapon",
                ItemAtk=5,
                ItemGold=1500,
                ItemInfo="어디선가 사용됐던거 같은 도끼입니다."
            },
            new Item {
                ItemNum = 6,
                ItemName = "스파르타의 창",
                ItemType="Weapon",
                ItemAtk=7,
                ItemGold=3000,
                ItemInfo="스파르타의 전사들이 사용했다는 전설의 창입니다."
            }
        };
    }

    public class Player
    {
        public int PlayerNum { get; set; }
        public int PlayerLv { get; set; }
        public string? PlayerName { get; set; }
        public string? PlayerJob { get; set; }
        public int PlayerAtk { get; set; }
        public int PlayerDef { get; set; }
        public int PlayerHP { get; set; }
        public int PlayerGold { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();

        public void PlayerStatus()
        {
            Console.WriteLine($"LV. {PlayerLv}");
            Console.WriteLine($"{PlayerName} ( {PlayerJob} )");
            Console.WriteLine($"공격력 : {PlayerAtk}");
            Console.WriteLine($"방어력 : {PlayerDef}");
            Console.WriteLine($"체  력 : {PlayerHP}");
            Console.WriteLine($"소지금 : {PlayerGold}G");

        }
    }

    public class Item
    {
        public int ItemNum { get; set; }
        public string? ItemName { get; set; }
        public string? ItemType { get; set; }
        public int ItemAtk { get; set; }
        public int ItemDef { get; set; }
        public string? ItemInfo { get; set; }
        public int ItemGold { get; set; }
        public bool ItemEqui { get; set; } = false;

        public void ItemStatus(string EquiMark = "")
        {
            Console.WriteLine($"{EquiMark}{ItemName} | {(ItemType=="Weapon"? "공격력" : "방어력")} : {(ItemType=="Weapon"? ItemAtk : ItemDef)} | {ItemInfo}");
            // if (ItemType == "Weapon")
            // {
            //     Console.WriteLine($"{EquiMark}{ItemName} | 공격력 : {ItemAtk} | {ItemInfo} | {ItemGold} G");
            // }
            // else if (ItemType == "Armor")
            // {
            //     Console.WriteLine($"{EquiMark}{ItemName} | 방어력 : {ItemDef} | {ItemInfo} | {ItemGold} G");
            // }
        }
    }

    public class Inventory
    {
        public List<Item> OwnedItems { get; set; } = new List<Item>();

        public void ShowInventory()
        {
            foreach (var item in OwnedItems)
            {
                string ItemEqui = item.ItemEqui ? "[E]" : "";
                item.ItemStatus();
            }
        }
    }

    static void Main(string[] args)
    {
        Page currentPage = Page.MainMenu;
        bool onOff = true;
        PlayerDB playerDB = new PlayerDB();
        ItemDB itemDB = new ItemDB();
        Player? targetPlayer = playerDB.AllPlayer.FirstOrDefault(p => p.PlayerNum == 1);

        while (onOff)
        {
            switch (currentPage)
            {
                case Page.MainMenu:
                    // Console.Clear();
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");
                    Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다");
                    Console.WriteLine();
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.WriteLine("4. 게임종료");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.WriteLine(">>");
                    int pageNumMain = int.Parse(Console.ReadLine());
                    if (1 <= pageNumMain && pageNumMain <= 4)
                    {
                        currentPage = (Page)pageNumMain;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");
                    }
                    break;
                case Page.Status:
                    //Console.Clear();
                    Console.WriteLine("상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                    Console.WriteLine();
                    if (targetPlayer != null)
                    {
                        targetPlayer.PlayerStatus();
                    }
                    else
                    {
                        Console.WriteLine("플레이어 정보를 찾을 수 없습니다");
                    }
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.WriteLine(">>");
                    int pageNumStat = int.Parse(Console.ReadLine());
                    if (pageNumStat == 0)
                    {
                        currentPage = (Page)pageNumStat;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");
                    }
                    break;
                case Page.Inventory:
                    //Console.Clear();
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine();
                    if (targetPlayer != null)
                    {
                        targetPlayer.Inventory.ShowInventory();
                    }
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.WriteLine(">>");
                    int pageNumItem = int.Parse(Console.ReadLine());
                    if (pageNumItem == 0)
                    {
                        currentPage = (Page)pageNumItem;
                    }
                    else if (pageNumItem == 1)
                    {
                        currentPage = Page.EquipInventory;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");
                    }
                    break;
                case Page.Shop:
                    //Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine();
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($"{targetPlayer.PlayerGold}G");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    foreach (var shopItem in itemDB.AllItems)
                    {
                        bool alreadyOwned = targetPlayer.Inventory.OwnedItems.Any(i => i.ItemNum == shopItem.ItemNum);

                        if (alreadyOwned)
                        {
                            Console.WriteLine($"{shopItem.ItemName} | {(shopItem.ItemType == "Weapon" ? "공격력" : "방어력")} : {(shopItem.ItemType == "Weapon" ? shopItem.ItemAtk : shopItem.ItemDef)} | {shopItem.ItemInfo} | 구매 완료");
                        }
                        else
                        {
                            Console.WriteLine($"{shopItem.ItemName} | {(shopItem.ItemType == "Weapon" ? "공격력" : "방어력")} : {(shopItem.ItemType == "Weapon" ? shopItem.ItemAtk : shopItem.ItemDef)} | {shopItem.ItemInfo} | {shopItem.ItemGold} G");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("1. 아이템 구매");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.WriteLine(">>");
                    int pageNumShop = int.Parse(Console.ReadLine());
                    if (pageNumShop == 0)
                    {
                        currentPage = (Page)pageNumShop;
                    }
                    else if (pageNumShop == 1)
                    {
                        currentPage = Page.BuyShop;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");
                    }
                    break;
                case Page.EquipInventory:
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    foreach (var item in targetPlayer.Inventory.OwnedItems)
                    {
                        string EquiMark = item.ItemEqui ? "[E]" : "";
                        Console.WriteLine($"{item.ItemNum}. {EquiMark}{item.ItemName} | {(item.ItemType == "Weapon" ? "공격력" : "방어력")} : {(item.ItemType == "Weapon" ? item.ItemAtk : item.ItemDef)} | {item.ItemInfo}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.WriteLine(">>");
                    int pageNumInven = int.Parse(Console.ReadLine());
                    if (pageNumInven == 0)
                    {
                        currentPage = Page.Inventory;
                    }
                    else
                    {
                        Item? selectedItem = targetPlayer.Inventory.OwnedItems.FirstOrDefault(i => i.ItemNum == pageNumInven);

                        if (selectedItem != null)
                        {
                            if (selectedItem.ItemEqui)
                            {
                                selectedItem.ItemEqui = false;
                                Console.WriteLine($"{selectedItem.ItemName} 장착 해제했습니다.");
                            }
                            else
                            {
                                selectedItem.ItemEqui = true;
                                Console.WriteLine($"{selectedItem.ItemName} 장작하였습니다.");
                            }
                        }

                    }

                    break;
                case Page.BuyShop:
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine();
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($"{targetPlayer.PlayerGold}G");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    for (int i = 0; i < itemDB.AllItems.Count; i++)
                    {
                        var shopItem = itemDB.AllItems[i];

                        bool alreadyOwned = targetPlayer.Inventory.OwnedItems.Any(i => i.ItemNum == shopItem.ItemNum);

                        if (alreadyOwned)
                        {
                            Console.WriteLine($"{shopItem.ItemNum}. {shopItem.ItemName} | {(shopItem.ItemType == "Weapon" ? "공격력" : "방어력")} : {(shopItem.ItemType == "Weapon" ? shopItem.ItemAtk : shopItem.ItemDef)} | {shopItem.ItemInfo} | 구매 완료");
                        }
                        else
                        {
                            Console.WriteLine($"{shopItem.ItemNum}. {shopItem.ItemName} | {(shopItem.ItemType == "Weapon" ? "공격력" : "방어력")} : {(shopItem.ItemType == "Weapon" ? shopItem.ItemAtk : shopItem.ItemDef)} | {shopItem.ItemInfo} | {shopItem.ItemGold} G");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.WriteLine(">>");
                    int pageNumBuy = int.Parse(Console.ReadLine());
                    if (pageNumBuy == 0)
                    {
                        currentPage = Page.Shop;
                    }
                    else
                    {
                        Item? selectedItem = itemDB.AllItems.FirstOrDefault(i => i.ItemNum == pageNumBuy);

                        if (selectedItem == null)
                        {
                            Console.WriteLine("잘못된 입력입니다");
                        }
                        else
                        {
                            bool alreadyOwned = targetPlayer.Inventory.OwnedItems.Any(i => i.ItemNum == selectedItem.ItemNum);

                            if (alreadyOwned)
                            {
                                Console.WriteLine("이미 구매한 아이템입니다");
                            }
                            else
                            {
                                if (targetPlayer.PlayerGold < selectedItem.ItemGold)
                                {
                                    Console.WriteLine("소지금이 부족합니다.");
                                }
                                else
                                {
                                    targetPlayer.PlayerGold -= selectedItem.ItemGold;
                                    targetPlayer.Inventory.OwnedItems.Add(selectedItem);
                                    Console.WriteLine($"{selectedItem.ItemName}을(를) 구매하였습니다.");
                                }
                            }
                        }
                    }
                    break;
                case Page.Exit:
                    Console.WriteLine("게임을 종료합니다");
                    onOff = false;
                    //Console.ReadKey();
                    break;
            }
        }
    }
}
