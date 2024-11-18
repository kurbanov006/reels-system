public static class CategoryMapping
{
    public static Category CreateCategory(this CreateCategoryInfo category)
    {
        return new Category()
        {
            Name = category.BaseCategoryInfo.Name
        };
    }

    public static Category ToUpdate(this Category category, UpdateCategoryInfo updateCategory)
    {
        category.Name = updateCategory.BaseCategoryInfo.Name;
        category.UpdatedAt = DateTime.UtcNow;
        return category;
    }

    public static Category ToDelete(this Category category)
    {
        category.IsDeleted = true;
        category.DeletedAt = DateTime.UtcNow;
        return category;
    }

    public static ReadCategoryInfo ToRead(this Category category)
    {
        return new ReadCategoryInfo()
        {
            Id = category.Id,
            CreatedAt = category.CreatedAt,
            BaseCategoryInfo = new BaseCategoryInfo()
            {
                Name = category.Name
            }
        };
    }
}