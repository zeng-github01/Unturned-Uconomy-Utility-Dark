using fr34kyn01535.Uconomy;
using MySql.Data.MySqlClient;
using SDG.Unturned;
using ShimmyMySherbet.MySQL.EF.Core;
using ShimmyMySherbet.MySQL.EF.Models;
using ShimmysUconomyUtilityModder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShimmyMySherbet.ZaupShopNameUpgrade
{
    public class PatchTool
    {
        public async Task Run(Action<string> Log)
        {
            Log("Connecting to database...");
            UconomyConfiguration config = Uconomy.Instance.Configuration.Instance;
            MySqlConnection connection = new MySqlConnection($"server={config.DatabaseAddress};Database={config.DatabaseName};Uid={config.DatabaseUsername};Pwd={config.DatabasePassword};Port={config.DatabasePort}");
            await connection.OpenAsync();

            var Client = new MySQLEntityClient(connection);

            Log("connected to database!");
            Log("Finding all Item Assets...");
            //Dictionary<ushort, string> Items = new Dictionary<ushort, string>();

            var itemsWriter = new TransactionalBulkInserter<ZaupItem>(connection, main.ItemsTable);
            var Items = new List<ushort>();

            Asset[] ItemAssets = Assets.find(EAssetType.ITEM).Where(x => (x is ItemAsset IA && IA.assetOrigin == EAssetOrigin.WORKSHOP)).ToArray();

            int Truncated = 0;

            foreach (Asset asset in ItemAssets)
            {
                if (asset is ItemAsset IA)
                {
                    if (!Items.Contains(asset.id))
                    {
                        Items.Add(asset.id);
                        itemsWriter.Insert(new ZaupItem() { ID = asset.id, ItemName = AssetNameTool.GetAssetName(asset, ref Truncated), BuyBack = 0, Cost = 0 });
                    }
                }
            }
            Log($"Found {Items.Count} items.");
            Log("Finding all Item Assets...");
            var vehiclesWriter = new TransactionalBulkInserter<ZaupVehicle>(connection, main.VehiclesTable);
            var vehicles = new List<ushort>();

            Asset[] VehicleAssets = Assets.find(EAssetType.VEHICLE).Where(x => (x is VehicleAsset IA && IA.assetOrigin == EAssetOrigin.WORKSHOP)).ToArray();
            foreach (Asset asset in VehicleAssets)
            {
                if (asset is VehicleAsset va)
                {
                    if (!vehicles.Contains(asset.id))
                    {
                        vehicles.Add(asset.id);
                        vehiclesWriter.Insert(new ZaupVehicle() { ID = asset.id, VehicleName = AssetNameTool.GetAssetName(asset, ref Truncated), Cost = 0 });
                    }
                }
            }

            Log($"Found {vehicles.Count} vehicles.");

            if (Truncated > 0)
            {
                Log($"WARNING: Some item names were too long to fit in the database, {Truncated} item/vehicle names were truncated to 32 characters.");
            }

            Log("Writing data to table...");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            vehiclesWriter.Commit();
            var r = itemsWriter.Commit();
            sw.Stop();

            Log($"Upload Complete in {sw.ElapsedMilliseconds}ms  (@ {Math.Round((vehicles.Count + Items.Count) / (double)(sw.ElapsedMilliseconds * 1000), 2)} p/s), rows modified: {r}.");
        }
    }

    public static class AssetNameTool
    {
        public static string GetAssetName(Asset asset, ref int Truncated)
        {
            if (asset is ItemAsset IA)
            {
                string name = (IA.itemName == null ? (IA.name == null ? "#NAME" : IA.name) : IA.itemName);
                if (name.Length > 32)
                {
                    name = name.Substring(0, 32);
                    Truncated++;
                }

                return name;
            }
            else if (asset is VehicleAsset VA)
            {
                string name = (VA.vehicleName == null ? (VA.name == null ? "#NAME" : VA.name) : VA.vehicleName);
                if (name.Length > 32)
                {
                    name = name.Substring(0, 32);
                    Truncated++;
                }

                return name;
            }
            else
            {
                string name = (asset.name == null ? "#NAME" : asset.name);

                if (name.Length > 32)
                {
                    name = name.Substring(0, 32);
                    Truncated++;
                }

                return name;
            }
        }
    }
}