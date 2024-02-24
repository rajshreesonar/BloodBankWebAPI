using BloodBankWebAPI.Contexts;
using Serilog.Context;

namespace BloodBankWebAPI.Middlewares
{
    public class CustomLog
    {
        private readonly BloodBankContext _context;

        public CustomLog(BloodBankContext context)
        {
            _context = context;
        }
        //public static void CreateLog()
        //{
        //    var EntityEntry= 
        //    LogContext.PushProperty("BeforeUpdate",System.Text.Json.JsonSerializer.Serialize())
        //}
    }
}
