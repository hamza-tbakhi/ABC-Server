using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SearchModels
{
    public class OrderSearchModel
    {
        public string UserName { get; set; }
        public int? OrderStatus { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductDesc { get; set; }
        public double? ProductPrice { get; set; }
        public string ProductQrCode { get; set; }
        public string ProductStorePlace { get; set; }
        public string ClientName { get; set; }
        public string ClientMobileNo { get; set; }
        public string ClientAddress { get; set; }
        public DateTime? OrderDate { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }

    }
}
