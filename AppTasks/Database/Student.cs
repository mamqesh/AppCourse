//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppTasks.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int StudentTicket { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Sex { get; set; }
        public int Group { get; set; }
        public string Password { get; set; }
    
        public virtual Group Group1 { get; set; }
        public virtual Sex Sex1 { get; set; }
    }
}
