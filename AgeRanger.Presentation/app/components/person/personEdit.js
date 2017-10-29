(function () {
    var app = angular.module("app");
    app.controller("personEditController", ["dataService", "$routeParams", "$location",
        function (dataService, $routeParams, $location) {
            var vm = this;
            var personId = $routeParams.personId;

            vm.mode = personId ? "Edit": "Add";

            if (personId) {
                dataService.getPerson(personId).then(function(response) {
                    vm.person = response.data;
                });
            }

            vm.save = function (isValid) {
                vm.submitted = true;
                if (!isValid) {
                    vm.error = "Validation failed";
                    return;
                }

                dataService.savePerson(vm.person).then(function() {
                    $location.path("/person");
                }, function (response) {
                    vm.error = (response.data.exceptionMessage) ? response.data.exceptionMessage : "An error has occurred.";
                });
            }

        }]);

}());
