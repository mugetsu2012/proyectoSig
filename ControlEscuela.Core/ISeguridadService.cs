using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscuela.Core
{
    public interface ISeguridadService:IDisposable
    {
        /// <summary>
        /// Indica si un login es valido o no
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool LoginValido(string usuario, string password);

        /// <summary>
        /// Le das un texto, te lo regresa encriptado
        /// </summary>
        /// <param name="passTexto"></param>
        /// <returns></returns>
        byte[] GetPassEncrypt(string passTexto);
    }
}
