using Domain.Entities.Products.Parameters;
using Store.Products.DesignTime.Events;

namespace Domain.Entities.Products;

public sealed class Product
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;
    
    private Guid _photo = Guid.NewGuid();
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;

    private int _quantity;
    
    private Guid _categoryId;

    private decimal _cost;

    private List<object> _domainEvents = [];

    private Product()
    {
    }

    public Product(CreateProductParameters parameters) : this()
    {
        SetTitle(new SetProductTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });
        
        SetDescription(new SetProductDescriptionParameters
        {
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider
        });
        
        SetQuantity(new SetProductQuantityParameters
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        
        SetCost(new SetProductCostParameters
        {
            Cost = parameters.Cost,
            TimeProvider = parameters.TimeProvider
        });
        
        UpdatePhoto(new SetProductPhotoParameters
        {
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductCreatedEvent
        {
            ProductId = Id,
            Title = Title,
            Description = Description,
            Photo = Photo,
            Cost = Cost,
            Quantity = Quantity,
            CetegoryId = CategoryId,
        });
    }

    public Guid Id => _id;

    public string Title => _title;
    
    public string Description => _description;

    public Guid Photo => _photo;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;

    public int Quantity => _quantity;
    
    public decimal Cost => _cost;

    public Guid CategoryId => _categoryId;

    public void SetTitle(SetProductTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductTitleSetEvent
        {
            ProductId = Id,
            Title = Title
        });
    }

    public void SetDescription(SetProductDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductDescriptionSetEvent
        {
            ProductId = Id,
            Description = Description
        });
    }

    public void SetQuantity(SetProductQuantityParameters parameters)
    {
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductQuantitySetEvent
        {
            ProductId = Id,
            Quantity = Quantity
        });
    }

    public void SetCost(SetProductCostParameters parameters)
    {
        _cost = parameters.Cost;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductCostSetEvent
        {
            ProductId = Id,
            Cost = Cost
        });
    }

    public void SetCategory(SetProductCategoryParameters parameters)
    {
        _categoryId = parameters.CategoryId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductCategorySetEvent
        {
            ProductId = Id,
            CategoryId = CategoryId
        });
    }

    public void UpdatePhoto(SetProductPhotoParameters parameters)
    {
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}