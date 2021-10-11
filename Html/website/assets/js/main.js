/**
 * Template Name: EstateAgency - v4.3.0
 * Template URL: https://bootstrapmade.com/real-estate-agency-bootstrap-template/
 * Author: BootstrapMade.com
 * License: https://bootstrapmade.com/license/
 */
(function() {
    "use strict";

    /**
     * Easy selector helper function
     */
    const select = (el, all = false) => {
        el = el.trim()
        if (all) {
            return [...document.querySelectorAll(el)]
        } else {
            return document.querySelector(el)
        }
    }

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        let selectEl = select(el, all)
        if (selectEl) {
            if (all) {
                selectEl.forEach(e => e.addEventListener(type, listener))
            } else {
                selectEl.addEventListener(type, listener)
            }
        }
    }

    /**
     * Easy on scroll event listener 
     */
    const onscroll = (el, listener) => {
        el.addEventListener('scroll', listener)
    }

    /**
     * Toggle .navbar-reduce
     */
    let selectHNavbar = select('.navbar-default')
    if (selectHNavbar) {
        onscroll(document, () => {
            if (window.scrollY > 100) {
                selectHNavbar.classList.add('navbar-reduce')
                selectHNavbar.classList.remove('navbar-trans')
            } else {
                selectHNavbar.classList.remove('navbar-reduce')
                selectHNavbar.classList.add('navbar-trans')
            }
        })
    }

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top')
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active')
            } else {
                backtotop.classList.remove('active')
            }
        }
        window.addEventListener('load', toggleBacktotop)
        onscroll(document, toggleBacktotop)
    }

    /**
     * Preloader
     */
    let preloader = select('#preloader');
    if (preloader) {
        window.addEventListener('load', () => {
            preloader.remove()
        });
    }

    /**
     * Search window open/close
     */
    let body = select('body');
    on('click', '.navbar-toggle-box', function(e) {
        e.preventDefault()
        body.classList.add('box-collapse-open')
        body.classList.remove('box-collapse-closed')
    })

    on('click', '.close-box-collapse', function(e) {
        e.preventDefault()
        body.classList.remove('box-collapse-open')
        body.classList.add('box-collapse-closed')
    })







    $(document).ready(function() {
        $(".quicksidebar").click(function() {
            if ($("#hdproperty").length > 0) {
                $("#hdproperty").val($(this).attr("data-prop"));
            }
            $(".quick-contact").addClass("active");
            $(".quick-contact-bg").addClass("show");
        });
        $(".close-box-collapse").click(function() {
            $(".quick-contact").removeClass("active");
            $(".quick-contact-bg").removeClass("show");
        });
    });





    /**
     * Intro Carousel
     */
    new Swiper('.intro-carousel', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 2000,
            disableOnInteraction: false
        },
        slidesPerView: 'auto',
        pagination: {
            el: '.swiper-pagination',
            type: 'bullets',
            clickable: true
        }
    });

    /**
     * Property carousel
     */
    new Swiper('#property-carousel', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        slidesPerView: 'auto',
        pagination: {
            el: '.propery-carousel-pagination',
            type: 'bullets',
            clickable: true
        },
        breakpoints: {
            320: {
                slidesPerView: 1,
                spaceBetween: 20
            },

            1200: {
                slidesPerView: 3,
                spaceBetween: 20
            }
        }
    });

    /**
     * News carousel
     */
    new Swiper('#news-carousel', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        slidesPerView: 'auto',
        pagination: {
            el: '.news-carousel-pagination',
            type: 'bullets',
            clickable: true
        },
        breakpoints: {
            320: {
                slidesPerView: 1,
                spaceBetween: 20
            },

            1200: {
                slidesPerView: 3,
                spaceBetween: 20
            }
        }
    });

    /**
     * Testimonial carousel
     */
    new Swiper('#testimonial-carousel', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        slidesPerView: 'auto',
        pagination: {
            el: '.testimonial-carousel-pagination',
            type: 'bullets',
            clickable: true
        }
    });

    /**
     * Property Single carousel
     */
    new Swiper('#property-single-carousel', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        pagination: {
            el: '.property-single-carousel-pagination',
            type: 'bullets',
            clickable: true
        }
    });

})()




// function generateCaptcha() {
//     var alpha = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z');
//     var i;
//     for (i = 0; i < 4; i++) {
//         var a = alpha[Math.floor(Math.random() * alpha.length)];
//         var b = alpha[Math.floor(Math.random() * alpha.length)];
//         var c = alpha[Math.floor(Math.random() * alpha.length)];
//         var d = alpha[Math.floor(Math.random() * alpha.length)];
//     }
//     var code = a + '' + b + '' + '' + c + '' + d;
//     document.getElementById("mainCaptcha").value = code
// }

// function CheckValidCaptcha() {
//     var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
//     var string2 = removeSpaces(document.getElementById('txtInput').value);
//     if (string1 == string2) {
//         document.getElementById('success').innerHTML = "Form is validated Successfully";
//         //alert("Form is validated Successfully");
//         return true;
//     } else {
//         document.getElementById('error').innerHTML = "Please enter a valid captcha.";
//         //alert("Please enter a valid captcha.");
//         return false;

//     }
// }

function removeSpaces(string) {
    return string.split(' ').join('');
}



function changeHandler(event) {


    let disProperty = ""
    if (event == "All") {
        disProperty = "block"
    } else {
        disProperty = "none"
    }

    var x = document.getElementsByClassName("displayNone");
    for (let i = 0; i < x.length; i++) {
        console.log(i)
        x[i].style.display = disProperty

    }
    document.getElementById("property" + event).style.display = "block"

}

function clearError() {

    document.getElementById("amountError").innerHTML = "";
}