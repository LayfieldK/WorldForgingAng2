System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Article;
    return {
        setters: [],
        execute: function () {
            Article = (function () {
                function Article(Id, Title, Description, Text) {
                    this.Id = Id;
                    this.Title = Title;
                    this.Description = Description;
                    this.Text = Text;
                }
                return Article;
            }());
            exports_1("Article", Article);
        }
    };
});
