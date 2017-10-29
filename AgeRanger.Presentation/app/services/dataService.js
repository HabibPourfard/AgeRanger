(function () {

    var app = angular.module("app");
    app.factory("dataService", ["$http", "settings", function ($http, settings) {

        return {

            getPeople: function () {
                return $http.get(settings.apiUrl + "/api/personDetail");
            },

            getPerson: function (id) {
                return $http.get(settings.apiUrl + "/api/personDetail/" + id);
            },
            
            savePerson: function(person) {
                return $http.post(settings.apiUrl + "/api/personDetail/",  person);
            }
        }
    }]);

}());