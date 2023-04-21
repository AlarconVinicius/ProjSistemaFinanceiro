using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico
{
    public class GenericoRepository<T> : IGenerica<T>, IDisposable where T : class
    {
        protected readonly ContextoBase _context;

        public GenericoRepository(ContextoBase context)
        {
            _context = context;
        }
        public async Task Adicionar(T objeto)
        {
            await _context.Set<T>().AddAsync(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(T objeto)
        {
            _context.Set<T>().Update(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var objeto = await ObterPorId(id);
            _context.Set<T>().Remove(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> ObterTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion

    }
}
