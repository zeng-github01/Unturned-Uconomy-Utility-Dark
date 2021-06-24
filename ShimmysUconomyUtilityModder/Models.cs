using ShimmyMySherbet.MySQL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShimmysUconomyUtilityModder
{
    public class ZaupItem 
    {
        [SQLPrimaryKey]
        public int ID;

        public string ItemName;

        public decimal Cost;

        public decimal BuyBack;

    }


    public class ZaupVehicle
    {
        [SQLPrimaryKey]
        public int ID;

        public string VehicleName;

        public decimal Cost;

    }
}
