using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IFilter negativefilter = new FilterNegative();
            IFilter greyscalefilter = new FilterGreyscale();
            IPipe pipenull = new PipeNull();
            IPipe pipe = new PipeSerial(negativefilter,pipenull);
            IPicture image1 = pipe.Send(picture);
            provider.SavePicture(image1,@"lukecopy.jpg");
            IPipe pipe2 = new PipeSerial(greyscalefilter,pipe);
            IPicture picture2 = provider.GetPicture(@"beer.jpg");
            IPicture image2 = pipe2.Send(picture2);
            provider.SavePicture(image2,@"beercopy.jpg");
        }
    }
}
