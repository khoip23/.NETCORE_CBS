using System.Net.Http;
using System.Net.Http.Json;

public class ProductStateService(HttpClient http)
{
    public List<ProductViewModel> lstProduct = new List<ProductViewModel>();

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task GetAllProductApiStore()
    {
        try
        {
            ResponseApiType<List<ProductViewModel>>? data = await http.GetFromJsonAsync<
                ResponseApiType<List<ProductViewModel>>
            >("http://apistore.cybersoft.edu.vn/api/Product");

            lstProduct = data.content;

            //render lại giao diện
            NotifyStateChanged(); //hàm yêu cầu giao diện reload 1 lần nữa
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GET failed: {ex.Message}");
        }
    }
}
