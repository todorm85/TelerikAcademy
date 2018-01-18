var frameModule = require('ui/frame');

exports.pageLoaded = function(args) {
    var page = args.object;
};

exports.myTrainings = function() {
    frameModule.topmost()
        .navigate("views/list/list");
};

exports.planTraining = function() {
    var topmost = frameModule.topmost();
    topmost.navigate('views/prognose-training/prognose-training');
};

exports.statistics = function function_name() {
    var topmost = frameModule.topmost();
    topmost.navigate('views/calories-statistics/calories-statistics');
};
