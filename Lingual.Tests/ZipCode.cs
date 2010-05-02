using System;

namespace Something.Domain.Demographic
{
    public class ZipCode
    {
        public int Zip { get; set; }
        public int PlusFour { get; set; }

        public static ZipCode Parse(string zip)
        {
            return new ZipCode
                       {
                           Zip = int.Parse(zip)
                       };
        }
    }
}