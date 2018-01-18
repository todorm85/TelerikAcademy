var dependencyObservableModule = require("ui/core/dependency-observable");

var CategoricalDataModel = (function(_super) {
    __extends(CategoricalDataModel, _super);

    function CategoricalDataModel(data) {
        _super.call(this);
        this._data = data;
    }
    Object.defineProperty(CategoricalDataModel.prototype, "categoricalSource", {
        get: function() {
            return this._data;
        },
        enumerable: true,
        configurable: true
    });
    // Object.defineProperty(CategoricalDataModel.prototype, "categoricalSource", {
    //     set: function(data) {
    //         this._data = data;
    //     },
    //     enumerable: true,
    //     configurable: true
    // });

    return CategoricalDataModel;
})(dependencyObservableModule.DependencyObservable);

module.exports = CategoricalDataModel;