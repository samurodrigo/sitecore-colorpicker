using Newtonsoft.Json;
using Sitecore.Diagnostics;
using Sitecore.Install.Files;
using System;
using System.Linq;
using System.Text;
using System.Web.UI;
using Control = Sitecore.Web.UI.HtmlControls.Control;

namespace Sitecore.CustomFields.RangeSelector.Project
{
    public class RangeSelector : Control
    {
        private RangeSelectorConfig _config = new RangeSelectorConfig();

        public bool HasPostData { get; set; }

        public string Source { get; set; }

        private string deserealizationErrorMessage = string.Empty;

        protected override void DoRender(HtmlTextWriter output)
        {
            var style = !string.IsNullOrWhiteSpace(_config.Width) ? $"style='width:{ _config.Width }px'" : string.Empty;
            output.Write("<div class='range-container'>");
            output.Write($"<input class='range-input' type='range' id='{this.ID}' data-id='{this.ID}' value='{this.Value}' name='{this.Name}' min='{_config.Min}' max='{_config.Max}' step='{_config.Step}' list='{this.ID}__markers' {style} /> {GetDataList()}");
            output.Write($"<span class='range-actual-value' data-id='{this.ID}'>{this.Value}</span>");
            if (!string.IsNullOrWhiteSpace(_config.ExampleBoxType)) { 
            
                output.Write("<div class='range-example'>");
                switch (_config.ExampleBoxType)
                {
                    case "color":
                        output.Write($"<div class='range-example-color' data-id='{this.ID}' data-change-class='{_config.PropertyToChangeOnExampleText}' data-property-suffix='{_config.PropertySuffix}'></div>");
                        break;
                    case "image":
                        output.Write($"<image class='range-example-image' src='/sitecore/shell/themes/standard/Images/Startbar/StartButton.png' data-id='{this.ID}' data-change-class='{_config.PropertyToChangeOnExampleText}' data-property-suffix='{_config.PropertySuffix}' />");
                        break;
                    case "text":
                        output.Write($"<span class='range-example-text' data-id='{this.ID}' data-change-class='{_config.PropertyToChangeOnExampleText}' data-property-suffix='{_config.PropertySuffix}'>Example</span>");
                        break;
                }
                output.Write("</div>");                
            }
            output.Write("</div>");
            if (!string.IsNullOrWhiteSpace(deserealizationErrorMessage))
            {
                output.Write($"<div class='range-error-message'>{deserealizationErrorMessage}</div>");
            }
            output.Write(@"
                <script type='text/javascript'>
                    if(!window.rangeScriptLoaded) {
                        var script = document.createElement('script');
                        script.src = '/sitecore modules/shell/SitecoreCustomFields/RangeSelector/range-selector.js';
                        document.head.appendChild(script);
                        script.onload = function () {
                            initializeRangeSelector();
                            window.rangeScriptLoaded = true;

                            const rangeSelectorStylesheet = document.createElement('link');
                            rangeSelectorStylesheet.rel = 'stylesheet';
                            rangeSelectorStylesheet.href = '/sitecore modules/shell/SitecoreCustomFields/RangeSelector/range-selector.css'
                            document.head.appendChild(rangeSelectorStylesheet);
                        }
                    } else {
                        initializeRangeSelector();
                    }

                </script>");
        }

        private string GetDataList()
        {
            if (_config.Values != null && !_config.Values.Any())
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<datalist id='{this.ID}__markers'>");
            foreach (var option in _config.Values)
            {
                sb.AppendLine($"<option value='{option.Value}'></option>");
            }
            sb.AppendLine("</datalist>");
            return sb.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            Assert.ArgumentNotNull(e, "e");
            base.OnLoad(e);

            try
            {
                if (!string.IsNullOrWhiteSpace(Source))
                {
                    _config = JsonConvert.DeserializeObject<RangeSelectorConfig>(this.Source);
                }
            }
            catch (Exception ex)
            {
                Diagnostics.Log.Error(ex.Message, this);
                deserealizationErrorMessage = "Error loading configuration. Please check source json.";
            }

            if (!HasPostData)
            {
                LoadPostData(string.Empty);
            }
        }

        protected override bool LoadPostData(string value)
        {
            this.HasPostData = true;

            if (value == null)
            {
                return false;
            }

            if (this.GetViewStateString("Value") != value)
            {
                SetModified();
            }

            this.SetViewStateString("Value", value);

            return true;
        }

        private static void SetModified()
        {
            Sitecore.Context.ClientPage.Modified = true;
        }
    }
}
