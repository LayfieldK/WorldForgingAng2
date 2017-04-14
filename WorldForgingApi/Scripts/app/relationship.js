System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Relationship;
    return {
        setters: [],
        execute: function () {
            Relationship = (function () {
                function Relationship(Id, Description) {
                    this.Id = Id;
                    this.Description = Description;
                }
                return Relationship;
            }());
            exports_1("Relationship", Relationship);
        }
    };
});
