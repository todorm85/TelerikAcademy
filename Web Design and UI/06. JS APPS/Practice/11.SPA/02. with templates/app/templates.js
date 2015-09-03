import 'jquery';

var htmlCache = {};

function get(htmlName) {
   return new Promise(function (resolve, reject) {
      if (htmlCache[htmlName]) {
         resolve(htmlCache[htmlName]);
      } else {
         $.ajax({
            url: 'templates/' + htmlName + '.html',
            type: 'GET',
            success: function (res) {
               htmlCache[htmlName] = res;
               resolve(res);
            }
         });
      }
   });
}

export default {
   get
};