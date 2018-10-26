"use strict";

$(window).load(function() {
	$(".loader").delay(500).fadeOut();
	$("#mask").delay(1000).fadeOut("slow");
});

$(document).ready(function(){ 

$(".header").sticky({ topSpacing: 0 });

/* Menu Anchors */
$('a[href*=#]').click(function() {
 if (location.pathname.replace(/^\//,'') === this.pathname.replace(/^\//,'') && location.hostname === this.hostname) {
	 var $target = $(this.hash);
	 $target = $target.length && $target || $('[name=' + this.hash.slice(1) +']');
	 if ($target.length) {
		 var targetOffset = $target.offset().top;
		 $('html,body').animate({scrollTop: targetOffset-75}, 1000);
		 return false;
		}
	}
});





/* This overrides the defaul Gallery behavior of popping up a image in a window 
   and allows clicking on the gallery thumbnail to redirect to a shipwreck page */

$(".featuredURL").click(function () {
    var url = ($(this).attr('href'));
    window.location = url;
});



});