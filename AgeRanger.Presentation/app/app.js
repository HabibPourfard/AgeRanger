
(function () {
    "use strict";

    var app = angular.module("app", ["ngRoute", "ngResource", "ngMessages"]);

    app.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/home", { templateUrl: "/app/components/home/home.html", controller: "homeController as vm" })
            .when("/person", { templateUrl: "/app/components/person/personList.html", controller: "personListController as vm" })
            .when("/person/add", { templateUrl: "/app/components/person/personEdit.html", controller: "personEditController as vm" })
            .when("/person/edit/:personId", { templateUrl: "/app/components/person/personEdit.html", controller: "personEditController as vm" })
            .otherwise({ redirectTo: "/home" });

    }]);

    app.constant("settings",
        {
            apiUrl: 'http://localhost:50401'
        });

}());