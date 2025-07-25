using System.Collections;
using System.ComponentModel.DataAnnotations;

public class PhongBan
{
    [Key]
    public int maPhongBan { get; set; }
    public string tenPhongBan { get; set; }
    public string diaDiem { get; set; }
    public ICollection<NhanVien> nhanViens{ get; set; }
}