
var apiURL = 'https://localhost:44385/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading',
        cocktails: null,
        currentCocktail: null
    },
    created: function () {
        var self = this;
        self.fetchCocktails();
    },
    methods: {
        fetchCocktails: function () {
            self = this;
            fetch(`${apiURL}Cocktails/Basic`)
                .then(resp => resp.json())
                .then(function (cocktails) {
                    cocktails.forEach(function (cocktail, i) {
                        cocktail.isActive = false;
                    });
                    self.cocktails = cocktails;
                    self.message = 'Overview';
                    if (self.cocktails.lenght > 0) {
                        self.message = 'no cocktails ?';
                    }
                })

        },

        getCocktailClass: function (cocktail) {
            if (cocktail.isActive) return 'list-group-item active';
            return 'list-group-item';
        },
    }
})
