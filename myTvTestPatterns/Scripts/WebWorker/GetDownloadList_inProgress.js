
function GetIP(request) {
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
                var start = strResponseHtml.indexOf("City</");
                var fragment = strResponseHtml.substring(start + 13, strResponseHtml.length);
                var end = fragment.indexOf("</span>");
                fragment = fragment.substring(0, end + 7);
                ipLocationArray.push(fragment);
            }
        }
    }
    return itemArray;
}

// Handle the "message" event to receive the message from the browser
self.onmessage = function () {

    // Data would be in the .data property

    var ipLocationArray = [];

    var MessageObject = {};  // new namespace

    var request = new XMLHttpRequest();

    // Event handler
    //request.onreadystatechange = function () {
        //if (request.readyState === 4) {
        //    if (request.status === 200) {
    var itemArray = GetIP(request);
                MessageObject.itemArray = itemArray;
                MessageObject.ipLocationArray = ipLocationArray;
                postMessage({ done: MessageObject });
        //    }
        //}
    //}

    self.postMessage(MessageObject);
    self.close();
};



