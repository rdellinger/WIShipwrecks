$(document).ready(function () {

    // When the County dropdown is selected, update the Nearest Cities dropdown
    //$(function () {
    //    $('#county').change(function () {
    //        var county = $(this).val();
    //            $.getJSON("http://aqua.wisc.edu/Shipwrecks/Vessel/ListNearestCitiesJson", { id: county },
    //                function (dropdowndata) {
    //                    var select = $("#nearestCity");
    //                    select.empty();
    //                    select.append($('<option/>', {
    //                        value: "",
    //                        text: "All"
    //                }));

    //                $.each(dropdowndata, function (index, itemData) {
    //                    select.append($('<option/>', {
    //                        value: itemData,
    //                        text: itemData
    //                }));
    //            });
    //        });
    //    });
    //});

    $(function () {
        $('#county').change(function () {
            var county = $(this).val();
            $.getJSON("../../Vessel/ListNearestCitiesJson", { id: county },
                function (dropdowndata) {
                    var select = $("#nearestCity");
                    select.empty();
                    select.append($('<option/>', {
                        value: "",
                        text: "All"
                    }));

                    $.each(dropdowndata, function (index, itemData) {
                        select.append($('<option/>', {
                            value: itemData,
                            text: itemData
                        }));
                    });
                });
        });
    });



    // Code to show and hide long list of nearby vessels
    $(".allNearbyVessels").hide();
    $(".viewFewer").hide();


    $(".viewMore").click(function () {
        $(".first10NearbyVessels").hide();
        $(".allNearbyVessels").show();
        $(".viewMore").hide();
        $(".viewFewer").show();
    });

    $(".viewFewer").click(function () {
        $(".first10NearbyVessels").show();
        $(".allNearbyVessels").hide();
        $(".viewMore").show();
        $(".viewFewer").hide();
    });



    // script to resize map canvas on screen resolutions or window resize smaller then 640px so that users can scroll using margins
    jQuery(function () {
        var windowWidth = jQuery(window).width();
        if (windowWidth <= 640) {
            jQuery('#map_canvas').css({
                'width': '90%',
                'margin-left': 'auto',
                'margin-right': 'auto'
            });
        }
        jQuery(window).on('resize', function () {
            var win = jQuery(this); //this = window
            if (win.width() <= 640) {
                jQuery('#map_canvas').css({
                    'width': '90%',
                    'margin-left': 'auto',
                    'margin-right': 'auto'
                });
            }
            else {
                jQuery('#map_canvas').css({
                    'width': '100%'
                });
            }
        });
    });



});