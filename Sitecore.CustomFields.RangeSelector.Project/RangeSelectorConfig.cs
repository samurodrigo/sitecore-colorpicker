using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sitecore.CustomFields.RangeSelector.Project
{
    /// <summary>
    /// Example json
    /// { min: 0, max: 100, step: '10', width: '200', exampleBoxType: 'color|image|text', propertyToChangeOnExampleText: 'font-size', propertySuffix: 'px', values : [{ value: 1 }, { value: 2 }] }
    /// </summary>
    public class RangeSelectorConfig
    {
        [JsonProperty("min")]
        public double Min { get; set; } = 0;
        [JsonProperty("max")]
        public double Max { get; set; } = 100;
        [JsonProperty("step")]
        public string Step { get; set; } = "1";
        [JsonProperty("width")]
        public string Width { get; set; } = "200";
        [JsonProperty("exampleBoxType")]
        public string ExampleBoxType { get; set; } = string.Empty;
        [JsonProperty("propertyToChangeOnExampleText")]
        public string PropertyToChangeOnExampleText { get; set; } = string.Empty;
        [JsonProperty("propertySuffix")]
        public string PropertySuffix { get; set; } = string.Empty;
        [JsonProperty("values")]
        public IEnumerable<RangeSelectorCustomValues> Values { get; set; } = new List<RangeSelectorCustomValues>();
    }

    public class RangeSelectorCustomValues
    {
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
