using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Extension for font awesome icons
    /// </summary>
    public static class IconExtension
    {
        /// <summary>
        /// Sort and gets the appropriate icon
        /// </summary>
        /// <param name="type">Type of icon</param>
        /// <returns></returns>
        public static string ToFontAwesome(this IconType type)
        {
            switch (type)
            {
                // Return notes icon for list item
                case IconType.NotesItem:
                    return "\uf56b";

                // Return books icon for list item
                case IconType.BooksItem:
                    return "\uf02a";

                // Return note icon
                case IconType.Note:
                    return "\uf249";

                // Return book icon
                case IconType.Book:
                    return "\uf02d";

                // Return calendar icon
                case IconType.Calendar:
                    return "\uf783";

                // Return share icon
                case IconType.Share:
                    return "\uf1e0";

                // Return settings icon
                case IconType.Settings:
                    return "\uf013";

                // Return trash icon
                case IconType.Trash:
                    return "\uf2ed";

                // If there's nothing to do, return null
                default:
                    return null!;
            }
        }
    }
}
