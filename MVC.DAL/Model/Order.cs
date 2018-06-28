namespace MVC.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        [StringLength(50)]
        public string OrderName { get; set; }

        public int? UserId { get; set; }

        public int? BurgerId { get; set; }

        public virtual Burger Burger { get; set; }

        public virtual User User { get; set; }
    }
}
