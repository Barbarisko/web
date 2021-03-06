﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    interface IProductPropertyRepository
    {
        IEnumerable<ProductProperties> GetAllItems(bool includePP = false);
        ProductProperties GetProductPropertiesById(int PPId, bool includePP = false);
        void SaveProductProperties(ProductProperties PP);
        void DeleteProductProperties(ProductProperties PP);
    }
}
