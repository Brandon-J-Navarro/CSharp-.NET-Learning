using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Infrastructure.Data.Repository;

public class BugRepository : TodoRepository<Bug>
{
    public BugRepository(GlobomanticsDbContext context) : base(context) { }

    public override async Task AddAsync(Bug bug)
    {
        var exisitingBug = await Context.Bugs.FirstOrDefaultAsync(b => b.Id == bug.Id);

        var user = await Context.Users.SingleOrDefaultAsync(u => u.Id == bug.CreatedBy.Id);

        user ??= new() { Id = bug.CreatedBy.Id, Name = bug.CreatedBy.Name };

        if(exisitingBug is not null)
        {
            await UpdateAsync(bug, exisitingBug, user);
        }
        else
        {
            await CreateAsync(bug, user);
        }
    }

    private async Task UpdateAsync(Bug bug, Models.Bug exisitingBug, Models.User user)
    {
        exisitingBug.IsCompleted = bug.IsCompleted;
        exisitingBug.AffectedVersion = bug.AffectedVersion;
        exisitingBug.AffectedUsers = bug.AffectedUsers;
        exisitingBug.Description = bug.Description;
        exisitingBug.Title = bug.Title;
        exisitingBug.Severity = (Data.Models.Severity) bug.Severity;

        await SetParentAsync(exisitingBug, bug);

        Context.Bugs.Update(exisitingBug);
    }

    private async Task CreateAsync(Bug bug, Models.User user)
    {
        var bugToAdd = DomainToDataMapping.MapTodoFromDomain<Bug, Data.Models.Bug>(bug);

        await SetParentAsync(bugToAdd, bug);

        bugToAdd.CreatedBy = user;

        await Context.AddAsync(bugToAdd);
    }

    public override async Task<Bug> GetAsync(Guid id)
    {
        var data = await Context.Bugs.SingleAsync(bug => bug.Id == id);

        return DataToDomainMapping.MapTodoFromData<Data.Models.Bug, Domain.Bug>(data);
    }
}
