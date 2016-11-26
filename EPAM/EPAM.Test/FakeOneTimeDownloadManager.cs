using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EPAM.Test
{
    public class FakeOneTimeDownloadManager
    {
        private static FakeOneTimeDownloadManager _instance;

        private Dictionary<String, String> TextValidRegEx;

        private Regex NamePattern;
        private Regex EmailPattern;
        private Regex LoginPattern;
        private Regex PasswordPattern;

        private FakeOneTimeDownloadManager()
        {
            TextValidRegEx = new Dictionary<String, String>();
            TextValidRegEx.Add("NamePattern", @"^[A-Za-z]{3,20}$");
            TextValidRegEx.Add("EmailPattern", @"^[A-Za-z0-9]+@[A-Za-z]+.[A-Za-z]+$");
            TextValidRegEx.Add("LoginPattern", @"^[A-Za-z0-9]{5,20}$");
            TextValidRegEx.Add("PasswordPattern", @"^[A-Za-z0-9]{8,20}$");
        }

        public static FakeOneTimeDownloadManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FakeOneTimeDownloadManager();
                return _instance;
            }
        }

        public Dictionary<String, String> GetTextValidRegEx()
        {
            return TextValidRegEx;
        }
    }
}
