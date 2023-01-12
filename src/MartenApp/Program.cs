using Marten;
using Marten.PLv8;
using Marten.PLv8.Patching;

// Init store
const string connectionString = "host=localhost;database=demo_db;password=Just4Now;username=user1";
var store = DocumentStore.For(
    cfg =>
    {
        cfg.Connection(connectionString);
        cfg.UseJavascriptTransformsAndPatching();
    }
);

// Remember items
var items = new List<Item>();

// Seed items
await using (var session = store.LightweightSession())
{
    // Delete old items
    session.DeleteWhere<Item>(_ => true);
    await session.SaveChangesAsync();
    Console.WriteLine("Deleted old data");
    
    // Create new items
    for (var i = 0; i < 1000; i++)
    {
        var id = Guid.NewGuid();
        var item = new Item {Id = id, Number = i};
        items.Add(item);
        session.Store(item);
        Console.WriteLine($"Added item {id}");
    }
    await session.SaveChangesAsync();
    Console.WriteLine("All items created");
}

// Check count
await using (var session = store.QuerySession())
{
    var count = await session.Query<Item>().CountAsync();
    Console.WriteLine($"Total items: {count}");
}

// Patch items concurrently
var tasks = items.Select(item => PatchItemAsync(store, item)).ToList();
await Task.WhenAll(tasks);

// Say something
Console.WriteLine("Done!");

async Task PatchItemAsync(IDocumentStore store, Item item)
{
    await using var session = store.LightweightSession();
    session.Patch<Item>(item.Id).Set(x => x.Number, item.Number * 10);
    await session.SaveChangesAsync();
}

public class Item
{
    public Guid Id { get; set; }
    public int Number { get; set; }
}
