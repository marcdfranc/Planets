using Newtonsoft.Json;

namespace XCliente.Core;

internal static class Util
{
    public static Pagination GetPagination(Dictionary<string, IEnumerable<string>> headers)
    {
        Pagination pagination = null!;

        IEnumerable<string>? header;

        if (headers.TryGetValue("Pagination", out header))
        {
            pagination = JsonConvert.DeserializeObject<Pagination>(header.FirstOrDefault()!)!;
        }

        return pagination;
    }
}
