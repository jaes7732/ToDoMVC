angular.module("MyApp", ["kendo.directives"]);

angular.module("MyApp")
       .controller("HelloController", HelloController)
       .controller("HomeController", HomeController)
       .factory("MovieService", MovieService);

MovieService.$inject = ["$http"];
function MovieService($http) {

    var service = {
        getMovies: function () {
            return [
                { "rank": 1, "rating": 9.2, "year": 1994, "title": "The Shawshank Redemption" },
                //{ "rank": 2, "rating": 9.2, "year": 1972, "title": "The Godfather" },
                //{ "rank": 3, "rating": 9, "year": 1974, "title": "The Godfather: Part II" },
                //{ "rank": 4, "rating": 8.9, "year": 1966, "title": "Il buono, il brutto, il cattivo." },
                //{ "rank": 5, "rating": 8.9, "year": 1994, "title": "Pulp Fiction" },
                //{ "rank": 6, "rating": 8.9, "year": 1957, "title": "12 Angry Men" },
                //{ "rank": 7, "rating": 8.9, "year": 1993, "title": "Schindler's List" },
                //{ "rank": 8, "rating": 8.8, "year": 1975, "title": "One Flew Over the Cuckoo's Nest" },
                //{ "rank": 9, "rating": 8.8, "year": 2010, "title": "Inception" },
                //{ "rank": 10, "rating": 8.8, "year": 2008, "title": "The Dark Knight" }
            ];
        },
        getServerMovies: function () {
            var config = { headers: { 'Accept': 'application/json' } };
            return $http.get('/Todo/JsonSample', config).then(function (response) {
                return response.data;
            });
        }
    }
    console.log("Create Movie Service");//Once time call
    return service;
}

HelloController.$inject = ["$scope", "MovieService"];
function HelloController(scope, service) {
    var vm = this;
    vm.foo = "bar";
    vm.userInput = {
        rank : 5
    };
    vm.productsDataSource = new kendo.data.DataSource({
        //data: service.getMovies(),
        schema: {
            model: {
                id: "rank"
            } 
        },
        transport: {
            read: function (kendo) {
                service.getServerMovies().then(function (data) {
                    //retrieve data from server success
                    kendo.success(data);
                });
            }
        }
    });

   
}

HomeController.$inject = ["MovieService"]
function HomeController(movieService) {
    var vm = this;
    vm.foo = "bar home";
    vm.productsDataSource = new kendo.data.DataSource({
        data: movieService.getMovies(),
        pageSize: 5,
    });
    vm.alertData = function (dataItem) {
        alert(dataItem.title);
    }

    vm.options = {
        columns: [{
            field: "title",
            title: "Tile",
            width: "120px"
        }, {
            field: "year",
            title: "Year",
            width: "120px"
        }, {
            field: "rank",
            title: "Rank",
            width: "120px",
        }, {
            field: "rank",
            title: "za",
            template: "<a class='btn btn-default' ng-click='vm.alertData(dataItem)' >Submit</a>",
            width: "120px",
        }],
        dataSource: vm.productsDataSource,
        pageable: {
            pageSize: 5,
            pageSizes: [5,10,20],
        },
    }
}