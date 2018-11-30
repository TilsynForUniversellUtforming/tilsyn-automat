﻿$(function () {
    $('[data-hide="True"]').hide();

    $('.jsAnswerItem').change(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        
        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideDown("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideUp("fast");
                } else {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideUp("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideDown("fast");
                }
            });
        }
    });

    $('.jsAnswerItem').each(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        var alwaysvisible = $(this).data("alwaysvisible").toLowerCase();

        if (alwaysvisible === "true") {
            $(this).appendTo($(this).prev().find(".jsNextAnswerItemPlaceHolder"));
        }

        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideDown("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideUp("fast");
                } else {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideUp("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideDown("fast");
                }
            });
        }
    });

    $(".jsButtonRemoveImage").click(function (e) {
        e.preventDefault();
        var id = $(this).data("id");

        $("#answer_image_" + id).val("");
        $("#old_" + id).hide();
    });
});