using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class PCLHelper
    {
        public async static Task<bool> ArquivoExisteAsync(this string nomeArquivo, IFolder pastaRaiz = null)
        {
            IFolder pasta = pastaRaiz ?? FileSystem.Current.LocalStorage;
            ExistenceCheckResult pastaExiste = await pasta.CheckExistsAsync(nomeArquivo);
            // não sobrescreve se existir
            if (pastaExiste == ExistenceCheckResult.FileExists)
            {
                return true;
            }
            return false;
        }
    }
}
