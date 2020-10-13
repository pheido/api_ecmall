using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using api_ecmall.Domain.Entities.WareHouse;

namespace api_ecmall.Domain.Abstract
{
    public interface IWarehouseRepository
    {
        IEnumerable<WarehouseInfo> WarehouseInfoes { get; }
        void SaveWarehouse(WarehouseInfo info);
    }
}
