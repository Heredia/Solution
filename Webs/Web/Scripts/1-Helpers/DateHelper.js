var DateHelper = new function () {
    this.GetDateFromDDMMYYYY = function (dateString) {
        if (!dateString || dateString.length !== 10) return undefined;

        var dateParts = dateString.split("/");

        var date = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);

        if (date instanceof Date && !isNaN(date.valueOf())) {
            return date;
        }
        return undefined;
    }

    this.FormatDateToDDMMYYYY = function (date) {
        if (!(date instanceof Date)) return undefined;
        return ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + date.getFullYear();
    }

    this.AddDays = function (date, days) {
        if (!(date instanceof Date)) return undefined;
        date.setDate(date.getDate() + parseInt(days));
        return new Date(date);
    }

    this.AddMonths = function (date, months) {
        if (!(date instanceof Date)) return undefined;
        date.setMonth(date.getMonth() + parseInt(months));
        return new Date(date);
    }

    this.AddYears = function (date, years) {
        if (!(date instanceof Date)) return undefined;
        date.setFullYear(date.getFullYear() + parseInt(years));
        return new Date(date);
    }
}