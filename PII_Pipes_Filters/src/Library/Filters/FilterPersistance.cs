using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe un path y guarda la imagen antes de continuar su camino por el pipe.
    /// </remarks>
    public class FilterPersistance : IFilter
    {
        /// <summary>
        /// Un filtro que guarda la imagen con el filtro del pipe anterior aplicado en la carpeta Assets/Persistance del proyecto.
        /// </summary>
        /// <param name="provider">El provider nos permitirá guardar la imagen</param>
        public FilterPersistance(PictureProvider provider, string fileName)
        {
    
            this.Path = @"../../Assets/Persistance/" + fileName;
            this.Provider = provider;

        }
        public IPicture Filter(IPicture image)
        {
            this.Provider.SavePicture(image, this.Path);
            return image;
        }
        private string Path {get;}
        private PictureProvider Provider {get;} 

    }
}
