using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repositories.Generic;

namespace Infrastructure.Repositories;

public class ItemTypeRepository : BaseReadRepository<ItemType, AppDbContext>
{
    public ItemTypeRepository(AppDbContext context) : base(context) { }
}