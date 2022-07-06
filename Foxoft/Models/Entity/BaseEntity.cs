using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public partial class BaseEntity
    {
        [DisplayName("Yaradan İstifadəçi")]
        [StringLength(20, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        [DefaultValue(@"substring(suser_name(),patindex('%\%',suser_name())+(1),(20))")]
        public string CreatedUserName { get; set; }

        [DefaultValue("getdate()")]
        [Column(TypeName = "datetime")]
        [DisplayName("Yaradılma tarixi")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Son Dəyişən İstifadəçi")]
        [StringLength(20, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        [DefaultValue(@"substring(suser_name(),patindex('%\%',suser_name())+(1),(20))")]
        public string LastUpdatedUserName { get; set; }

        [DefaultValue("getdate()")]
        [Column(TypeName = "datetime")]
        [DisplayName("Son Dəyişmə tarixi")]
        public DateTime LastUpdatedDate { get; set; }
    }
}
