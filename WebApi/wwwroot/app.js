function AppViewModel() {
    var self = this;

    self.username = ko.observable("");
    self.password = ko.observable("");
    self.isLoggedIn = ko.observable(false);
    self.loginErrorMessage = ko.observable(""); // Для отображения сообщений об ошибках

    self.login = function () {
        var loginData = {
            username: self.username(),
            password: self.password()
        };

        $.ajax({
            url: '/api/Employee/Authenticate', // Убедитесь, что путь правильный
            type: 'POST',
            data: JSON.stringify(loginData),
            contentType: 'application/json',
            success: function (data) {
                // Обработка успешной авторизации
                localStorage.setItem('userToken', data.token);
                self.isLoggedIn(true);
                self.loginErrorMessage(""); // Очистка сообщения об ошибке
            },
            error: function (error) {
                // Обработка ошибок
                console.error(error);
                self.isLoggedIn(false);
                self.loginErrorMessage("Login failed. Please check your credentials.");
            }
        });
    };

    // Функции для управления сущностями Project, ProjectTask, Employee
    // Например, добавление, удаление, обновление и просмотр сущностей
}

ko.applyBindings(new AppViewModel());
