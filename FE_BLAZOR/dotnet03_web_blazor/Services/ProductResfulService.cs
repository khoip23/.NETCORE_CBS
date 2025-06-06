using System.Net.Http;
using System.Net.Http.Json;

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
        lstProduct = await _http.GetFromJsonAsync<List<ProductResfulModel>>(
            "https://svcy.myclass.vn/api/ProductApi/getall"
        );
        NotifyStateChanged();
    }

    // Place your HTTP methods below
}
