using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CurrencyConverter
{
    class Interactor
    {
        Reqester reqester = new Reqester();

        private void CreateTimer()
        {
           
        }
        public Interactor()
        {
           
        }

        async public Task<string> GetCourse(string atr1, string atr2, string value)
        {
            double course = await reqester.ReqestAsync(atr1, atr2);

            double doubleValue;

            if(double.TryParse(value, out doubleValue))
            {
                return (course * doubleValue).ToString();
            }
            else
            {
                return "Error!!!";
            }
        }
    }
}
