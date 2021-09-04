var app = angular.module("ViewUserApp", []);
app.controller("ViewUserCtrl", function ($scope) {
    $scope.Id = "";
    $scope.PageTitle = "Add User";
    $scope.UserName = "";
    $scope.Email = "";
    $scope.RoleName = "";
    $scope.UserId = "";
    $scope.UserFullName = "";
    $scope.UserAddress1 = "";
    $scope.UserAddress2 = "";
    $scope.UserCity = "";
    $scope.UserState = "";
    $scope.UserZip = "";
    $scope.UserCountry = "";
    $scope.Active = true;
    $scope.UserPhone = "";

    
    $scope.GetUser = function () {
        const params = new URLSearchParams(window.location.search);
        const UserId = params.get("id");
        if (typeof UserId !== "undefined" && UserId !== null) {
            var UserObj = new Object();
            UserObj.UserId = UserId;
            var UserJson = JSON.stringify(UserObj);
            $.ajax({
                type: "POST",
                url: "ViewUser.aspx/GetUserInfo",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: UserJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.Id = items.d.Id;
                    $scope.PageTitle = items.d.Id + " - " + items.d.UserFullName;
                    $scope.RoleName = items.d.RoleName;
                    $scope.UserName = items.d.UserName;
                    $scope.UserFullName = items.d.UserFullName;
                    $scope.Email = items.d.Email;
                    $scope.UserPhone = items.d.UserPhone;
                    $scope.UserAddress1 = items.d.UserAddress1;
                    $scope.UserCity = items.d.UserCity;
                    $scope.UserState = items.d.UserState;
                    $scope.UserZip = items.d.UserZip;
                    $scope.UserCountry = items.d.UserCountry;
                    $scope.Active = items.d.Active;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading User. Please try again.");
                }

            });
        }

    };

    $scope.GetUser();
});