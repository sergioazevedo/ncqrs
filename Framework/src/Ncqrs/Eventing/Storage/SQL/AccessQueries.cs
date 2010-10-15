using System;

namespace Ncqrs.Eventing.Storage.SQL
{
    internal static class AccessQueries
    {
        public const String DeleteUnusedProviders = "DELETE FROM [EventSources] WHERE (SELECT Count(EventSourceId) FROM [Events] WHERE [EventSourceId]=[EventSources].[Id]) = 0";

        public const String InsertNewEventQuery = "INSERT INTO [Events]([Id], [EventSourceId], [Name], [Version], [Data], [Sequence], [TimeStamp]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

        public const String InsertNewProviderQuery = "INSERT INTO [EventSources](Id, Type, Version) VALUES (@Id, @Type, @Version)";
        
        public const String SelectAllEventsQuery = "SELECT [Id], [EventSourceId], [Name], [Version], [TimeStamp], [Data], [Sequence] FROM [Events] WHERE [EventSourceId] = @EventSourceId AND [Sequence] > @EventSourceVersion ORDER BY [Sequence]";

        public const String SelectAllIdsForTypeQuery = "SELECT [Id] FROM [EventSources] WHERE [Type] = @Type";

        public const String SelectVersionQuery = "SELECT [Version] FROM [EventSources] WHERE [Id] = @id";

        public const String UpdateEventSourceVersionQuery = "UPDATE [EventSources] SET [Version] = {0} WHERE [Id] = {1}";

        public const String InsertSnapshot = "DELETE FROM [Snapshots] WHERE [EventSourceId]= {0}; INSERT INTO [Snapshots]([EventSourceId], [Timestamp], [Version], [Type], [Data]) VALUES ('{1}', Date(), '{2}', '{3}', '{4}')";

        public const String SelectLatestSnapshot = "SELECT TOP 1 * FROM [Snapshots] WHERE [EventSourceId]=@EventSourceId ORDER BY Version DESC";

    }
}
