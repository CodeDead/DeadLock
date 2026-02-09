using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Syncfusion.Windows.Forms;

namespace DeadLock.Classes
{
    /// <summary>
    /// The LanguageManager can be used to load or return a Language object.
    /// </summary>
    internal class LanguageManager
    {
        /// <summary>
        /// Gets the current language.
        /// </summary>
        internal Language CurrentLanguage { get; private set; }

        /// <summary>
        /// Generate a new LanguageManager.
        /// </summary>
        internal LanguageManager()
        {
            CurrentLanguage = new Language();
        }

        /// <summary>
        /// Load a custom language.
        /// </summary>
        /// <param name="path">Path to the XML language file.</param>
        internal void LoadLanguage(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(CurrentLanguage.GetType());
                using StreamReader reader = new StreamReader(path);
                CurrentLanguage = (Language)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadLanguage(1);
            }
        }

        /// <summary>
        /// Load a language using the Resources, depending on the index.
        /// </summary>
        /// <param name="index">The index of the language that should be loaded.</param>
        internal void LoadLanguage(int index)
        {
            XmlSerializer serializer = new XmlSerializer(CurrentLanguage.GetType());
            using MemoryStream stream = new MemoryStream();
            using StreamWriter writer = new StreamWriter(stream);
            string res = index switch
            {
                0 => Properties.Resources.nl,
                2 => Properties.Resources.fr,
                3 => Properties.Resources.ger,
                4 => Properties.Resources.ita,
                5 => Properties.Resources.kor,
                6 => Properties.Resources.pl,
                7 => Properties.Resources.rus,
                8 => Properties.Resources.sr,
                9 => Properties.Resources.esp,
                10 => Properties.Resources.swe,
                11 => Properties.Resources.tr,
                12 => Properties.Resources.bg,
                _ => Properties.Resources.eng
            };
            writer.Write(res);
            writer.Flush();
            stream.Position = 0;
            CurrentLanguage = (Language)serializer.Deserialize(stream);
        }
    }
}