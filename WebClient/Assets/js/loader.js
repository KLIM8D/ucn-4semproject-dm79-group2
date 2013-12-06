function loadFile(filename, filetype) {
    var fileref;
    if (filetype == "js") {
        fileref = document.createElement('script');
        fileref.setAttribute("type", "text/javascript");
        fileref.setAttribute("src", filename);
    }
    else if (filetype == "css") {
        fileref = document.createElement("link");
        fileref.setAttribute("rel", "stylesheet");
        fileref.setAttribute("type", "text/css");
        fileref.setAttribute("href", filename);
    }
    else if (filetype == "icon") {
        fileref = document.createElement("link");
        fileref.setAttribute("rel", "shortcut icon");
        fileref.setAttribute("type", "image/x-icon");
        fileref.setAttribute("href", filename);
    }
    if (typeof fileref != "undefined")
        document.getElementsByTagName("head")[0].appendChild(fileref);
}

function getIEVersion() {
    var rv = -1;
    if (navigator.appName == 'Microsoft Internet Explore') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}

loadFile("https://cdnjs.cloudflare.com/ajax/libs/jquery/1.10.2/jquery.min.js", "js");
loadFile("https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js", "js");
loadFile("https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.0/js/bootstrap.min.js", "js");
loadFile("https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.11.1/jquery.validate.min.js", "js");
loadFile("/assets/js/jquery.unobtrusive-ajax.min.js", "js");

if (getIEVersion() != -1 && getIEVersion() <= 8.0) {
    loadFile("https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.6.2/html5shiv.js", "js");
    loadFile("https://cdnjs.cloudflare.com/ajax/libs/respond.js/1.3.0/respond.js", "js");
}

if (getIEVersion() != -1 && getIEVersion() <= 10.0) {
    loadFile("https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.7.1/modernizr.min.js", "js");
}

loadFile("https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.0/css/bootstrap.min.css", "css");
loadFile("/assets/css/custom.css", "css");

//loadFile("assets/img/bookmark.ico", "icon")