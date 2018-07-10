
app.filter("jsonToDate", function () {
    return function ConverterDataJsonParaData(input) {

        var dataFormatada = new Date(parseInt(input.substr(6)));

        return ((dataFormatada.getDate() < 10) ? "0" : "")
            + dataFormatada.getDate() + "/" + (((dataFormatada.getMonth() + 1) < 10) ? "0" : "")
            + (dataFormatada.getMonth() + 1) + "/" + dataFormatada.getFullYear();

    };
});



/*
app.filter("jsonToDate", function () {
    return function ConverterDataJsonParaData(input) {

        var dataFormatada = new Date(parseInt(input.substr(6)));

        return (dataFormatada.getFullYear) + "/"
            + dataFormatada.getDate() + "/" + (((dataFormatada.getMonth() + 1) < 10) ? "0" : "") + (dataFormatada.getMonth() + 1)
            + ((dataFormatada.getDate() < 10) ? "0" : "");

    };
});
*/
