README
======

Start demo app:

```
docker compose up
```

Connect to PostgreSQL:

```
docker exec -it postgres bash
psql --host=postgres --dbname=demo_db --username=user1
```

## Expected exception

When running the `MartenApp` application then this exception gets thrown:

```
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.Collections.Generic.Dictionary`2.TryInsert(TKey key, TValue value, InsertionBehavior behavior)
   at System.Collections.Generic.Dictionary`2.Add(TKey key, TValue value)
   at Marten.PLv8.Transforms.TransformSchema.AddFunction(TransformFunction function)
   at Marten.PLv8.Transforms.TransformSchema.Load(TransformFunction function)
   at Marten.PLv8.Transforms.TransformSchema.loadPatchDoc()
   at Marten.PLv8.Transforms.TransformSchema.schemaObjects()+MoveNext()
   at System.Collections.Generic.LargeArrayBuilder`1.AddRange(IEnumerable`1 items)
   at System.Collections.Generic.EnumerableHelpers.ToArray[T](IEnumerable`1 source)
   at Marten.PLv8.Transforms.TransformSchema.get_Objects()
   at Weasel.Core.Migrations.DatabaseBase`1.generateOrUpdateFeature(Type featureType, IFeatureSchema feature, CancellationToken token)
   at Weasel.Core.Migrations.DatabaseBase`1.ensureStorageExists(IList`1 types, Type featureType, CancellationToken token)
   at Weasel.Core.Migrations.DatabaseBase`1.EnsureStorageExists(Type featureType)
   at Marten.Storage.MartenDatabase.Marten.Storage.IMartenDatabase.EnsureStorageExists(Type documentType)
   at Marten.PLv8.Transforms.TransformExtensions.EnsureTransformsExist(IDocumentOperations operations)
   at Marten.PLv8.Patching.PatchingExtensions.patchById[T](IDocumentOperations operations, Object id)
   at Marten.PLv8.Patching.PatchingExtensions.Patch[T](IDocumentOperations operations, Guid id)
   at Program.<<Main>$>g__PatchItemAsync|0_2(IDocumentStore store, Guid itemId) in /Users/dustingorski/Documents/Temp/MartenApp/src/MartenApp/Program.cs:line 56
   at Program.<<Main>$>g__PatchItemAsync|0_2(IDocumentStore store, Guid itemId) in /Users/dustingorski/Documents/Temp/MartenApp/src/MartenApp/Program.cs:line 57
   at Program.<Main>$(String[] args) in /Users/dustingorski/Documents/Temp/MartenApp/src/MartenApp/Program.cs:line 47
   at Program.<Main>(String[] args)
```
