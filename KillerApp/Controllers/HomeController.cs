using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KillerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;

namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        private ShopItemLogic shopItemLogic =
           new ShopItemLogic(StorageType.Memory);
        private InvItemLogic invItemLogic =
           new InvItemLogic(StorageType.Database);
        private PlayerLogic playerLogic =
            new PlayerLogic(StorageType.Memory);

        public IActionResult Index(int playerID)
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Shop(int itemID)
        {
            if(itemID != 0)
            {
                PlayerModel player = playerLogic.Get(1);
                ItemModel item = shopItemLogic.Buy(itemID, player);
                invItemLogic.Transfer(item);
            }
            return PartialView("Shop", shopItemLogic.GetAll());
        }
        [HttpGet]
        public PartialViewResult Inventory(int itemID, int actionID)
        {
            if (itemID != 0)
            {
                ItemModel item;
                PlayerModel player = playerLogic.Get(1);

                switch (actionID)
                {
                    case 1:
                        item = invItemLogic.Sell(itemID, player);
                        shopItemLogic.Transfer(item);
                        break;
                    case 2:
                        item = invItemLogic.Use(invItemLogic.Get(itemID), player);
                        break;
                    case 3:
                        item = invItemLogic.Repair(invItemLogic.Get(itemID), player);
                        break;
                }
            }
            
            return PartialView("Inventory", invItemLogic.GetAll());
        }
        [HttpGet]
        public PartialViewResult InvItemInfo(int id)
        {
            ItemModel item = invItemLogic.Get(id);
            return PartialView("ItemInfo", item);
        }
        [HttpGet]
        public PartialViewResult ShopItemInfo(int id)
        {
            ItemModel item = shopItemLogic.Get(id);
            return PartialView("ItemInfo", item);
        }
        [HttpGet]
        public PartialViewResult PlayerStats()
        {
            PlayerModel player = playerLogic.Get(1);
            return PartialView("PlayerStats", player);
        }

        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(ItemViewModel addItemVM)
        {
            if (ModelState.IsValid)
            {
                ItemModel newItem = new ItemModel()
                {
                    Name = addItemVM.Name,
                    BuyPrice = addItemVM.BuyPrice,
                    CurrentDurability = addItemVM.CurrentDurability,
                    Damage = addItemVM.Damage,
                    Defense = addItemVM.Defense,
                    HealthUp = addItemVM.HealthUp,
                    ItemLoc = addItemVM.ItemLoc,
                    ItemType = addItemVM.ItemType,
                    MaxDurability = addItemVM.MaxDurability,
                    SellPrice = addItemVM.SellPrice,
                    SpeedUp = addItemVM.SpeedUp,
                    StrengthUp = addItemVM.StrengthUp
                };
                if(newItem.ItemLoc == eItemLoc.Inventory)
                {
                    invItemLogic.Create(newItem);
                }
                else if(newItem.ItemLoc == eItemLoc.Shop)
                {
                    shopItemLogic.Create(newItem);
                }
                return RedirectToAction("");
            }
            return View(addItemVM);
        }
    }
}
