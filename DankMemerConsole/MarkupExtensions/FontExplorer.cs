using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace DankMemerConsole.MarkupExtensions
{
    /// <summary>
    ///     Loads fonts from the Fonts directory as resources without leaking memory.
    ///     Credit:
    ///     https://stackoverflow.com/questions/50964801/wpf-use-font-installed-with-addfontmemresourceex-for-process-only
    /// </summary>
    public class FontExplorer : MarkupExtension
    {
        private static readonly Dictionary<string, FontFamily> _CachedFonts = new Dictionary<string, FontFamily>();

        static FontExplorer()
        {
            foreach (var fontFamily in Fonts.GetFontFamilies(new Uri("pack://application:,,,/"), "./Fonts/"))
                _CachedFonts.Add(fontFamily.FamilyNames.First().Value, fontFamily);
        }

        public string Key { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ReadFont();
        }

        private object ReadFont()
        {
            if (string.IsNullOrEmpty(Key)) return new FontFamily("Tahoma");
            return _CachedFonts.ContainsKey(Key) ? _CachedFonts[Key] : new FontFamily("Tahoma");
        }
    }
}
