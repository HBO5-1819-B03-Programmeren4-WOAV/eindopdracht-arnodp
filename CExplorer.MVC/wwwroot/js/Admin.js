
var apiURL = 'https://localhost:44385/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading',
        cocktails: null,
        isReadOnly: true,
        currentCocktail: null,
        ingredients: null,
        CanAddIngredient: false,
        addBtn_Text: 'Add Ingredient',
        NewIngredient: {name : '', volume: null, dosage : '', id : 0},
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
                    self.cocktails = cocktails;
                    self.message = 'Overview';
                    if (self.cocktails.lenght > 0) {
                        fetchCocktailDetails(seld.cocktails[0]);
                    }
                });

        },

        //getCocktailClass: function (cocktail) {
        //    if (cocktail.isActive) return 'list-group-item active';
        //    return 'list-group-item';
        //},

        fetchCocktailDetails: function (cocktail) {
            self = this;
            if (!self.isReadOnly) return;
            debugger;
            fetch(`${apiURL}Cocktails/detailed/${cocktail.id}`)
                .then(resp => resp.json())
                .then(function (resp) {
                    debugger;
                    self.currentCocktail = resp;
                }).catch(err => console.error('Fout: ' + err));
        },

        addIngredient: function () {
            if (!this.CanAddIngredient) {
                this.CanAddIngredient = true;
                this.addBtn_Text = 'Save';
            }
            else {
                debugger;
                this.currentCocktail.ingredients.push({ volume: this.NewIngredient.volume, dosage: this.NewIngredient.dosage, cocktailId: this.currentCocktail.id,cocktail: null ,ingredientBase: {name: this.NewIngredient.name}});
                this.SaveCocktail();
                debugger;
                this.CanAddIngredient = false;
                this.addBtn_Text = 'Add Ingredient';
                this.resetNewIngredient();
            }
           
        },

        SaveCocktail: function () {
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
                    debugger;
                })
                .catch(err => console.error('Fout: ' + err));
        },

        resetNewIngredient: function () {
            this.NewIngredient.name = '';
            this.NewIngredient.volume = 0;
            this.NewIngredient.dosage = '';
        },
    }
});
