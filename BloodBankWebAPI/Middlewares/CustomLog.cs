using BloodBankWebAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;

namespace BloodBankWebAPI.Middlewares
{
    public  class CustomLog
    {
        public static void CreateLog(BloodBankContext context, ILogger logger)
        {
            var entries = context.ChangeTracker.Entries()
             .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
             .ToList();

            entries.ForEach(e => {
                LogLevel logLevel = LogLevel.Information;
                var messageTemplate = "{Entity} Was {State}";
                LogContext.PushProperty("EntityName", e);
                LogContext.PushProperty("BeforeUpdate", System.Text.Json.JsonSerializer.Serialize(e.OriginalValues.ToObject()));
                LogContext.PushProperty("AfterUpdate", System.Text.Json.JsonSerializer.Serialize(e.CurrentValues.ToObject()));
                logger.Log(logLevel, messageTemplate, e.Metadata.GetTableName(),e.State.ToString());
            });
        }
    }
}
