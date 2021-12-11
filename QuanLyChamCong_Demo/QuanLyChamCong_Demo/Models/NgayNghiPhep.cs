using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class NgayNghiPhep
    {
        public NgayNghiPhep()
        {
            CaNghiPheps = new HashSet<CaNghiPhep>();
        }

        public string MaNgayNghiPhep { get; set; }
        public string MaYeuCauNghiPhep { get; set; }
        public DateTime NgayNghi { get; set; }
        public bool? Xoa { get; set; }

        public virtual YeuCauNghiPhep MaYeuCauNghiPhepNavigation { get; set; }
        public virtual ICollection<CaNghiPhep> CaNghiPheps { get; set; }
    }
}
