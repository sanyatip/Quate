using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuateProject
{
    public class Quote
    {

        public string idtable1 { get; set; }
        public string quoteText { get; set; }
        public string quoteAuthor { get; set; }
        public string senderName { get; set; }
        public string senderLink { get; set; }
        public string quoteLink { get; set; }

        public Quote GetQuote()
        {
            string answer = string.Empty;
            Quote q = new Quote();
            string url = "https://api.forismatic.com/api/1.0/?method=getQuote&lang=ru&format=json";
            var webclient = new WebClient();
            // Кодировка для клиента 
            webclient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                // Получаем json с сайта
                answer = webclient.DownloadString(url);

                // Начинаем десериализацию с помощью класса выше созданного
                Quote myDeserializedClass = JsonConvert.DeserializeObject<Quote>(answer);
                // Упаковываем полученные данные в класс
                q = myDeserializedClass;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return q;
        }
    }
}
