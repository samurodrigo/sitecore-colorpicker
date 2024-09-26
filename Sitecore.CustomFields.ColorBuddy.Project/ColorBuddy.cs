using System.Web.UI;

namespace Sitecore.CustomFields.ColorBuddy.Project
{
    public class ColorBuddy: Sitecore.Web.UI.HtmlControls.Edit
    {
        protected override void DoRender(HtmlTextWriter output)
        {
            output.Write("<input type='color' id='{0}' name='{1}' value='{2}' /><span style='color:{2}; margin-left:10px'>{2}</span>", this.ID, this.Name, this.Value);
        }
    }
}
