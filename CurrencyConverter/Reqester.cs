using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CurrencyConverter
{
    class Reqester
    {
            public Reqester()
            {
            }
     
            public async Task<double> ReqestAsync(string atr1, string atr2)
            {
                string url = $"https://free.currconv.com/api/v7/convert?q={atr1}_{atr2}&compact=ultra&apiKey=f731dbae8f77ddac4d07";
           
                WebRequest request = WebRequest.Create(url);

             WebResponse response = await request.GetResponseAsync();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string str;
                    if ((str = stream.ReadToEnd()) != null)
                    {
                        JObject o = JObject.Parse(str);
                        return Convert.ToDouble(o[$"{atr1}_{atr2}"]);
                    }
                }
                return -1;
            }
        
    }
}
