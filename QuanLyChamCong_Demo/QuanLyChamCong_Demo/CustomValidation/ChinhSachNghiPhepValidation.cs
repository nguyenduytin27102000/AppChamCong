using QuanLyChamCong_Demo.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuanLyChamCong_Demo.CustomValidation
{
    public class MaChinhSachNghiPhepBiTrung : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (QLCHAMCONGContext)validationContext.GetService(typeof(QLCHAMCONGContext));
            var dsChinhSach = context.ChinhSachNghiPheps.ToList();

            string maChinhSachMoi = value.ToString();

            foreach (var chinhSach in dsChinhSach)
            {
                if (maChinhSachMoi == chinhSach.MaChinhSachNghiPhep)
                {
                    return new ValidationResult("Mã này đã tồn tại trong danh sách!");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class SoPhepTonBeHonSoPhepTieuChuan : ValidationAttribute
    {
        private readonly string _soLuongPhepChuanNam;

        public SoPhepTonBeHonSoPhepTieuChuan(string soLuongPhepChuanNam)
        {
            _soLuongPhepChuanNam = soLuongPhepChuanNam;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_soLuongPhepChuanNam.ToString());

            byte soLuongPhepChuan = (byte)property.GetValue(validationContext.ObjectInstance, null);
            byte soLuongPhepTon = (byte)value;

            if (soLuongPhepTon > soLuongPhepChuan)
            {
                return new ValidationResult("Số lượng phép tồn không hợp lệ!");
            }

            return ValidationResult.Success;
        }
    }
}
