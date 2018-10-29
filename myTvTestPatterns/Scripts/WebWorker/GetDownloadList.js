
onmessage = function (event) {
    var ipLocationArray = [];

    var MessageObject = {};  // new namespace

    var request = new XMLHttpRequest();

    // Event handler
    request.onreadystatechange = function () {
        if (request.readyState === 4) {
            if (request.status === 200) {
                jsonString = JSON.parse(request.response);
                itemArray = JSON.parse(jsonString);
                var count = itemArray.length;
                if (count > 200) { count = 200 }
                for (var j = 0; j < count - 1; j++) {
                    if (typeof itemArray[j].Client_IP != undefined) {
                        var firstDigit = Number(itemArray[j].Client_IP.slice(0, 1));
                        if (!itemArray[j].Client_IP == "" && !isNaN(firstDigit)) {
                            var ipRequest = new XMLHttpRequest();
                            var ipResponse;
                            ipRequest.open("GET", "http://ipinfo.io/" + itemArray[j].Client_IP, false);
                            ipRequest.send();
                            while (ipRequest.responseText.length < 3000) { }
                            var strResponseHtml = ipRequest.responseText;
							var iStart = strResponseHtml.indexOf("<td>City</td>");
							var fragment = strResponseHtml.substring(iStart + 13, strResponseHtml.length);
							var iEnd = fragment.indexOf("</tr>");
							fragment = fragment.substring(0, iEnd - 5);
                            ipLocationArray.push(fragment);
                        }
                    }
                }
                MessageObject.itemArray = itemArray;
                MessageObject.ipLocationArray = ipLocationArray;
                self.postMessage(MessageObject);
            }
        }
    }

    //request.open("POST", "http://localhost:63704/Default/GetDownloads", true);
    request.open("POST", "http://www.mytvtestpatterns.com/Default/GetDownloads", true);
    request.setRequestHeader("Content-Type", "application/json");
    request.send();

}

