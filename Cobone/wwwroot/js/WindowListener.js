

// listen for page resize
//function resizeListener(dotnethelper) {
//    $(window).resize(() => {
//        let browserHeight = $(window).innerHeight();
//        let browserWidth = $(window).innerWidth();
//        DotNet.invokeMethodAsync('Cobone','SetBrowserDimensions', browserWidth, browserHeight).then(() => {
//            // success, do nothing
//        }).catch(error => {
//            console.log("Error during browser resize: " + error);
//        });
//    });
//}

//window.onresize = function () {
//    var browserHeight = window.innerHeight;
//    var browserWidth = window.innerWidth;
//    DotNet.invokeMethodAsync('Cobone','SetBrowserDimensions', browserWidth, browserHeight)
//        .then(() => {
//            // success, do nothing
//        }).catch(error => {
//            console.log("Error during browser resize: " + error);
//        });
//}