using System.ComponentModel.DataAnnotations;

public class ProductResfulModel
{
    [Required(ErrorMessage ="input id")]
    public string id { get; set; }
    public string name { get; set; }
    public string price { get; set; }
    public string img { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public bool deleted { get; set; }
}