﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_BD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShoppingCenterEntities : DbContext
    {
        public ShoppingCenterEntities()
            : base("name=ShoppingCenterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<МАГАЗИН> МАГАЗИН { get; set; }
        public virtual DbSet<ПОКУПАТЕЛЬ> ПОКУПАТЕЛЬ { get; set; }
        public virtual DbSet<ПРОДАЖА> ПРОДАЖА { get; set; }
        public virtual DbSet<ПРОДУКТ> ПРОДУКТ { get; set; }
        public virtual DbSet<СОТРУДНИК> СОТРУДНИК { get; set; }
        public virtual DbSet<ЭЛЕМЕНТ_ПРОДАЖИ> ЭЛЕМЕНТ_ПРОДАЖИ { get; set; }
    }
}
