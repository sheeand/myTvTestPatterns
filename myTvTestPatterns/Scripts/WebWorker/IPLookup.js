onmessage = function (Client_IP) {
    var ipLocationArray = [];
    var ipRequest = new XMLHttpRequest();

    // Event handler
    ipRequest.onreadystatechange = function () {
        if (ipRequest.readyState === 4) {
            if (ipRequest.status === 200) {
                var strResponseHtml = ipRequest.responseText;
                //var iStart = strResponseHtml.indexOf("<td>City</td>");
                //var fragment = strResponseHtml.substring(iStart + 13, strResponseHtml.length);
				//var iEnd = fragment.indexOf("Try our");
                //fragment = fragment.substring(0, iEnd - 5);
                //var fragment = strResponseHtml.substring(0, 60);
				var fragment = "test";
                ipLocationArray.push(fragment);
                self.postMessage(ipLocationArray);
            }
        }
    }

    ipRequest.open("GET", "http://ipinfo.io/" + Client_IP, false);
    ipRequest.send();
}