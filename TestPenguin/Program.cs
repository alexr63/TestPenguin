using Newtonsoft.Json;

// Initialise data

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
    new DoorTypeAndHinge { Id = 5, Name = "Brushed stainless rolled edge door with slam latch (std option)" },
    new DoorTypeAndHinge { Id = 6, Name = "Integrated throw hinge door (internal use only)" },
    new DoorTypeAndHinge { Id = 7, Name = "316 Stainless with rolled edge door & slam latch (external use)" },
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
    new Category
    {
        Id = 4, Name = "MS130 – 130 Litre stainless marine fridge",
        CategoryDoorTypeAndHinges = new List<CategoryDoorTypeAndHinge>
        {
            new CategoryDoorTypeAndHinge { CategoryId = 4, DoorTypeAndHingeId = 5 },
            new CategoryDoorTypeAndHinge { CategoryId = 4, DoorTypeAndHingeId = 6 },
            new CategoryDoorTypeAndHinge { CategoryId = 4, DoorTypeAndHingeId = 7 },
        },
    },
};

var products = new List<Product>
{
    new Product(1, "VFC39IBLAL", 1, 664.70m, 3, 1, 1, 1),
    new Product(2, "VFC39PBLAL", 1, 664.70m, 4, 1, 1, 1),
    new Product(3, "VFDP144LBLAL-K-", 2, 61996.41m, 1, 1, 3, 1),
    new Product(4, "VFTL20L", 3, 832.17m, 2, null, 5, 1),
    new Product(5, "1G50841-TH-12V-A-12/24", 4, 2472.00m, 3, 6, 1, 1),
};

foreach (var product in products)
{
    product.Category = categories.Single(c => c.Id == product.CategoryId);
    product.FridgeFreezerConfiguration = fridgeFreezerConfigurations.Single(f => f.Id == product.FridgeFreezerConfigurationId);
    product.DoorTypeAndHinge = doorTypeAndHinges.SingleOrDefault(d => d.Id == product.DoorTypeAndHingeId);
    product.CompressorAndCondenser = compressorAndCondensers.Single(c => c.Id == product.CompressorAndCondenserId);
    product.CompressorVoltage = compressorVoltages.Single(c => c.Id == product.CompressorVoltageId);
}

// Display all products
foreach (var product in products)
{
    var json = JsonConvert.SerializeObject(product, Formatting.Indented);
    Console.WriteLine(json);
}

// Display FridgeFreezerConfigurationIds for Category 1 products
Console.WriteLine("FridgeFreezerConfigurationIds for Category 39 Litre 12/24 volt marine fridge products");
var category1Products = products.Where(p => p.CategoryId == 1).ToList();
var category1ProductFridgeFreezerConfigurationIds = category1Products.Select(p => p.FridgeFreezerConfigurationId).ToList();
string jsonString = JsonConvert.SerializeObject(category1ProductFridgeFreezerConfigurationIds, Formatting.Indented);
Console.WriteLine(jsonString);

// Display FridgeFreezerConfigurationIds for Category 3 products  
Console.WriteLine("FridgeFreezerConfigurationIds for Category 20 Litre top opening 12/24 volt marine fridge products");
var category3Products = products.Where(p => p.CategoryId == 3).ToList();
var category3ProductFridgeFreezerConfigurationIds = category3Products.Select(p => p.FridgeFreezerConfigurationId).ToList();
jsonString = JsonConvert.SerializeObject(category3ProductFridgeFreezerConfigurationIds, Formatting.Indented);
Console.WriteLine(jsonString);

// Display DoorTypeAndHingeIds for Category 3 products
Console.WriteLine("DoorTypeAndHingeIds for Category 20 Litre top opening 12/24 volt marine fridge products");
var category3ProductDoorTypeAndHingeIds = category3Products.Select(p => p.DoorTypeAndHingeId).ToList();
jsonString = JsonConvert.SerializeObject(category3ProductDoorTypeAndHingeIds, Formatting.Indented);
Console.WriteLine(jsonString);

// Display Category C39 – 39 Litre 12/24 volt marine fridge products with FridgeFreezerConfiguration = Front opening with ice box - standard option
Console.WriteLine("Category C39 – 39 Litre 12/24 volt marine fridge products with FridgeFreezerConfiguration = Front opening with ice box - standard option");
category1Products.Where(p => p.FridgeFreezerConfigurationId == 3).ToList().ForEach(p => Console.WriteLine(p.Name));

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CategoryDoorTypeAndHinge> CategoryDoorTypeAndHinges { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public class CategoryDoorTypeAndHinge
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public int DoorTypeAndHingeId { get; set; }
    public virtual DoorTypeAndHinge DoorTypeAndHinge { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public decimal Price { get; set; }

    public int? FridgeFreezerConfigurationId { get; set; }
    public virtual FridgeFreezerConfiguration FridgeFreezerConfiguration { get; set; }
    public int? DoorTypeAndHingeId { get; set; }
    public virtual DoorTypeAndHinge? DoorTypeAndHinge { get; set; }
    public int? CompressorAndCondenserId { get; set; }
    public virtual CompressorAndCondenser CompressorAndCondenser { get; set; }
    public int? CompressorVoltageId { get; set; }
    public virtual CompressorVoltage CompressorVoltage { get; set; }

    public Product(int id, string name, int categoryId, decimal price,
        int? fridgeFreezerConfigurationId,
        int? doorTypeAndHingeId,
        int? compressorAndCondenserId,
        int? compressorVoltageId)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Price = price;
        FridgeFreezerConfigurationId = fridgeFreezerConfigurationId;
        DoorTypeAndHingeId = doorTypeAndHingeId;
        CompressorAndCondenserId = compressorAndCondenserId;
        CompressorVoltageId = compressorVoltageId;
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