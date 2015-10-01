/* globals $ */
function solve() {
    var data = {        
                headers: ['Vendor', 'Model', 'OS'],          
                items: [{          
                col1: 'Nokia',            
                  col2: 'Lumia 920',            
                  col3: 'Windows Phone'                      
                }, {          
                  col1: 'LG',            
                  col2: 'Nexus 5',            
                  col3: 'Android'                      
                }, {          
                  col1: 'Apple',            
                  col2: 'iPhone 6',                        
                  col3: 'iOS'                      
                }]          
              }; 

    return function (selector) {
        var htmlTemplate = $('#table-template').html();
        var htmlRenderer = Handlebars.compile(htmlTemplate);
        var renderedHtml = htmlRenderer(data);

        $(selector).html(renderedHtml);
    };
}
solve()('#content');
// var domWriter = solve();
// domWriter('#content');
// module.exports = solve;
