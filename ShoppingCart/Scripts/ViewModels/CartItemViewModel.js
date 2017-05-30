function CartItemViewModel(params) {
    var self = this;

    self.sending = ko.observable(false);

    self.cartItem = params.cartItem;
    self.showButton = params.showButton;

    self.upsertCartItem = function (form) {
        if (!$(form).valid())
            return false;

        self.sending(true);

        var data = {
            id: self.cartItem.id,
            cartId: self.cartItem.cartId,
            bookId: self.cartItem.book.id,
            quantity: self.cartItem.quantity()
        };

        $.ajax({
            url: '/api/cartitems',
            type: self.cartItem.id === undefined ? 'post' : 'put',
            contentType: 'application/json',
            data: ko.toJSON(data)
        })
        .success(self.successfulSave)
        .error(self.errorSave)
        .complete(function () { self.sending(false) });
    };

    self.successfulSave = function (data) {
        var msg = '<div class="alert alert-success"><strong>成功!</strong> 购物车已经 ';
        if (self.cartItem.id === undefined)
            msg += '增加了';
        else
            msg += '更新了';

        $('.body-content').prepend(msg + ' 你的购物车.</div>');

        self.cartItem.id = data.id;

        cartSummaryViewModel.updateCartItem(ko.toJS(self.cartItem));
    };

    self.errorSave = function () {
        var msg = '<div class="alert alert-danger"><strong>出错了！</strong> 这个错误是 ';
        if (self.cartItem.id === undefined)
            msg += '增加出错';
        else
            msg += '更新出错';

        $('.body-content').prepend(msg + ' 对于购物车.</div>');
    };
};

ko.components.register('upsert-cart-item', {
    viewModel: CartItemViewModel,
    template: { element: 'cart-item-form' }
});