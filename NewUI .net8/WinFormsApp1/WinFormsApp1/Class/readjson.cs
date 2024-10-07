using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace NSLaunch.Class
{
    internal class readjson
    {
        public string JsonVersion = null;
        public string changelog = null;
        public string findimgdelay = null;
        //public string Event = null;

        public string Theme = "System";

        public bool Notify = false;

        public bool KeepRound = false;
        public bool ResetRound = false;

        public bool Basic = false;
        public bool Great = false;
        public bool Ultra = false;

        public bool Tomb = false;
        public bool Snowball = false;
        public bool Azure = false;
        public bool Kuro = false;

        public bool wt_jade = false;
        public bool wt_coin = false;
        public bool wt_sushi = false;
        public bool wt_food = false;

    private bool CheckIsWindows10OrLower()
        {
            Version windows10Version = new Version(10, 0, 0, 0);
            return Environment.OSVersion.Version <= windows10Version;
        }

        private class VersionData
        {
            public string version { get; set; }
            public string eventtext { get; set; }
            public string roundoption { get; set; }
            public string theme { get; set; }
            public string disc { get; set; }
            public bool tomb { get; set; }
            public bool snowball { get; set; }
            public bool azure { get; set; }
            public bool kuro { get; set; }
            public bool notify { get; set; }
            public string changelog { get; set; }
            public string findimgdelay { get; set; }
        }

        public void ReadVersionJson()
        {
            try
            {
                bool isWindows10OrLower = CheckIsWindows10OrLower();

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
                string jsonContent = File.ReadAllText(jsonPath);

                VersionData jsonData = JsonConvert.DeserializeObject<VersionData>(jsonContent);

                JsonVersion = jsonData.version;
                //Event = jsonData.eventtext;
                changelog = jsonData.changelog;

                string NSBotVer = $"NSBot {jsonData.version}";

                switch (jsonData.disc)
                {
                    case "1":
                        Basic = true;
                        break;
                    case "2":
                        Great = true;
                        break;
                    case "3":
                        Ultra = true;
                        break;
                }

                if (jsonData.notify == true)
                {
                    this.Notify = true;
                }

                switch (jsonData.theme)
                {
                    case "system":
                        this.Theme = "system";
                        break;
                    case "dark":
                        this.Theme = "dark";
                        break;
                    case "light":
                        this.Theme = "light";
                        break;
                }

                switch (jsonData.roundoption)
                {
                    case "keep":
                        this.KeepRound = true;
                        break;
                    case "reset":
                        this.ResetRound = true;
                        break;
                }

                this.Tomb = jsonData.tomb;
                this.Snowball = jsonData.snowball;
                this.Azure = jsonData.azure;
                this.Kuro = jsonData.kuro;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading version from JSON: " + ex.Message);
            }
        }

        public void ReadConfigJson()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                string jsonContent = File.ReadAllText(jsonPath);

                dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                findimgdelay = jsonData.VALUE.FIND_IMG_DELAY;

                if (jsonData.VALUE.WQ_JADE == true)
                {
                    wt_jade = true;
                }
                if (jsonData.VALUE.WQ_COIN == true)
                {
                    wt_coin = true;
                }
                if (jsonData.VALUE.WQ_SUSHI == true)
                {
                    wt_sushi = true;
                }
                if (jsonData.VALUE.WQ_FOOD == true)
                {
                    wt_food = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading version from JSON: " + ex.Message);
            }
        }
    }
}
