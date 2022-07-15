using Arvato.Core.UnitOfWorks;

namespace Arvato.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMDBContext _context;

        public UnitOfWork(IMDBContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
