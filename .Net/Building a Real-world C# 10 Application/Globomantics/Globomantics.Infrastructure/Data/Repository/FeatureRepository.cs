using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Infrastructure.Data.Repository;

public class FeatureRepository : TodoRepository<Feature>
{
    public FeatureRepository(GlobomanticsDbContext context) : base(context) { }

    public override async Task AddAsync(Feature feature)
    {
        var existingFeature = await Context.Features.FirstOrDefaultAsync(b => b.Id == feature.Id);
        
        var user = await Context.Users.SingleOrDefaultAsync(u => u.Id == feature.CreatedBy.Id);

        user ??= new() { Id = feature.CreatedBy.Id, Name = feature.CreatedBy.Name };

        if (existingFeature is not null)
        {
            await UpdateAsync(feature, existingFeature, user);
        }
        else
        {
            await CreateAsync(feature, user);
        }
}

    private async Task UpdateAsync(Feature feature, Data.Models.Feature featureToUpdate, Data.Models.User user)
    {
        await SetParentAsync(featureToUpdate, feature);

        featureToUpdate.IsCompleted = feature.IsCompleted;
        featureToUpdate.Component = feature.Component;
        featureToUpdate.Description = feature.Description;
        featureToUpdate.Title = feature.Title;
        featureToUpdate.Priority = feature.Priority;
        featureToUpdate.AssigedTo = user;
        featureToUpdate.CreatedBy = user;

        Context.Features.Update(featureToUpdate);
    }

    private async Task CreateAsync(Feature feature, Models.User user)
    {
        var featrueToAdd = DomainToDataMapping.MapTodoFromDomain<Feature, Data.Models.Feature>(feature);

        await SetParentAsync(featrueToAdd, feature);

        featrueToAdd.AssigedTo = user;
        featrueToAdd.CreatedBy = user;

        await Context.AddAsync(featrueToAdd);
    }

    public override async Task<Feature> GetAsync(Guid id)
    {
        var data = await Context.Features.SingleAsync(feature => feature.Id == id);

        return DataToDomainMapping.MapTodoFromData<Data.Models.Feature, Domain.Feature>(data);
    }
}

