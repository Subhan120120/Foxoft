using System;
using System.Linq;
using Foxoft.Models;
using Foxoft.Models.Context;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        try
        {
            using subContext ctx = new();
            Guid invoiceHeaderId = Guid.Parse("FBF3B973-C79E-46CC-8336-69C289C69D4A");
            string documentNumber = "WS-134360";

            var log = ctx.TrMessageLogs.FirstOrDefault(x => x.DocumentHeaderId == invoiceHeaderId);
            Console.WriteLine("Direct log find: " + (log != null ? log.MessageLogId.ToString() : "null"));
            Console.WriteLine("ChannelCode: " + log?.ChannelCode);
            Console.WriteLine("IsSuccessful: " + log?.IsSuccessful);

            bool res = ctx.TrMessageLogs.Any(x =>
                x.ChannelCode == "WhatsApp" &&
                x.IsSuccessful &&
                (
                    (invoiceHeaderId != Guid.Empty && x.DocumentHeaderId == invoiceHeaderId) ||
                    (!string.IsNullOrEmpty(documentNumber) && (
                        (x.Message != null && x.Message.Contains(documentNumber)) ||
                        ctx.TrInvoiceHeaders.Any(h => h.DocumentNumber == documentNumber && h.InvoiceHeaderId == x.DocumentHeaderId)
                    ))
                ));

            Console.WriteLine("Query Any() result: " + res);
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION: " + ex);
        }
    }
}
