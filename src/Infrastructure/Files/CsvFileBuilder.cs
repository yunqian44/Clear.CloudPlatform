using System.Globalization;
using Clear.CloudPlatform.Application.Common.Interfaces;
using Clear.CloudPlatform.Application.TodoLists.Queries.ExportTodos;
using Clear.CloudPlatform.Infrastructure.Files.Maps;
using CsvHelper;

namespace Clear.CloudPlatform.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
