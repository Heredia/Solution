var Regex = {
    DATE_DDMMYYYY: /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))) ?((20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2}))?$/,
    DECIMAL: /^((-?[1-9]+)|[0-9]+)(\.?|\,?)([0-9]*)$/,
    EMAIL: /^([a-z0-9_\.\-]{3,})@([\da-z\.\-]{3,})\.([a-z\.]{2,6})$/,
    HEX: /^#?([a-f0-9]{6}|[a-f0-9]{3})$/,
    TIME_HHMM: /^(20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2})$/,
    INTEGER: /^((-?[1-9]+)|[0-9]+)$/,
    URL: /^(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})$/
};

var Validation = new function () {
    this.IsDate = function (value) { return Regex.DATE_DDMMYYYY.test(value); }
    this.IsDecimal = function (value) { return Regex.DECIMAL.test(value); }
    this.IsEmail = function (value) { return Regex.EMAIL.test(value); }
    this.IsHex = function (value) { return Regex.HEX.test(value); }
    this.IsTimeHHMM = function (value) { return Regex.TIME_HHMM.test(value); }
    this.IsInteger = function (value) { return Regex.INTEGER.test(value); }
    this.IsUrl = function (value) { return Regex.URL.test(value); }
    this.IsEmpty = function (value) { return !value || value.toString().trim() === ""; }
    this.IsMinimumLength = function (value, minimum) { return value && minimum && value.length >= minimum; }
    this.IsMaximumLength = function (value, maximum) { return value && maximum && value.length <= maximum; }
};

var ValidationHelper = new function () {
    var InvalidCssClass = "validation-invalid";
    var InvalidElements = [];

    function GetValidationElements(group) {
        if (group) { return $("[val-groups*='" + group + "']"); }

        return $(
            "[val-date], [val-decimal], [val-email], [val-hex], [val-time], " +
            "[val-integer], [val-maximum], [val-minimum], [val-required], [val-url]"
        );
    }

    function ClearInvalidElements() {
        InvalidElements = [];
        $("." + InvalidCssClass).removeClass(InvalidCssClass);
    }

    function SetElementInvalid($element, rulesInvalids) {
        InvalidElements.push({ Element: $element[0], Errors: rulesInvalids });
        $element.addClass(InvalidCssClass);
    }

    function SetFocusFirstElementInvalid() {
        $("." + InvalidCssClass + ":first").focus();
    }

    this.IsValid = function (group) {
        ClearInvalidElements();

        var $elements = GetValidationElements(group);
        if (!$elements || $elements.length === 0) return true;

        for (var i = 0; i < $elements.length; i++) {
            var $element = $($elements[i]);
            var elementValue = $element.val();
            var rulesInvalids = [];

            if ($element.is("[val-required]")) {
                if (Validation.IsEmpty(elementValue)) { rulesInvalids.push("required"); };
            }

            if ($element.is("[val-date]")) {
                if (!Validation.IsEmpty(elementValue) && !Validation.IsDate(elementValue)) { rulesInvalids.push("date"); };
            }

            if ($element.is("[val-decimal]")) {
                if (!Validation.IsEmpty(elementValue) && !Validation.IsDecimal(elementValue)) { rulesInvalids.push("decimal"); };
            }

            if ($element.is("[val-email]")) {
                if (!Validation.IsEmpty(elementValue) && !Validation.IsEmail(elementValue)) { rulesInvalids.push("email"); };
            }

            if ($element.is("[val-hex]")) {
                if (!Validation.IsEmpty(elementValue) && !Validation.IsHex(elementValue)) { rulesInvalids.push("hex"); };
            }

            if ($element.is("[val-time]")) {
                if (!Validation.IsEmpty(elementValue) && !Validation.IsTimeHHMM(elementValue)) { rulesInvalids.push("time"); };
            }

            if ($element.is("[val-integer]")) {
                if (!Validation.IsEmpty(elementValue) && !Validation.IsInteger(elementValue)) { rulesInvalids.push("integer"); };
            }

            var ruleValue = undefined;

            if ($element.is("[val-maximum]")) {
                ruleValue = $element.attr("val-maximum");
                if (!Validation.IsEmpty(elementValue) && !Validation.IsMaximumLength(elementValue, ruleValue)) { rulesInvalids.push("maximum"); };
            }

            if ($element.is("[val-minimum]")) {
                ruleValue = $element.attr("val-minimum");
                if (!Validation.IsMinimumLength(elementValue, ruleValue)) { rulesInvalids.push("minimum"); };
            }

            if ($element.is("[val-url]")) {
                if (!Validation.IsEmpty(elementValue) && !this.IsUrl(elementValue)) { rulesInvalids.push("url"); };
            }

            if (rulesInvalids && rulesInvalids.length > 0) {
                SetElementInvalid($element, rulesInvalids);
            }
        }

        SetFocusFirstElementInvalid();

        if (InvalidElements.length > 0) {
            console.log("Validation Errors: ", InvalidElements);
            return false;
        }

        return true;
    }
}