//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ЭЛЕМЕНТ_ПРОДАЖИ
    {
        public int ИдентификаторЭлементаПродажи { get; set; }
        public Nullable<int> ИдентификаторПродажи { get; set; }
        public Nullable<int> ИдентификаторПродукта { get; set; }
        public Nullable<int> Количество { get; set; }
        public Nullable<decimal> СуммаПозиции { get; set; }
    
        public virtual ПРОДАЖА ПРОДАЖА { get; set; }
        public virtual ПРОДУКТ ПРОДУКТ { get; set; }
    }
}
