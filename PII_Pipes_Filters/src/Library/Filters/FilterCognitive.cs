using System;
using System.Drawing;
using System.Dynamic;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    /// <summary>
    /// 
    /// </remarks>
    public class FilterCognitive : IFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        public FilterCognitive()
        {
            this.Cog = new CognitiveFace(false);
            this.FaceFound = false;
        }
        public IPicture Filter(IPicture image)
        {
            Cog.Recognize(@"luke.jpg");
            FoundFace(Cog);
            return image;
        }
        private CognitiveFace Cog {get;}
        private bool FaceFound {get;}
        static void FoundFace (CognitiveFace cog)
        {
            if (cog.FaceFound)
            {
                Console.WriteLine("Post it to twitter!");
            }
            else
            {
                Console.WriteLine("Go through NegativeFilter");
            }
        }
        
    }
}
