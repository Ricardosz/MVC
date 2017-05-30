ko.bindingHandlers.appendToHref = {
    init: function (element, valueAccessor) {
        var currentHref = $(element).attr('href');

        $(element).attr('href', currentHref + '/' + valueAccessor());
    }
}

ko.bindingHandlers.isDirty = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var originalValue = ko.unwrap(valueAccessor());
        
        var interceptor = ko.pureComputed(function () {
            return (bindingContext.$data.showButton !== undefined && bindingContext.$data.showButton)
                    || originalValue != valueAccessor()();
        });

        ko.applyBindingsToNode(element, {
            visible: interceptor
        });
    }
};

ko.extenders.subTotal = function (target, multiplier) {
    target.subTotal = ko.observable();

    function calculateTotal(newValue) {
        target.subTotal((newValue * multiplier).toFixed(2));
    };

    calculateTotal(target());

    target.subscribe(calculateTotal);

    return target;
};

ko.observableArray.fn.total = function () {
    return ko.pureComputed(function () {
        var runningTotal = 0;

        for (var i = 0; i < this().length; i++) {
            runningTotal += parseFloat(this()[i].quantity.subTotal());
        }

        return runningTotal.toFixed(2);
    }, this);
};