var app = angular.module("UserApp", []);
app.controller("UserCtrl", function ($scope) {
    $scope.Id = "";
    $scope.PageTitle = "Add User";
    $scope.UserName = "";
    $scope.Email = "";
    $scope.RoleId = 0;
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

    $scope.SaveUser = function (isEmailModified) {
        if ($scope.Email === null || $scope.Email == "") {
            alert("Email is required");
            return;
        }
        if ($scope.RoleId == 0 ) {
            alert("Role is required");
            return;
        }
        var UserObj = new Object();
        UserObj.Id = $scope.Id;
        UserObj.UserName = $scope.Email;
        UserObj.RoleId = $scope.RoleId.RoleId;
        UserObj.Email = $scope.Email;
        UserObj.UserFullName = $scope.UserFullName;
        UserObj.UserAddress1 = $scope.UserAddress1;
        UserObj.UserCity = $scope.UserCity;
        UserObj.UserState = $scope.UserState;
        UserObj.UserZip = $scope.UserZip;
        UserObj.UserCountry = $scope.UserCountry;
        UserObj.Active = $scope.Active;
        UserObj.UserPhone = $scope.UserPhone;
        UserObj.IsEmailModified = isEmailModified;

        var UserJson = JSON.stringify(UserObj);
        $.ajax({
            type: "POST",
            url: "User.aspx/SaveUser",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: UserJson
        }).done(function (items) {
            if (items.d > 0) {
                alert("User was saved successfully.");
                $scope.GetUser();
            } else {
                alert("There was some error in saving User. Please try again.");
            }

        });
    };
    $scope.SaveWithEmailCheck = function () {
        if ($scope.Email === null || $scope.Email == "") {
            alert("Email is required");
            return;
        }
        if ($scope.Id == null || $scope.Id == "") {
            var UserObj = new Object();
            UserObj.Email = $scope.Email;
            var UserJson = JSON.stringify(UserObj);
            $.ajax({
                type: "POST",
                url: "User.aspx/CheckValidEmail",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: UserJson
            }).done(function (items) {
                if (items.d == true) {
                    $scope.SaveUser(false);
                } else {
                    alert("The email already exist. Please try another email.");
                }

            });
        } else {
            var UserObj = new Object();
            UserObj.UserId = $scope.Id;
            var UserJson = JSON.stringify(UserObj);
            $.ajax({
                type: "POST",
                url: "User.aspx/GetValidEmail",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: UserJson
            }).done(function (items) {
                if (items.d != null && items.d == $scope.Email) {
                    $scope.SaveUser(false);
                } else {
                    if (confirm('Email has been modified. Are you sure you want to update email?')) {
                        $scope.SaveUser(true);
                    } else {
                        return;
                    }
                }

            });
        }
    };
    $scope.RoleTypeList = [];
    $scope.GetRoleType = function () {
        $.ajax({
            type: "POST",
            url: "User.aspx/GetAllRoleType",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.RoleTypeList = items.d;
                $scope.$apply();

            } else {
                alert("There was some error in loading Roles. Please try again.");
            }

        });
    };

    $scope.GetRoleType();

    $scope.GetUser = function () {
        const params = new URLSearchParams(window.location.search);
        const UserId = params.get("id");
        if (typeof UserId !== "undefined" && UserId !== null) {
            var UserObj = new Object();
            UserObj.UserId = UserId;
            var UserJson = JSON.stringify(UserObj);
            $.ajax({
                type: "POST",
                url: "User.aspx/GetUserInfo",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: UserJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.Id = items.d.Id;
                    $scope.PageTitle = items.d.Id + " - " + items.d.UserName;
                    $scope.RoleId = items.d.RoleId;
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
                    if ($scope.RoleTypeList == null || $scope.RoleTypeList.length == 0) {
                        $scope.GetRoleType();
                    }
                    let element = document.getElementById("selRoles");
                    element.value = $scope.RoleId;

                } else {
                    alert("There was some error in loading User. Please try again.");
                }

            });
        }

    };

    $scope.GetUser();
});