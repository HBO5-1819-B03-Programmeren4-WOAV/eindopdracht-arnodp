
var apiURL = 'https://localhost:44385/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading',
        cocktails: null,
        currentCocktail: null,
        //ingredients: null,
        //newCocktail: null,
    },
    created: function () {
        var self = this;
        self.fetchCocktails();
        //self.fetchIngredients();
    },
   
    methods: {
        fetchCocktails: function () {
            self = this;
            fetch(`${apiURL}Cocktails/Basic`)
                .then(resp => resp.json())
                .then(function (cocktails) {
                    self.cocktails = cocktails;
                    self.message = 'Overview';
                    if (self.cocktails.lenght > 0) {
                        fetchCocktailDetails(seld.cocktails[0]);
                    }
                });
        },

        //fetchIngredients: function () {
        //    fetch(`${apiURL}Ingredients`)
        //        .then(res => res.json())
        //        .then(function (res) {
        //            debugger;
        //            this.ingredients = res;
        //        });
        //},

        fetchCocktailDetails: function (cocktail) {
            self = this;
            debugger;
            fetch(`${apiURL}Cocktails/detailed/${cocktail.id}`)
                .then(resp => resp.json())
                .then(function (resp) {
                    self.currentCocktail = resp;
                }).catch(err => console.error('Fout: ' + err));
        },

        UpdateCocktail: function () {
            debugger;
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(app.currentCocktail),
                headers: ajaxHeaders
            };

            let myRequest = new Request(`${apiURL}Cocktails/${this.currentCocktail.id}`, ajaxConfig);
            fetch(myRequest)
                .then(res => res.json())
                .then(res => {
                })
                .catch(err => console.error('Fout: ' + err));
        },
    }
});
