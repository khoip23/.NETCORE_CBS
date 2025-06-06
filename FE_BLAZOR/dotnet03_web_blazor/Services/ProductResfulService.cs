using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
public class ProductResfulService
{
    public HttpClient _http;
    public List<ProductResfulModel>? lstProduct = new List<ProductResfulModel>();
    public ProductResfulService(HttpClient http)
    {
        _http = http;
    }
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task getAllProduct()
    {
        // Gọi API ở đây nếu cần
        lstProduct = await _http.GetFromJsonAsync<List<ProductResfulModel>>("https://svcy.myclass.vn/api/ProductApi/getall");
        Console.WriteLine($"{JsonSerializer.Serialize(lstProduct)}");
        //Gọi để giao diện cập nhật lại
        NotifyStateChanged();
    }

    public async Task<int> createProduct(ProductResfulModel prd)
    {
        var response = await _http.PostAsJsonAsync("https://svcy.myclass.vn/api/ProductApi/create", prd);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //Thêm thành công 
            await getAllProduct();
            NotifyStateChanged();
            return 1;
        }
        else
        {
            NotifyStateChanged();
            return 2;
        }
    }

}



