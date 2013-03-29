﻿
namespace Bolo.WebShop.Models
{
    public class OrderDetailRecord
    {
        public virtual int Id { get; set; }
        public virtual int OrderRecord_Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal VatRate { get; set; }

        public virtual decimal UnitVat
        {
            get { return UnitPrice * VatRate; }
        }

        public virtual decimal Vat
        {
            get { return UnitVat * Quantity; }
        }

        public virtual decimal SubTotal
        {
            get { return UnitPrice * Quantity; }
        }

        public virtual decimal Total
        {
            get { return SubTotal + Vat; }
        }
    }
}