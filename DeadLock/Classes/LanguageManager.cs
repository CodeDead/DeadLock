using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace DeadLock.Classes
{
    internal class LanguageManager
    {
        private readonly ResourceManager _rm;
        private CultureInfo _ci;

        internal LanguageManager(int cultureId)
        {
            _rm = new ResourceManager("DeadLock.Resources.Languages.Res", typeof(LanguageManager).Assembly);
            SetCulture(cultureId);
        }

        internal void SetCulture(int cultureId)
        {
            try
            {
                switch (cultureId)
                {
                    case 0:
                        _ci = CultureInfo.CreateSpecificCulture("nl");
                        break;
                    case 1:
                        _ci = CultureInfo.CreateSpecificCulture("en");
                        break;
                    case 2:
                        _ci = CultureInfo.CreateSpecificCulture("fr");
                        break;
                    case 3:
                        _ci = CultureInfo.CreateSpecificCulture("de");
                        break;
                    case 4:
                        _ci = CultureInfo.CreateSpecificCulture("it");
                        break;
                    case 5:
                        _ci = CultureInfo.CreateSpecificCulture("pl");
                        break;
                    case 6:
                        _ci = CultureInfo.CreateSpecificCulture("ru");
                        break;
                    case 7:
                        _ci = CultureInfo.CreateSpecificCulture("th");
                        break;
                    default:
                        _ci = CultureInfo.CreateSpecificCulture("en");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal string GetText(string key)
        {
            return _rm.GetString(key, _ci);
        }
    }
}