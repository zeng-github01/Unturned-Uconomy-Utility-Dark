using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fr34kyn01535.Uconomy;
using MySql.Data.MySqlClient;
using SDG.Unturned;
using ShimmysUconomyUtilityModder;

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
            Log("connected to database!");
            Log("Finding all Item Assets...");
            Dictionary<ushort, string> Items = new Dictionary<ushort, string>();
            Asset[] ItemAssets = Assets.find(EAssetType.ITEM).Where(x => (x is ItemAsset IA && IA.assetOrigin == EAssetOrigin.WORKSHOP)).ToArray();

            int Truncated = 0;

            foreach (Asset asset in ItemAssets)
            {
                if (asset is ItemAsset IA)
                {
                    if (!Items.ContainsKey(asset.id))
                        Items.Add(asset.id, AssetNameTool.GetAssetName(asset, ref Truncated));
                }
            }
            Log($"Found {Items.Count} items.");
            Log("Finding all Item Assets...");
            Dictionary<ushort, string> Vehicles = new Dictionary<ushort, string>();
            Asset[] VehicleAssets = Assets.find(EAssetType.VEHICLE).Where(x => (x is VehicleAsset IA && IA.assetOrigin == EAssetOrigin.WORKSHOP)).ToArray();
            foreach (Asset asset in VehicleAssets)
            {
                if (asset is VehicleAsset)
                {
                    if (!Vehicles.ContainsKey(asset.id))
                        Vehicles.Add(asset.id, AssetNameTool.GetAssetName(asset, ref Truncated));
                }
            }

            Log($"Found {Vehicles.Count} vehicles.");

            if (Truncated > 0)
            {
                Log($"WARNING: Some item names were too long to fit in the database, {Truncated} item/vehicle names were truncated to 32 characters.");
            }

            Log("Generating update dump");

            StringBuilder Writer = new StringBuilder();

            foreach (var Item in Items)
            {
                Writer.AppendLine($"INSERT IGNORE INTO `{main.ItemsTable}` VALUES ({Item.Key}, '{Item.Value.Replace("'", "''")}');");
            }
            foreach (var Vehicle in Vehicles)
            {
                Writer.AppendLine($"INSERT IGNORE INTO `{main.VehiclesTable}` VALUES ({Vehicle.Key}, '{Vehicle.Value.Replace("'", "''")}');");
            }

            Log("Dumping SQL dump...");

            Log("SQL Dump generated, uploading dump to database...");

            MySqlScript script = new MySqlScript(connection, Writer.ToString());

            int r = await script.ExecuteAsync();

            Log($"Upload Complete, rows modified: {r}.");
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