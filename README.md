
# Custom Sitecore Fields

This project contains a collection of custom fields for Sitecore, designed to simplify data creation and management with visually intuitive components.

## Available Fields

### 1. **Color Selector**

The `Color Selector` is a straightforward field based on the `input type="color"` element, allowing users to select colors quickly and efficiently. The selected color is stored as an HTML string (e.g., `#ffffff`).

#### Usage Example

Ideal for scenarios where quick color selection is needed, such as defining themes, button styles, etc.

### 2. **Range Selector**

The `Range Selector` is a field based on the `input type="range"` element, which can be highly configurable through a JSON defined in the `Source` field of Sitecore. This field allows for more granular control over the behavior and appearance of numeric values.

#### Configuration

The field can be configured with the following example JSON:

`{
  "min": 0,
  "max": 100,
  "step": 10,
  "width": "200px",
  "exampleBoxType": "color",
  "propertyToChangeOnExampleText": "font-size",
  "propertySuffix": "px",
  "values": [{ "value": 10 }, { "value": 20 }]
}` 

#### Properties

-   **min**: Minimum range value (default: `0`).
-   **max**: Maximum range value (default: `100`).
-   **step**: Increment interval between values (default: `1`).
-   **width**: Width of the range field (can be set with a unit like `px` or `em, default: 200`).
-   **exampleBoxType**: Defines a visual example that reacts to the range changes. Possible values:
    -   `color`: Displays a `div` with a background color.
    -   `image`: Displays a `div` with an image inside.
    -   `text`: Displays text that changes based on the range value.
-   **propertyToChangeOnExampleText**: CSS property to be modified in the text example (e.g., `font-size`, `line-height`).
-   **propertySuffix**: Suffix for the CSS property value (e.g., `px`, `%`).
-   **values**: Specific values that will be displayed as markers on the range field.

#### Behavior Example

If configured with `exampleBoxType: "text"`, `propertyToChangeOnExampleText: "font-size"`, and `propertySuffix: "px"`, moving the `Range Selector` will increase or decrease the font size of the displayed text according to the selected value.

----------

### How to Add to Sitecore

You can download the package for any custom field.
If you want to build from source, build the solution, copy App_Config and sitecore modules folders to you sitecore installation.
Also, copy dll files to you sitecore installation bin folder.
There is also a serialization folder which contains all core database fields.

----------

### Final Considerations

These fields were created to provide a more intuitive interface for users and reduce configuration time in Sitecore solutions. Suggestions and contributions are welcome!