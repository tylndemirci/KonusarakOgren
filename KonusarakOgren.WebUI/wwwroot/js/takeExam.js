function takeExam() {
    for (let i = 0; i < 4; i++) {
        let selectColor = ".color" + (i);
        $(selectColor).click(function () {
            $(this).css("background-color", "yellow")
            $(this).attr("isChecked", "true")
            $(selectColor).not(this).css("background-color", "")
            $(selectColor).not(this).attr("isChecked", "false")
        })
    }
}


$("button").click(function () {

    $('[data-isTrue]').each(function (index, element) {

        var isTrue = $(element).attr("data-isTrue");
        var isChecked = $(element).attr("isChecked");
        if (isChecked == "true") {
            if (isTrue === "False") {
                $(element).css("background-color", "red")
                $(element).not(this).css("background-color", "")
            } else {
                $(element).css("background-color", "green")
                $(element).not(this).css("background-color", "")
            }
        }
    });

});
