using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ultilities
{
    public class InternetHelper
    {
        public static bool CheckForInternetConnection(string urlCheck = "google.com")
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(urlCheck))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
