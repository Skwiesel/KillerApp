using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Contexts
{
    internal class InvItemDBContext : IItemContext
    {
        static string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KillerApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;

        ItemModel dbItem;
        List<ItemModel> dbItems = new List<ItemModel>();

        public void Remove(int id)
        {
            
        }
        public ItemModel Create(ItemModel dbItem)
        {
            dbItem.ItemLoc = eItemLoc.Inventory;
            dbItems.Add(dbItem);
            return dbItem;
        }
        public ItemModel Get(int id)
        {
            con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetItemFromInv",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = con
            };
            cmd.Parameters.AddWithValue("@Item_Id", id);

            con.Open();
            using(SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    dbItem = Create(new ItemModel()
                    {
                        Id = (int)rdr[9],
                        Name = (string)rdr[1],
                        HealthUp = (int)rdr[2],
                        SpeedUp = (int)rdr[3],
                        StrengthUp = (int)rdr[4],
                        Damage = (int)rdr[5],
                        MaxDurability = (int)rdr[6],
                        ItemType = (eItemType)rdr[7],
                        Defense = (int)rdr[8],
                        BuyPrice = (int)rdr[12],
                        SellPrice = (int)rdr[13],
                        CurrentDurability = (int)rdr[14]
                    });
                }
            }
            con.Close();

            return dbItem;
        }
        public IEnumerable<ItemModel> GetAll()
        {
            con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetItemsInv",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = con
            };
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    dbItem = Create(new ItemModel()
                    {
                        Id = (int)rdr[9],
                        Name = (string)rdr[1],
                        HealthUp = (int)rdr[2],
                        SpeedUp = (int)rdr[3],
                        StrengthUp = (int)rdr[4],
                        Damage = (int)rdr[5],
                        MaxDurability = (int)rdr[6],
                        ItemType = (eItemType)Enum.Parse(typeof(eItemType), (string)rdr[7]),
                        Defense = (int)rdr[8],
                        BuyPrice = (int)rdr[12],
                        SellPrice = (int)rdr[13],
                        CurrentDurability = (int)rdr[14]
                    });
                }
            }
            con.Close();

            return dbItems;
        }
    }
}
