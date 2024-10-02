function initializeRangeSelector() {
    const rangeInputs = document.querySelectorAll('input[type="range"]');
    rangeInputs.forEach(input => {
        const value = document.querySelector(`span[data-id="${input.dataset.id}"].range-actual-value`);
        const color = document.querySelector(`[data-id="${input.dataset.id}"].range-example-color`);
        const image = document.querySelector(`[data-id="${input.dataset.id}"].range-example-image`);
        const text = document.querySelector(`[data-id="${input.dataset.id}"].range-example-text`);
        value.textContent = input.value;

        changeElementProperty(color, input.value);
        changeElementProperty(image, input.value);
        changeElementProperty(text, input.value);

        input.addEventListener('input', (e) => {
            value.textContent = e.target.value
            changeElementProperty(color, e.target.value);
            changeElementProperty(image, e.target.value);
            changeElementProperty(text, e.target.value);
        })
    });
}

function changeElementProperty(element, value) {
    if (!element) return;

    const propertyToChange = element.dataset.changeClass;
    const propertySuffix = element.dataset.propertySuffix;
    element.style.cssText = `${propertyToChange}:${value}${propertySuffix}`;
    
}