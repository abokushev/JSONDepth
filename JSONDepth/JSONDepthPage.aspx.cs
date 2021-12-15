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
    /// <param name="invalidJSONResponse">Result for invalid JSON input.</param>
    public partial class JSONDepthCalculatingWebForm : System.Web.UI.Page
    {
        private static readonly string invalidJSONResponse = "{\"error\": \"Invalid JSON\"}";
        protected void Page_Load(object sender, EventArgs args){}

        protected void CalculateJsonMaxDepthButton(object sender, EventArgs args)
        {
            
            JSONOutput.Text = ProcessJSON(JSONInput.Text);
        }

        /// <summary>
        ///Checks correctness of JSON string and returns information about it
        /// </summary>
        /// /// <returns>
        /// The output for the program. 
        /// </returns>
        /// <param name="jsonInString">JSON string from web page.</param>
        public String ProcessJSON(string jsonInString)
        {
            int maxDepth = 0;
            JObject jsonRoot = null;            
            try
            {
                jsonRoot = JsonConvert.DeserializeObject<JObject>(jsonInString);
                if(jsonRoot == null)
                {
                    return invalidJSONResponse;
                }
            }
            catch (Exception ex)
            {    
                return invalidJSONResponse;
            }            
            return "{\"levels\" : " + CalculateJSONDepth(jsonRoot, 0, maxDepth).ToString() + '}';            
        }

        /// <summary>
        ///Calculates depth of JSON
        /// </summary>
        /// <returns>
        /// The depth of JSON.
        /// </returns>
        /// <param name="objTree">JToken using in JObject's depth calculation.</param>
        /// <param name="iChildDepth">Current JToken's depth.</param>
        /// <param name="maxDepth">Parameter to calculate the depth of the JSON</param>
        private int CalculateJSONDepth(JToken objTree, int iChildDepth, int maxDepth)
        {            
            if (objTree.Values().Count() > 0)
            {
                iChildDepth++;
                if (maxDepth < iChildDepth)
                {
                    maxDepth = iChildDepth;
                }
                foreach (JToken jt in objTree.Values())
                {
                    if (maxDepth < CalculateJSONDepth(jt, iChildDepth, maxDepth))
                    {
                        maxDepth = CalculateJSONDepth(jt, iChildDepth, maxDepth);
                    }
                }
            }
            return maxDepth;
        }
    }
}