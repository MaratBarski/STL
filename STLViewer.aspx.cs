using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Xml;

//example call
//https://localhost:44382/STLViewer?g=6255FF4C-9C07-4158-92C4-109C6D6AD120

namespace STL
{
    public partial class STLViewer : System.Web.UI.Page
    {
        const string API_URL = "https://www.statusdent.com/BL_iLabsStatusPhotoDev/Doctor_LoadPictures.asmx/UrlFle";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["FileGuId"] = FileGuid;
                    var response = wc.UploadValues(API_URL, values);
                    var responseString = Encoding.UTF8.GetString(response);
                    var xml = new XmlDocument();
                    xml.LoadXml(responseString);
                    var node = xml.DocumentElement.SelectSingleNode("//Table");
                    PassportId = node.SelectSingleNode("//PassportId").InnerText;
                    FirstName = node.SelectSingleNode("//FirstName").InnerText;
                    LastName = node.SelectSingleNode("//LastName").InnerText;
                    StlUrl = node.SelectSingleNode("//HTTPPath").InnerText.Replace("\\","/");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected string PassportId { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected string StlUrl { get; set; }
        private string FileGuid
        {
            get { return Request.QueryString["g"]; }
        }
    }
}