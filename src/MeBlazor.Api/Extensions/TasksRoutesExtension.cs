using MeBlazor.Api.Data;

namespace MeBlazor.Api.Extensions
{
    public static class TasksRoutesExtension
    {

        public static void MapTasksRoutes(this WebApplication app)
        {
            var groups = app.MapGroup("/api/taskitems")
            .WithTags("tasks");

            groups.MapGet("/", async (ICommonRepo<TaskItem> store) =>
            {
                var items = await store.GetAll();

                return Results.Ok(items.ToList().Select(item => item.ReadToDto()));
            });

            groups.MapGet("/{id:guid}", async (ICommonRepo<TaskItem> store, Guid Id) =>
            {
                var item = await store.Get(Id);
                if (item == null) return Results.NotFound();
                return Results.Ok(item.ReadToDto());

            }).WithName("GetTask");

            groups.MapPost("/", async (ICommonRepo<TaskItem> store, TaskItemCreateDto dto) =>
            {
                var taskitem = TaskItem.CreateFromDto(dto);
                await store.Add(taskitem);
                await store.SaveAsync();
                return Results.Created($"/GetTask/{taskitem.Id}", taskitem.ReadToDto());

            });
            groups.MapDelete("/{id:guid}", async (ICommonRepo<TaskItem> store, Guid Id) =>
            {
                var item = await store.Get(Id);
                if (item == null) return Results.NotFound();
                store.Delete(item);
                await store.SaveAsync();
                return Results.NoContent();
            });


            groups.MapPut("/{id:guid}", async (ICommonRepo<TaskItem> store, Guid Id, TaskItemReadDto dto) =>
            {
                var item = await store.Get(Id);
                if (item == null || item.Id != dto.Id)
                    return Results.NotFound();

                // store.Update(Id, item);
                item.UpdateFromDto(dto);
                await store.SaveAsync();
                return Results.NoContent();
            });
        }

    }
}