function BookDetailViewModel(model) {
    var self = this;

    self.cartItem = {
        cartId: cartSummaryViewModel.cart.id,
        quantity: ko.observable(1),
        book: model
    };
};