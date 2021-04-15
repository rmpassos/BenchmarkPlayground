using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground
{
    /* O objetivo é extraur como um int32 o ano de dentro de uma string que está no formato datetime iso.
      exemplo de datetime iso: 2021-04-15T00:20:53Z    
     */

    public class DateParser
    {
        public  int UsingDateTimeParser(string dateTimeString)
        {
            var dateTime = DateTime.Parse(dateTimeString);
            return dateTime.Year;
        }

        public int UsingStringSplitThenIntParse(string dateTimeString) 
        {
            var splitted = dateTimeString.Split('-');
            return int.Parse(splitted[0]);
        }

        public int UsingSubstringThenIntParse(string dateTimeString) 
        {
            var index = dateTimeString.IndexOf("-");
            var yearSubstring = dateTimeString.Substring(0, index);
            return int.Parse(yearSubstring);
        }

        //Artigo sobre Span, explicando como ele é otimizado para não alocar memória ao ser dividido, preciso estudar mais.
        //https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/january/csharp-all-about-span-exploring-a-new-net-mainstay
        public int UsingSpan(ReadOnlySpan<char> dateTimeSpan) 
        {
            var index = dateTimeSpan.IndexOf("-");
            return int.Parse(dateTimeSpan.Slice(0, index));
        }
        public int UsingSpanAndManualConversion(ReadOnlySpan<char> dateTimeSpan)
        {
            var index = dateTimeSpan.IndexOf("-");
            var spanYear = dateTimeSpan.Slice(0, index);
            var tmpYear = 0;
            for (int i = 0; i < spanYear.Length; i++)
            {
                tmpYear = tmpYear *  10 + (spanYear[i] - '0'); //Essa formula funciona pq os chars de 0 a 9 são representados internamente
            }                                                  //por números consecutivos, então diminuindo o char '0' do char desejado 
            return tmpYear;                                    //obtemos um int32 equivalente. Veja no watch  window a expressão: '1' - '0'
        }
    }
}
