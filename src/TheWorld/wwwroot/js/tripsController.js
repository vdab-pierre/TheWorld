(function() {
    "use strict";
    //getting the existing module
    angular.module("app-trips")
        .controller("tripsController", tripsController);

    function tripsController($http) {
        var vm = this;

        //leeg we halen de data van de api in $http.get
        vm.trips = [];

        vm.newTrip = {};

        vm.addTrip = function() {
            //vm.trips.push({ name: vm.newTrip.name, created: new Date() });
            ////newtrip leeg maken, triname input wordt zo ook gecleared
            //vm.newTrip = {};

            //en nu naar de api
            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("/api/trips", vm.newTrip)
            .then(function(response) {
                //success
                //een trip object bevat nog andere velden misschien, dus me nemen hem eerst uit de response
                //om dan te tonen in de tabel
                vm.trips.push(response.data);
                vm.newTrip = {};
                }, function() {
                //failure
                vm.errorMessage = "Failed to save new trip";
                })
                .finally(function() {
                    vm.isBusy = false;
                });

        };

        vm.errorMessage = "";
        //voor in real life situaties wanneer het laden van de data langer duurt, hier gesimuleerd
        //met Thread.Sleep(2000) om 2 seconden vertraging te simuleren.
        //bound to div dat zegt loading...
        vm.isBusy = true;
        $http.get("/api/trips")
            .then(function(response) {
                //success
                angular.copy(response.data, vm.trips);
            }, function(error) {
                //failure
                vm.errorMessage = "Failed to load data:" + error;
            })
        .finally(function () {
            vm.isBusy = false;
            });

    }
})();