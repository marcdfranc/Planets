using Api.Dtos;
using System.Text.Json;

namespace Api.Extensions;

public static class HttpExtension
{
    public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
    {       
        response.Headers.Add("Pagination", JsonSerializer.Serialize(new Pagination
        {
            CurrentPage = currentPage,
            ItemsPerPage = itemsPerPage,
            TotalItems = totalItems,
            TotalPages = totalPages
        }));
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
    }
}
