using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_QLTienAn.Models
{
    class Object_ThanhToan
    {
        public int maDKy { get; set; }
        public string HoTen { get; set; }
        public int maCTN { get; set; }
        public int maHV { get; set; }
        public int maThanhToan { get; set; }
        public DateTime ngayNghi { get; set; }
        public int sang { get; set; }
        public int toi { get; set; }
        public int trua { get; set; }
        public int TienCuaCTN { get; set; }


        public int AutoFindTCA_CALTienCTN(List<TieuChuanAn> TCA)
        {
            DateTime temp = this.ngayNghi;

            int MAXvalue = Int32.MaxValue;
            foreach (var item in TCA)
            {
                TimeSpan diffDate = temp.Date - item.NgayApDung.Date;
                int diffDays = (int)diffDate.TotalDays;
                if (diffDays <= MAXvalue && diffDays >= 0)
                {
                    MAXvalue = diffDays;
                }
            }
            DateTime ngayCal = DateTime.Now;
            if (MAXvalue == Int32.MaxValue)
            {
                ngayCal = TCA[0].NgayApDung;
            }
            else
            {
                ngayCal = temp.AddDays(MAXvalue * (-1));
            }

            TieuChuanAn TruthTCA = TCA.Find(s => s.NgayApDung.Date == ngayCal.Date);

            TienCuaCTN = sang * (int)TruthTCA.TienAnSang + trua * (int)TruthTCA.TienAnTrua + toi * (int)TruthTCA.TienAnToi;

            return TienCuaCTN;
        }
    }
}
