System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var EntityRelationship;
    return {
        setters: [],
        execute: function () {
            EntityRelationship = (function () {
                function EntityRelationship(Id, Description, Entity1Id, Entity2Id, Entity1Name, Entity2Name) {
                    this.Id = Id;
                    this.Description = Description;
                    this.Entity1Id = Entity1Id;
                    this.Entity2Id = Entity2Id;
                    this.Entity1Name = Entity1Name;
                    this.Entity2Name = Entity2Name;
                }
                return EntityRelationship;
            }());
            exports_1("EntityRelationship", EntityRelationship);
        }
    };
});
