using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace KillerApp.ViewModels
{
    public class ItemViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Item Type is required")]
        [Display]
        public eItemType ItemType { get; set; }
        public eItemLoc ItemLoc { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int HealthUp { get; set; }
        public int SpeedUp { get; set; }
        public int StrengthUp { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }
    }
}
