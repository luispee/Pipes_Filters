using System;
using System.Drawing;
using System.Globalization;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe un path y guarda la imagen antes de continuar su camino por el pipe.
    /// </remarks>
    public class FilterTwitter : IFilter
    {
        /// <summary>
        /// Un filtro que guarda la imagen con el filtro del pipe anterior aplicado en la carpeta Assets/Persistance del proyecto.
        /// </summary>
        /// <param name="provider">El provider nos permitirá guardar la imagen</param>
        public FilterTwitter(string text, string path)
        {
            this.Twitter = new TwitterImage();
            this.Text = text;
            this.Path = path;
        }
        public IPicture Filter(IPicture image)
        {
            Console.WriteLine(Twitter.PublishToTwitter(this.Text, this.Path));
            Console.WriteLine("Twit publish if API worked");
            return image;
        }

        private TwitterImage Twitter {get;}
        private string Text {get;}
        private string Path {get;}
    }
}
