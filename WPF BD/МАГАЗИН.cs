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
    
    public partial class МАГАЗИН
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public МАГАЗИН()
        {
            this.ПРОДУКТ = new HashSet<ПРОДУКТ>();
            this.СОТРУДНИК = new HashSet<СОТРУДНИК>();
        }
    
        public int ИдентификаторМагазина { get; set; }
        public string НазваниеМагазина { get; set; }
        public string КатегорияМагазина { get; set; }
        public string Местоположение { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПРОДУКТ> ПРОДУКТ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<СОТРУДНИК> СОТРУДНИК { get; set; }
    }
}
