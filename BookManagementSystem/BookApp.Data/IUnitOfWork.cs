using System;

namespace BookApp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
