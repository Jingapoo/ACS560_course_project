using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BootChatClient
{
    class BootChatHttpAgent
    {
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public Dictionary<String, Object> doHttpPost(String URL, NameValueCollection postData)
        {
            using (WebClient client = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                try
                {
                    byte[] response = client.UploadValues(URL, postData);
                    String jsonText = System.Text.Encoding.UTF8.GetString(response);

                    //System.Windows.Forms.MessageBox.Show(jsonText);

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    Dictionary<String, Object> dict = jss.Deserialize<dynamic>(jsonText);
  
                    return dict;
                } catch (Exception e) {
                    Dictionary<String, Object> errorResult = new Dictionary<string, object>();
                    errorResult["success"] = false;
                    errorResult["exception"] = "BootChatAgentException: " + e.Message;
                    return errorResult;
                }
            }
            return null;
        }
    }
}
