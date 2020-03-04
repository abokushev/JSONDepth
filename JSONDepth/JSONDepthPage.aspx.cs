using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONDepth
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected int maxDepth = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            JSONOutput.Text = Output("");//JSONInput.Text);
        }

        public String Output(string input)
        {
            JObject jsonRoot = null;
            try
            {
                jsonRoot = JsonConvert.DeserializeObject<JObject>(input);
                if(jsonRoot == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {    
                return "{\"error\": \"Invalid JSON\"}";
            }           
            JSONDepth(jsonRoot, maxDepth);
            return "{\"levels\" : " + maxDepth.ToString() + '}';            
        }

        private void JSONDepth(JToken objTree, int iChildDepth)
        {           
            iChildDepth++;            
            if (objTree.Values().Count() > 0)
            {
                if (maxDepth < iChildDepth)
                {
                    maxDepth = iChildDepth;
                }
                foreach (JToken jt in objTree.Values())
                {
                    JSONDepth(jt, iChildDepth);
                }
            }
            else
            {
                return;
            }
        }
    }
}