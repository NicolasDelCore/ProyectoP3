using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.Tools
{
    public abstract class SubirImagen {
        /*
        public static void Subir(FileInfo fi, IWebHostEnvironment whe)
        {
            string ext = fi.Extension;
            if (ext == ".png" || ext == ".jpg")
            {
                string nombreArchivo = ecosistemaViewModel.Ecosistema.Nombre + ext;
                ecosistemaViewModel.Ecosistema.Imagen = nombreArchivo;
                string directorioRaiz = WHE.WebRootPath;
                string rutaCompleta = Path.Combine(directorioRaiz, "imgs", nombreArchivo);
                FileStream fs = new FileStream(rutaCompleta, FileMode.Create);
                fi.CopyTo(fs);
            }
            else
            {
                throw new Exception("El tipo de imagen no es válido");
            }
        }

        */
    }
}
