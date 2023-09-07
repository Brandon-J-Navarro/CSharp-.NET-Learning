using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repository;

public abstract class TodoRepository<T> : IRepository<T>
    where T : TodoTask
{
    protected GlobomanticsDbContext Context { get; }
    public TodoRepository(GlobomanticsDbContext context)
    {
        Context = context;
    }

    public abstract Task AddAsync(T item);
    public abstract Task<T> GetAsync(Guid id);
    public virtual async Task<IEnumerable<T>> AllAsync()
    {
        return await Context.TodoTasks.Where(t => !t.IsDeleted)
            .Include(t => t.CreatedBy)
            .Include(t => t.Parent)
            .Select(x => DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, T>(x))
            .ToListAsync();
    }

    public virtual async Task<T> FindByAsync(string title)
    {
        var task = await Context.TodoTasks
            .SingleAsync(t => t.Title == title);

        return DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, T>(task);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    protected async Task SetParentAsync(Data.Models.Todo toBeAdded, Todo items)
    {
        Data.Models.TodoTask? existingParent = null;
        if (items.Parent is not null)
        {
            existingParent = await Context.TodoTasks.FirstOrDefaultAsync(
                i => i.Id == items.Parent.Id
                );
        }

        if (existingParent is not null)
        {
            toBeAdded.Parent = existingParent;
        }
        else if (items.Parent is not null)
        {
            var parentToAdd = DomainToDataMapping.MapTodoFromDomain<TodoTask, Data.Models.TodoTask>(items.Parent);
            toBeAdded.Parent = parentToAdd;
            await Context.AddAsync(parentToAdd);
        }
    }
}
