using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Services
{
    public class SeguridadService:ISeguridadService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public SeguridadService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Dispose()
        {
           _usuarioRepository.Dispose();
        }

        public byte[] GetPassEncrypt(string passTexto)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] hashed = md5.ComputeHash(enc.GetBytes(passTexto));
            return hashed;
        }

        public bool LoginValido(string usuario, string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            Usuario user = _usuarioRepository.FindBy(x =>  x.IdUsuario == usuario);

            if (user == null)
            {
                return false;
            }

            byte[] passTentativo = GetPassEncrypt(password);
            return ByteArrayIguales(passTentativo, user.Password);
        }

        private bool ByteArrayIguales(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }


    }
}
