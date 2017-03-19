System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Story;
    return {
        setters: [],
        execute: function () {
            Story = (function () {
                function Story(Id, Title, Description, Genre) {
                    this.Id = Id;
                    this.Title = Title;
                    this.Description = Description;
                    this.Genre = Genre;
                }
                return Story;
            }());
            exports_1("Story", Story);
        }
    };
});
