using Login.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data.Context
{
    public interface ILoginDBContext
    {
        DbSet<Usuario> Usuarios { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}