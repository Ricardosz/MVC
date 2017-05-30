function AuthorFormViewModel(author) {
    var self = this;

    self.saveCompleted = ko.observable(false);
    self.sending = ko.observable(false);

    self.isCreating = author.id == 0;

    self.author = {
        id: author.id,
        firstName: ko.observable(author.firstName),
        lastName: ko.observable(author.lastName),
        biography: ko.observable(author.biography),
    };

    self.validateAndSave = function (form) {
        if (!$(form).valid())
            return false;

        self.sending(true);

        // include the anti forgery token
        self.author.__RequestVerificationToken = form[0].value;

        $.ajax({
            url: '/api/authors',
            type: (self.isCreating) ? 'post' : 'put',
            contentType: 'application/json',
            data: ko.toJSON(self.author)
        })
        .success(self.successfulSave)
        .error(self.errorSave)
        .complete(function () { self.sending(false) });
    };

    self.successfulSave = function () {
        self.saveCompleted(true);

        $('.body-content').prepend('<div class="alert alert-success"><strong>成功！</strong> 这个作者已保存</div>');
        setTimeout(function () {
            if (self.isCreating)
                location.href = './';
            else
                location.href = '../';
        }, 1000);
    };

    self.errorSave = function () {
        $('.body-content').prepend('<div class="alert alert-danger"><strong>出错了!</strong> 出现错误无法保存这个作者.</div>');
    };
}