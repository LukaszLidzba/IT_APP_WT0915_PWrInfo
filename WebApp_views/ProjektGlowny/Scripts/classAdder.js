function classAdder(xsWidth, smWidth, mdWidth, lgWidth) {
    var badge;

    window.addEventListener("resize", function () {
        initClasses();
        setBadgeText();
    });

    $(document).ready(function () {
        initClasses();
        initBadge();
        setBadgeText();
    });

    function getWidth() {
        if (self.innerHeight) {
            return self.innerWidth;
        }
        if (document.documentElement && document.documentElement.clientHeight) {
            return document.documentElement.clientWidth;
        }
        if (document.body) {
            return document.body.clientWidth;
        }
    }

    function getScrollBarWidth() {
        var $outer = $('<div>').css({ visibility: 'hidden', width: 100, overflow: 'scroll' }).appendTo('body'),
            widthWithScroll = $('<div>').css({ width: '100%' }).appendTo($outer).outerWidth();
        $outer.remove();
        return 100 - widthWithScroll;
    };

    function getWindowWidth() {
        //return $(window).width() + getScrollBarWidth();
        return getWidth();
    }

    function addClasses() {
        var width = getWindowWidth();

        if (width < smWidth) {
            $("*").addClass("xs");
            badge = "XS";
        } else if (width < mdWidth) {
            $("*").addClass("sm");
            badge = "SM";
        } else if (width < lgWidth) {
            $("*").addClass("md");
            badge = "MD";
        } else {
            $("*").addClass("lg");
            badge = "LG";
        }
    }

    function removeClasses() {
        $("*").removeClass("xs sm md lg");
    }

    function initClasses() {
        removeClasses();
        addClasses();
    }

    function initBadge() {
        $("body").append("<div id='widthBadge' style='background-color: #000; position: fixed; left: 50%; top: 0; color: #FFF; padding: 10px;'></div>");
    }

    function setBadgeText() {
        $("#widthBadge").text(badge + " | " + getWindowWidth());
    }
}