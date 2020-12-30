using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using fr34kyn01535.Uconomy;
using MySql.Data.MySqlClient;
using Rocket.Core;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using ShimmyMySherbet.MySQL.EF.Core;
using ShimmyMySherbet.MySQL.EF.Models;
using ShimmyMySherbet.ZaupShopNameUpgrade;

namespace ShimmysUconomyUtilityModder
{
    public class main : RocketPlugin
    {
        public MySQLEntityClient SQL;
        private FieldInfo ConnInfo = typeof(MySQLEntityClient).GetField("ActiveConnection", BindingFlags.NonPublic | BindingFlags.Instance);
        //public MySqlConnection connection => (MySqlConnection)ConnInfo.GetValue(SQL);
        public MySqlConnection connection;
        public UconomyConfiguration Config => Uconomy.Instance.Configuration.Instance;
        public static main Instance;
        public const string ItemsTable = "uconutility_modded_items";
        public const string VehiclesTable = "uconutility_modded_vehicles";

        public override void LoadPlugin()
        {
            base.LoadPlugin();
            Instance = this;
            R.Plugins.OnPluginsLoaded += Plugins_OnPluginsLoaded;
        }

        private void Plugins_OnPluginsLoaded()
        {
            SQL = new MySQLEntityClient(Config.DatabaseAddress, Config.DatabaseUsername, Config.DatabasePassword, Config.DatabaseName, Config.DatabasePort, true);
            connection = new MySqlConnection(SQL.ConnectionString);
            connection.Open();
            SQL.Connect();
            Logger.Log($"Connected: {SQL.Connected}");
            CheckSchema();
        }


        public void CheckSchema()
        {
            if (!SQL.TableExists(ItemsTable))
                SQL.CreateTable<DBModel>(ItemsTable);
            if (!SQL.TableExists(VehiclesTable))
                SQL.CreateTable<DBModel>(VehiclesTable);
        }


        public class DBModel
        {
            [SQLPrimaryKey]
            public ushort ID;
            public string Name;
        }

        public async Task RunUpdate()
        {
            PatchTool tool = new PatchTool();
            await tool.Run(x => Console.WriteLine(x));
            Console.WriteLine("ucon Modded update complete.");
        }
    }
}
