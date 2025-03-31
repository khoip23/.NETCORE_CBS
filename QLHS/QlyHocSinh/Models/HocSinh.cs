class HocSinh
{
    public int Id { get; set; }
    public string HoTen { get; set; }
    public int diemToan { get; set; }
    public int diemVan { get; set; }
    public int diemAnh { get; set; }

    public HocSinh()
    {
        // contructor mặc định
    }

    public HocSinh(string hoten, int diemtoan, int diemvan, int diemanh)
    {
        Id = Id++; // iddem default =1
        HoTen = hoten;
        diemToan = diemtoan;
        diemVan = diemvan;
        diemAnh = diemanh;
    }

    public void ShowInfor()
    {
        Console.WriteLine(
            $"{Id} - {HoTen} - Diem toan: {diemToan} - Diem van: {diemVan} - Diem anh: {diemAnh}"
        );
    }
}
