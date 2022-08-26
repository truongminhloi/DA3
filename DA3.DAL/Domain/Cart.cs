﻿using DA3.Common;

namespace DA3.DAL.Domain
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string ProductId { get; set; }

        public decimal Amount { get; set; }

        public double PricePerProduct { get; set; }

        public double PricePerAllProducts { get; set; }

        public Status Status { get; set; }
    }
}
