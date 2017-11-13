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

        private String serverURL = "https://bootchat-poyomiao.c9users.io";

        private String authenticatedUsername = String.Empty;
        private String authenticatedPassword = String.Empty;
        private String nickname = String.Empty;
        private String gender = String.Empty;
        private Boolean newMessage = false;
        private Boolean loggedIn = false;

        public BootChatHttpAgent(String serverURL)
        {
            //this.serverURL = serverURL;
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors){
            return true;
        }
   
        public String getNickname()
        {
            return nickname;
        }

        public String getUsername()
        {
            return authenticatedUsername;
        }

        public Dictionary<String, Object> request(Dictionary<String, Object> postData)
        {
            Dictionary<String, Object> result = new Dictionary<String, Object>();
            using (WebClient client = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                try{
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    String jsonText = client.UploadString(serverURL, jss.Serialize(postData));
                    result = jss.Deserialize<dynamic>(jsonText);
                    //System.Windows.Forms.MessageBox.Show(jsonText);
                }catch (Exception e){
                    result["success"] = false;
                    result["exception"] = "BootChatAgentException: " + e.Message;
                }
            }
            return result;
        }

        public Boolean login(String username, String password){
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            postData.Add("request", "login");
            postData.Add("username", username);
            postData.Add("password", password);

            Dictionary<String, Object> result = request(postData);


            bool success = Convert.ToBoolean(result["success"]);

            if (success)
            {
                this.authenticatedUsername = username;
                this.authenticatedPassword = password;
                this.nickname = Convert.ToString(result["nickname"]);
                this.gender = Convert.ToString(result["gender"]);
            }

            loggedIn = success;

            return success;
        }

        public Boolean getMyRow()
        {
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            postData.Add("request", "getmyrow");
            postData.Add("username", this.authenticatedUsername);
            postData.Add("password", this.authenticatedPassword);

            Dictionary<String, Object> result = request(postData);

            return Convert.ToBoolean(result["success"]);
        }

        public Dictionary<String,Object> getAllMessages()
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            if (!loggedIn)
            {
                result["success"] = false;
                result["exception"] = "not logged in";
                return result;
            }

            Dictionary<String, Object> postData = new Dictionary<String, Object>();
            postData.Add("request", "getallmsgs");
            postData.Add("username", this.authenticatedUsername);
            postData.Add("password", this.authenticatedPassword);

            result = request(postData);

            return result;
        }

        public Dictionary<String, Object> getInboxStatus()
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            if (!loggedIn)
            {
                result["success"] = false;
                result["exception"] = "not logged in";
                return result;
            }

            Dictionary<String, Object> postData = new Dictionary<String, Object>();
            postData.Add("request", "getinboxstatus");
            postData.Add("username", this.authenticatedUsername);
            postData.Add("password", this.authenticatedPassword);

            result = request(postData);

            return result;
        }

        public Dictionary<String, Object> setNewMessage(Boolean value)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            if (!loggedIn)
            {
                result["success"] = false;
                result["exception"] = "not logged in";
                return result;
            }

            Dictionary<String, Object> postData = new Dictionary<String, Object>();
            postData.Add("request", "setnewmsg");
            postData.Add("username", this.authenticatedUsername);
            postData.Add("password", this.authenticatedPassword);
            postData.Add("value", value ? "1" : "0");

            result = request(postData);

            return result;
        }

        public Dictionary<String, Object> registerNewUser(String username, String password, String nickname, String gender, String question, String answer)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();

            Dictionary<String, Object> postData = new Dictionary<String, Object>();
            postData.Add("request", "register");
            postData.Add("username", username);
            postData.Add("password", password);
            postData.Add("nickname", username);
            postData.Add("question", question);
            postData.Add("answer", answer);

            result = request(postData);

            return result;
        }

        public Dictionary<String, Object> sendMessage(String to, String body)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            if (!loggedIn)
            {
                result["success"] = false;
                result["exception"] = "not logged in";
                return result;
            }

            Dictionary<String, Object> postData = new Dictionary<String, Object>();
            postData.Add("request", "send");
            postData.Add("username", this.authenticatedUsername);
            postData.Add("password", this.authenticatedPassword);
            postData.Add("to_user", to);
            postData.Add("body", body);

            result = request(postData);

            return result;
        }

        public void DebugPrintDictionary(Dictionary<String, Object> map){
            if (map != null && map.Keys.Count > 0){
                foreach (string key in map.Keys){
                    try
                    {
                        Object[] array = (Object[])map[key];
                        foreach(object o in array)
                        {
                            DebugPrintDictionary((Dictionary<String, Object>)o);
                        }
                    }
                    catch (Exception e) { }
                    System.Windows.Forms.MessageBox.Show(key + " = " + (string)map[key].ToString());
                }
            }
        }
    }
}
