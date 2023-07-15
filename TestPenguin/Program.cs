// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var fridgeFreezerConfigurations = new List<FridgeFreezerConfiguration>
{
    new FridgeFreezerConfiguration { Id = 1, Name = "Front opening fridge freezer" },
    new FridgeFreezerConfiguration { Id = 2, Name = "Top opening fridge" },
    new FridgeFreezerConfiguration { Id = 3, Name = "Front opening with ice box - standard option" },
    new FridgeFreezerConfiguration { Id = 4, Name = "Front opening larder fridge (no ice box)" },
};

var doorTypeAndHinges = new List<DoorTypeAndHinge>
{
    new DoorTypeAndHinge { Id = 1, Name = "Black door no fitting frame" },
    new DoorTypeAndHinge { Id = 2, Name = "Black door and fitting frame" },
    new DoorTypeAndHinge { Id = 3, Name = "Grey door no fitting frame" },
    new DoorTypeAndHinge { Id = 4, Name = "Grey door and fitting frame" },
};

var compressorAndCondensers = new List<CompressorAndCondenser>
{
    new CompressorAndCondenser { Id = 1, Name = "Air cooled compressor (integral at base of cabinet)" },
    new CompressorAndCondenser { Id = 2, Name = "Separate remote air cooled compressor (with couplings)" },
    new CompressorAndCondenser { Id = 3, Name = "Frigoboat keelcooler and compressor" },
    new CompressorAndCondenser { Id = 4, Name = "Frigoboat sea water cooled compressor" },
    new CompressorAndCondenser { Id = 5, Name = "Air cooled compressor (pre-mounted 1.2m pipe length no couplings)" },
    new CompressorAndCondenser { Id = 6, Name = "Remote mount air cooled compressor with couplings - 1.2m pipe set" },
};

var compressorVoltages = new List<CompressorVoltage>
{
    new CompressorVoltage { Id = 1, Name = "12v/24V DC" },
};

var categories = new List<Category>
{
    new Category { Id = 1, Name = "C39 – 39 Litre 12/24 volt marine fridge" },
    new Category { Id = 2, Name = "SLIM150 144 Litre 12/24 volt marine fridge freezer" },
    new Category { Id = 3, Name = "20 Litre top opening 12/24 volt marine fridge" },
};

var products = new List<Product>
{
    new Product(1, "VFC39PBLAL", 1, 664.70m)
    {
        FridgeFreezerConfigurationId = 4,
        DoorTypeAndHingeId = 1,
        CompressorAndCondenserId = 1,
        CompressorVoltageId = 1,
    },
    new Product(2, "VFDP144LBLAL-K-", 2, 61996.41m)
    {
        FridgeFreezerConfigurationId = 1,
        DoorTypeAndHingeId = 1,
        CompressorAndCondenserId = 3,
        CompressorVoltageId = 1,
    },
    new Product(3, "VFTL20L", 3, 832.17m)
    {
        FridgeFreezerConfigurationId = 2,
        DoorTypeAndHingeId = null,
        CompressorAndCondenserId = 5,
        CompressorVoltageId = 1,
    },
};

var category3Products = products.Where(p => p.CategoryId == 3).ToList();
var category3ProductFridgeFreezerConfigurationIds = category3Products.Select(p => p.FridgeFreezerConfigurationId).ToList();
string productJsonString = JsonConvert.SerializeObject(category3ProductFridgeFreezerConfigurationIds, Formatting.Indented);
Console.WriteLine(productJsonString);

var category3ProductDoorTypeAndHingeIds = category3Products.Select(p => p.DoorTypeAndHingeId).ToList();
productJsonString = JsonConvert.SerializeObject(category3ProductDoorTypeAndHingeIds, Formatting.Indented);
Console.WriteLine(productJsonString);

foreach (var product in products)
{
    Console.WriteLine(product);
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public decimal Price { get; set; }

    public int FridgeFreezerConfigurationId { get; set; }
    public virtual FridgeFreezerConfiguration FridgeFreezerConfiguration { get; set; }
    public int? DoorTypeAndHingeId { get; set; }
    public virtual DoorTypeAndHinge DoorTypeAndHinge { get; set; }
    public int CompressorAndCondenserId { get; set; }
    public virtual CompressorAndCondenser CompressorAndCondenser { get; set; }
    public int CompressorVoltageId { get; set; }
    public virtual CompressorVoltage CompressorVoltage { get; set; }

    public Product(int id, string name, int categoryId, decimal price)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Price = price;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, CategoryId: {CategoryId}, Price: {Price}";
    }
}

public class CompressorVoltage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public class CompressorAndCondenser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public class DoorTypeAndHinge
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public class FridgeFreezerConfiguration
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}