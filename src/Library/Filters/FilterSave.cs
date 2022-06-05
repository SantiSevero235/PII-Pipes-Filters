using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        private int count = 0;
        public IPicture Filter (IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,@$"imagen{count}.jpg");
            count++;
            return image;
        }

    }
}