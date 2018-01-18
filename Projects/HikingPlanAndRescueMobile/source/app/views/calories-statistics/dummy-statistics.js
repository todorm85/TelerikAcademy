var dependencyObservableModule = require("ui/core/dependency-observable");
var CategoricalDataModel = (function (_super) {
    __extends(CategoricalDataModel, _super);
    function CategoricalDataModel() {
        _super.call(this);
    }
    Object.defineProperty(CategoricalDataModel.prototype, "categoricalSource", {
        get: function () {
            return [
                { Country: "Germany", Amount: Math.random() * 10 },
                { Country: "France", Amount: Math.random() * 10 },
                { Country: "Bulgaria", Amount: Math.random() * 10 },
                { Country: "Spain", Amount: Math.random() * 10 },
                { Country: "USA", Amount: Math.random() * 10 }
            ];
        },
        enumerable: true,
        configurable: true
    });
    
    return CategoricalDataModel;
})(dependencyObservableModule.DependencyObservable);
exports.CategoricalDataModel = CategoricalDataModel;