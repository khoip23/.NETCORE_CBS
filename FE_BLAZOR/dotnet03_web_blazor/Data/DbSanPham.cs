public static class DbSanPham
{
    public static List<SanPhamVM> lst = new List<SanPhamVM>();

    static DbSanPham()
    {
        for (int i = 1; i <= 3; i++)
        {
            SanPhamVM sp = new SanPhamVM()
            {
                maSanPham = i,
                tenSanPham = $"Sản phẩm {i}",
                hinhAnh = $"https://dummyimage.com/200x200?text=sản phẩm {i}",
                giaBan = 1000 * i,
            };
            lst.Add(sp);
        }
    }
}
