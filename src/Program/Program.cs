using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            //Ejercicio 1
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            //Se crea filtros
            IFilter negativefilter = new FilterNegative();
            IFilter greyscalefilter = new FilterGreyscale();
            IPipe pipenull = new PipeNull();//Se crea PipeNull
            IPipe pipe = new PipeSerial(negativefilter,pipenull);
            IPicture image1 = pipe.Send(picture);
            provider.SavePicture(image1,@"lukecopy.jpg");
            IPipe pipe2 = new PipeSerial(greyscalefilter,pipe);
            IPicture picture2 = provider.GetPicture(@"beer.jpg");
            IPicture image2 = pipe2.Send(picture2);
            provider.SavePicture(image2,@"beercopy.jpg");
            
            //Se crea imagenes solo con Filtro de Escala de Grises
            IPipe pipe3 = new PipeSerial(greyscalefilter,pipenull);
            IPicture picture3 = provider.GetPicture(@"beer.jpg");
            IPicture image3 = pipe3.Send(picture3);
            provider.SavePicture(image3,@"beergrey.jpg");
            IPicture picture4 = provider.GetPicture(@"luke.jpg");
            IPicture image4 = pipe3.Send(picture4);
            provider.SavePicture(image4,@"lukegrey.jpg");

            //Ejercicio 2
            //Se crea Filter Save
            IFilter filtersave = new FilterSave();
            IPicture picej2=provider.GetPicture(@"luke.jpg");
            IPicture Imagen1 = pipe.Send(picej2);
            Imagen1 = filtersave.Filter(Imagen1);
            IPicture image = pipe2.Send(Imagen1);
            image = filtersave.Filter(image);
            num++; 

            //Ejercicio 3
            //Se crea Filtro de Twitter
            FilterTwitter tweet = new FilterTwitter();
            tweet.Filter("By: Santi Severo",$"imagen0");
            tweet.Filter("By: Santi Severo",$"imagen1");


        }
    }
}
