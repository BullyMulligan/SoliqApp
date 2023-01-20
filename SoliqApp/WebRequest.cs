using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SoliqApp
{
    public class WebRequest
    {
        public Automatic.PsicInfo _psicInfo;
        private string _response;
        
        public void Post(string url)
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["username"] = "myUser";
                data["password"] = "myPassword";
                var response = wb.UploadValues(url, "POST", data);
                _response = Encoding.UTF8.GetString(response);
            }
        }

        public void Get(string url)
        {
            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(url);
                byte[] text = Encoding.UTF8.GetBytes(response);
                _response = Encoding.UTF8.GetString(text);
            }
        }

        public void GetPsicInfoOnGet(string response)
        {
            _psicInfo = new Automatic.PsicInfo();
            _psicInfo = JsonConvert.DeserializeObject<Automatic.PsicInfo>(response);
        }

        public void GetPsicInfo(object cell)
        {
            Get($"https://tasnif.soliq.uz/api/cls-api/mxik/search/by-params?mxikCode={cell}&size=1");
            GetPsicInfoOnGet(_response);
        }
        
    }
}