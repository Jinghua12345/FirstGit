namespace DataBaseLibrary.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
