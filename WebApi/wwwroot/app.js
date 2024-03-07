function AppViewModel() {
    var self = this;

    self.username = ko.observable("");
    self.password = ko.observable("");
    self.isLoggedIn = ko.observable(false);
    self.loginErrorMessage = ko.observable(""); // ��� ����������� ��������� �� �������

    self.login = function () {
        var loginData = {
            username: self.username(),
            password: self.password()
        };

        $.ajax({
            url: '/api/Employee/Authenticate', // ���������, ��� ���� ����������
            type: 'POST',
            data: JSON.stringify(loginData),
            contentType: 'application/json',
            success: function (data) {
                // ��������� �������� �����������
                localStorage.setItem('userToken', data.token);
                self.isLoggedIn(true);
                self.loginErrorMessage(""); // ������� ��������� �� ������
            },
            error: function (error) {
                // ��������� ������
                console.error(error);
                self.isLoggedIn(false);
                self.loginErrorMessage("Login failed. Please check your credentials.");
            }
        });
    };

    // ������� ��� ���������� ���������� Project, ProjectTask, Employee
    // ��������, ����������, ��������, ���������� � �������� ���������
}

ko.applyBindings(new AppViewModel());
