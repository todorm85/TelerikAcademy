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

            // you could also just write this, and the resolve will be called with one param
            // that will be the result of the ajax
            // success: resolve
         }).error(reject);
      }
   });
}

export default {
   get
};
