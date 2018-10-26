using System;

namespace WIShipwrecks.Models
{
    public static class Helpers
    {

        // Trims a large string down to a desired length for display
        public static string TrimIfLongerThan(this string value, int maxLength)
        {
            if (!String.IsNullOrEmpty(value))
            {
                if (value.Length > maxLength)
                {
                    return value.Substring(0, maxLength - 3) + "...";
                }

                return value;
            }

            return null;          
        }



    }
}