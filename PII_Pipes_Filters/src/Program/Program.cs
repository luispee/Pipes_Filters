using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {  
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            FilterNegative negative = new FilterNegative();
            FilterGreyscale greyscale = new FilterGreyscale();
            FilterBlurConvolution blurConvolution = new FilterBlurConvolution();

            string greyFileName = "greyscaleP.jpg";
            FilterPersistance greyscalePersistance = new FilterPersistance(provider, greyFileName);
            string blurFileName = "blurP.jpg";
            FilterPersistance blurPersistance = new FilterPersistance(provider, blurFileName);

            string twitterMessage = "Hello Twitter";
            string fileName = "greyscaleP.jpg";
            string twitterPath = @"../../Assets/Persistance/" + fileName;
            FilterTwitter filterTwitter = new FilterTwitter(twitterMessage, twitterPath);
            /* Console.WriteLine(twitter.PublishToTwitter("Hello", @"greyscaleNegativeBeer.jpg")); */

            PipeNull lastPipe = new PipeNull();
            PipeSerial negativePipe = new PipeSerial(negative, lastPipe);

            PipeSerial persistancePipe = new PipeSerial(greyscalePersistance, negativePipe);
            PipeSerial greyscalePipe = new PipeSerial(greyscale, persistancePipe);

            PipeSerial twitterPipe = new PipeSerial(filterTwitter, greyscalePipe);

            PipeSerial persistanceBlurPipe = new PipeSerial(blurPersistance, twitterPipe);
            PipeSerial blurPipe = new PipeSerial(blurConvolution, persistanceBlurPipe);

            IPicture blurGreyscaleNegativeImg = blurPipe.Send(picture);

            provider.SavePicture(blurGreyscaleNegativeImg, @"blurGreyscaleNegativeBeer.jpg");

            //Ejercicio 4
            IPicture cogPicture = provider.GetPicture(@"luke.jpg");

            FilterCognitive cognitiveFilter = new FilterCognitive();
            //reuse PipeNull lastPipe


            Console.WriteLine("DONE");
        }
    }
}
