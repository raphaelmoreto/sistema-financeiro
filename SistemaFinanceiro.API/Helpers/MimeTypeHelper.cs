namespace SistemaFinanceiro.API.Helpers
{
    public static class MimeTypeHelper
    {
        private static readonly Dictionary<string, string> MimeTypes = new()
        {
            { ".csv", "text/csv" },
            { ".txt", "text/plain" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }
        };

        public static string GetMimeType(string extensao)
        {
            if (MimeTypes.TryGetValue(extensao.ToLower(), out var mimeType))
            {
                return mimeType;
            }

            return "application/octet-stream";
        }
    }
}
